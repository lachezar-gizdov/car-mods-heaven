using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.ProjectsList;
using Microsoft.AspNet.Identity;
using PagedList;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        public ProjectsController(IProjectsService projectsService, IUsersService usersService)
        {
            this.projectsService = projectsService;
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GetProjects(int? page, string sortBy)
        {
            var projects = this.projectsService
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .MapTo<ProjectViewModel>()
                .ToList();

            int pageSize = 10;
            int pageNumber = page ?? 1;

            switch (sortBy)
            {
                case "date": projects = projects.OrderBy(x => x.CreatedOn).ToList();
                    break;
                case "brand": projects = projects.OrderBy(x => x.CarBrand).ToList();
                    break;
                case "title": projects = projects.OrderBy(x => x.Title).ToList();
                    break;
                default:
                    break;
            }
            return this.PartialView("_GetProjectsPartial", projects.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(string title)
        {
            var project = this.projectsService
                .GetAll()
                .MapTo<ProjectViewModel>()
                .SingleOrDefault(x => x.Title == title);

            return this.View(project);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddProject()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProject(ProjectViewModel project)
        {
            var dbModel = Mapper.Map<Project>(project);
            var userId = User.Identity.GetUserId();
            this.projectsService.Add(dbModel, userId);

            return this.RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProject(string title)
        {
            var project = this.projectsService
                .GetAll()
                .SingleOrDefault(x => x.Title == title);

            this.TempData["EditProjectId"] = project.Id;

            var viewModel = Mapper.Map<ProjectViewModel>(project);

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProject(ProjectViewModel project)
        {
            var dbModel = Mapper.Map<Project>(project);
            dbModel.Id = (System.Guid)TempData["EditProjectId"];
            this.projectsService.Update(dbModel);
            return this.RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteProject(ProjectViewModel project)
        {
            var found = this.projectsService
                .GetAll()
                .SingleOrDefault(x => x.Title == project.Title);

            this.projectsService.Delete(found);
            return this.RedirectToAction("Index");
        }
    }
}