
namespace PokemonReviewApp.Interface
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
        decimal GetPokemonRating(int Id);
        object GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    }
}
