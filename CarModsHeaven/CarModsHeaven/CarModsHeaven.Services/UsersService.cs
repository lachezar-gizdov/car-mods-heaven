using System.Linq;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Bytes2you.Validation;

namespace CarModsHeaven.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> usersRepo;
        private readonly IUnitOfWork context;
        private readonly string usersRepoCheck = "Users Repository is null";
        private readonly string contextCheck = "DbContext is null";

        public UsersService(IEfRepository<User> usersRepo, IUnitOfWork context)
        {
            Guard.WhenArgument(usersRepo, usersRepoCheck).IsNull().Throw();
            Guard.WhenArgument(context, contextCheck).IsNull().Throw();

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
