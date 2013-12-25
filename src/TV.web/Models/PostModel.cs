using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models
{
    public class PostModel 
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Required]
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Column("ImageQuantity")]
        public int? ImageQuantity { get; set; }

        
        [Column("Post")]
        public string Post { get; set; }

        [Column("IsCompleted")]
        public int IsCompleted { get; set; }

        [StringLength(100, MinimumLength=4, ErrorMessage="The title must be at least 4 characters")]
        [Column("Title")]
        public string Title { get; set; }

        
        [Column("LandLord/Management Company")]
        public string LandLord { get; set; }

        [EmailAddress]
        [Column("LandLord/Management Company Email")]
        public string LLemail { get; set; }

        
        [Column("BuildingNumber")]
        public int? BuildingNumber { get; set; }

        [Column("AptNumber")]
        public string AptNumber { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        
        [Range(2000, 2013)]
        [Column("LeaseYear")]
        public int? LeaseYear { get; set; }

        
        [Column("DatePosted")]
        public string DatePosted { get; set; }

        [Column("Rent")]
        [Range(0,5000, ErrorMessage="The rent must be $0 thru $5000")]
        public int? Rent { get; set; }

        [Column("Deposit")]
        [Range(0, 5000, ErrorMessage = "The deposit must be $0 thru $5000")]
        public int? Deposit { get; set; }

        [Column("AmountKept")]
        public int? AmountKept { get; set; }

        [Column("NearestIntersection")]
        public string Intersection { get; set; }

        [Column("Rating")]
        public double? Rating { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
