using System.Data.Entity;
using CarModsHeaven.Data.Models;

namespace CarModsHeaven.Data.Contracts
{
    public interface ICarModsContext
    {
        IDbSet<Project> Projects { get; set; }

        IDbSet<TEntity> DbSet<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}