using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quizdom.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string QuizTilte { get; set; }

        public bool IsActive { get; set; }

        public virtual Users User { get; set; }

        public DateTime DateCreated { get; set; }

        public string Link { get; set; }
    }
}