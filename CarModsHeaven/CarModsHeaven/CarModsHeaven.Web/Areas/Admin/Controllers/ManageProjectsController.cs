using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarModsHeaven.Auth.Contracts;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.ProjectsList;
using CarModsHeaven.Web.Models.UsersList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IAuthProvider authProvider;
        private readonly string projectsServiceCheck = "Projects service is null";
        private readonly string authProviderCheck = "Auth provider is null";

        public ManageProjectsController(IProjectsService projectsService, IAuthProvider authProvider)
        {
            Guard.WhenArgument(projectsService, this.projectsServiceCheck).IsNull().Throw();
            Guard.WhenArgument(authProvider, this.authProviderCheck).IsNull().Throw();
            this.projectsService = projectsService;
            this.authProvider = authProvider;
        }

        public ActionResult Index()
        {
            var users = this.projectsService
                .GetAll()
                .ProjectTo<ProjectDetailsViewModel>()
                .ToList();

            return this.View(users);
        }

        public ActionResult DeleteProject(Guid id)
        {
            var project = this.projectsService.GetById(id).SingleOrDefault();
            if (project == null)
            {
                return this.View("Error");
            }

            this.projectsService.Delete(project);

            return this.RedirectToAction("Index");
        }
    }
}