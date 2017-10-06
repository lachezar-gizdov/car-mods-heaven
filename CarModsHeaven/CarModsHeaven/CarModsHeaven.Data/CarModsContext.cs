using System;
using System.Data.Entity;
using System.Linq;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Models.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarModsHeaven.Data
{
    public class CarModsContext : IdentityDbContext<User>, ICarModsContext
    {
        public CarModsContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Project> Projects { get; set; }

        public static CarModsContext Create()
        {
            return new CarModsContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
