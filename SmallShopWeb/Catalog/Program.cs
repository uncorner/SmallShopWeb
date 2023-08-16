//using Microsoft.EntityFrameworkCore;
//using SmallShopWeb.Catalog.App;
//using SmallShopWeb.Catalog.Infrastructure;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//var connectionString = builder.Configuration.GetConnectionString("Default")
//    ?? throw new NullReferenceException("Cannot get connection string");
//builder.Services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
//builder.Services.AddCustomServices();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//// todo: turn on https (check launchSettings.json)
////app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using SmallShopWeb.Catalog.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<TranslatorService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
