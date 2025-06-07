using System.Collections.Generic;
using System.Web.Mvc;
using u24634400_Prac8.Models;

namespace u24634400_Prac8.Controllers
{
    public class ShapesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuView()
        {
            return View();
        }

        public ActionResult DisplayShape()
        {
            ViewBag.Shape = TempData["shape"];
            ViewBag.ShapeType = TempData["type"];
            return View("DisplayShapeView");
        }

        public ActionResult CreateTriangleView()
        {
            return View(new Triangle());
        }

        [HttpPost]
        public ActionResult CreateTriangle(Triangle triangle)
        {
            if (ModelState.IsValid)
            {
                TempData["shape"] = triangle;
                TempData["type"] = "triangle";
                return RedirectToAction("DisplayShape");
            }
            return View("CreateTriangleView", triangle);
        }

        public ActionResult CreateEllipseView()
        {
            return View(new Ellipse());
        }

        [HttpPost]
        public ActionResult CreateEllipse(Ellipse ellipse)
        {
            if (ModelState.IsValid)
            {
                TempData["shape"] = ellipse;
                TempData["type"] = "ellipse";
                return RedirectToAction("DisplayShape");
            }
            return View("CreateEllipseView", ellipse);
        }

        public ActionResult CreateRectangleView()
        {
            return View(new Rectangle());
        }

        [HttpPost]
        public ActionResult CreateRectangle(Rectangle rectangle)
        {
            if (ModelState.IsValid)
            {
                TempData["shape"] = rectangle;
                TempData["type"] = "rectangle";
                return RedirectToAction("DisplayShape");
            }
            return View("CreateRectangleView", rectangle);
        }

        public static List<Polygon>shapes = new List<Polygon>();
        public static List<Polygon> GetSavedShapes()
        {
            return shapes;
        }

        [HttpPost]
        public ActionResult AddShapeToList()
        {
            var shape = TempData["shape"] as Polygon;
            string type = TempData["type"] as string;

            if (shape != null)
            {
                ShapesController.shapes.Add(shape); 
            }

            
            TempData["shape"] = shape;
            TempData["type"] = type;

            return View("DisplayShapeView"); 
        }

        public ActionResult CreateCircleView()
        {
            return View(new circle());
        }

        [HttpPost]
        public ActionResult CreateCircle(circle circle)
        {
            if (ModelState.IsValid)
            {
                TempData["shape"] = circle;
                TempData["type"] = "circle";
                return RedirectToAction("DisplayShape");
            }
            return View("CreateCircleView", circle);
        }
    }
}