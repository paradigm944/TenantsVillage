using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class VerifyEmailCodeViewModel 
    {
        [Required]
        public string Password { get; set; }

        public int? UserId { get; set; }

        public string Token { get; set; }

        [Required]
        public string UserName { get; set; }

    }
}
