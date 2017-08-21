using System.Web.Mvc;
using Antlr.Runtime.Misc;
using ConwaysGameOfLife.Models;
using ConwaysGameOfLife.ViewModels;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        private readonly Func<IMatrix> matrix;

        public GameController(Func<IMatrix> matrix)
        {
            this.matrix = matrix;
        }

        public ActionResult Index()
        {
            return View(new Game {Matrix = matrix().CreateNewMatrix()});
        }
    }
}