using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories
{
    namespace DataAccess.Repositories
    {
        public class ReviewRepository : IReviewRepository
        {
            private readonly string _connectionString;

            public ReviewRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            private IDbConnection CreateConnection()
            {
                return new SqlConnection(_connectionString);
            }

            public async Task<Review> AddAsync(Review review)
            {
                const string query = @"
                INSERT INTO Reviews (RecipeId, UserId, Rating, Comment)
                OUTPUT INSERTED.*
                VALUES (@RecipeId, @UserId, @Rating, @Comment)";

                using (var connection = CreateConnection())
                {
                    return await connection.QuerySingleAsync<Review>(query, review);
                }
            }

            public async Task<Review> GetByIdAsync(int id)
            {
                const string query = "SELECT * FROM Reviews WHERE Id = @Id";

                using (var connection = CreateConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<Review>(query, new { Id = id });
                }
            }

            public async Task<IEnumerable<Review>> GetAllAsync()
            {
                const string query = "SELECT * FROM Reviews";

                using (var connection = CreateConnection())
                {
                    return await connection.QueryAsync<Review>(query);
                }
            }

            public async Task<IEnumerable<Review>> GetByRecipeIdAsync(int recipeId)
            {
                const string query = "SELECT * FROM Reviews WHERE RecipeId = @RecipeId";

                using (var connection = CreateConnection())
                {
                    return await connection.QueryAsync<Review>(query, new { RecipeId = recipeId });
                }
            }

            public async Task UpdateAsync(Review review)
            {
                const string query = @"
                UPDATE Reviews
                SET RecipeId = @RecipeId,
                    UserId = @UserId,
                    Rating = @Rating,
                    Comment = @Comment
                WHERE Id = @Id";

                using (var connection = CreateConnection())
                {
                    await connection.ExecuteAsync(query, review);
                }
            }

            public async Task<bool> RemoveAsync(int id)
            {
                const string query = "DELETE FROM Reviews WHERE Id = @Id";

                using (var connection = CreateConnection())
                {
                    var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
                    return affectedRows > 0;
                }
            }
        }
    }
}