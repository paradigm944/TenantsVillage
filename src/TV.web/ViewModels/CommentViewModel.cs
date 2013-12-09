using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.ViewModels
{
    public class CommentViewModel 
    {
        
        public int? ParentThreadId { get; set; }
        
        public string Author { get; set; }
        
        [DisplayName("Subject")]
        [Required, MinLength(4)]
        public string Subject { get; set; }

        [DisplayName("Body")]
        [Required, StringLength(500)]
        public string Body { get; set; }

        public bool? DisplayMode { get; set; }

        [DisplayName("Recipient")]
        public string Recipient { get; set; }

        public bool IsThread { get; set; }

        public DateTime EntryDate { get; set; }

        public IList<Comment> Messages { get; set; }

    }
}
