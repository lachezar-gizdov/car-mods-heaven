using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using System.Linq;

namespace CarModsHeaven.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IEfRepository<Project> projectsRepo;

        public ProjectsService(IEfRepository<Project> projectsRepo)
        {
            this.projectsRepo = projectsRepo;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projectsRepo.AllVisible;
        }
    }
}
