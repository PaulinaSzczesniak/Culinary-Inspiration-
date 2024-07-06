using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{

    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IDbConnection _dbConnection;

        public FavoriteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Favorite> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Favorites WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Favorite>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId)
        {
            var sql = "SELECT * FROM Favorites WHERE UserId = @UserId";
            return await _dbConnection.QueryAsync<Favorite>(sql, new { UserId = userId });
        }

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            var sql =
                "INSERT INTO Favorites (UserId, RecipeId) VALUES (@UserId, @RecipeId); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, favorite);
            favorite.Id = id;
            return favorite;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var sql = "DELETE FROM Favorites WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }
    }
}
