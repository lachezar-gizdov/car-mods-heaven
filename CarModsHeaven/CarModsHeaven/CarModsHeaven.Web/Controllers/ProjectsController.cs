using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.ProjectsList;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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

        public ActionResult Index(int? page)
        {
            var projects = this.projectsService
                .GetAll()
                .MapTo<ProjectViewModel>()
                .ToList();

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(projects.ToPagedList(pageNumber, pageSize));
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
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProject(ProjectViewModel project)
        {
            var dbModel = Mapper.Map<Project>(project);
            var userId = User.Identity.GetUserId();
            this.projectsService.Add(dbModel, userId);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditProject(string title)
        {
            var project = this.projectsService
                .GetAll()
                .MapTo<ProjectViewModel>()
                .SingleOrDefault(x => x.Title == title);

            return this.View(project);
        }


        [HttpPost]
        public ActionResult EditProject(ProjectViewModel project)
        {
            var dbModel = Mapper.Map<Project>(project);
            this.projectsService.Update(dbModel);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteProject(string title)
        {
            var project = this.projectsService
                .GetAll()
                .SingleOrDefault(x => x.Title == title);

            this.projectsService.Delete(project);
            return RedirectToAction("Index");
        }
    }
}