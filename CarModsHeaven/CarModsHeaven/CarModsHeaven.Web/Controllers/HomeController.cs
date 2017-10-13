using Bytes2you.Validation;
using CarModsHeaven.Data;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.Home;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}