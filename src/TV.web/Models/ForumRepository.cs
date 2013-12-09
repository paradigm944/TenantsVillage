using System.Linq;
using System.Data;
using Microsoft.Web;
using System.Collections.Generic;
using TV.web.Models;

namespace TV.web.Models
{
    public class ForumRepository : IForumRepository
    {
        private TVContext _ctx;

        //public ForumRepository()
        //    : this(new DataContextWrapper("conForumsDB", "~/Models/ForumsDB.xml"))
        //{ }

        public ForumRepository(TVContext dataContext)
        {
            _ctx = dataContext;
        }

        public IList<Comment> SelectThreads()
        {
            var messages = _ctx.Comment.Select(m => m);
            var threads = from m in messages
                          
                          select m;
            return threads.ToList();
        }

        public IList<Comment> SelectMessages(int threadId)
        {
            var messages = _ctx.Comment.Select(m => m);
            var threads = from m in messages
                         
                          select m;
            return threads.ToList();
        }


        public Comment AddComment(Comment messageToAdd)
        {
            _ctx.Comment.Add(messageToAdd);

            //var errors = _ctx.GetValidationErrors();

            _ctx.SaveChanges();

            return messageToAdd;
        }
    }
}