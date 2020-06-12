using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Question
    {
        public int ID { get; set; }

        public string QuestionContent { get; set; }
        

        public virtual ICollection<StudentAnswerInExam> StudentAnswerInExams { get; set; }

        //public virtual TrueFalseQuestion TrueFalseQuestion { get; set; }

        //public virtual MCQ MCQ { get; set; }


    }
}