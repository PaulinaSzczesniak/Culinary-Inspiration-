using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _recipeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _recipeRepository.GetAllAsync();
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
        {
            return await _recipeRepository.CreateAsync(recipe);
        }

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
        {
            return await _recipeRepository.UpdateAsync(recipe);
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            return await _recipeRepository.DeleteAsync(id);
        }
    }
}
