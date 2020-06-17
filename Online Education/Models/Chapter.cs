using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Chapter
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CourseCode { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Course { get; set; }

        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}