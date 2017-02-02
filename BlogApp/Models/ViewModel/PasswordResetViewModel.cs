using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ViewModel
{
    public class PasswordResetViewModel
    {

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Minimum length is 8 characters")]
        //[RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Retype Password")]
        [MinLength(8, ErrorMessage = "Minimum length is 8 characters")]
        [Compare(otherProperty: "Password", ErrorMessage = "Passwords Mismatch")]
        //[RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        public string ConfirmPassword { get; set; }
    }
}