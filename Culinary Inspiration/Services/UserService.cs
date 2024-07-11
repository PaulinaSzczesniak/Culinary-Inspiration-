using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    namespace Services
    {
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;

            public UserService(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<User> CreateUserAsync(User user)
            {
                return await _userRepository.AddAsync(user);
            }

            public async Task<User> GetUserByIdAsync(int id)
            {
                return await _userRepository.GetByIdAsync(id);
            }

            public async Task<IEnumerable<User>> GetAllUsersAsync()
            {
                return await _userRepository.GetAllAsync();
            }

            public async Task UpdateUserAsync(User user)
            {
                await _userRepository.UpdateAsync(user);
            }

            public async Task<bool> DeleteUserAsync(int id)
            {
                return await _userRepository.RemoveAsync(id);
            }

            public async Task<User> AuthenticateUserAsync(string email, string password)
            {
                var user = await _userRepository.GetByEmailAsync(email);
                if (user == null || user.PasswordHash != password)
                {
                    return null;
                }
                return user;
            }
        }
    }
}