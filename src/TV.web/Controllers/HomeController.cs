using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TV.web.Models;
using TV.web.ViewModels;

namespace TV.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly TVContext _ctx;

        public HomeController(TVContext ctx)
        {
            _ctx = ctx;
        }


        public ActionResult SlideShowTest()
        {
            ViewBag.Message = "";

            return View();
        }

        
        public ActionResult Index()
        {


            var pics = _ctx.Image.Where(m => m.IsDeleted == false && m.Post.IsDeleted == false && m.IsThumbnail == false).OrderByDescending(m => m.Id).Take(10).ToList<ImageModel>();
            var outModel = new ViewPostViewModel();
           

            
                outModel.Pic_0 = pics[0];
                outModel.Pic_1 = pics[1];
                outModel.Pic_2 = pics[2];
                outModel.Pic_3 = pics[3];
                outModel.Pic_4 = pics[4];
                outModel.Pic_5 = pics[5];
                outModel.Pic_6 = pics[6];
                outModel.Pic_7 = pics[7];
                outModel.Pic_8 = pics[8];
                outModel.Pic_9 = pics[9];
                    

            return View(outModel);
        }

        [HttpPost]
        public JsonResult MorePictures(int? picId)
        {
            var quantity = new int?(10);

            if (picId < quantity)
            {
                quantity = picId;
            }
            var hiId = new int?();

            var pics = _ctx.Image.Where(m => m.IsDeleted == false && m.Post.IsDeleted == false).Where(m => m.Id < picId).OrderByDescending(m => m.Id).Take(quantity.Value).ToList<ImageModel>();

            if (pics.Count == 0) {
                hiId = picId;
            }
            else
            {
                hiId = pics.LastOrDefault<ImageModel>().Id;
            }

            if (hiId == picId)
            {
                pics = _ctx.Image.Where(m => m.IsDeleted == false && m.Post.IsDeleted == false).OrderByDescending(m => m.Id).Take(10).ToList<ImageModel>();

            }

            return Json(pics, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResetPictures(int? picId)
        {
            var quantity = new int?(10);

            if (picId < quantity)
            {
                quantity = picId;
            }
            var hiId = new int?();

            var pics = _ctx.Image.Where(m => m.IsDeleted == false && m.Post.IsDeleted == false).Where(m => m.Id < picId).OrderByDescending(m => m.Id).Take(quantity.Value).ToList<ImageModel>();

            if (pics.Count == 0)
            {
                hiId = picId;
            }
            else
            {
                hiId = pics.LastOrDefault<ImageModel>().Id;
            }

            if (hiId == picId)
            {
                pics = _ctx.Image.Where(m => m.IsDeleted == false && m.Post.IsDeleted == false).OrderByDescending(m => m.Id).Take(10).ToList<ImageModel>();

            }

            return Json(pics, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            throw new Exception("Test");       
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Links()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
