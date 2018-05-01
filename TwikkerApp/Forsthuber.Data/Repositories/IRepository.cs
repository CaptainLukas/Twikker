using Forsthuber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Repositories
{
    public interface IRepository
    {
        void AddUser(string email, string userName, string password);

        void AddMessage(string text, ApplicationUser user);

        void AddComment(string text, ApplicationUser user, Message message);

        void AddLike(string userName, int messageID);

        ApplicationUser GetUserByUserName(string userName);

        Message GetMessageById(int messageID);

        List<Message> GetAllMessages();

        void DeleteMessage(int messageID);

        void DeleteComment(int commentID);

        void AddLikeComment(string userName, int commentID);
        Comment GetCommentById(int commentID);
    }
}
