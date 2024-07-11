using Dapper;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<User> AddAsync(User user)
        {
            var query = "INSERT INTO Users (Email, PasswordHash, UserName) " +
                        "VALUES (@Email, @PasswordHash, @UserName); SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = CreateConnection())
            {
                return await connection.QuerySingleAsync<User>(query, user);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM Users WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            const string query = "SELECT * FROM Users WHERE Email = @Email";

            using (var connection = CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            const string query = "SELECT * FROM Users";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<User>(query);
            }
        }

        public async Task UpdateAsync(User user)
        {
            const string query = @"
                UPDATE Users
                SET Email = @Email,
                    PasswordHash = @PasswordHash,
                    UserName = @UserName
                WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            const string query = "DELETE FROM Users WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
                return affectedRows > 0;
            }
        }
    }
}