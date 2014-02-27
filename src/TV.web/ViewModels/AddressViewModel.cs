using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class AddressViewModel
    {
        public PostModel SinglePost { get; set; }

        public int? ZipCode { get; set; }

        public string City { get; set; }

        public bool? IsZipSearch { get; set; }

        public bool? IsCitySearch { get; set; }

        public bool? IsSinglePost { get; set; }
    }
}