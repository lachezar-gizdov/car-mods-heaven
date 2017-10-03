using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using System.Linq;

namespace CarModsHeaven.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IEfRepository<Project> projectsRepo;
        private readonly IMyContext context;

        public ProjectsService(IEfRepository<Project> projectsRepo, IMyContext context)
        {
            this.projectsRepo = projectsRepo;
            this.context = context;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projectsRepo.AllVisible;
        }

        public void Add(Project project)
        {
            this.projectsRepo.Add(project);
            this.context.SaveChanges();
        }

        public void Update(Project project)
        {
            this.projectsRepo.Update(project);
            this.context.SaveChanges();
        }
    }
}
