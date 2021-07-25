using Quizdom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizdom.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(Questions questions)
        {

            //var db = new dbContext();
            //// get existing user with with a particular ID
            //var sub = db.Users.FirstOrDefault(x => x.ID == Main.UserID);

            //questions.User = sub;

            //db.Questions.Add(questions);
            //db.SaveChanges();

            return View();
        }
    }
}