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
            //var post_1 = _ctx.Post.FirstOrDefault();
            
            var pics = _ctx.Image.Select(m => m).Where(m => m.IsDeleted == 1 && m.Post.IsDeleted == false).Take(50).ToList<ImageModel>();

            //var imgUrl_1 = _ctx.Image.Where(i => i.PostId == post_1.Id).SingleOrDefault().ImageUrl.ToString();

            var outModel = new ViewPostViewModel
            {
                Pics = pics,
                //ImgUrl_1 = imgUrl_1
            };

            return View(outModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
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
