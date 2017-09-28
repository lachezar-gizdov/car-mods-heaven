using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.ProjectsList;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsListController : Controller
    {
        private readonly IProjectsService projectsService;

        public ProjectsListController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public ActionResult Index()
        {
            var projects = this.projectsService
                .GetAll()
                .Select(x => new ProjectsViewModel()
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
    }
}