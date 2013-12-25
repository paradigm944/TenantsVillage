using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StructureMap;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class CreatePostViewModel 
    {
        public int? UserId { get; set; }

        public int? Id { get; set; }

        public bool IsDeleted { get; set; }

        public bool Confirmed { get; set; }

        public CommentViewModel ComViewModel { get; set; }

        public double? Rating { get; set; }

        [Required]
        [DisplayName("Feedback")]
        public string Post { get; set; }

        [DisplayName("Building/House Number")]
        [Range(0, 10000)]
        public int? BuildingNumber { get; set; }

        [DisplayName("Apartment #/letter")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string AptNumber { get; set; }

        [DisplayName("Street")]
        public IList<String> StreetList { get; set; }

        [DisplayName("Zip")]
        [Range(52200, 52250)]
        public int? Zip { get; set; }

        [Required]
        [DisplayName("LandLord/Mgmt Company")]
        public string LandLord { get; set; }

        [DisplayName("LandLord/Mgmt Email")]
        [EmailAddress]
        public string LLemail { get; set; }

        [DisplayName("Lease ended in Year:")]
        [Range(2000, 2013, ErrorMessage="The year must be between 2000 and 2013")]
        public int? LeaseYear {get; set;}

        [DisplayName("Rent")]
        [Range(0, 5000, ErrorMessage = "The amount must be from 0 to $5000")]
        public int? Rent { get; set; }

        [DisplayName("Deposit Amount")]
        [Range(0, 5000, ErrorMessage = "The amount must be from 0 to $5000")]
        public int? Deposit { get; set; }

        [DisplayName("Amount of Deposit Kept")]
        [Range(0, 5000, ErrorMessage="The amount must be from 0 to $5000")]
        public int? AmountKept { get; set; }

        [DisplayName("Street")]
        public string Street{ get; set; }

        [Required]
        public string Title { get; set; }

        //used for editing

        public bool? IsEDitMode { get; set; }

        [DisplayName("Comments")]
        public IList<Comment> Comments { get; set; }

        [DisplayName("Images")]
        public IList<ImageModel> Images { get; set; }

    }
}
