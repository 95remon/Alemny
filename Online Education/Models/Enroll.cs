using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Enroll
    {

        [Key , Column(Order =0)]
        public string StudentID { get; set; }

        [Key, Column(Order = 1)]
        public string CourseCode { get; set; }

        public DateTime EnrollDate { get; set; }

        [ForeignKey("StudentID")]
        public virtual User Student { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Course { get; set; }
    }
}