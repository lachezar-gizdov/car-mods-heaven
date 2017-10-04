using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using System;
using System.Linq;

namespace CarModsHeaven.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> usersRepo;
        private readonly IMyContext context;

        public UsersService(IEfRepository<User> usersRepo, IMyContext context)
        {
            if (usersRepo == null)
            {
                throw new ArgumentNullException(nameof(usersRepo));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.usersRepo = usersRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.usersRepo.AllVisible;
        }

        public User GetUserById(string id)
        {
            var user = this.usersRepo.GetById(id);

            return user;
        }
    }
}
