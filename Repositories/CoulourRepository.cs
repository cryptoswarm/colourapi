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

    public IQueryable<Colour> GetColourById(Guid id)
    {
        return _colourContext.Colours.Where(c => c.Id == id);
    }

    public IQueryable<Colour> GetColours()
    {
        return _colourContext.Colours;
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