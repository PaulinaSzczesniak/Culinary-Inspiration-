using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services
{
    public interface IFavoriteService
    {
        Task<Favorite> GetFavoriteByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId);
        Task<Favorite> AddFavoriteAsync(Favorite favorite);
        Task<bool> RemoveFavoriteAsync(int id);
    }
}
