using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetByRecipeIdAsync(int recipeId);
        Task<Review> CreateAsync(Review review);
        Task<Review> UpdateAsync(Review review);
        Task<bool> DeleteAsync(int id);
    }
}
