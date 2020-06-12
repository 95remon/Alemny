using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Choices 
    {
        [Key]
        public int QuestionID { get; set; }

        public string Choice { get; set; }

        public bool IsTrue { get; set; }

        [ForeignKey("QuestionID")]
        public virtual MCQ MCQ { get; set; }
    }
}