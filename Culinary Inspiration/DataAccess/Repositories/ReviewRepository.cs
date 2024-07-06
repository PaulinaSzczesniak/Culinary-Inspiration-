using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbConnection _dbConnection;

        public ReviewRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Reviews WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Review>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Review>> GetByRecipeIdAsync(int recipeId)
        {
            var sql = "SELECT * FROM Reviews WHERE RecipeId = @RecipeId";
            return await _dbConnection.QueryAsync<Review>(sql, new { RecipeId = recipeId });
        }

        public async Task<Review> CreateAsync(Review review)
        {
            var sql = "INSERT INTO Reviews (RecipeId, UserId, Rating, Comment) VALUES (@RecipeId, @UserId, @Rating, @Comment); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, review);
            review.Id = id;
            return review;
        }

        public async Task<Review> UpdateAsync(Review review)
        {
            var sql = "UPDATE Reviews SET RecipeId = @RecipeId, UserId = @UserId, Rating = @Rating, Comment = @Comment WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, review);
            return review;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Reviews WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }
    }
}
