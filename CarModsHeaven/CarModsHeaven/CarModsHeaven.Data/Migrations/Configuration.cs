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
            this.SeedAdmin(context);
            this.SeedProject(context);
        }

        private void SeedAdmin(SqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedProject(SqlDbContext context)
        {
            if (!context.Projects.Any())
            {
                var project = new Project()
                {
                    Title = "Power Project",
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
