using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.ViewModels;

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
                //outModel.statusMessage = statusMessage;
            }
            return View(outModel);
        }


        
        [HttpPost]
        public JsonResult Rate(int? postId, float? value)
        { 
            var message = "";

            if (postId == null)
            {
                message = "There was a problem with the post Id";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            var post = _ctx.Post.Find(postId);

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

        public ActionResult CancelCreate(int? id)
        {
            var currentUserId = _ctx.UserProfiles.Where(m => m.UserName == HttpContext.User.Identity.Name).SingleOrDefault().UserId;

            var post = _ctx.Post.Find(id);

            if (post != null)
            {
                _ctx.Post.Remove(post);
                _ctx.SaveChanges();

            }
            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your Post has been canceled" });
        }

        [HttpPost]
        public ActionResult Create(CreatePostViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }

            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var post = _ctx.Post.Where(m => m.Id == inModel.Id).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>();

            
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
            
            _ctx.SaveChanges();

            return RedirectToAction("Manage", "Post", new { needStatusUpdate = true, statusMessage = "Your Post has been successfully created" });

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
            //return View("CreatePostSuccess", outModel);
        }

        public ActionResult Edit(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var postId = post.Id;
            var images = _ctx.Image.Where(m => m.PostId == postId).ToList<ImageModel>();
            var commentz = _ctx.Comment.Where(m => m.PostId == postId).ToList<Comment>();

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
                Zip = post.ZipCode
                
            };
            
            return View("Create", outModel);
        }

        [HttpPost]
        public ActionResult Edit(CreatePostViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();
            var user = _ctx.UserProfiles.Where(u => u.UserId == inModel.UserId).SingleOrDefault();
            var images = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>();

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
        public ActionResult Delete(ViewPostViewModel inModel)
        {
            var post = _ctx.Post.Where(p => p.Id == inModel.Id).SingleOrDefault();

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

       
        public  ActionResult DeletePhoto(int? photoId)
        {
            var photo = _ctx.Image.Where(m => m.Id == photoId).SingleOrDefault();

            var postId = _ctx.Post.Where(m => m.Id == photo.PostId).SingleOrDefault().Id;

            
            _ctx.Image.Remove(photo);
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = postId });
        }

        public ActionResult DeleteComment(int? commentId)
        {
            var comment = _ctx.Comment.Where(m => m.Id == commentId).SingleOrDefault();

            var postId = _ctx.Post.Where(m => m.Id == comment.PostId).SingleOrDefault().Id;


            _ctx.Comment.Remove(comment);
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = postId });
        }
    }
}
