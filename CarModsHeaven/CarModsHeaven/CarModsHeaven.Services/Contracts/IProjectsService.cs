using System.Linq;
using CarModsHeaven.Data.Models;

namespace CarModsHeaven.Services.Contracts
{
    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        void Add(Project project);

        void Update(Project project);
    }
}