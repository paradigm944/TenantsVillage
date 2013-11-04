using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace TV.web.ViewModels
{
    public class ResetPasswordViewModel 
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string ResetToken { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Password")]
        public string Password { get; set; }

        
        [System.ComponentModel.DataAnnotations.Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
