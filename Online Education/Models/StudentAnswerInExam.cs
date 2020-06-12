using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class StudentAnswerInExam
    {
        public int ID { get; set; }

        public string StudentID { get; set; }

        public int ExamID { get; set; }

        public int QuestionID { get; set; }
        
        [ForeignKey("ExamID")]
        public virtual Exam Exam { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }

        [ForeignKey("StudentID")]
        public virtual  User User { get; set; }




    }
}