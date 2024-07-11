using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFavoritesByUserId(int userId)
        {
            var favorites = await _favoriteService.GetFavoritesByUserIdAsync(userId);
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites([FromBody] Favorite favorite)
        {
            var createdFavorite = await _favoriteService.AddFavoriteAsync(favorite);
            return CreatedAtAction(nameof(GetFavoritesByUserId), new { userId = createdFavorite.UserId }, createdFavorite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            var result = await _favoriteService.RemoveFavoriteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}