namespace CarModsHeaven.Data.Migrations
{
    using CarModsHeaven.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SqlDbContext>
    {
        const string AdministratorUserName = "info@carmodsheaven.com";
        const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedProjects(context);
        }

        private void SeedUsers(SqlDbContext context)
        {
            const string AdministratorUserName = "info@carmodsheaven.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedProjects(SqlDbContext context)
        {
            if (!context.Projects.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    var project = new Project()
                    {
                        Title = "Power Project" + i,
                        CarBrand = "Audi",
                        CarModel = "A4",
                        CarYear = 1999,
                        ShortStory = "Bla bla bla",
                        CreatedOn = DateTime.Now,
                        Owner = context.Users.First(x => x.Email == AdministratorUserName)
                    };

                    context.Projects.Add(project);
                }
            }
        }
    }
}
