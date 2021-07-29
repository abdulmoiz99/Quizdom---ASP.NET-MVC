using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizdom.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Results()
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

        public ActionResult Result()
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

        public ActionResult Dashboard()
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
    }
}