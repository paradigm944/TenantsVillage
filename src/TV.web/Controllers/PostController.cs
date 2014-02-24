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
        public List<string> streetList = new List<string>
        {
            "-", "Pl", "Rd", "St", "Ave", "Blvd", "Cr", "Ct", "Way", "Ln",
            "Dr"
        };

        private readonly TVContext _ctx;

        public PostController(TVContext ctx)
        {
            _ctx = ctx;
        }

        [AllowAnonymous]
        public ActionResult NearMe()
        {
            var outModel = new AddressViewModel
            {
                IsZipSearch = false
            };

         
            return View(outModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult NearMe(AddressViewModel inModel)
        {
            var outModel = new AddressViewModel{
                ZipCode = inModel.ZipCode,
                IsZipSearch = true
            };


            return View(outModel);
        }

        [AllowAnonymous]
        public JsonResult GetAddresses(int zipCode)
        {
            var postAddresses = new List<string>();
            var posts = _ctx.Post.Where(m => m.ZipCode == zipCode).ToList<PostModel>();

            if (posts.Count > 0)
            {
                for (int i = 0; i < posts.Count; i++)
                {
                    var address = posts[i].BuildingNumber + " " + posts[i].Street + ",  " + posts[i].ZipCode;
                    postAddresses.Add(address);
                }
            }

            return Json(postAddresses, JsonRequestBehavior.AllowGet);
        } 

        public ActionResult UploadPhotos()
        {
            return View("UploadTest");
        }

        //[SessionExpireFilter]
        public ActionResult Manage(bool? needStatusUpdate, int? statusMessage)
        {
            var StatusMessages = new List<string>();
            StatusMessages.Add("");
            StatusMessages.Add("Your delete has been canceled");
            StatusMessages.Add("Any changes made have been saved");
            StatusMessages.Add("Your post has been canceled");
            StatusMessages.Add("Your Post has been successfully created");
            StatusMessages.Add("Your Post has been deleted");
            StatusMessages.Add("Your bookmark has been removed");

            

            var currentUser = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault();

            var outModel = new ManageViewModel();

            outModel.Bookmarks = _ctx.UserBookmark.Where(m => m.User.UserId == currentUser.UserId).ToList<UserBookmark>();

            if (needStatusUpdate == true && statusMessage.HasValue )
            {
                outModel.needStatusMessage = true;
                outModel.statusMessage = StatusMessages[statusMessage.GetValueOrDefault()];

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
            
            outModel.UserId = user.UserId;
            outModel.StreetList = streetList;
            _ctx.Post.Add(post);
            _ctx.SaveChanges();
            outModel.Id = post.Id;

            return View(outModel);
        }

        //[SessionExpireFilter]
        //[ValidateAntiForgeryToken]
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
                post.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else
            {
                return View("Error");
            }

            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = 3 });
        }

        [HttpPost]
        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostViewModel inModel, IEnumerable<HttpPostedFileBase> files)
        {
            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var post = _ctx.Post.Where(m => m.Id == inModel.Id).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.Post.Id == post.Id).ToList<ImageModel>();

            //Check for use of back button after cancel was pressed
            if (post.IsDeleted)
            {
                ModelState.AddModelError("", "This Post has previously been deleted");
            }
           
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
            post.StreetSuffix = inModel.StreetSuffix;
            post.IsCompleted = 1;
            post.City = inModel.City;
            post.ZipCode = inModel.Zip;

            var errors = _ctx.GetValidationErrors();

            _ctx.SaveChanges();

            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = 4 });

        }

        //[SessionExpireFilter]
        public ActionResult Edit(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var postId = post.Id;
            var images = _ctx.Image.Where(m => m.Post.Id == post.Id && m.IsThumbnail == false && m.IsDeleted == false).ToList<ImageModel>();
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
                IsEDitMode = true,
                BuildingNumber = post.BuildingNumber,
                StreetSuffix = post.StreetSuffix,
                StreetList = streetList,
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
            
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();
            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.Post.Id == post.Id  && m.IsThumbnail == false).ToList<ImageModel>();

            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
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
                return View("Create", inModel);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
                ModelState.AddModelError("", "Any pictures Upload are already saved.");
                return View("Create", inModel);
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
            post.StreetSuffix = inModel.StreetSuffix;
            post.IsDeleted = false;
            post.AptNumber = inModel.AptNumber;
            post.BuildingNumber = inModel.BuildingNumber;
            post.City = inModel.City;
            post.ZipCode = inModel.Zip;
            

             _ctx.SaveChanges();

             return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = 2 });
     
        }

        public ActionResult Delete(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.Post.Id == post.Id).ToList<ImageModel>();
            //var user = _ctx.UserProfiles.Find(post.User.UserId);
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }

            if (post.IsDeleted == true)
            {
                ModelState.AddModelError("", "This post has already been deleted");
                return View();
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
                IsDeleteMode = true,
               
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
                 return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = 5 }); 
            }
            else
            {
                return View("Error", inModel);
            }
        }

        //[SessionExpireFilter]
        //[ValidateAntiForgeryToken]
        public  ActionResult DeletePhoto(int? photoId)
        {
            var photo = _ctx.Image.Where(m => m.Id == photoId).SingleOrDefault();
            var thumbnail = _ctx.Image.Where(m => m.Post.Id == photo.Post.Id && m.IsThumbnail == true).ToList<ImageModel>();
            var post = _ctx.Post.Where(m => m.Id == photo.Post.Id).SingleOrDefault();
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            if (post.User.UserId != currentUserId)
            {
                return View("Error");
            }
            
            photo.IsDeleted = true;

            for (int i = 0; i < thumbnail.Count; i++)
            {
                thumbnail[i].IsDeleted = true;
            }
            
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = post.Id });
        }

        //[ValidateAntiForgeryToken]
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

        [AllowAnonymous]
        public ActionResult Sample()
        {
            var post = "These people were ok.  Maintainence was done pretty quickly. Snow removal was lacking at times, " +
                        "but overall the parking was clear.  Parking was expensive, $500 a year, and there was no visitor parking. " +
                       "These people definitey gouge tenants on parking.  At the end of the lease, only a portion of my deposit was returned. "+
                       "Money was kept for carpet cleaning and minor repairs.  I am not too happy about the amount of my deposit withheld, but I did not take "+
                       "pictures so it will be difficult to counter their claims.  I would recommend this unit and company if the person renting is prepared "+
                       "to takes pictures and stand their ground come deposit time.";

            var images = _ctx.Image.Where(m => m.Post.Id == 8).ToList<ImageModel>();

            var comments = _ctx.Comment.Where(m => m.PostId == 0).ToList<Comment>();
            
                                

            var outModel = new ViewPostViewModel
            {
                Title = "Sample Post",
                LandLord = "Sample Management",
                LeaseYear = 2012,
                LLemail = "sample@mail.com",
                Post = post,
                Rent = 650,
                Deposit = 650,
                AmountKept = 400,
                IsDeleted = false,
                Id = 0,
                AptNumber = "1",
                Images = images,
                BuildingNumber = 419,
                Street = "Poplar Rd",
                UserName = "samplePostUser",
                City = "Iowa City",
                ZipCode = 52246,
                Rating = 6.5,
                IsDeleteMode = false,
                Comments = comments

            };

            return View(outModel);
        }
    }
}
