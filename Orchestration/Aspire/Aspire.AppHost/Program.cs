var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServerContainer("karan", "Pass@123")
    .AddDatabase("JobGenie");

builder.AddProject<Projects.User_Api>("user.api")
    .WithReference(sqlServer);

builder.AddProject<Projects.Resume_Api>("resume.api")
    .WithReference(sqlServer);

builder.AddProject<Projects.MockTest_Api>("mocktest.api")
    .WithReference(sqlServer);

builder.Build().Run();
