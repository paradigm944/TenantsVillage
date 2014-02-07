using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models
{
    public class ImageModel 
    {
        
        [Column("PkId")]
        public int? Id { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Column("IsThumbnail")]
        public bool IsThumbnail { get; set; }

        [Column("Post")]
        public virtual PostModel Post { get; set; }
    }
}
