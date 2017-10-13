using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CarModsHeaven.Data.Models.Contracts;
using CarModsHeaven.Data.Repositories.Contracts;

namespace CarModsHeaven.Data.Repositories
{
    public class EfRepostory<T> : IEfRepository<T>
        where T : class, IDeletable, IAuditable
    {
        private readonly CarModsContext context;

        public EfRepostory(CarModsContext context)
        {
            this.context = context;
        }

        public IQueryable<T> AllVisible
        {
            get
            {
                return this.context.Set<T>().Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllWithDeleted
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                entity.CreatedOn = DateTime.Now;
                this.context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public T GetById(object id)
        {
            return this.context.Set<T>().Find(id.ToString());
        }
    }
}
