using System.Linq;
using System.Web.Mvc;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.UsersList;

namespace CarModsHeaven.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProjectsService projectsService;

        public UsersController(IUsersService usersService, IProjectsService projectsService)
        {
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