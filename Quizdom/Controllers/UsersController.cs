using Quizdom.Models;
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
            db.Users.Add(userdetails);
            db.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerifyLogin(Users users)
        {
            var db = new dbContext();
            var SearchData = db.Users.Where(x => x.Email == users.Email && x.Password == users.Password).SingleOrDefault();
            if (SearchData != null)
            {
                return View("Login");
            }
            else
            {
                return View("LoginFailed");
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}