﻿using System;
using System.Linq;
using Bytes2you.Validation;
using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;

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
            Guard.WhenArgument(projectsRepo, this.projectsRepoCheck).IsNull().Throw();
            Guard.WhenArgument(usersService, this.usersServiceCheck).IsNull().Throw();
            Guard.WhenArgument(context, this.contextCheck).IsNull().Throw();

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

        public void Add(Project project, string userId)
        {
            Guard.WhenArgument(project, this.projectCheck).IsNull().Throw();

            this.projectsRepo.Add(project);
            var currentUser = this.usersService.GetUserById(userId).SingleOrDefault();
            currentUser.Projects.Add(project);
            this.context.SaveChanges();
        }

        public void Update(Project project)
        {
            Guard.WhenArgument(project, this.projectCheck).IsNull().Throw();
            this.projectsRepo.Update(project);
            this.context.SaveChanges();
        }

        public void Delete(Project project)
        {
            Guard.WhenArgument(project, this.projectCheck).IsNull().Throw();
            this.projectsRepo.Delete(project);
            this.context.SaveChanges();
        }

        public IQueryable<Project> GetAllSorted(string pattern)
        {
            var projects = this.projectsRepo.AllVisible;

            switch (pattern)
            {
                case "date":
                    projects = projects.OrderBy(x => x.CreatedOn);
                    break;
                case "brand":
                    projects = projects.OrderBy(x => x.CarBrand);
                    break;
                case "title":
                    projects = projects.OrderBy(x => x.Title);
                    break;
                default:
                    projects = projects.OrderBy(x => x.CreatedOn);
                    break;
            }

            return projects;
        }
    }
}
