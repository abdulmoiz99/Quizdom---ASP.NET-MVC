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
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}