using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                return null;
            }
            return user;
        }

        private bool VerifyPassword(string storedHash, string password)
        {
            //  password verification 
            return true;
        }
    }
}
