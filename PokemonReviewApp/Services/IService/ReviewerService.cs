
namespace PokemonReviewApp.Services.Interfaces
{
    public interface IReviewerService
    {
        List<ReviewerDto> GetAll();
        ReviewerDto? GetById(int id);
        List<ReviewDto> GetReviewsByReviewer(int reviewerId);
        (bool IsSuccess, string? ErrorMessage) Create(ReviewerDto reviewerCreate);
        (bool IsSuccess, string? ErrorMessage) Update(int id, ReviewerDto reviewerUpdate);
        (bool IsSuccess, string? ErrorMessage) Delete(int id);
    }
}
