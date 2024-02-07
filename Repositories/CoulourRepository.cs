using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourAPI.Contexts;
using ColourAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Repositories;

public class ColourRepository : IColourRepository
{
    private readonly ColourContext _colourContext;

    public ColourRepository(ColourContext colourContext)
    {
        _colourContext = colourContext;
    }

    public async Task<Colour> AddColourAsync(Colour colour)
    {
        await _colourContext.Colours.AddAsync(colour);
        await _colourContext.SaveChangesAsync();

        return colour;
    }

    public async Task<Colour> GetColourByIdAsync(Guid id)
    {
        return await _colourContext.Colours.FindAsync(id);
    }

    public async Task<IEnumerable<Colour>> GetColours()
    {
        return await _colourContext.Colours.ToListAsync();
    }

    public async Task RemoveColourByIdAsync(Guid id)
    {
        var colour = await _colourContext.Colours.FindAsync(id);
        _colourContext.Colours.Remove(colour);
    }

    public async Task<Colour> UpdateColourAsync(Guid id, Colour colour)
    {
        var existing = await _colourContext.Colours.FindAsync(id);
        existing.Name = colour.Name;

        await _colourContext.SaveChangesAsync();

        return existing;
    }
}