using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class ErrorController : Controller
    {
        [OutputCache(Duration = 60)]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}