using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Education.Models
{
    public enum Gender {
        Male ,
        Female
    };
    public enum UserType
    {
        Instructor,
        Student
    };
    public enum Level
    {
        First,
        Second,
        Third,
        Forth,
    };
    public class Account
    {
        [Required]
        public UserType Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public Level Level { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

    }
}