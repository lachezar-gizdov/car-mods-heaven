using System.Linq;
using Bytes2you.Validation;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;

namespace CarModsHeaven.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> usersRepo;
        private readonly IUnitOfWork context;
        private readonly string usersRepoCheck = "Users Repository is null";
        private readonly string contextCheck = "DbContext is null";
        private readonly string userCheck = "Project is null";

        public UsersService(IEfRepository<User> usersRepo, IUnitOfWork context)
        {
            Guard.WhenArgument(usersRepo, this.usersRepoCheck).IsNull().Throw();
            Guard.WhenArgument(context, this.contextCheck).IsNull().Throw();

            this.usersRepo = usersRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.usersRepo.AllVisible;
        }

        public IQueryable<User> GetUserById(string id)
        {
            return this.usersRepo.AllVisible
                .Where(x => x.Id == id);
        }

        public void Delete(User user)
        {
            Guard.WhenArgument(user, this.userCheck).IsNull().Throw();
            this.usersRepo.Delete(user);
            this.context.SaveChanges();
        }
    }
}
