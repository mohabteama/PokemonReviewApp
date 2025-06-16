
namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context) { }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews
                .Where(r => r.Pokemon.Id == pokeId)
                .ToList();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.Reviews.RemoveRange(reviews);
            return Save();
        }
    }
}
