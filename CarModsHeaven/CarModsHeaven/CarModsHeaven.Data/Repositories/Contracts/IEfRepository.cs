using System.Linq;
using CarModsHeaven.Data.Models.Contracts;

namespace CarModsHeaven.Data.Repositories.Contracts
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}