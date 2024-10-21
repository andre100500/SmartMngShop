var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SmartMngShop_Web>("web");

builder.AddProject<Projects.SmartMngShop_Customer>("smartmngshop-customer");

builder.Build().Run();
