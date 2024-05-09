
using ColourAPI.Models.Entities;

namespace ColourAPI.Services;

public interface IColoursService 
{

    Task<IEnumerable<Colour>> GetColours();
    Task<Colour> GetColourByIdAsync(Guid id);
    Task<Colour> CreateColourAsync(Colour colour);
    Task<Colour> UpdateColourAsync(Guid id, Colour colour);
}