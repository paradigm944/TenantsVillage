﻿using System;
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
                Street = post.Street

            };
            return View("CreatePostSuccess", outModel);
        }

        public ActionResult Edit(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var postId = post.Id;
            var images = _ctx.Image.Where(m => m.PostId == postId).ToList<ImageModel>();

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
                Street = post.Street
                
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
                Street = post.Street
            };

            _ctx.SaveChanges();
            return View("EditPostSuccess", outModel);
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
                UserName = post.User.UserName
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
                return View("DeleteSuccess");
            }
            else
            {
                return View("Error", inModel);
            }
        }

        public ActionResult UnDelete(int? id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            post.IsDeleted = false;
            _ctx.SaveChanges();

            
            return View("UserPosts");
        }

       
        public  ActionResult DeletePhoto(int? photoId)
        {
            var photo = _ctx.Image.Where(m => m.Id == photoId).SingleOrDefault();

            var postId = _ctx.Post.Where(m => m.Id == photo.PostId).SingleOrDefault().Id;

            
            _ctx.Image.Remove(photo);
            _ctx.SaveChanges();

            return RedirectToAction("Edit", "Post", new { id = postId });
        }
    }
}
