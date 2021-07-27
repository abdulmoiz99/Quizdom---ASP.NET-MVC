using Quizdom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizdom
{
    public class Main
    {
        public static List<Questions> Questions = new List<Questions>();
        public static int UserID = 1;
        public static string Username { get; set; }

        public static int QuizID { get; set; }

        public static string QuizTitle { get; set; }


        public static bool IsLoggedIn = false;

        public static int total = 0;

        public static string GetUserName()
        {
            Username = "Abdul Moiz";
            return Username;
        }

        public static List<Questions> GetQuestions(int QuizId)
        {
            List<Questions> data = new List<Questions>();

            var db = new dbContext();
            var details = db.Questions.Where(x => x.Quiz.Id == QuizId && x.IsActive == true);

            foreach (var detail in details)
            {
                data.Add(detail);
            }
            return data;
        }
        public static List<Quiz> GetQuizDetails(int UserID)
        {
            var model = new List<Quiz>();

            var db = new dbContext();
            model = db.Quiz.Where(x=> x.User.ID == UserID).ToList();

            return model;
        }

        public static List<Result> GetResults(int UserID) 
        {
            var db = new dbContext();
            return db.Quiz.Where(q => q.User.ID == UserID).GroupJoin(db.Questions, x => x.Id, y => y.Quiz.Id,
            (quiz, questions) => new { Id = quiz.Id, Name = quiz.QuizTilte, DateCreated = quiz.DateCreated, TotalScore = questions.Where(t => t.Quiz.Id == quiz.Id).Sum(t => t.Points) }).GroupJoin(db.Students, x => x.Id, y => y.Quiz.Id, (quizQuestions, students) => new Result(){ Id = quizQuestions.Id, Title = quizQuestions.Name, DateCreated = quizQuestions.DateCreated, TotalScore = quizQuestions.TotalScore, StudentsAttempted = students.Where(x => x.Quiz.Id == quizQuestions.Id).Count() }).ToList();        
        }
    }

    public class Result 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int TotalScore { get; set; }
        public int StudentsAttempted { get; set; }
    }
}