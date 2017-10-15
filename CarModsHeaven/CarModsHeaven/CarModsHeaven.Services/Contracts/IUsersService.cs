using System.Linq;
using CarModsHeaven.Data.Models;

namespace CarModsHeaven.Services.Contracts
{
    public interface IUsersService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetUserById(string id);

        void Delete(User user);
    }
}