using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class TrueFalseQuestion 
    {
        [Key]
        public int QuestionID { get; set; }

        public bool CorrectAnswer { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}