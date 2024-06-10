var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SmartMngShop_Web>("web");

builder.Build().Run();
