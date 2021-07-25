using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quizdom.Models
{
    public class dbContext :DbContext
    {
        public dbContext():base("quizEntities")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Questions> Questions { get; set; }

        public DbSet<QuestionChoices> QuestionChoices { get; set; }

    }
}