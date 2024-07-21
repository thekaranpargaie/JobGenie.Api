var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServerContainer("karan", "Pass@123")
    .AddDatabase("JobGenie");

var userApi = builder.AddProject<Projects.User_Api>("user.api")
    .WithReference(sqlServer);

var resumeApi = builder.AddProject<Projects.Resume_Api>("resume.api")
    .WithReference(sqlServer);

builder.Build().Run();
