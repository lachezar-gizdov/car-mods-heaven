using System.Linq;
using CarModsHeaven.Data.Models;

namespace CarModsHeaven.Services.Contracts
{
    public interface IContactService
    {
        void Add(ContactEmail email);
        IQueryable<ContactEmail> GetAll();
    }
}