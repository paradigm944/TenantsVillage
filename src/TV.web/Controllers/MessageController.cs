using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.ViewModels;

namespace TV.web.Controllers
{
    public class MessageController : Controller
    {

        private readonly TVContext _ctx;

        public MessageController(TVContext ctx)
        {
            _ctx = ctx;
        }


        //public ActionResult ViewPostMessage(int id)
        //{
        //    var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
        //    var recipient = _ctx.UserProfiles.Where(u => u.UserId == post.User.UserId).SingleOrDefault();
        //    var currentUser = System.Web.HttpContext.Current.User.Identity.Name;

        //    var outModel = new ViewPostMessageViewModel()
        //    {
        //        recipient = recipient,
        //        currentUser = currentUser,
        //        postId = post.Id
        //    };

        //    return View(outModel);
        //}



        public ActionResult SendMessage(ViewPostViewModel inModel)
        {
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();
            var recipient = _ctx.UserProfiles.Where(u => u.UserId == post.User.UserId).SingleOrDefault();
            var currentUser = System.Web.HttpContext.Current.User.Identity.Name;
            var currentUserEmail = _ctx.UserProfiles.Where(name => name.UserName == currentUser).SingleOrDefault().Email;

            try
            {

                var bemail = new MailMessage(currentUserEmail, recipient.Email, "A message from " + currentUser,
                    inModel.message.ToString());
                var smtpServer = new SmtpClient();
                smtpServer.Send(bemail);

                return View("MessageSuccess");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "There was an error sending your message");
                return View(inModel);
            }



        }

    }
}
