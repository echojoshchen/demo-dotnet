using GrpcDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DemoService>();
app.MapGet("/", () => "Demo gRPC app");

app.Run();
