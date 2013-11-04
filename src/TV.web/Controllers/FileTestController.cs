using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.ViewModels;

namespace TV.web.Controllers
{
    public class FileTestController : Controller
    {

        public ActionResult UploadPhotos()
        {
            var outmodel = new UploadPicViewModel
            {
                PostId = 1,

            };
            return View(outmodel);
        }

        //[HttpPost]
        //public ActionResult UploadPhotos(ListOfPicsViewModel inModel)
        //{
        //    var photos = inModel.photos;

        //    if (photos != null)
        //    {
        //        foreach (var photo in photos)
        //        {
        //            string path = Url.Content("~/UserImages");

        //            //if (photo.ContentLength > 10240)
        //            //{
        //            //    ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
        //            //    return View();
        //            //}

        //            var supportedTypes = new[] { "jpg", "jpeg", "png" };

        //            var fileExt = System.IO.Path.GetExtension(photo.).Substring(1);

        //            if (!supportedTypes.Contains(fileExt))
        //            {
        //                ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //                return View();
        //            }

        //            photo.SaveAs(path + photo.FileName);
        //        }
        //    }

        //    return View();
        //}
    }
}
