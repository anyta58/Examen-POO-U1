using ProyectoExamenU1;
using ProyectoExamenU1.Services.Interfaces;
using ProyectoExamenU1.Services;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Services.AddScoped<IRatingService, ratingService>();

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
