using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models
{
    public class UserBookmark
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public virtual UserProfile User { get; set; }

        [Required]
        public virtual PostModel Post { get; set; }

    }
}
