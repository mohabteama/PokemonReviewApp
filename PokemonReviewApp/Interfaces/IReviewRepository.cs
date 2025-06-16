
namespace PokemonReviewApp.Interface
{
    public interface IReviewRepository : IRepository<Review>
    {
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool DeleteReviews(List<Review> reviews);
    }
}
