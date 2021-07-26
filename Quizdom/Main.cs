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


        public static bool IsLoggedIn = false;

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
    }
}