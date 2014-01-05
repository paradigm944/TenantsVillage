using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.Controllers
{
    public class UserBookmarkController : Controller
    {
        private readonly TVContext _ctx;
       
        public UserBookmarkController(TVContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public JsonResult Bookmark(int? postId)
        {
            var message = "";
            var currentUser = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault();
            var post = _ctx.Post.Find(postId);

            if (currentUser == null || post == null)
            {
                message = "Problem with UserName or Post";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            var newBookmark = new UserBookmark
            {
                Post = post,
                User = currentUser
            };

            _ctx.UserBookmark.Add(newBookmark);
            _ctx.SaveChanges();

            message = "Bokkmark Success";
            
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}
