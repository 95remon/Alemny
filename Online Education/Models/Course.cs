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
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxDegree { get; set; }
        [Required]
        public int MinDegree { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int StageID { get; set; }
        [Required]
        public semester Semester { get; set; }
      

        [JsonIgnore]
        [ForeignKey("StageID")]
        public virtual Stage Stage { get; set; }



        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        [JsonIgnore]

        public virtual ICollection<Enroll> Enrolls { get; set; }
        [JsonIgnore]

        public virtual ICollection<Teach> Teach { get; set; }

        [JsonIgnore]
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}