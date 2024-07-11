using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public interface IFavoriteRepository
    {
        Task<Favorite> GetByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId);
        Task<Favorite> AddAsync(Favorite favorite);
        Task<bool> RemoveAsync(int id);
    }
}
