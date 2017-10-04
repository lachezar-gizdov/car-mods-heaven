using CarModsHeaven.Data.Contracts;

namespace CarModsHeaven.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarModsContext context;

        public UnitOfWork(CarModsContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
