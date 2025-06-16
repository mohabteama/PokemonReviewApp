
namespace PokemonReviewApp.Services.Interfaces
{
    public interface IReviewService
    {
        List<ReviewDto> GetAllReviews();
        ReviewDto? GetReviewById(int reviewId);
        List<ReviewDto> GetReviewsByPokemon(int pokeId);
        (bool IsSuccess, int StatusCode, string[]? Errors) CreateReview(ReviewDto reviewCreate, int reviewerId, int pokeId);
        bool UpdateReview(ReviewDto updatedReview);
        bool DeleteReview(int reviewId);
        bool DeleteReviewsByReviewer(int reviewerId);
    }
}
