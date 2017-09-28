using CarModsHeaven.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarModsHeaven.Data
{
    public class SqlDbContext : IdentityDbContext<User>
    {
        public SqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Project> Projects { get; set; }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
