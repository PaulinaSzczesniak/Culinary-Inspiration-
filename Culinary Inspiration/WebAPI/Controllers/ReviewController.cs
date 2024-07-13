using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedReview = await _reviewService.CreateReviewAsync(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = addedReview.Id }, addedReview);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpGet("recipe/{recipeId}")]
        public async Task<IActionResult> GetReviewsByRecipeId(int recipeId)
        {
            var reviews = await _reviewService.GetReviewsByRecipeIdAsync(recipeId);
            return Ok(reviews);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}