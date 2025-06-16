
namespace PokemonReviewApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository,
                             IReviewerRepository reviewerRepository,
                             IPokemonRepository pokemonRepository,
                             IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _reviewerRepository = reviewerRepository;
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public List<ReviewDto> GetAllReviews()
        {
            return _mapper.Map<List<ReviewDto>>(_reviewRepository.GetAll());
        }

        public ReviewDto? GetReviewById(int reviewId)
        {
            if (!_reviewRepository.Exists(reviewId))
                return null;

            return _mapper.Map<ReviewDto>(_reviewRepository.GetById(reviewId));
        }

        public List<ReviewDto> GetReviewsByPokemon(int pokeId)
        {
            return _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAPokemon(pokeId));
        }

        public (bool IsSuccess, int StatusCode, string[]? Errors) CreateReview(ReviewDto reviewCreate, int reviewerId, int pokeId)
        {
            var existingReview = _reviewRepository.GetAll()
                .FirstOrDefault(r => r.Title.Trim().ToUpper() == reviewCreate.Title.Trim().ToUpper());

            if (existingReview != null)
                return (false, 422, new[] { "Review already exists" });

            var reviewMap = _mapper.Map<Review>(reviewCreate);
            reviewMap.Reviewer = _reviewerRepository.GetById(reviewerId);
            reviewMap.Pokemon = _pokemonRepository.GetById(pokeId);

            if (!_reviewRepository.Create(reviewMap))
                return (false, 500, new[] { "Something went wrong while saving" });

            return (true, 200, null);
        }

        public bool UpdateReview(ReviewDto updatedReview)
        {
            if (!_reviewRepository.Exists(updatedReview.Id))
                return false;

            var reviewMap = _mapper.Map<Review>(updatedReview);
            return _reviewRepository.Update(reviewMap);
        }

        public bool DeleteReview(int reviewId)
        {
            if (!_reviewRepository.Exists(reviewId))
                return false;

            var review = _reviewRepository.GetById(reviewId);
            return _reviewRepository.Delete(review);
        }

        public bool DeleteReviewsByReviewer(int reviewerId)
        {
            if (!_reviewerRepository.Exists(reviewerId))
                return false;

            var reviews = _reviewerRepository.GetReviewsByReviewer(reviewerId).ToList();
            return _reviewRepository.DeleteReviews(reviews);
        }
    }
}
