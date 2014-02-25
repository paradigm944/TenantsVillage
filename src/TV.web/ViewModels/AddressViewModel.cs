using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TV.web.ViewModels
{
    public class AddressViewModel
    {
        public int? ZipCode { get; set; }

        public string City { get; set; }

        public bool? IsZipSearch { get; set; }

        public bool? IsCitySearch { get; set; }
    }
}