using CarModsHeaven.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarModsHeaven.Data
{
    public class SqlDbContext : IdentityDbContext<User>
    {
        public SqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
