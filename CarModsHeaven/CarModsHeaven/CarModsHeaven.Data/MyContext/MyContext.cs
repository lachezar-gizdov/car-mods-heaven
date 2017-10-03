namespace CarModsHeaven.Data.Contracts
{
    public class MyContext : IMyContext
    {
        private readonly SqlDbContext context;

        public MyContext(SqlDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
