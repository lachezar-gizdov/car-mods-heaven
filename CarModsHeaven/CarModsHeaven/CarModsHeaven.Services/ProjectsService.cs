using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace CarModsHeaven.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IEfRepository<Project> projectsRepo;
        private readonly IUsersService usersService;
        private readonly IUnitOfWork context;

        public ProjectsService(IEfRepository<Project> projectsRepo, IUsersService usersService, IUnitOfWork context)
        {
            this.projectsRepo = projectsRepo;
            this.usersService = usersService;
            this.context = context;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projectsRepo.AllVisible;
        }

        public void Add(Project project, string id)
        {
            this.projectsRepo.Add(project);
            var currentUser = this.usersService.GetUserById(id);
            currentUser.Projects.Add(project);
            this.context.SaveChanges();
        }

        public void Update(Project project)
        {
            this.projectsRepo.Update(project);
            this.context.SaveChanges();
        }

        public void Delete(Project project)
        {
            this.projectsRepo.Delete(project);
            this.context.SaveChanges();
        }
    }
}
