var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServerContainer("karan", "Pass@123")
    .AddDatabase("JobGenie");

var userApi = builder.AddProject<Projects.User_Api>("user.api")
    .WithReference(sqlServer);

var resumeApi = builder.AddProject<Projects.Resume_Api>("resume.api")
    .WithReference(sqlServer);

builder.AddProject<Projects.WebApp>("webapp")
    .WithReference(userApi)
    .WithReference(resumeApi);

builder.Build().Run();
