using Demo.Search;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<QueryService>();
app.MapGrpcService<IndexService>();
app.MapGet("/", () => "Demo search app with gRPC and SQLite.");

app.Run();
