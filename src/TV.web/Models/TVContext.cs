using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TV.web.Models
{
    public class TVContext : DbContext
    {
        public TVContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ImageModel> Image { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<PostModel> Post { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}