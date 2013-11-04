using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using TV.web.Models.DataRepository;


namespace TV.web.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// Action that handles initiall request and returns empty view
        /// </summary>
        /// <returns>Home/Index view</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Returns data by the criterion
        /// </summary>
        /// <param name="param">Request sent by DataTables plugin</param>
        /// <returns>JSON text used to display data
        /// <list type="">
        /// <item>sEcho - same value as in the input parameter</item>
        /// <item>iTotalRecords - Total number of unfiltered data. This value is used in the message: 
        /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
        /// </item>
        /// <item>iTotalDisplayRecords - Total number of filtered data. This value is used in the message: 
        /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
        /// </item>
        /// <item>aoData - Twodimensional array of values that will be displayed in table. 
        /// Number of columns must match the number of columns in table and number of rows is equal to the number of records that should be displayed in the table</item>
        /// </list>
        /// </returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var allPosts = DataRepository.GetPosts();
            IEnumerable<PostModel> filteredPosts;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var LandlordFilter = Convert.ToString(Request["sSearch_1"]);
                var TitleFilter = Convert.ToString(Request["sSearch_2"]);
                var StreetFilter = Convert.ToString(Request["sSearch_3"]);

                //Optionally check whether the columns are searchable at all 
                var isLandlordSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isTitleSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isStreetSearchable = Convert.ToBoolean(Request["bSearchable_3"]);

                filteredPosts = DataRepository.GetPosts()
                   .Where(c => isLandlordSearchable && c.LandLord.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isTitleSearchable && c.Title.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isStreetSearchable && c.Street.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredPosts = allPosts;
            }

            var isLandlordSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isTitleSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isStreetSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PostModel, string> orderingFunction = (c => sortColumnIndex == 1 && isLandlordSortable ? c.LandLord :
                                                           sortColumnIndex == 2 && isTitleSortable ? c.Title :
                                                           sortColumnIndex == 3 && isStreetSortable ? c.Street :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredPosts = filteredPosts.OrderBy(orderingFunction);
            else
                filteredPosts = filteredPosts.OrderByDescending(orderingFunction);

            var displayedPosts = filteredPosts.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { Convert.ToString(c.Id), c.LandLord, c.Title, c.Street };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allPosts.Count(),
                iTotalDisplayRecords = filteredPosts.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }

    }
}
