using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizdom
{
    public class Main
    {
        public static int UserID = 1;
        public static string Username { get; set; }

        public static bool IsLoggedIn = false;

        public static string GetUserNmae()
        {
            Username = "Abdul Moiz";
            return Username;
        }
    }
}