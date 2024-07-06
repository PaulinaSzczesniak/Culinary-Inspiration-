using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal interface IReviewService
    {
        Task<Review> GetReviewByIdAsync(int id);
        Task<IEnumerable<Review>> GetReviewsByRecipeIdAsync(int recipeId);
        Task<Review> CreateReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
