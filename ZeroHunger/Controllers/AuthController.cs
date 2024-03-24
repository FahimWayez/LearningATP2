using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.Models.DTO;
using ZeroHunger.Models.EF;

namespace Zero_Hunger.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            if (Session["Username"] != null)
            {
                if (Session["Access"].ToString() == "Restaurant")
                {
                    return RedirectToAction("Dashboard", "Restaurant");
                }
                else
                {
                    return RedirectToAction("Dashboard", "NGO");
                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerDbContext();
                var user = db.Users.FirstOrDefault(u => u.UserName == login.Username);

                if (user != null && user.Password == login.Password)
                {
                    Session["Username"] = login.Username;
                    Session["Access"] = user.AccessName;
                    if (user.AccessName == "Restaurant")
                    {
                        return RedirectToAction("Dashboard", "Restaurant");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "NGO");
                    }
                }
                ViewBag.Error = "Invalid Username or Password";
                return View();
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult RestaurantRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestaurantRegistration(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerDbContext();
                var data = db.Users.FirstOrDefault(u => u.UserName == user.UserName);

                if (data == null)
                {
                    User userEntity = new User();
                    userEntity.Id = Guid.NewGuid();
                    userEntity.UserName = user.UserName;
                    userEntity.Password = user.Password;
                    userEntity.AccessName = "Restaurant";
                    db.Users.Add(userEntity);
                    db.SaveChanges();

                    Restaurant RestaurantEntity = new Restaurant();
                    RestaurantEntity.Id = userEntity.Id;
                    RestaurantEntity.Name = user.Name;
                    db.Restaurants.Add(RestaurantEntity);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Auth");
                }
                ViewBag.Error = "The Username Already Exists";
                return View();
            }
            ViewBag.Error = "Something Went Wrong";
            return View();
        }
    }
}