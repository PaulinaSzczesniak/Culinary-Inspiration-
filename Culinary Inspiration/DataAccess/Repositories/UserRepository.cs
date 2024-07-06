using Dapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User> CreateAsync(User user)
        {
            var sql = "INSERT INTO Users (Email, PasswordHash, UserName) VALUES (@Email, @PasswordHash, @UserName); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, user);
            user.Id = id;
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Users WHERE Email = @Email";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email });
        }
    }
}
