using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TV.web.ViewModels
{
    public class AddressViewModel
    {
        public string ZipCode { get; set; }

        public bool? IsZipSearch { get; set; }
    }
}