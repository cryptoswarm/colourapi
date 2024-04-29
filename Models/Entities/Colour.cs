using System;
namespace ColourAPI.Models.Entities;
public class Colour
{
    public Guid Id {get; set;}
    public string Name {get; set;}

    public override string ToString()
    {
        return $"Id {Id} Name {Name}";
    }
}