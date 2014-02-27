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
        public CommentViewModel ComViewModel { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public List<string> Pics { get; set; }

        public double? Rating { get; set; }

        public bool? IsBookmarked { get; set; }

        public bool? IsDeleteMode { get; set; }

        [DisplayName("Post")]
        public string Post { get; set; }

        public int? Id { get; set; }

        [DisplayName("Zip Code")]
        public int? ZipCode { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

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

        [DisplayName("Amt Kept")]
        public int? AmountKept { get; set; }

        public bool? Confirmed { get; set; }

        [DisplayName("Amount of Deposit with-held")]
        public int? AmtKept { get; set; }

        

        [DisplayName("Message")]
        public string message { get; set; }

        public string currentUser { get; set; }

        [DisplayName("Attached Images")]
        public IEnumerable<ImageModel> Images { get; set; }

        
        public UserProfile User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string PostAddress { get; set; }

        public string Author { get; set; }

        public ImageModel Pic_0 { get; set; }

        public ImageModel Pic_1 { get; set; }

        public ImageModel Pic_2 { get; set; }

        public ImageModel Pic_3 { get; set; }

        public ImageModel Pic_4 { get; set; }

        public ImageModel Pic_5 { get; set; }

        public ImageModel Pic_6 { get; set; }

        public ImageModel Pic_7 { get; set; }

        public ImageModel Pic_8 { get; set; }

        public ImageModel Pic_9 { get; set; }

        [DisplayName("Title")]
        [Required, MinLength(4)]
        public string Subject { get; set; }

        [DisplayName("Body")]
        [Required, StringLength(500)]
        public string Body { get; set; }

        public DateTime EntryDate { get; set; }

        public IList<Comment> Messages { get; set; }
        
        


    }
}
