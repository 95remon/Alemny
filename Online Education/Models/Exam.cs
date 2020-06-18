using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Exam
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TotalDegree { get; set; } 

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }

        public virtual ICollection<StudentAnswerInExam> StudentAnswerInExams { get; set; }

       

    }
}