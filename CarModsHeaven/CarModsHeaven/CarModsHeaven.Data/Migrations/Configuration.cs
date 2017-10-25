using System;
using System.Data.Entity.Migrations;
using System.Linq;
using CarModsHeaven.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CarModsHeaven.Providers.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace CarModsHeaven.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarModsContext>
    {
        private const string AdministratorEmail = "info@carmodsheaven.com";
        private const string AdministratorName = "Admin";
        private const string AdministratorPassword = "123456";
        private readonly string dateTimeProviderCheck = "Date Time Provider is null";
        private readonly IDateTimeProvider dateTimeProvider;

        public Configuration() { }

        public Configuration(IDateTimeProvider dateTimeProvider)
        {
            Guard.WhenArgument(dateTimeProvider, this.dateTimeProviderCheck).IsNull().Throw();
            this.dateTimeProvider = dateTimeProvider;
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CarModsContext context)
        {
            //this.SeedUsers(context);
            //this.SeedProjects(context);
        }

        private void SeedUsers(CarModsContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    FullName = AdministratorName,
                    UserName = AdministratorEmail,
                    Email = AdministratorEmail,
                    EmailConfirmed = true,
                    CreatedOn = dateTimeProvider.GetCurrentTime()
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedProjects(CarModsContext context)
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
                        ModificationsType = Models.Enums.ModificationsType.AllAround,
                        ModificationsList = "mods",
                        CreatedOn = dateTimeProvider.GetCurrentTime(),
                        Owner = context.Users.First(x => x.Email == AdministratorEmail),
                        MadeBy = "YourSelf",
                        Score = 0
                    };

                    context.Projects.Add(project);
                }
            }
        }
    }
}
