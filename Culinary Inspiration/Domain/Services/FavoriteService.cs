using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal class FavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite> GetFavoriteByIdAsync(int id)
        {
            return await _favoriteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _favoriteRepository.GetByUserIdAsync(userId);
        }

        public async Task<Favorite> AddFavoriteAsync(Favorite favorite)
        {
            return await _favoriteRepository.AddAsync(favorite);
        }

        public async Task<bool> RemoveFavoriteAsync(int id)
        {
            return await _favoriteRepository.RemoveAsync(id);
        }

    }
}
