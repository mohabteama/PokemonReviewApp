
namespace PokemonReviewApp.Interface
{
    public interface IReviewerRepository : IGenericRepository<Reviewer>
    {
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
    }
}
