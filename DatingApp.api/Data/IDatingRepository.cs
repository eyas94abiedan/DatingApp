using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.api.Models;

namespace DatingApp.api.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T element) where T : class;
        void Delete<T>(T element) where T : class;
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> SaveChanges();
    }
}