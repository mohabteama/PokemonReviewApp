
namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Include(pc => pc.Pokemon)
                .Select(pc => pc.Pokemon)
                .ToList();
        }

        
    }
}
