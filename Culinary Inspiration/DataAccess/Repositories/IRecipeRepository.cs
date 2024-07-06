using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal interface IRecipeRepository
    {
        Task<Recipe> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> CreateAsync(Recipe recipe);
        Task<Recipe> UpdateAsync(Recipe recipe);
        Task<bool> DeleteAsync(int id);
    }
}
