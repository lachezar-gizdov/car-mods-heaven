using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarModsHeaven.Auth.Contracts;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.UsersList;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}