using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.ProjectsList;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public ActionResult Index()
        {
            var projects = this.projectsService
                .GetAll()
                .Select(x => new ProjectViewModel()
                {
                    Title = x.Title,
                    CarBrand = x.CarBrand,
                    CarModel = x.CarModel,
                    CarYear = x.CarYear,
                    ShortStory = x.ShortStory,
                    OwnerEmail = x.Owner.Email,
                    CreatedOn = x.CreatedOn

                })
                .ToList();

            return View(projects);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel project)
        {
            //this.projectsService.Add(project);
            return View();
        }
    }
}