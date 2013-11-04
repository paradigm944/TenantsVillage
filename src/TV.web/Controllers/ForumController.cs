using System;
using System.Web.Mvc;
using MvcForums.Models;
using Microsoft.Web;
using TV.web.Models;
using TV.web.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace MvcForums.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository _repository;
        private readonly TVContext _ctx;
        //public ForumController()
        //    : this(new ForumRepository())
        //{ }

        public ForumController(IForumRepository repository, TVContext ctx)
        {
            _repository = repository;
            _ctx = ctx;
        }

        public ActionResult Index()
        {
            var outModel = new ForumRepositoryViewModel
            {
                Messages = _repository.SelectThreads()
            };

            return View("Index", outModel);
        }

        public ActionResult CreateMessage()
        {
            var outmodel = new MessageViewModel 
            {
               DisplayMode = false
            };



            return View(outmodel);
        }

        [HttpPost]
        public ActionResult CreateReply(MessageViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }


            var messageToCreate = new Message();
            if (inModel.ParentThreadId.HasValue)
            {
                messageToCreate.ParentThreadId = inModel.ParentThreadId;
            }

            if (inModel.ParentMessageId.HasValue)
            {
                messageToCreate.ParentMessageId = inModel.ParentMessageId;
            }

            messageToCreate.Recipient = inModel.Recipient;
            messageToCreate.Author = HttpContext.User.Identity.Name;
            messageToCreate.Subject = inModel.Subject;
            messageToCreate.Body = inModel.Body;
            messageToCreate.EntryDate = DateTime.Now;

           
            _repository.AddMessage(messageToCreate);


            return View("Success");
        }

        public ActionResult CreateThread()
        {
            var outmodel = new MessageViewModel();



            return View("Create", outmodel);
        }

        [HttpPost]
        public ActionResult CreateThread(MessageViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }


            var messageToCreate = new Message();
            if (inModel.ParentThreadId.HasValue)
            {
                messageToCreate.ParentThreadId = inModel.ParentThreadId;
            }

            if (inModel.ParentMessageId.HasValue)
            {
                messageToCreate.ParentMessageId = inModel.ParentMessageId;
            }

            messageToCreate.Recipient = inModel.Recipient;
            messageToCreate.Author = HttpContext.User.Identity.Name;
            messageToCreate.Subject = inModel.Subject;
            messageToCreate.Body = inModel.Body;
            messageToCreate.EntryDate = DateTime.Now;


            _repository.AddMessage(messageToCreate);


            return View("Success");
        }

        public ActionResult ViewThread(int threadId)
        {
            var outModel = new MessageViewModel
            {
                Messages = _repository.SelectMessages(threadId)
            };

            return View(outModel);
        }

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var allmessages = _repository.SelectThreads();
            IEnumerable<Message> filteredmessages;
            //Check whether the messages should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var UserFilter = Convert.ToString(Request["sSearch_1"]);
                var SubjectFilter = Convert.ToString(Request["sSearch_2"]);
                var LandlordFilter = Convert.ToString(Request["sSearch_3"]);
                var DateFilter = Convert.ToString(Request["sSearch_4"]);

                //Optionally check whether the columns are searchable at all 
                var isUserSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isSubjectSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isLandlordSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isDateSearchable = Convert.ToBoolean(Request["bSearchable_4"]);

                filteredmessages = _repository.SelectThreads()
                    .Where(c => isUserSearchable && c.LandLord.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isSubjectSearchable && c.LLemail.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isLandlordSearchable && c.DatePosted.Contains(param.sSearch.ToLower())
                               ||
                               isDateSearchable && c.Title.Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredmessages = allmessages;
            }

            var isLandLordSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isLLemailSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isDatePostedSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isTitleSortable = Convert.ToBoolean(Request["bSortable_4"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PostModel, string> orderingFunction = (c => sortColumnIndex == 1 && isLandLordSortable ? c.LandLord :
                                                           sortColumnIndex == 2 && isLLemailSortable ? c.LLemail :
                                                           sortColumnIndex == 3 && isDatePostedSortable ? c.DatePosted :
                                                           sortColumnIndex == 3 && isTitleSortable ? c.Title :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredmessages = filteredmessages.OrderBy(orderingFunction);
            else
                filteredmessages = filteredmessages.OrderByDescending(orderingFunction);

            var displayedmessages = filteredmessages.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedmessages select new[] { Convert.ToString(c.Id), c.Title, c.LandLord, c.LLemail, c.DatePosted, };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allmessages.Count,
                iTotalDisplayRecords = filteredmessages.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }

    }
}