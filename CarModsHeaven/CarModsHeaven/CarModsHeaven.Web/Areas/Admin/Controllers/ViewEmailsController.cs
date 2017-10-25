using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Models.Contact;

namespace CarModsHeaven.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ViewEmailsController : Controller
    {
        private readonly IContactService contactService;
        private readonly string contactServiceCheck = "Passed Contact service is null";

        public ViewEmailsController(IContactService contactService)
        {
            Guard.WhenArgument(contactService, this.contactServiceCheck).IsNull().Throw();
            this.contactService = contactService;
        }

        public ActionResult Index()
        {
            var emails = this.contactService
                .GetAll()
                .ProjectTo<ContactViewModel>()
                .ToList();
            return this.View(emails);
        }
    }
}