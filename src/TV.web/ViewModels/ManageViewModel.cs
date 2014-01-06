using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class ManageViewModel
    {
        public bool? needStatusMessage { get; set; }

        public string statusMessage { get; set; }

        public List<UserBookmark> Bookmarks { get; set; }
    }
}