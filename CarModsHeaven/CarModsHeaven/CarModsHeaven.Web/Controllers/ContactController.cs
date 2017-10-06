using System;
using System.Net.Mail;
using System.Web.Mvc;
using CarModsHeaven.Web.Models.Account;

namespace ContactUS.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage
                    {
                        // Email which you are getting 
                        From = new MailAddress(vm.Email)
                    };

                    // Where mail will be sent 
                    msz.To.Add("olebg01@gmail.com");
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",

                        Port = 465,

                        Credentials = new System.Net.NetworkCredential("luchezar.gizdov@gmail.com", "quattrobg"),

                        EnableSsl = true
                    };

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return this.View();
        }
    }
}