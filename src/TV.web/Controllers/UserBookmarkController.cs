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

            message = "Bookmark Success";
            
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult DeleteBookmark(int? postId)
        {
            var message = "";
            var currentUser = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault();
            var post = _ctx.Post.Find(postId);

            if (currentUser == null || post == null)
            {
                message = "Problem with UserName or Post";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            var bookmark = _ctx.UserBookmark.Where(m => m.Post.Id == post.Id).Where(m => m.User.UserId == currentUser.UserId).SingleOrDefault();



            _ctx.UserBookmark.Remove(bookmark);
            _ctx.SaveChanges();


            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your bookmark has been removed" });
        }

    }
}
