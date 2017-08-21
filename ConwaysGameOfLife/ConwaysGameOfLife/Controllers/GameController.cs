using System.Web.Mvc;
using ConwaysGameOfLife.Models;
using ConwaysGameOfLife.ViewModels;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View(new Game {Matrix = new Matrix().CreateNewMatrix(50)});
        }
    }
}