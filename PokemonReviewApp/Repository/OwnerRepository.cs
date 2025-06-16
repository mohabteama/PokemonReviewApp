
namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context) : base(context) { }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners
                .Where(po => po.Pokemon.Id == pokeId)
                .Select(po => po.Owner)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners
                .Where(po => po.Owner.Id == ownerId)
                .Select(po => po.Pokemon)
                .ToList();
        }
    }
}
