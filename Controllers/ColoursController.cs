using ColourAPI.Models.Entities;
using ColourAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ColourAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ColoursController : ControllerBase
{
    private readonly IColourRepository _coulourRepository;

    public ColoursController(IColourRepository coulourRepository)
    {
        _coulourRepository = coulourRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
    {
        return new OkObjectResult(await _coulourRepository.GetColours());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Colour>> GetColour(Guid id)
    {
        var entity = await _coulourRepository.GetColourByIdAsync(id);
        if(entity == null)
        {
            return NotFound();
        }
        return new OkObjectResult(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Colour>> CreateColour([FromBody] Colour colour)
    {
        var created = await _coulourRepository.AddColourAsync(colour);
        return CreatedAtAction(nameof(GetColour), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Colour>> UpdateColour(Guid id, [FromBody] Colour colour)
    {
        var updated = await _coulourRepository.UpdateColourAsync(id, colour);
        return new OkObjectResult(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteColour(Guid id)
    {
        await _coulourRepository.RemoveColourByIdAsync(id);
        return NoContent();
    }
}