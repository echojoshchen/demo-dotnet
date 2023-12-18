/// <summary>
/// Program.cs
/// 
/// This is the main entry point for the application.
/// </summary>

using Demo.Search;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Use(async (context, next) =>
{
    var stopwatch = Stopwatch.StartNew();

    await next();

    stopwatch.Stop();
    var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

    // Report the latency metric
    Console.WriteLine($"Request latency: {elapsedMilliseconds}ms");
});

app.MapGrpcService<QueryService>();
app.MapGrpcService<IndexService>();
app.MapGet("/", () => "Demo search app with gRPC and SQLite.");

app.Run();
