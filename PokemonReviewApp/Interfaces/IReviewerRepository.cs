
namespace PokemonReviewApp.Interface
{
    public interface IReviewerRepository : IRepository<Reviewer>
    {
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
    }
}
