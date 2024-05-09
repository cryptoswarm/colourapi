using ColourAPI.Models.Entities;
using ColourAPI.Repositories;
using ColourAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ColourAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ColoursController : ControllerBase
{
    private readonly IColourRepository _coulourRepository;
    private readonly IColoursService _coloursService;

    public ColoursController(IColoursService coloursService)
    {
        _coloursService = coloursService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
    {
        return new OkObjectResult(await _coloursService.GetColours());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Colour>> GetColour(Guid id)
    {
        var entity = await _coloursService.GetColourByIdAsync(id);
        if(entity == null)
        {
            return NotFound(new ProblemDetails{
                Status= StatusCodes.Status404NotFound,
                Type= "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Title="Not Found",
                Extensions= new Dictionary<string, object?>
                {
                    {"errors", $"Resouce by id: {id} was not found"}
                }   
            });
        }
        return new OkObjectResult(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Colour>> CreateColour([FromBody] Colour colour)
    {
        var created = await _coloursService.CreateColourAsync(colour);
        return CreatedAtAction(nameof(GetColour), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Colour>> UpdateColour(Guid id, [FromBody] Colour colour)
    {
        var updated = await _coloursService.UpdateColourAsync(id, colour);
        return new OkObjectResult(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteColour(Guid id)
    {
        await _coulourRepository.RemoveColourByIdAsync(id);
        return NoContent();
    }
}