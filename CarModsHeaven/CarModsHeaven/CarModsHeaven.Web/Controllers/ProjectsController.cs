using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
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
                .MapTo<ProjectViewModel>()
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
            var dbModel = Mapper.Map<Project>(project);
            this.projectsService.Add(dbModel);
            return RedirectToAction("Index");
        }
    }
}