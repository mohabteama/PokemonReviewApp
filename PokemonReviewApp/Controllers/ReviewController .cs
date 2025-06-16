
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public IActionResult GetReviews() => Ok(_reviewService.GetAllReviews());

    [HttpGet("{reviewId}")]
    public IActionResult GetReview(int reviewId)
    {
        var review = _reviewService.GetReviewById(reviewId);
        return review == null ? NotFound() : Ok(review);
    }

    [HttpGet("pokemon/{pokeId}")]
    public IActionResult GetReviewsForAPokemon(int pokeId)
        => Ok(_reviewService.GetReviewsByPokemon(pokeId));

    [HttpPost]
    public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int pokeId, [FromBody] ReviewDto reviewCreate)
    {
        if (reviewCreate == null)
            return BadRequest();

        var result = _reviewService.CreateReview(reviewCreate, reviewerId, pokeId);
        if (!result.IsSuccess)
            return StatusCode(result.StatusCode, result.Errors);

        return Ok("Successfully created");
    }

    [HttpPut("{reviewId}")]
    public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDto updatedReview)
    {
        if (updatedReview == null || reviewId != updatedReview.Id)
            return BadRequest();

        return _reviewService.UpdateReview(updatedReview) ? NoContent() : StatusCode(500, "Error updating review");
    }

    [HttpDelete("{reviewId}")]
    public IActionResult DeleteReview(int reviewId)
    {
        return _reviewService.DeleteReview(reviewId) ? NoContent() : StatusCode(500, "Error deleting review");
    }

    [HttpDelete("DeleteByReviewer/{reviewerId}")]
    public IActionResult DeleteReviewsByReviewer(int reviewerId)
    {
        return _reviewService.DeleteReviewsByReviewer(reviewerId) ? NoContent() : StatusCode(500, "Error deleting reviews");
    }
}
