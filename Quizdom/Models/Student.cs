using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quizdom.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Score { get; set; }

        public DateTime Date { get; set; }
        public virtual Quiz Quiz { get; set; }

    }
}