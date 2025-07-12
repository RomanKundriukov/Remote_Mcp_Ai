using Microsoft.AspNetCore.OutputCaching;

var builder = DistributedApplication.CreateBuilder(args);


var remoteMcpAi = builder.AddProject<Projects.Remote_Mcp_Ai>("mcptools");
builder
    .AddNpmApp("AngularFrontend", "../aihelper")
    .WithReference(remoteMcpAi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
