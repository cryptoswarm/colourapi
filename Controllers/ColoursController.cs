using System;
using System.Threading.Tasks;
using ColourAPI.Models.Entities;
using ColourAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ColourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        private readonly IColourRepository _coulourRepository;

        public ColoursController(IColourRepository coulourRepository)
        {
            _coulourRepository = coulourRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetColous()
        {
            return new OkObjectResult(await _coulourRepository.GetColours());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColourAsync(Guid id)
        {
            var entity = await _coulourRepository.GetColourByIdAsync(id);
            if(entity == null)
            {
                return NotFound();
            }
            return new OkObjectResult(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColourAsync([FromBody] Colour colour)
        {
            var created = await _coulourRepository.AddColourAsync(colour);
            return CreatedAtAction(nameof(GetColourAsync), new {id = created.Id}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColourAsync(Guid id, [FromBody] Colour colour)
        {
            var updated = await _coulourRepository.UpdateColourAsync(id, colour);
            return new OkObjectResult(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColourAsync(Guid id)
        {
            await _coulourRepository.RemoveColourByIdAsync(id);
            return NoContent();
        }
    }
}
