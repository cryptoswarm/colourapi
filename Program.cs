using ColourAPI.Contexts;
using ColourAPI.Middlewares;
using ColourAPI.Repositories;
using ColourAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ColourApi");
Console.WriteLine("connectionString {0}", connectionString);

builder.Services.AddDbContext<ColourContext>(opts => {
    opts.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddScoped<IColoursService, ColourService>();
builder.Services.AddScoped<IColourRepository, ColourRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

// app. UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
