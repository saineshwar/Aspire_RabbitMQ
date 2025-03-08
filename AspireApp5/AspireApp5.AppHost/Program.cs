var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

// Added RabbitMQ server resource
var rabbitmq = builder.AddRabbitMQ("messaging")
    .WithDataVolume()
    .WithManagementPlugin();

var apiService = builder.AddProject<Projects.AspireApp5_ApiService>("apiservice")
    .WithReference(rabbitmq);

builder.AddProject<Projects.AspireApp5_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
