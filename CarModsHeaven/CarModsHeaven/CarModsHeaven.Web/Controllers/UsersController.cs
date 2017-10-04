﻿using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.UsersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            var projects = this.usersService
                .GetAll()
                .MapTo<UserViewModel>()
                .ToList();

            return View(projects);
        }
    }
}