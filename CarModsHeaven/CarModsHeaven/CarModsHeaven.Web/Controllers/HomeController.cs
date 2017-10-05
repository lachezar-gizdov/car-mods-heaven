using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }
    }
}