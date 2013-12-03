using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class ViewPostViewModel 
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public List<string> Pics { get; set; }

        [DisplayName("Post")]
        public string Post { get; set; }

        public int? Id { get; set; }

        public bool IsDeleted { get; set; }

        [DisplayName("LandLord Email")]
        public string LLemail { get; set; }

        [DisplayName("LandLord")]
        public string LandLord { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("Building Number")]
        public int? BuildingNumber { get; set; }

        [DisplayName("Apt Number")]
        public string AptNumber { get; set; }
       
        public int? LeaseYear { get; set; }

        [DisplayName("Rent")]
        public int? Rent { get; set; }

        [DisplayName("Deposit")]
        public int? Deposit { get; set; }

        [DisplayName("Amount Kept")]
        public int? AmountKept { get; set; }

        public bool? Confirmed { get; set; }

        [DisplayName("Amount of Deposit with-held")]
        public int? AmtKept { get; set; }

        [DisplayName("Nearest Intersection")]
        public string Intersection { get; set; }

        [DisplayName("Message")]
        public string message { get; set; }

        public string currentUser { get; set; }

        [DisplayName("Attached Images")]
        public IEnumerable<ImageModel> Images { get; set; }

        [ForeignKey("customer_ref")]
        [DisplayName("Recipient")]
        public virtual UserProfile User { get; set; }

        public IEnumerable<Message> Comments { get; set; }

        /// <summary>
        /// everything below here is used for comenting on posts
        /// </summary>


        public int? ParentPostId { get; set; }

        public string Author { get; set; }

        public string Pic_0 { get; set; }

        public string Pic_1 { get; set; }

        public string Pic_2 { get; set; }

        public string Pic_3 { get; set; }

        public string Pic_4 { get; set; }

        public string Pic_5 { get; set; }

        public string Pic_6 { get; set; }

        public string Pic_7 { get; set; }

        [DisplayName("Title")]
        [Required, MinLength(4)]
        public string Subject { get; set; }

        [DisplayName("Body")]
        [Required, StringLength(500)]
        public string Body { get; set; }

        public DateTime EntryDate { get; set; }

        public IList<Message> Messages { get; set; }
        
        


    }
}
