using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();