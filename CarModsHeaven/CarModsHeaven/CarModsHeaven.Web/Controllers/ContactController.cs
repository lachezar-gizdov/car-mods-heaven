using System.Web.Mvc;
using Bytes2you.Validation;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Web.Models.Contact;

namespace CarModsHeaven.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly string contactServiceCheck = "Contact service is null";

        public ContactController(IContactService contactService)
        {
            Guard.WhenArgument(contactService, this.contactServiceCheck).IsNull().Throw();
            this.contactService = contactService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var dbModel = new ContactEmail()
            {
                SenderName = model.SenderName,
                SenderEmail = model.SenderEmail,
                Subject = model.Subject,
                Content = model.Content
            };

            this.contactService.Add(dbModel);
            return this.Redirect("/");
        }
    }
}