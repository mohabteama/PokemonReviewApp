
namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(ApplicationDbContext context) : base(context) { }

        public decimal GetPokemonRating(int Id)
        {
            var review = _context.Reviews.Where(r => r.Pokemon.Id == Id);
            if (!review.Any())
                return 0;
            return (decimal)review.Average(r => r.Rating);
        }

        public object GetPokemonTrimToUpper(PokemonDto pokemonCreate)
        {
            return _context.Pokemons
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.Trim().ToUpper());
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.FirstOrDefault(a => a.Id == ownerId);
            var category = _context.Categories.FirstOrDefault(a => a.Id == categoryId);

            if (pokemonOwnerEntity == null || category == null)
                return false;

            var pokemonOwner = new PokemonOwner
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            var pokemonCategory = new PokemonCategory
            {
                Category = category,
                Pokemon = pokemon
            };

            _context.Add(pokemon);
            _context.Add(pokemonOwner);
            _context.Add(pokemonCategory);

            return Save();
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            // Optional: handle relations if needed
            _context.Update(pokemon);
            return Save();
        }
    }
}
