using ColourAPI.Contexts;
using ColourAPI.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ColourApi");
Console.WriteLine("connectionString {0}", connectionString);

builder.Services.AddDbContext<ColourContext>(opts => {
    opts.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IColourRepository, ColourRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
