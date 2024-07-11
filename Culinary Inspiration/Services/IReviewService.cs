using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services
{
    public interface IReviewService
    {
        Task<Review> CreateReviewAsync(Review review);
        Task<Review> GetReviewByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<IEnumerable<Review>> GetReviewsByRecipeIdAsync(int recipeId);
        Task UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
