using ColourAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Contexts;
public class ColourContext : DbContext
{
    public ColourContext(DbContextOptions<ColourContext> options): base(options){}
    
    public DbSet<Colour> Colours {get; set;}
}