
using ColourAPI.Models.Entities;
using ColourAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Services
{
    public class ColourService : IColoursService
    {
        private readonly IColourRepository _colourRepository;
        private readonly ILogger<ColourService> _logger;

        public ColourService(IColourRepository colourRepository,
                            ILogger<ColourService> logger)
        {
            _colourRepository = colourRepository;
            _logger = logger;
        }

        public async Task<Colour> CreateColourAsync(Colour colour)
        {
            //TODO some check
            return await _colourRepository.AddColourAsync(colour);
        }

        public async Task<Colour> GetColourByIdAsync(Guid id)
        {
            var result = await _colourRepository.GetColourById(id).FirstOrDefaultAsync();
            
            if(result is null){
                _logger.LogDebug("Resource not found by id {MissngResourceId}", id);
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<Colour>> GetColours()
        {
            return await _colourRepository.GetColours().ToListAsync();
        }

        public async Task<Colour> UpdateColourAsync(Guid id, Colour colour)
        {
            return await _colourRepository.UpdateColourAsync(id, colour);
        }
    }
}