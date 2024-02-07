using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourAPI.Models.Entities;

namespace ColourAPI.Repositories;
public interface IColourRepository{

    Task<Colour> GetColourByIdAsync(Guid guid);
    Task<IEnumerable<Colour>> GetColours();
    Task<Colour> AddColourAsync(Colour colour);
    Task RemoveColourByIdAsync(Guid id);
    Task<Colour> UpdateColourAsync(Guid id, Colour colour);

}