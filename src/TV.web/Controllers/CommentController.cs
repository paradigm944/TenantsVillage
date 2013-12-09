using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TV.web.Models;
using TV.web.ViewModels;
using WebMatrix.WebData;

namespace MvcForums.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private IForumRepository _repository;
        private readonly TVContext _ctx;
       
        public CommentController(IForumRepository repository, TVContext ctx)
        {
            _repository = repository;
            _ctx = ctx;
        }

        public ActionResult Index()
        {
            var outModel = new ForumRepositoryViewModel
            {
                Messages = _repository.SelectThreads()
            };

            return View("Index", outModel);
        }

        [HttpGet]
        public ActionResult ViewComment(int threadId)
        {
            var thread = _ctx.Comment.Where(m => m.Id == threadId).SingleOrDefault();
            var cModel = new CommentViewModel
            {
                Author = thread.Author,
                Body = thread.Body,
                EntryDate = thread.EntryDate,
                Subject = thread.Subject
            };

            var outModel = new ViewPostViewModel
            {
                ComViewModel = cModel
            };
                
            return PartialView("_ViewComment", outModel);
        }

        [HttpPost]
        public ActionResult CreateComment(ViewPostViewModel inModel)
        {

            var post = _ctx.Post.Where(m => m.Id == inModel.Id).SingleOrDefault();
            var images = _ctx.Image.Where(i => i.Post.Id == post.Id).AsEnumerable();
            var user = _ctx.UserProfiles.Where(u => u.UserId == post.User.UserId).SingleOrDefault();
            var recipient = post.User;
            var recipientEmail = recipient.Email;
            var comments = _ctx.Comment.Where(c => c.PostId == post.Id).ToList<Comment>();

            //TODO
            //if (!ModelState.IsValid)
            //{
            //    return View(inModel);
            //}


            var comment = new Comment(); 
            

            comment.Recipient = recipient.UserName;
            comment.Author = HttpContext.User.Identity.Name;
            comment.Subject = inModel.Subject;
            comment.Body = inModel.Body;
            comment.EntryDate = DateTime.Now;
            comment.LandLord = post.LandLord;
            comment.PostId = post.Id;


            _repository.AddComment(comment);

            try
            {
                var bemail = new MailMessage(recipientEmail, user.Email, "Someone commented on your Tenant's Village post", inModel.Body);
                var smtpServer = new SmtpClient();
                smtpServer.Send(bemail);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "There was an error sending your message");
                return View("Error");
            }

            var outModel = new ViewPostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                LandLord = post.LandLord,
                LLemail = post.LLemail,
                Post = post.Post,
                Rent = post.Rent,
                Intersection = post.Intersection,
                Deposit = post.Deposit,
                AmtKept = post.AmountKept,
                LeaseYear = post.LeaseYear,
                Images = images,
                User = user,
                Comments = comments
                
            };

            return RedirectToAction("ViewPost", "Search", outModel);
        }

        

        

    }
}