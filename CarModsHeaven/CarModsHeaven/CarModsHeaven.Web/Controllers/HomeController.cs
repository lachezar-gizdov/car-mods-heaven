using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.Home;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        public HomeController(IProjectsService projectsService, IUsersService usersService)
        {
            this.projectsService = projectsService;
            this.usersService = usersService;
        }

        [HandleError]
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