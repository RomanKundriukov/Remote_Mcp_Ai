// Program.cs
using ModelContextProtocol.Server;
using Remote_Mcp_Ai.Tools;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly()
    .WithTools<DBTools>();

var app = builder.Build();

app.MapMcp("/sse");

app.Run();

