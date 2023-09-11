using SmallShopWeb.ShopAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
// turn on https on production
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
