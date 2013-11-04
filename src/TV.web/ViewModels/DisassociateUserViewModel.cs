using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class DisassociateUserViewModel
    {
        public string UserName { get; set; }

        public int? UserId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        

    }
}
