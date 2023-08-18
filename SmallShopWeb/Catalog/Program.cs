using SmallShopWeb.Catalog.App;
using SmallShopWeb.Catalog.App.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomServices(builder.Configuration);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductCatalogService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
