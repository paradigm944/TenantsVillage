using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class ListOfPicsViewModel 
    {
        public IEnumerable<ListOfPicsViewModel> photos { get; set; }


    }
}
