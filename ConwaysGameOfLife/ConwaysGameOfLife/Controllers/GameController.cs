using System.Web.Mvc;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
