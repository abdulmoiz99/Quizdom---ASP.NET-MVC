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
            questions.DateCreated = DateTime.Now;
            questions.IsActive = true;

            var db = new dbContext();
            db.Questions.Add(questions);
            db.SaveChanges();

            return View();
        }
    }
}