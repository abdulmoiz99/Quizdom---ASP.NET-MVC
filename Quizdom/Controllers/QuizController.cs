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
        public ActionResult AddQuizName()
        {
            return View();
        }
        public ActionResult Quizes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuiz(Quiz quiz)
        {
            var db = new dbContext();
            // get existing user with with a particular ID
            var sub = db.Users.FirstOrDefault(x => x.ID == Main.UserID);
            quiz.User = sub;
            quiz.IsActive = true;
            quiz.DateCreated = DateTime.Now;
            db.Quiz.Add(quiz);
            db.SaveChanges();

            ViewBag.QuizTitle = quiz.QuizTilte;
            Main.QuizID = quiz.Id;

            return View("Create");
        }
        [HttpPost]
        public ActionResult AddQuestion(Questions questions)
        {
            var db = new dbContext();
            // get existing user with with a particular ID
            var sub = db.Quiz.FirstOrDefault(x => x.Id == Main.QuizID);
            questions.Quiz = sub;
            questions.IsActive = true;
            db.Questions.Add(questions);
            db.SaveChanges();

            return View("Create");
        }
    }
}