using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Services.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerService _reviewerService;

        public ReviewerController(IReviewerService reviewerService)
        {
            _reviewerService = reviewerService;
        }

        [HttpGet]
        public IActionResult GetReviewers()
        {
            var reviewers = _reviewerService.GetAll();
            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        public IActionResult GetReviewer(int reviewerId)
        {
            var reviewer = _reviewerService.GetById(reviewerId);
            if (reviewer == null)
                return NotFound();

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer(int reviewerId)
        {
            var reviews = _reviewerService.GetReviewsByReviewer(reviewerId);
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (reviewerCreate == null)
                return BadRequest(ModelState);

            var result = _reviewerService.Create(reviewerCreate);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Error");
                return StatusCode(422, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{reviewerId}")]
        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDto updatedReviewer)
        {
            if (updatedReviewer == null || reviewerId != updatedReviewer.Id)
                return BadRequest(ModelState);

            var result = _reviewerService.Update(reviewerId, updatedReviewer);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{reviewerId}")]
        public IActionResult DeleteReviewer(int reviewerId)
        {
            var result = _reviewerService.Delete(reviewerId);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
