using System.Linq;
using CarModsHeaven.Data.Models;
using System;

namespace CarModsHeaven.Services.Contracts
{
    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetUserById(Guid? id);
    }
}