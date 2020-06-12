using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Online_Education.Models
{
    public enum semester
    {
        First = 1,
        Second = 2
    }
    public class Course
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MaxDegree { get; set; }

        public int MinDegree { get; set; }

        public int StageID { get; set; }

        public semester Semester { get; set; }

        [JsonIgnore]
        [ForeignKey("StageID")]
        public virtual Stage Stage { get; set; } 




        public virtual ICollection<Exam> Exams { get; set; } 

        public virtual ICollection<Enroll> Enrolls { get; set; }

        public virtual ICollection<Teach> Teach { get; set; }


    }
}