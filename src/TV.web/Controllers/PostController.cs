using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.ViewModels;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Web.Helpers;
using System.Runtime.Remoting.Contexts;

namespace TV.web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly TVContext _ctx;

        public IList<string> StreetList = new List<String>{"Iowa", "Burlington", "Govenor", "Dodge", "Washinton", "Jefferson", "Bloominton", "Glibert", "Luscas", "Johnson", "Benton", "Van Bruen South",
                "Prentiss", "Dubuque", "Clinton", "Market", "E. Davenport", "Linn", "Hotz", "Summit", "Muscatine", "Clark", "Church", "Fairchild", "Ronalds", "Brown", "College", "Center", "Reno", 
                "Pleasant" , "Union", "Mott", "Cedar", "Van Bruen North", "Maiden Ln", "Capitol", "Madison", "Lafayette", "Webster", "Page", "Walnut", "Kirkwood", "Mormen Trek", "Melrose"};

        public PostController(TVContext ctx)
        {
            _ctx = ctx;
        }

        //[SessionExpireFilter]
        public ActionResult Manage(bool? needStatusUpdate, string statusMessage)
        {
            var currentUser = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault();

            var outModel = new ManageViewModel();

            outModel.Bookmarks = _ctx.UserBookmark.Where(m => m.User.UserId == currentUser.UserId).ToList<UserBookmark>();

            if (needStatusUpdate == true)
            {
                outModel.needStatusMessage = true;
                outModel.statusMessage = statusMessage;

            }
            else
            {
                outModel.needStatusMessage = false;
                
            }
            return View(outModel);
        }


        
        [HttpPost]
        //[SessionExpireFilter]
        public JsonResult Rate(int? postId, float? value)
        { 
            var post = _ctx.Post.Find(postId);
            var message = "";
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                message = "There was a problem with the post Id";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            if (postId == null)
            {
                message = "There was a problem with the post Id";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            

            if (post == null)
            {
                message = "There was an error setting your rating";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            post.Rating = value;
            _ctx.SaveChanges();
            message = "Your rating has been saved";

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            
            var user = _ctx.UserProfiles.Where(u => u.UserName == (HttpContext.User.Identity.Name)).SingleOrDefault();
            var outModel = new CreatePostViewModel();
            var post = new PostModel
            {
                User = user,
                IsDeleted = false,
                IsCompleted = 0
                
            };
            outModel.StreetList = StreetList;
            //TODO sort array abc
            outModel.UserId = user.UserId;
            _ctx.Post.Add(post);
            _ctx.SaveChanges();
            outModel.Id = post.Id;

            return View(outModel);
        }

        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult CancelCreate(int? id)
        {
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;
            var post = _ctx.Post.Find(id);

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            if (post != null)
            {
                _ctx.Post.Remove(post);
                _ctx.SaveChanges();

            }
            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your Post has been canceled" });
        }

        [HttpPost]
        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostViewModel inModel)
        {
            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var post = _ctx.Post.Where(m => m.Id == inModel.Id).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>();

           
            if (!post.Rating.HasValue)
            {
                ModelState.AddModelError("", "Please provide a rating");
                ModelState.AddModelError("", "Any pictures Upload are already saved.");
                return View(inModel);
            }

            if (!ModelState.IsValid)
            {
                return View(inModel);
            }

            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                ModelState.AddModelError("", "Any pictures Upload are already saved.");
                return View(inModel);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
                ModelState.AddModelError("", "Any pictures Upload are already saved.");
                return View(inModel);
            }

            post.User = user;
            post.Title = inModel.Title;
            post.LandLord = inModel.LandLord;
            post.LeaseYear = inModel.LeaseYear;
            post.LLemail = inModel.LLemail;
            post.Post = inModel.Post;
            post.DatePosted = DateTime.Now.ToShortDateString();
            post.Rent = inModel.Rent;
            post.Deposit = inModel.Deposit;
            post.AmountKept = inModel.AmountKept;
            post.Street = inModel.Street;
            post.IsDeleted = false;
            post.AptNumber = inModel.AptNumber;
            post.BuildingNumber = inModel.BuildingNumber;
            post.IsCompleted = 1;
            post.City = inModel.City;

            var errors = _ctx.GetValidationErrors();

            _ctx.SaveChanges();

            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your Post has been successfully created" });

        }

        //[SessionExpireFilter]
        public ActionResult Edit(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var postId = post.Id;
            var images = _ctx.Image.Where(m => m.PostId == postId).ToList<ImageModel>();
            var commentz = _ctx.Comment.Where(m => m.PostId == postId).ToList<Comment>();
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            var outModel = new CreatePostViewModel
            {
                
                Title = post.Title,
                LandLord = post.LandLord,
                LeaseYear = post.LeaseYear,
                LLemail = post.LLemail,
                Post = post.Post,
                Rent = post.Rent,
                Deposit = post.Deposit,
                AmountKept = post.AmountKept,
                IsDeleted = post.IsDeleted,
                Id = post.Id,
                AptNumber = post.AptNumber,
                Images = images,
                StreetList = StreetList,
                IsEDitMode = true,
                BuildingNumber = post.BuildingNumber,
                Street = post.Street,
                Comments = commentz,
                Rating = post.Rating, 
                City = post.City,
                Zip = post.ZipCode,
                UserId = post.User.UserId
                
            };
            
            return View("Create", outModel);
        }

        [HttpPost]
        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreatePostViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();
            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>();

            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            post.User = user;
            post.Title = inModel.Title;
            post.LandLord = inModel.LandLord;
            post.LeaseYear = inModel.LeaseYear;
            post.LLemail = inModel.LLemail;
            post.Post = inModel.Post;
            post.DatePosted = DateTime.Now.ToShortDateString();
            post.Rent = inModel.Rent;
            post.Deposit = inModel.Deposit;
            post.AmountKept = inModel.AmountKept;
            post.Street = inModel.Street;
           
            post.IsDeleted = false;
            post.AptNumber = inModel.AptNumber;
            post.BuildingNumber = inModel.BuildingNumber;
            post.City = inModel.City;
            post.ZipCode = inModel.Zip;
            

             _ctx.SaveChanges();

             return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Any changes made have been saved" });

            //var outModel = new ViewPostViewModel
            //{
                
            //    Title = post.Title,
            //    LandLord = post.LandLord,
            //    LeaseYear = post.LeaseYear,
            //    LLemail = post.LLemail,
            //    Post = post.Post,
            //    Rent = post.Rent,
            //    Deposit = post.Deposit,
            //    AmountKept = post.AmountKept,
            //    IsDeleted = post.IsDeleted,
            //    Id = post.Id,
            //    AptNumber = post.AptNumber,
            //    Images = images,
            //    BuildingNumber = post.BuildingNumber,
            //    Street = post.Street
            //};

           
            //return View("EditPostSuccess", outModel);
        }

        public ActionResult Delete(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>();
            //var user = _ctx.UserProfiles.Find(post.User.UserId);
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            var outModel = new ViewPostViewModel
            {
                Title = post.Title,
                LandLord = post.LandLord,
                LeaseYear = post.LeaseYear,
                LLemail = post.LLemail,
                Post = post.Post,
                Rent = post.Rent,
                Deposit = post.Deposit,
                AmountKept = post.AmountKept,
                IsDeleted = post.IsDeleted,
                Id = post.Id,
                AptNumber = post.AptNumber,
                Images = images,
                BuildingNumber = post.BuildingNumber,
                Street = post.Street,
                UserName = post.User.UserName,
                City = post.City,
                ZipCode = post.ZipCode,
                Rating = post.Rating,
                IsDeleteMode = true
            };

            return View("DeleteConfirmation", outModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ViewPostViewModel inModel)
        {
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            if (post.User.UserName == inModel.UserName) {
                post.IsDeleted = true;
                 _ctx.SaveChanges();
                 return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your Post has been deleted" }); 
            }
            else
            {
                return View("Error", inModel);
            }
        }

        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public  ActionResult DeletePhoto(int? photoId)
        {
            var photo = _ctx.Image.Where(m => m.Id == photoId).SingleOrDefault();
            var post = _ctx.Post.Where(m => m.Id == photo.PostId).SingleOrDefault();
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            
            _ctx.Image.Remove(photo);
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = post.Id });
        }

        [ValidateAntiForgeryToken]
        //[SessionExpireFilter]
        public ActionResult DeleteComment(int? commentId)
        {
            var comment = _ctx.Comment.Where(m => m.Id == commentId).SingleOrDefault();

            var post = _ctx.Post.Where(m => m.Id == comment.PostId).SingleOrDefault();
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }


            _ctx.Comment.Remove(comment);
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = post.Id });
        }
    }
}
