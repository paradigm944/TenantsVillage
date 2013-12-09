using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Column("ParentPostId")]
        public int? ParentPostId { get; set; }
       
        [Required]
        [Column("Author")]
        public string Author { get; set; }

        [Column("LandLord")]
        public string LandLord { get; set; }

        [Column("Recipient")]
        public  string Recipient { get; set; }

        [Required, MinLength(4)]
        [Column("Subject")]
        public string Subject { get; set; }

        [Required, StringLength(500)]
        [Column("Body")]
        public string Body { get; set; }

        [Required]
        [Column("EntryDate")]
        public DateTime EntryDate { get; set; }
    }
}
