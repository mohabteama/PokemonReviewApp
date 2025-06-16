
namespace PokemonReviewApp.Services.Interfaces
{
    public interface IPokemonService
    {
        List<PokemonDto> GetAll();
        PokemonDto? GetById(int pokeId);
        decimal GetRating(int pokeId);
        bool CreatePokemon(int ownerId, int catId, PokemonDto pokemonCreate);
        bool UpdatePokemon(int pokeId, int ownerId, int catId, PokemonDto pokemonUpdate);
        bool DeletePokemon(int pokeId);
    }
}
