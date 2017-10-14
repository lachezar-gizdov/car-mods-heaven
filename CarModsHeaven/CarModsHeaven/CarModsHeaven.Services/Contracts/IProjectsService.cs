using System.Linq;
using CarModsHeaven.Data.Models;
using System;

namespace CarModsHeaven.Services.Contracts
{
    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        IQueryable<Project> GetById(Guid? id);

        void Add(Project project, string id);

        void Update(Project project);

        void Delete(Project project);
    }
}