using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quizdom.Models
{
    public class QuestionChoices
    {
        [Key]
        public int Id { get; set; }

        public virtual Questions Question { get; set; }
        public string Choice { get; set; }
        public bool IsRight { get; set; }


    }
}