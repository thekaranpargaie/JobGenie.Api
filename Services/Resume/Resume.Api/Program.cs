using Base.Filters;
using Base.Options;
using FluentValidation.AspNetCore;
using GenAI;
using GenAI.Providers.Gemini;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Resume.Api.Configuration;
using Resume.Infrastructure;
using Resume.Infrastructure.Configuration.DataAccess;
using Resume.Infrastructure.Configuration.Mediation;
using Resume.Infrastructure.Configuration.Processing;
using Resume.Infrastructure.Repositories;
using Shared.Configurations;
using Shared.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);
var appSetting = InitializeApp(builder.Configuration);

var app = builder.Build();

app.MapDefaultEndpoints();
ConfigureApp(app);

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.AddServiceDefaults();
    //Setting up request size
    builder.Services.Configure<KestrelServerOptions>(options =>
    {
        options.Limits.MaxRequestBodySize = int.MaxValue; // Set to 50 MB (adjust as needed)
    });
    //Setting FormData size limit
    builder.Services.Configure<FormOptions>(x =>
    {
        x.ValueLengthLimit = int.MaxValue;
        x.MultipartBodyLengthLimit = int.MaxValue;
        x.MultipartHeadersLengthLimit = int.MaxValue;
    });
    builder.Services.AddHttpContextAccessor();
    builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));
    var jwtOption = builder.Configuration.GetSection("JwtOptions").Get<JwtOption>();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOption.Secret))
                };
            });
    builder.Services.AddCors(o => o.AddPolicy("corsPolicy", builder =>
    {
        builder.SetIsOriginAllowedToAllowWildcardSubdomains()
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));
    builder.Services.AddFluentValidation(mv => mv.RegisterValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Resume.Application")));
    builder.Services.AddControllers(config => config.Filters.Add(typeof(ApiResultFilterAttribute)));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    var swagconfig = builder.Configuration.GetSection("SwaggerAuth");
    ConfigSwagger(builder.Services);
    builder.Services.AddLogging(configure =>
    {
        configure.ClearProviders();
        configure.AddJsonConsole(opts =>
        {
            opts.TimestampFormat = "s";
        });
    });
    builder.Services.Configure<ApiBehaviorOptions>(config => config.SuppressModelStateInvalidFilter = false);
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.Services.AddVersionSupport(builder.Configuration.GetSection("Version").Get<VersionSettings>());
    builder.Services.RegisterSessionManager();
    builder.Services.AddScoped<IResumeModule, ResumeModule>();
    builder.Services.AddDataAccessModule();
    builder.Services.AddServiceModule();
    builder.Services.AddRepositories();
    builder.Services.AddMediatorModule(loggingEnabled: true);
    builder.Services.AddScoped<IGenAI, Gemini>();
    builder.Services.AddOptions();
    builder.Services.Configure<GeminiConfig>(builder.Configuration.GetSection("GeminiConfig"));
}

AppSettings InitializeApp(IConfiguration configuration)
{
    IConfigurationSection appSettings = configuration.GetSection("AppSettings");
    var appSetting = appSettings.Get<AppSettings>();
    // Register service to discovery
    //builder.Services.RegisterService(appSetting.ServiceConfig);

    //appSetting.RabitMQConfiguration.UserName = Environment.GetEnvironmentVariable(CommonEnvVariables.RabbitMQUserName) ?? string.Empty;
    //appSetting.RabitMQConfiguration.Password = Environment.GetEnvironmentVariable(CommonEnvVariables.RabbitMQPassword) ?? string.Empty;
    //appSetting.RabitMQConfiguration.HostName = Environment.GetEnvironmentVariable(CommonEnvVariables.RabbitMQHost) ?? string.Empty;
    //appSetting.RabitMQConfiguration.Port = Convert.ToUInt16(Environment.GetEnvironmentVariable(CommonEnvVariables.RabbitMQPort));
    return appSetting;
}
void ConfigSwagger(IServiceCollection serviceCollection)
{
    // Add SwaggerGen for API documentation
    serviceCollection.AddSwaggerGen();
}
void ConfigureApp(WebApplication app)
{
    app.UseCors("corsPolicy");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}