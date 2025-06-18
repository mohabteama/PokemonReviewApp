
namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    }
}
