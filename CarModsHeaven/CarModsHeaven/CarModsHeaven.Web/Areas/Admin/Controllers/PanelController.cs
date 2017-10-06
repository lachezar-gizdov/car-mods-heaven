using System.Web.Mvc;

namespace CarModsHeaven.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}