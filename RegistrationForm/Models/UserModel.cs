using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email is Not Valid")]
        public string Email { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }
}