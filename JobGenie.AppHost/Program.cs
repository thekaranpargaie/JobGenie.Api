var builder = DistributedApplication.CreateBuilder(args);

string connectionString = "Host=pg-jobgenie-korkaran14-2b27.d.aivencloud.com;Port=23102;Database=defaultdb;Username=avnadmin;Password=AVNS_Kg3Fx9RQ5gzhMKfguq1;SslMode=Require;";

var userApi = builder.AddProject<Projects.User_Api>("userapi")
    .WithEnvironment("ConnectionStrings__JobGenie", connectionString);

var resumeApi = builder.AddProject<Projects.Resume_Api>("resumeapi")
    .WithEnvironment("ConnectionStrings__JobGenie", connectionString);

builder.AddProject<Projects.WebApp>("webapp")
    .WithReference(userApi)
    .WithReference(resumeApi);

builder.Build().Run();
