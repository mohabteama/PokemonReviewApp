using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme )]
[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public IActionResult GetOwners()
    {
        var owners = _ownerService.GetAllOwners();
        return Ok(owners);
    }

    [HttpGet("{ownerId}")]
    public IActionResult GetOwner(int ownerId)
    {
        var owner = _ownerService.GetOwnerById(ownerId);
        if (owner == null) return NotFound();
        return Ok(owner);
    }

    [HttpGet("{ownerId}/pokemon")]
    public IActionResult GetPokemonByOwner(int ownerId)
    {
        var pokemons = _ownerService.GetPokemonByOwner(ownerId);
        if (pokemons == null) return NotFound();
        return Ok(pokemons);
    }

    [HttpPost]
    public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDto ownerDto)
    {
        if (ownerDto == null) return BadRequest(ModelState);

        var created = _ownerService.CreateOwner(countryId, ownerDto);
        if (!created)
        {
            ModelState.AddModelError("", "Owner already exists or failed to create.");
            return StatusCode(422, ModelState);
        }

        return Ok("Successfully created");
    }

    [HttpPut("{ownerId}")]
    public IActionResult UpdateOwner(int ownerId, [FromBody] OwnerDto ownerDto)
    {
        if (ownerDto == null || ownerId != ownerDto.Id) return BadRequest(ModelState);

        var updated = _ownerService.UpdateOwner(ownerId, ownerDto);
        if (!updated)
            return StatusCode(500, "Failed to update owner.");

        return NoContent();
    }

    [HttpDelete("{ownerId}")]
    public IActionResult DeleteOwner(int ownerId)
    {
        var deleted = _ownerService.DeleteOwner(ownerId);
        if (!deleted)
            return StatusCode(500, "Failed to delete owner.");

        return NoContent();
    }
}
