﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class Material
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int LessonID { get; set; }

        [ForeignKey("LessonID")]
        public virtual Lesson Lesson { get; set; }
    }
}