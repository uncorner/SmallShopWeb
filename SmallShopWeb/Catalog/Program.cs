var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// todo: turn on https (check launchSettings.json)
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
