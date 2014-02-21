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

        [Required(ErrorMessage = "Please provide some description")]
        [DisplayName("Feedback")]
        public string Post { get; set; }

        [DisplayName("Building/House Number")]
        public int? BuildingNumber { get; set; }

        [DisplayName("Apt #/letter")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string AptNumber { get; set; }

        [DisplayName("Street Suffix")]
        public string StreetSuffix { get; set; }
        
        public IList<String> StreetList { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please provide a City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please provide a Zip")]
        public int? Zip { get; set; }

        [Required(ErrorMessage = "Please provide a Landlord/Mgmt Company")]
        [DisplayName("Landlord/Mgmt Company")]
        public string LandLord { get; set; }

        [DisplayName("LandLord/Mgmt Email")]
        [EmailAddress]
        public string LLemail { get; set; }

        [DisplayName("Lease end year")]
        [Range(1980, 2020, ErrorMessage="The year must be between 1980 and 2020")]
        public int? LeaseYear {get; set;}

        [DisplayName("Monthly Rent")]
        [Range(0, 5000, ErrorMessage = "The amount must be from 0 to $,5000")]
        public int? Rent { get; set; }

        [DisplayName("Deposit Amount")]
        [Range(0, 5000, ErrorMessage = "The amount must be from 0 to $5,000")]
        public int? Deposit { get; set; }

        [DisplayName("Amount of deposit withheld")]
        [Range(0, 10000, ErrorMessage="The amount must be from 0 to $10,000")]
        public int? AmountKept { get; set; }

        [DisplayName("Street")]
        [Required(ErrorMessage = "Please provide a Street")]
        public string Street{ get; set; }

        [Required]
        [MinLength(4, ErrorMessage="The title must be at least 4 characters long")]
        public string Title { get; set; }

        //used for editing

        public bool? IsEDitMode { get; set; }

        [DisplayName("Comments")]
        public IList<Comment> Comments { get; set; }

        [DisplayName("Images")]
        public IList<ImageModel> Images { get; set; }

    }
}
