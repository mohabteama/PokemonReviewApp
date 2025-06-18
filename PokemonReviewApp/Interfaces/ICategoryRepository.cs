
namespace PokemonReviewApp.Interface
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    }
}
