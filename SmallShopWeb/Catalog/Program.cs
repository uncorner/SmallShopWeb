using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog;
using SmallShopWeb.Catalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("Cannot get connection string");
builder.Services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
// todo: turn on https (check launchSettings.json)
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
