using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> CreateRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(Recipe recipe);
        Task<bool> DeleteRecipeAsync(int id);
        Task<Review> AddReviewAsync(Review review);
    }
}
