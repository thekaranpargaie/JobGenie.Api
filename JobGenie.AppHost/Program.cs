var builder = DistributedApplication.CreateBuilder(args);

string connectionString = "Host=glacially-mint-fish.data-1.use1.tembo.io;Port=5432;Database=postgres;Username=postgres;Password=PjvSYBDTU7SVuLEj;";

var userApi = builder.AddProject<Projects.User_Api>("userapi")
    .WithEnvironment("ConnectionStrings__JobGenie", connectionString);

var resumeApi = builder.AddProject<Projects.Resume_Api>("resumeapi")
    .WithEnvironment("ConnectionStrings__JobGenie", connectionString);

builder.AddProject<Projects.WebApp>("webapp")
    .WithReference(userApi)
    .WithReference(resumeApi);

builder.Build().Run();
