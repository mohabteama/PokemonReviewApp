
namespace PokemonReviewApp.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    }
}
