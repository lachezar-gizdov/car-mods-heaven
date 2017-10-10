using System.Linq;
using System.Web.Mvc;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.UsersList;
using Bytes2you.Validation;

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
                .MapTo<UserViewModel>()
                .ToList();

            return this.View(users);
        }

        public ActionResult Details(string userName)
        {
            var user = this.usersService.GetAll()
                .MapTo<UserViewModel>()
                .SingleOrDefault(x => x.UserName == userName);

            return this.View(user);
        }
    }
}