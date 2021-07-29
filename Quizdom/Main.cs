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
        private static Random random = new Random();

        public static string GetUserName()
        {
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
            var query = db.Quiz.Where(q => q.User.ID == UserID).GroupJoin(db.Questions, x => x.Id, y => y.Quiz.Id,
            (quiz, questions) => new { Id = quiz.Id, Name = quiz.QuizTilte, DateCreated = quiz.DateCreated, TotalScore = questions.Where(t => t.Quiz.Id == quiz.Id).Sum(t => t.Points) }).GroupJoin(db.Students, x => x.Id, y => y.Quiz.Id, (quizQuestions, students) => new Result(){ Id = quizQuestions.Id, Title = quizQuestions.Name, DateCreated = quizQuestions.DateCreated, TotalScore = quizQuestions.TotalScore, StudentsAttempted = students.Where(x => x.Quiz.Id == quizQuestions.Id).Count() }).ToList();
            return query;
        }

        public static List<StudentResult> GetStudentResults(int quizID)
        {
            var db = new dbContext();
            double total = db.Questions.Where(q => q.Quiz.Id == quizID).Sum(x => x.Points);
            return db.Students.Where(s => s.Quiz.Id == quizID).Select(x => new StudentResult() { Id = x.Id, Name = x.Name, Score = x.Score/total * 100 }).ToList();
        }

        
        public static string RandomString(int length)
        {
            var db = new dbContext();
            string randomString = String.Empty;
            bool found = true;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            while (found) 
            {
                randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                if (db.Quiz.Any(x => x.Link == randomString)) found = true;
                else found = false;
            }
            return randomString;       
        }

        public static int GetTotalQuiz(int userID) 
        {
            var db = new dbContext();
            return db.Quiz.Where(q => q.User.ID == userID).Count();
        }

        public static int GetTotalQuestions(int userID) 
        {
            var db = new dbContext();
            return db.Quiz.Where(q => q.User.ID == userID).Join(db.Questions, x => x.Id, y => y.Quiz.Id, (quiz, questions) => new { quizId = quiz.Id, questions = questions.Id }).Count();
            
        }

        public static int GetTotalStudentsAttempted(int userID)
        {
            var db = new dbContext();
            return db.Quiz.Where(q => q.User.ID == userID).Join(db.Students, x => x.Id, y => y.Quiz.Id, (quiz, students) => new { quizId = quiz.Id, students = students.Id }).Count();

        }

        public static double GetSuccessRate(int userID)
        {
            var studentsScore = new List<double>();
            var db = new dbContext();
            var quizIds = db.Quiz.Where(x => x.User.ID == userID).Select(q => q.Id).ToList();
            foreach (var id in quizIds) 
            {
                double total = db.Questions.Where(q => q.Quiz.Id == id).Sum(x => x.Points);
                studentsScore.AddRange(db.Students.Where(s => s.Quiz.Id == id).Select(x => x.Score / total * 100));
            }
            var passedStudents = studentsScore.Where(x => x >= 50).ToList();
            return Math.Round(Convert.ToDouble(passedStudents.Count()) / Convert.ToDouble(studentsScore.Count()) * 100);

        }

        public static double GetScoreRange(int userID, double min, double max)
        {
            var studentsScore = new List<double>();
            var db = new dbContext();
            var quizIds = db.Quiz.Where(x => x.User.ID == userID).Select(q => q.Id).ToList();
            foreach (var id in quizIds)
            {
                double total = db.Questions.Where(q => q.Quiz.Id == id).Sum(x => x.Points);
                studentsScore.AddRange(db.Students.Where(s => s.Quiz.Id == id).Select(x => x.Score / total * 100));
            }
            var passedStudents = studentsScore.Where(x => x >= min && x < max).ToList();
            return Math.Round(Convert.ToDouble(passedStudents.Count()) / Convert.ToDouble(studentsScore.Count()) * 100);

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

    public class StudentResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
    }
}