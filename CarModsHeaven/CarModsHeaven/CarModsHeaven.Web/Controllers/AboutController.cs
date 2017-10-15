using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.About;

namespace ContactUS.Controllers
{
    public class AboutController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        private readonly string projectsServiceCheck = "Project service is null";
        private readonly string usersServiceCheck = "Users service is null";

        public AboutController(IProjectsService projectsService, IUsersService usersService)
        {
            Guard.WhenArgument(projectsService, this.projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, this.usersServiceCheck).IsNull().Throw();

            this.projectsService = projectsService;
            this.usersService = usersService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var projectsCount = this.projectsService.GetAll().ToList().Count;
            var usersCount = this.usersService.GetAll().ToList().Count;
            var viewModel = new AboutViewModel() { ProjectsCount = projectsCount, UsersCount = usersCount };

            return this.View(viewModel);
        }
    }
}