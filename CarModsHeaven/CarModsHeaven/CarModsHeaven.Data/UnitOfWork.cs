using CarModsHeaven.Data.Contracts;
using System;

namespace CarModsHeaven.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarModsContext context;

        public UnitOfWork(CarModsContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
