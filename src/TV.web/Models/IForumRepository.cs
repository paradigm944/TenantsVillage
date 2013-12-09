using Microsoft.Web;
using System.Collections.Generic;
using TV.web.Models;

namespace TV.web.Models
{
    public interface IForumRepository
    {
        IList<Comment> SelectThreads();
        IList<Comment> SelectMessages(int threadId);
        Comment AddComment(Comment messageToAdd);
    }
}