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