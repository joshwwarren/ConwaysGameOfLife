using System.Web.Mvc;
using ConwaysGameOfLife.Models;
using ConwaysGameOfLife.Models.Matrix;
using ConwaysGameOfLife.ViewModels;

namespace ConwaysGameOfLife.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var newMatrix = new Matrix().CreateNewMatrix(50);
            Session.Add("matrix", newMatrix);
            return View(new Game {Matrix = newMatrix});
        }

        public ActionResult Judge()
        {
            if (Session["matrix"] == null) Response.Redirect("Index");

            var newMatrix = new Matrix().JudgeMatrix((Matrix) Session["matrix"]);
            Session.Add("matrix", newMatrix);
            ViewBag.ShowCreateNewMatrixButton = true;
            return View("Index", new Game {Matrix = newMatrix});
        }
    }
}