
namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IActionResult GetPokemons()
        {
            return Ok(_pokemonService.GetAll());
        }

        [HttpGet("{pokeId}")]
        public IActionResult GetPokemon(int pokeId)
        {
            var pokemon = _pokemonService.GetById(pokeId);
            if (pokemon == null)
                return NotFound();

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        public IActionResult GetPokemonRating(int pokeId)
        {
            return Ok(_pokemonService.GetRating(pokeId));
        }

        [HttpPost]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
        {
            if (!ModelState.IsValid || pokemonCreate == null)
                return BadRequest(ModelState);

            if (!_pokemonService.CreatePokemon(ownerId, catId, pokemonCreate))
                return StatusCode(422, "Pokemon already exists or error in creation");

            return Ok("Successfully created");
        }

        [HttpPut("{pokeId}")]
        public IActionResult UpdatePokemon(int pokeId, [FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto updatedPokemon)
        {
            if (!ModelState.IsValid || updatedPokemon == null || updatedPokemon.Id != pokeId)
                return BadRequest(ModelState);

            if (!_pokemonService.UpdatePokemon(pokeId, ownerId, catId, updatedPokemon))
                return StatusCode(500, "Something went wrong updating");

            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonService.DeletePokemon(pokeId))
                return StatusCode(500, "Something went wrong deleting");

            return NoContent();
        }
    }
}
