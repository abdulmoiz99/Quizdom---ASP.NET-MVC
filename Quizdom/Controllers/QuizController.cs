using Quizdom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult StudentLogin()
        {
            return View();
        }

        public ActionResult StudentScore(Student student)
        {
            var db = new dbContext();
            // get existing user with with a particular ID
            var sub = db.Quiz.FirstOrDefault(x => x.Id == Main.QuizID);
            student.Quiz = sub;
            student.Date = DateTime.Now;
            db.Students.Add(student);
            db.SaveChanges();

            ViewBag.Score = student.Score;

            var total =  db.Questions.Where(t => t.Quiz.Id == Main.QuizID).Sum(t => t.Points);


            ViewBag.Total = total;


            return View("StudentScore");
        }

        [HttpPost]
        public ActionResult StudentQuiz(Quiz quiz)
        {
            var db = new dbContext();
            if (db.Quiz.Any(x => x.Link == quiz.Link))
            {
                Main.QuizID = db.Quiz.Where(x => x.Link == quiz.Link).Select(x => x.Id).FirstOrDefault();
                Main.QuizTitle = db.Quiz.Where(x => x.Link == quiz.Link).Select(x => x.QuizTilte).FirstOrDefault();
                return View("StudentQuizInput");
                
            }
            else
            {
                return View("StudentLoginIncorrect");
            }
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
            quiz.Link = Main.RandomString(6);
            db.Quiz.Add(quiz);
            db.SaveChanges();

            Main.QuizTitle = quiz.QuizTilte;
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