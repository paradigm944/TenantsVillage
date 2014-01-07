using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TV.web.Models;
using TV.web.Models.DataRepository;
using TV.web.ViewModels;
using WebMatrix.WebData;


namespace TV.web.Controllers
{
    public class SearchController : Controller
    {
        private readonly TVContext _ctx;
        private readonly IForumRepository _repository;




        public SearchController(TVContext ctx, IForumRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserPosts()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewPost(int id)
        {
            var post = _ctx.Post.Where(p => p.Id == id).SingleOrDefault();
            var images = _ctx.Image.Where(i => i.Post.Id == id).AsEnumerable();
            var user = _ctx.UserProfiles.Where(u => u.UserId == post.User.UserId).SingleOrDefault();
            var comments = _ctx.Comment.Where(m => m.PostId == post.Id).ToList<Comment>();

            if (post.IsDeleted == true)
            {
                return View("DeletedPostError");
            }
            var outModel = new ViewPostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                LandLord = post.LandLord,
                LLemail = post.LLemail,
                Post = post.Post,
                Rent = post.Rent,
                Street = post.Street,
                Deposit = post.Deposit,
                AmtKept = post.AmountKept,
                LeaseYear = post.LeaseYear,
                Images = images,
                User = user,
                Comments = comments,
                AptNumber = post.AptNumber,
                BuildingNumber = post.BuildingNumber,
                Rating = post.Rating

            };

            if (_ctx.UserBookmark.Where(m => m.User.UserId == user.UserId).Where(m => m.Post.Id == post.Id).Any())
            {
                outModel.IsBookmarked = true;
            }        

            return View(outModel);
        }


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
                var CityFilter = Convert.ToString(Request["sSearch_4"]);
                var ZipCodeFilter = Convert.ToString(Request["sSearch_5"]);

                //Optionally check whether the columns are searchable at all 
                var isLandlordSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isTitleSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isStreetSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isCitySearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isZipCodeSearchable = Convert.ToBoolean(Request["bSearchable_5"]);

                filteredPosts = DataRepository.GetPosts()
                   .Where(c => c.ZipCode.ToString().Contains(param.sSearch) || c.LandLord.ToLower().Contains(param.sSearch.ToLower()) || c.Street.ToLower().Contains(param.sSearch.ToLower()) || c.City.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredPosts = allPosts;
            }

            var isLandlordSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isTitleSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isStreetSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isCitySortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isZipCodeSortable = Convert.ToBoolean(Request["bSortable_5"]);
            var isRatingSortable = Convert.ToBoolean(Request["bSortable_6"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PostModel, string> orderingFunction = (c => sortColumnIndex == 1 && isLandlordSortable ? c.LandLord :
                                                           sortColumnIndex == 2 && isTitleSortable ? c.Title :
                                                           sortColumnIndex == 3 && isStreetSortable ? c.Street :
                                                           sortColumnIndex == 4 && isCitySortable ? c.City :
                                                           sortColumnIndex == 5 && isZipCodeSortable ? c.ZipCode.ToString() :
                                                           sortColumnIndex == 6 && isRatingSortable ? c.Rating.ToString() :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredPosts = filteredPosts.OrderBy(orderingFunction);
            else
                filteredPosts = filteredPosts.OrderByDescending(orderingFunction);

            var displayedPosts = filteredPosts.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { Convert.ToString(c.Id), c.LandLord, c.Title, c.Street, c.City, c.ZipCode.ToString(), c.Rating.ToString()};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allPosts.Count(),
                iTotalDisplayRecords = filteredPosts.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserPostsAjaxHandler(JQueryDataTableParamModel param)
        {
            var allPosts = DataRepository.GetUserPosts();
            IEnumerable<PostModel> filteredPosts;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var LandlordFilter = Convert.ToString(Request["sSearch_1"]);
                var TitleFilter = Convert.ToString(Request["sSearch_2"]);
                var StreetFilter = Convert.ToString(Request["sSearch_3"]);
                var IsCompletedFilter = Convert.ToString(Request["sSearch_4"]);
                var IsDeletedFilter = Convert.ToString(Request["sSearch_5"]);

                //Optionally check whether the columns are searchable at all 
                var isLandlordSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isTitleSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isStreetSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isIsCompletedSearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isIsDeletedSearchable = Convert.ToBoolean(Request["bSearchable_5"]);

                filteredPosts = DataRepository.GetPosts()
                   .Where(c => isLandlordSearchable && c.LandLord.ToLower().Contains(param.sSearch.ToLower())
                       //||
                       //isTitleSearchable && c.Title.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isStreetSearchable && c.Street.ToLower().Contains(param.sSearch.ToLower()));
                               //||
                               //isIsCompletedSearchable && c.IsCompleted.ToString().Contains(param.sSearch.ToLower())
                               //||
                               //isIsDeletedSearchable && c.IsDeleted.ToString().Contains(param.sSearch.ToLower()));
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
                                                           sortColumnIndex == 4 && isStreetSortable ? c.Rating.ToString() :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredPosts = filteredPosts.OrderBy(orderingFunction);
            else
                filteredPosts = filteredPosts.OrderByDescending(orderingFunction);

            var displayedPosts = filteredPosts.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { Convert.ToString(c.Id), c.LandLord, c.Title, c.Street, c.Rating.ToString() };
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


