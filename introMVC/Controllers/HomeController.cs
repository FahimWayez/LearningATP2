using System.Web.Mvc;

namespace introMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Submit()
        {
            return Redirect("/Dashboard/Profile");
            return Redirect("https://www.aiub.edu");
            //return RedirectToAction("Profile", "Dashboard");
        }
    }
}