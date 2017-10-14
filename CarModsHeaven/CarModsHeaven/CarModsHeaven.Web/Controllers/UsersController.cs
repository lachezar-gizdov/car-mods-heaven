using System.Linq;
using System.Web.Mvc;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.UsersList;
using Bytes2you.Validation;
using AutoMapper.QueryableExtensions;

namespace CarModsHeaven.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProjectsService projectsService;

        private readonly string projectsServiceCheck = "Project service is null";
        private readonly string usersServiceCheck = "Users service is null";

        public UsersController(IUsersService usersService, IProjectsService projectsService)
        {
            Guard.WhenArgument(projectsService, projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, usersServiceCheck).IsNull().Throw();

            this.usersService = usersService;
            this.projectsService = projectsService;
        }

        public ActionResult Index()
        {
            var users = this.usersService
                .GetAll()
                .ProjectTo<UserViewModel>()
                .ToList();

            return this.View(users);
        }

        public ActionResult Details(string id)
        {
            if (id == null || id == string.Empty)
            {
                return this.View("Error");
            }
            var user = this.usersService.GetUserById(id)
                .ProjectTo<UserViewModel>()
                .SingleOrDefault();

            if (user == null)
            {
                return this.View("Error");
            }

            return this.View(user);
        }
    }
}