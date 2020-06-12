using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Teach
    {
        [Key, Column(Order = 0)]
        public string TeacherID { get; set; }

        [Key, Column(Order = 1)]
        public string CourseCode { get; set; }


        [ForeignKey("TeacherID")]
        public virtual User Teacher { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Course { get; set; }
    }
}