using System.Linq;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Bytes2you.Validation;
using System;

namespace CarModsHeaven.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IEfRepository<Project> projectsRepo;
        private readonly IUsersService usersService;
        private readonly IUnitOfWork context;
        private readonly string projectsRepoCheck = "Projects Repository is null";
        private readonly string usersServiceCheck = "Users Service is null";
        private readonly string contextCheck = "DbContext is null";
        private readonly string projectCheck = "Passed project is null";

        public ProjectsService(IEfRepository<Project> projectsRepo, IUsersService usersService, IUnitOfWork context)
        {
            Guard.WhenArgument(projectsRepo, projectsRepoCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, usersServiceCheck).IsNull().Throw();
            Guard.WhenArgument(context, contextCheck).IsNull().Throw();

            this.projectsRepo = projectsRepo;
            this.usersService = usersService;
            this.context = context;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projectsRepo.AllVisible;
        }

        public IQueryable<Project> GetById(Guid? id)
        {
            return this.projectsRepo.AllVisible
                .Where(x => x.Id == id);
        }

        public void Add(Project project, string UserId)
        {
            Guard.WhenArgument(project, projectCheck).IsNull().Throw();

            this.projectsRepo.Add(project);
            var currentUser = this.usersService.GetUserById(UserId);
            currentUser.Projects.Add(project);
            this.context.SaveChanges();
        }

        public void Update(Project project)
        {
            Guard.WhenArgument(project, projectCheck).IsNull().Throw();
            this.projectsRepo.Update(project);
            this.context.SaveChanges();
        }

        public void Delete(Project project)
        {
            Guard.WhenArgument(project, projectCheck).IsNull().Throw();
            this.projectsRepo.Delete(project);
            this.context.SaveChanges();
        }
    }
}
