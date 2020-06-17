using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Lesson
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ChapterID { get; set; }
 
        [JsonIgnore]
        [ForeignKey("ChapterID")]
        public virtual Chapter Chapter { get; set; }


        public virtual ICollection<Material> Materials { get; set; }

    }
}