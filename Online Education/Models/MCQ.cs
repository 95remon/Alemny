using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class MCQ 
    {

        [Key]
        public int QuestionID { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }

        public virtual ICollection<Choices> Choices { get; set; }

    }

    /*
     * Choices
     * a)                        false
     * b)                        true
     * c)                        false
     */

}