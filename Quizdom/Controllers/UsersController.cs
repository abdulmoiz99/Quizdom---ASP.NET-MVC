using Quizdom.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Quizdom.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Users userdetails)
        {
            var db = new dbContext();
            userdetails.IsActive = true;
            userdetails.DateCreated = DateTime.Now;
            db.Users.Add(userdetails);
            db.SaveChanges();
            return View("Login");
        }
        public ActionResult Login()
        {
            Main.IsLoggedIn = false;
            return View();
        }
        [HttpPost]
        public ActionResult VerifyLogin(Users users)
        {
            var db = new dbContext();
            var SearchData = db.Users.Where(x => x.Email == users.Email && x.Password == users.Password).SingleOrDefault();
            if (SearchData != null)
            {
                Main.IsLoggedIn = true;
                Main.UserID = SearchData.ID;
                Main.Username = SearchData.FirstName + " " + SearchData.LastName;
                return View("Profile");
            }
            else return View("LoginFailed");

        }
        public new ActionResult Profile()
        {
            if (Main.IsLoggedIn)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult UpdateProfile(Users users)
        {
            var db = new dbContext();
            var SearchData = db.Users.Where(x => x.ID == Main.UserID).SingleOrDefault();
            if (users.Password == SearchData.Password)
            {
                SearchData.Password = users.Email; // Email in a temp variable to store New Password
                db.SaveChanges();
                return View("Profile");
            }
            else
            {
                return View("ProfileIncorrect");
            }

        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}