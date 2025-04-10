var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Projects.Taches_Management_API>("backservice");
builder.AddProject<Projects.Taches_Management_Front>("frontservice");

builder.Build().Run();
