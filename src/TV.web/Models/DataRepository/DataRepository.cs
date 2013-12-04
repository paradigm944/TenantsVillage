using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models.DataRepository
{
    public class DataRepository

{
        public static IList<PostModel> postData = new List<PostModel>();

      
        public static IList<PostModel> GetPosts()
        {
            var ctx = ObjectFactory.GetInstance<TVContext>();

            postData = ctx.Post.Select(p => p).Where(p => p.IsDeleted == false).Where(m => m.IsCompleted == 1).ToList<PostModel>();
            
            
            return postData;
        }

        public static IList<PostModel> GetUserPosts()
        {
            var ctx = ObjectFactory.GetInstance<TVContext>();

            postData = ctx.Post.Select(p => p).Where(p => p.User.UserName == HttpContext.Current.User.Identity.Name && p.IsDeleted == false).ToList<PostModel>();
            return postData;
        }  
    }
}
    

