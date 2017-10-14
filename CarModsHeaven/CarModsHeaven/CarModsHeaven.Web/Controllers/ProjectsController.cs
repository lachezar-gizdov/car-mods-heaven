using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarModsHeaven.Auth.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.ProjectsList;
using X.PagedList;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;
        private readonly IAuthProvider authProvider;
        private readonly string projectsServiceCheck = "Project service is null";
        private readonly string usersServiceCheck = "Users service is null";
        private readonly string authProviderCheck = "Auth provider is null";

        public ProjectsController(IProjectsService projectsService, IUsersService usersService, IAuthProvider authProvider)
        {
            Guard.WhenArgument(projectsService, this.projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, this.usersServiceCheck).IsNull().Throw();
            Guard.WhenArgument(authProvider, this.authProviderCheck).IsNull().Throw();

            this.projectsService = projectsService;
            this.usersService = usersService;
            this.authProvider = authProvider;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var projects = this.projectsService
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ProjectTo<ProjectDetailsViewModel>()
                .ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            return this.View(projects.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult GetProjects(int? page, string pattern)
        {
            var projects = this.projectsService
                .GetAllSorted(pattern)
                .ProjectTo<ProjectDetailsViewModel>()
                .ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            return this.PartialView("_GetProjectsPartial", projects.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return this.View("Error");
            }

            var project = this.projectsService
                .GetById(id)
                .ProjectTo<ProjectDetailsViewModel>()
                .SingleOrDefault();

            if (project == null)
            {
                return this.View("Error");
            }

            return this.View(project);
        }

        [HttpGet]
        public ActionResult AddScore(int score)
        {
            // TODO: implement scoring
            return this.View("Details");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddProject()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(ProjectAddViewModel project)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var dbModel = Mapper.Map<Project>(project);
            var userId = this.authProvider.CurrentUserId;
            this.projectsService.Add(dbModel, userId);

            return this.RedirectToAction("Details", new { id = dbModel.Id });
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProject(Guid? id)
        {
            if (id == null)
            {
                return this.View("Error");
            }

            var project = this.projectsService
                .GetById(id)
                .ProjectTo<ProjectDetailsViewModel>()
                .SingleOrDefault();

            if (project == null)
            {
                return this.View("Error");
            }

            return this.View(project);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProject(ProjectDetailsViewModel project)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var dbModel = Mapper.Map<Project>(project);
            this.projectsService.Update(dbModel);
            return this.RedirectToAction("Details", new { id = dbModel.Id });
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteProject(Guid? id)
        {
            if (id == null)
            {
                return this.View("Error");
            }

            var project = this.projectsService
                .GetById(id)
                .SingleOrDefault();

            if (project == null)
            {
                return this.View("Error");
            }

            this.projectsService.Delete(project);
            return this.RedirectToAction("Index");
        }
    }
}