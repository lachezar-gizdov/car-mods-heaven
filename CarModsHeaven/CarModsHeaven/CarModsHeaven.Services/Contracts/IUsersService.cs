using System.Linq;
using CarModsHeaven.Data.Models;

namespace CarModsHeaven.Services.Contracts
{
    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetUserById(string id);
    }
}