using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IDbConnection _dbConnection;

        public RecipeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Recipes WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Recipe>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            var sql = "SELECT * FROM Recipes";
            return await _dbConnection.QueryAsync<Recipe>(sql);
        }

        public async Task<Recipe> CreateAsync(Recipe recipe)
        {
            var sql =
                "INSERT INTO Recipes (Name, Ingredients, Instructions, CookingTime, Difficulty, DietType) VALUES (@Name, @Ingredients, @Instructions, @CookingTime, @Difficulty, @DietType); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, recipe);
            recipe.Id = id;
            return recipe;
        }

        public async Task<Recipe> UpdateAsync(Recipe recipe)
        {
            var sql =
                "UPDATE Recipes SET Name = @Name, Ingredients = @Ingredients, Instructions = @Instructions, CookingTime = @CookingTime, Difficulty = @Difficulty, DietType = @DietType WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, recipe);
            return recipe;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Recipes WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }
        public async Task<Review> AddReviewAsync(Review review)
        {
            var sql =
                "INSERT INTO Reviews (RecipeId, UserId, Rating, Comment) " +
                "VALUES (@RecipeId, @UserId, @Rating, @Comment); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, review);
            review.Id = id;
            return review;
        }
    }
}
