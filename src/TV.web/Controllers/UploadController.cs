using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.Other;
using TV.web.ViewModels;
using TV.web.Controllers;


namespace non_profit.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private readonly TVContext _ctx;

        public UploadController(TVContext ctx)
        {
            _ctx = ctx;
        }

//        [AjaxOnly]

        public JsonResult JSUpload(int postId)
        {
            bool success = false;

            var image = WebImage.GetImageFromRequest();
            var imgFormat = image.ImageFormat.ToString();
            var post = _ctx.Post.Where(p => p.Id == postId).SingleOrDefault();
            var imgQuantity = _ctx.Image.Where(m => m.PostId == post.Id).ToList<ImageModel>().Count;

            if (imgFormat == "jpeg" || imgFormat == "png" )
            {
                if (imgQuantity >= 4)
                {
                    return Json(new { success, testforurl = MakeThumbnail(image, post.Id, true) });
                }

                if (image.Width > 250)
                {
                    image.Resize(250, ((250 * image.Height) / image.Width));
                }

                var filename = Path.GetFileName(image.FileName);
                image.Save(Path.Combine("~/Images", filename));

                var postImage = new ImageModel
                {
                    ImageUrl = ("/Images/" + filename),
                    IsDeleted = 1,
                    PostId = post.Id

                };

                _ctx.Image.Add(postImage);
                _ctx.SaveChanges();

                success = true;
                return Json(new { success, testforurl = MakeThumbnail(image, post.Id, false) });
            }
            else
            {
                return Json(new { success, testforurl = MakeThumbnail(image, post.Id, true) });
            }
        }


        public ActionResult PicUpload(int postId)
        {
            var outModel = new PicUploadViewModel { postId = postId };
            return View(outModel);
        }


        public string MakeThumbnail(WebImage image, int? postId, bool reachedPicLimit)
        {
            image.Resize(110, 110, true, true);

            var filename = Path.GetFileName(image.FileName);
            image.Save(Path.Combine("~/Thumbnails", filename));

            var postImage = new ImageModel
            {
                ImageUrl = ("/Thumbnails/" + filename),
                IsDeleted = 1,
                PostId = null

            };

            if (reachedPicLimit)
            {
                postImage.ImageUrl = "You have reached your picture limit of 4. ";
            }

            _ctx.Image.Add(postImage);
            _ctx.SaveChanges();

            return postImage.ImageUrl;

        }
        
        //public ActionResult Upload(int? id)
        //{
        //    var post = _ctx.Post.Where(m => m.Id == id).SingleOrDefault();

        //    var outModel = new UploadPicViewModel
        //    {
        //        Title = post.Title,
        //        LandLord = post.LandLord,
        //        LLemail = post.LLemail,
        //        LeaseYear = post.LeaseYear,
        //        Rent = post.Rent,
        //        Deposit = post.Deposit,
        //        AmountKept = post.AmountKept,
        //        Post = post.Post,
        //        PostId = id
        //    };

        //    return View("upload", outModel);
        //}


        //[HttpPost]
        //public ActionResult Upload(UploadPicViewModel inModel)
        //{
            
        //    var image = WebImage.GetImageFromRequest();

        //    var post = _ctx.Post.Where(p => p.Id == inModel.PostId).SingleOrDefault();
            

        //    if (image.Width > 500)
        //    {
        //        image.Resize(500, ((500 * image.Height) / image.Width));
        //    }
        //    var filename = Path.GetFileName(image.FileName);
        //    image.Save(Path.Combine("~/Images", filename));
                
        //    var postImage = new ImageModel
        //        {
        //        ImageUrl = ("/Images/"+ filename),
        //        PostId = post.Id
                    
        //    };
                
        //    _ctx.Image.Add(postImage);
        //    _ctx.SaveChanges();
                
        //    //outModel.Images.ToList<string>().Add(postImage.ImageUrl);
        //    filename = Path.Combine("~/Images", filename);  
        //    inModel.ImageUrl = Url.Content(filename);
        //    var outModel = new UploadPicViewModel
        //    {
        //        Title = inModel.Title,
        //        Rent = inModel.Rent,
        //        Post = inModel.Post,
        //        LLemail = inModel.LLemail,
        //        LandLord = inModel.LandLord,
        //        Deposit = inModel.Deposit,
        //        AmountKept = inModel.AmountKept,
        //        PostId = post.Id,
        //        AlreadyUploaded = true
        //    };
        //    //outModel.Urls.Add(filename);

        //    post.Title = inModel.Title;
        //    post.LandLord = inModel.LandLord;
        //    post.LLemail = inModel.LLemail;
        //    post.LeaseYear = inModel.LeaseYear;
        //    post.Rent = inModel.Rent;
        //    post.Deposit = inModel.Deposit;
        //    post.AmountKept = inModel.AmountKept;
        //    post.Post = inModel.Post;
       
        //    var editModel = new EditorInputModel
        //        {
        //            Profile = inModel,
        //            Width = image.Width,
        //            Height = image.Height,
        //            Top = image.Height * 0.1,
        //            Left = image.Width * 0.9,
        //            Right = image.Width * 0.9,
        //            Bottom = image.Height * 0.9
        //        };
        //    _ctx.SaveChanges();
        //    return View("Confirm", outModel);
               
        // }

        //public ActionResult Edit(EditorInputModel editor)
        //{
        //    var image = new WebImage("~" + editor.Profile.ImageUrl);
        //    var height = image.Height;
        //    var width = image.Width;
        //    //TODO fix crop width
        //    image.Crop((int)editor.Top, (int)editor.Left, (int)(height), (int)(width));
        //    var originalFile = editor.Profile.ImageUrl;
        //    editor.Profile.ImageUrl = Url.Content("~/ProfileImages/" + Path.GetFileName(image.FileName));

        //    image.Resize(100, 100, true, false);
        //    //var total = height + width;
        //    image.Save(@"~" + editor.Profile.ImageUrl);
        //    System.IO.File.Delete(Server.MapPath(originalFile));
        //    return View("Index", editor.Profile);
        //}
       }
}

