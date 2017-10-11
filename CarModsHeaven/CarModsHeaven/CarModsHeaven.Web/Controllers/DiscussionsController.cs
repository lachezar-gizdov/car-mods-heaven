using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class DiscussionsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}