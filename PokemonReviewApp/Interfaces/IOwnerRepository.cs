
namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    }
}
