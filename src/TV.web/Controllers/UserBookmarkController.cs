using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;

namespace TV.web.Controllers
{
    public class UserBookmarkController : Controller
    {
        private readonly TVContext _ctx;
       
        public UserBookmarkController(TVContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public JsonResult Bookmark()
        {
            var message = "Bookmark Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}
