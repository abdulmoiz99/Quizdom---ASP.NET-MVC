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
            if (Main.IsLoggedIn)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult AddQuizName()
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
        public ActionResult Quizes()
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

            var total = db.Questions.Where(t => t.Quiz.Id == Main.QuizID).Sum(t => t.Points);


            ViewBag.Total = total;


            return View("StudentScore");

        }

        public ActionResult ToggleStatus(Quiz _quiz)
        {
            var db = new dbContext();
            var quiz = db.Quiz.FirstOrDefault(x => x.Id == _quiz.Id);
            quiz.IsActive = !(quiz.IsActive);
            db.SaveChanges();
            return View("Quizes");


        }

        public ActionResult DeleteQuiz(Quiz _quiz)
        {
            var db = new dbContext();

            //Removing associated questions
            List<Questions> questionsToRemove = db.Questions.Where(x => x.Quiz.Id == _quiz.Id).ToList();
            foreach (var question in questionsToRemove) db.Questions.Remove(question);

            //Removing associated students
            List<Student> studentsToRemove = db.Students.Where(x => x.Quiz.Id == _quiz.Id).ToList();
            foreach (var student in studentsToRemove) db.Students.Remove(student);

            var quiz = db.Quiz.FirstOrDefault(x => x.Id == _quiz.Id);
            if (quiz != null) db.Quiz.Remove(quiz);
            db.SaveChanges();
            return View("Quizes");

        }

        [HttpPost]
        public ActionResult StudentQuiz(Quiz quiz)
        {
            var db = new dbContext();
            if (db.Quiz.Any(x => x.Link == quiz.Link && x.IsActive == true))
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
            if (Main.IsLoggedIn)
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
            else
            {
                return View("Login");
            }

        }
        [HttpPost]
        public ActionResult AddQuestion(Questions questions)
        {
            if (Main.IsLoggedIn)
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
            else
            {
                return View("Login");
            }

        }

        public ActionResult AboutUs()
        {
                return View();
        }
    }
}