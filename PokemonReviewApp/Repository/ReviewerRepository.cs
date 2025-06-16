
namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : GenericRepository<Reviewer>, IReviewerRepository
    {
        public ReviewerRepository(ApplicationDbContext context) : base(context) { }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews
                .Where(r => r.Reviewer.Id == reviewerId)
                .ToList();
        }
    }
}
