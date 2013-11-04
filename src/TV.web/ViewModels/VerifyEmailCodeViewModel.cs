using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class VerifyEmailCodeViewModel 
    {
        public bool IsPasswordChange { get; set; }

        public string NewPassword { get; set; }

        public int? UserId { get; set; }

        public string Code { get; set; }

        public string UserName { get; set; }

    }
}
