using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.ProjectsList;
using Microsoft.AspNet.Identity;
using X.PagedList;
using Bytes2you.Validation;
using AutoMapper.QueryableExtensions;
using System;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        private readonly string projectsServiceCheck = "Project service is null";
        private readonly string usersServiceCheck = "Users service is null";

        public ProjectsController(IProjectsService projectsService, IUsersService usersService)
        {
            Guard.WhenArgument(projectsService, projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, usersServiceCheck).IsNull().Throw();

            this.projectsService = projectsService;
            this.usersService = usersService;
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
        public ActionResult GetProjects(int? page, string sortBy, string searchPattern)
        {
            var projects = this.projectsService
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ProjectTo<ProjectDetailsViewModel>()
                .ToList();

            if (!string.IsNullOrEmpty(searchPattern))
            {
                projects = projects.Where(p => p.Title.ToLower().Contains(searchPattern.ToLower())).ToList();
            }

            int pageSize = 6;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
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
            var dbModel = Mapper.Map<Project>(project);
            this.projectsService.Update(dbModel);
            return this.RedirectToAction("Details", new { id = dbModel.Id });
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteProject(ProjectDetailsViewModel project)
        {
            var found = this.projectsService
                .GetAll()
                .SingleOrDefault(x => x.Title == project.Title);

            this.projectsService.Delete(found);
            return this.RedirectToAction("Index");
        }
    }
}