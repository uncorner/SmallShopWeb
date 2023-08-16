using SmallShopWeb.ShopAPI.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
// todo: turn on https (check launchSettings.json)
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
