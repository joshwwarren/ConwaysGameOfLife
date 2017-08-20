using System.Web.Mvc;
using ConwaysGameOfLife.Models;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View(new Game());
        }
    }
}
