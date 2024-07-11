using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> AddAsync(Review review);
        Task<Review> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetByRecipeIdAsync(int recipeId);
        Task UpdateAsync(Review review);
        Task<bool> RemoveAsync(int id);
    }
}
