using ColourAPI.Contexts;
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

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
