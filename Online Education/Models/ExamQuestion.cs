using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class ExamQuestion
    {
        
        [Key , Column(Order = 0)]
        public int ExamID { get; set; }

        [Key, Column(Order = 1)]
        public int QuestionID { get; set; }

        public int Degree { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam Eaxm { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Questions { get; set; }


    }
}