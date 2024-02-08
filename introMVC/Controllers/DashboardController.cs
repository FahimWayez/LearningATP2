using introMVC.Models;
using System.Web.Mvc;

namespace introMVC.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Profile()
        {
            var s1 = new student();
            s1.name = "Fahim";
            s1.id = "1";
            s1.cgpa = 2.44f;
            ViewBag.student = s1;

            var s2 = new student();
            s2.name = "Fahim";
            s2.id = "2";
            s2.cgpa = 3.234f;
            ViewBag.student = s1;


            student[] students = new student[] { s1, s2 };

            var name = "Fahim";
            var id = 1;
            var cgpa = 3.44;

            ViewBag.Name = name;
            ViewBag.Id = id;
            ViewBag.Cgpa = cgpa;
            return View();
        }
    }
}