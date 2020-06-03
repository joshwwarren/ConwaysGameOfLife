using System.Web.Mvc;
using ConwaysGameOfLife.Models.Matrix;
using ConwaysGameOfLife.ViewModels;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        private readonly IMatrix matrix;

        public GameController(IMatrix matrix)
        {
            this.matrix = matrix;
        }

        public ActionResult Index()
        {
            var newMatrix = matrix.CreateNewMatrix(50);

            Session.Add("matrix", newMatrix);

            return View(new Game {Matrix = newMatrix});
        }

        public ActionResult Judge()
        {
            if (Session["matrix"] == null) Response.Redirect("Index");

            var newMatrix = matrix.JudgeMatrix((Matrix) Session["matrix"]);

            Session.Add("matrix", newMatrix);

            ViewBag.ShowCreateNewMatrixButton = true;

            return View("Index", new Game {Matrix = newMatrix});
        }
    }
}