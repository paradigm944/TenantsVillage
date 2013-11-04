using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.ViewModels;


namespace TV.web.Models
{
    public class EditorInputModel 
    {
        public UploadPicViewModel Profile { get; set; }

        public double Top { get; set; }

        public double Bottom { get; set; }

        public double Left { get; set; }

        public double Right { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
