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

        public IList<Message> SelectThreads()
        {
            var messages = _ctx.Message.Select(m => m);
            var threads = from m in messages
                          
                          select m;
            return threads.ToList();
        }

        public IList<Message> SelectMessages(int threadId)
        {
            var messages = _ctx.Message.Select(m => m);
            var threads = from m in messages
                         
                          select m;
            return threads.ToList();
        }


        public Message AddComment(Message messageToAdd)
        {
            _ctx.Message.Add(messageToAdd);

            //var errors = _ctx.GetValidationErrors();

            _ctx.SaveChanges();

            return messageToAdd;
        }
    }
}