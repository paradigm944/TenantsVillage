using Backload.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Controllers
{
    public class BackloadUploadController : BackloadController
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> FileHandler()
        {
            // Call base class method to handle the file upload asynchronously
            ActionResult result = await base.HandleRequestAsync();
            return result;
        }
    }
}
