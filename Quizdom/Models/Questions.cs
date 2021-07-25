using System;
using System.ComponentModel.DataAnnotations;

namespace Quizdom.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string Question { get; set; }

        [MaxLength(50)]
        public string ChoiceA { get; set; }

        [MaxLength(50)]
        public string ChoiceB { get; set; }

        [MaxLength(50)]
        public string ChoiceC { get; set; }

        [MaxLength(50)]
        public string ChoiceD { get; set; }

        [MaxLength(1)]
        public string CorrectChoice { get; set; }

        public int Points { get; set; }

        public bool IsActive { get; set; }
        
    }
}