using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class DisassociateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        public int? UserId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        

    }
}
