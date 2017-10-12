using Bytes2you.Validation;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.Home;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        private readonly string projectsServiceCheck = "Project service is null";
        private readonly string usersServiceCheck = "Users service is null";

        public HomeController(IProjectsService projectsService, IUsersService usersService)
        {
            Guard.WhenArgument(projectsService, projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, usersServiceCheck).IsNull().Throw();

            this.projectsService = projectsService;
            this.usersService = usersService;
        }

        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            var projectsCount = this.projectsService.GetAll().ToList().Count;
            var usersCount = this.usersService.GetAll().ToList().Count;
            var viewModel = new AboutViewModel() { ProjectsCount = projectsCount, UsersCount = usersCount };

            return this.View(viewModel);
        }
    }
}