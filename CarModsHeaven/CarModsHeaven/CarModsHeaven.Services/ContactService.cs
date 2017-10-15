using Bytes2you.Validation;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using System.Linq;

namespace CarModsHeaven.Services
{
    public class ContactService : IContactService
    {
        private readonly IEfRepository<ContactEmail> repository;
        private readonly IUnitOfWork context;
        private readonly string contextCheck = "DbContext is null";
        private readonly string repositoryCheck = "Repository is null";
        private readonly string emailCheck = "Receaved email is null";

        public ContactService(IEfRepository<ContactEmail> repository, IUnitOfWork context)
        {
            Guard.WhenArgument(repository, this.repositoryCheck).IsNull().Throw();
            Guard.WhenArgument(context, this.contextCheck).IsNull().Throw();
            this.repository = repository;
            this.context = context;

        }

        public IQueryable<ContactEmail> GetAll()
        {
            return this.repository.AllVisible;
        }

        public void Add(ContactEmail email)
        {
            Guard.WhenArgument(email, this.emailCheck).IsNull().Throw();
            this.repository.Add(email);
            this.context.SaveChanges();
        }
    }
}
