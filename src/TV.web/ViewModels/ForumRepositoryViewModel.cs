using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class ForumRepositoryViewModel
    {

        public bool? DisplayMode { get; set; }

        public IList<Comment> Messages { get; set; }
    }
}
