using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.ViewModels
{
    public class ConfirmPostViewModel 
    {
        public int? PostId { get; set; }

        [DisplayName("Feedback")]
        public string Post { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        
        [DisplayName("LandLord/Management Company")]
        public string LandLord { get; set; }

        [DisplayName("LandLord/Management Company Email")]
        public string LLemail { get; set; }

        [DisplayName("Lease ended in Year:")]
        public int LeaseYear { get; set; }

        [DisplayName("Rent")]
        public int? Rent { get; set; }

        [DisplayName("Deposit Amount")]
        public int? Deposit { get; set; }

        [DisplayName("Amount of Deposit Kept")]
        public int? AmountKept { get; set; }

        [DisplayName("Nearest Intersection")]
        public string Intersection { get; set; }
    }
}
