using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class LearningContext : IdentityDbContext
    {
        public LearningContext():base("Alemny")
        {

        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<ExamQuestion> ExamsQuestions { get; set; }

        public virtual DbSet<MCQ> MCQs { get; set; }

        public virtual DbSet<Choices> Choices { get; set; }

        public virtual DbSet<TrueFalseQuestion> TrueFalseQuestions { get; set; }

        public virtual DbSet<StudentAnswerInExam> StudentAnswerInExams { get; set; }

        public virtual DbSet<Enroll> Enroll{ get; set; }

        public virtual DbSet<Teach> Teach { get; set; }


    }
}