using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public class User : IdentityUser
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }  
        public string Level { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

    }
}