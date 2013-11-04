using Microsoft.Web;
using System.Collections.Generic;
using TV.web.Models;

namespace TV.web.Models
{
    public interface IForumRepository
    {
        IList<Message> SelectThreads();
        IList<Message> SelectMessages(int threadId);
        Message AddComment(Message messageToAdd);
    }
}