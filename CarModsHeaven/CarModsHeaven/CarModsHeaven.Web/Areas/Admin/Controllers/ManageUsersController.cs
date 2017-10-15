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
    public class ManageUsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IAuthProvider authProvider;
        private readonly string usersServiceCheck = "Users service is null";
        private readonly string authProviderCheck = "Auth provider is null";

        public ManageUsersController(IUsersService usersService, IAuthProvider authProvider)
        {
            Guard.WhenArgument(usersService, this.usersServiceCheck).IsNull().Throw();
            Guard.WhenArgument(authProvider, this.authProviderCheck).IsNull().Throw();
            this.usersService = usersService;
            this.authProvider = authProvider;
        }

        public ActionResult Index()
        {
            var users = this.usersService
                .GetAll()
                .ProjectTo<UserViewModel>()
                .ToList();

            return this.View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddAdmin(string id)
        {
            this.authProvider.AddToRole(id, "Admin");

            return this.RedirectToAction("Index");
        }

        public ActionResult DeleteUser(string id)
        {
            var user = this.usersService.GetUserById(id).SingleOrDefault();
            if (user == null)
            {
                return this.View("Error");
            }

            this.usersService.Delete(user);

            return this.RedirectToAction("Index");
        }
    }
}