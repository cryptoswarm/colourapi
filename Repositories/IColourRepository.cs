using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourAPI.Models.Entities;

namespace ColourAPI.Repositories;
public interface IColourRepository{

    IQueryable<Colour> GetColourById(Guid guid);
    IQueryable<Colour> GetColours();
    Task<Colour> AddColourAsync(Colour colour);
    Task RemoveColourByIdAsync(Guid id);
    Task<Colour> UpdateColourAsync(Guid id, Colour colour);

}