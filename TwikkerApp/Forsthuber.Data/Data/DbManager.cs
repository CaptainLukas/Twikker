using System;
using System.Collections.Generic;
using System.Text;
using Forsthuber.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Forsthuber.Data.Data
{
    public class DbManager
    {
        public UserContext userContext;

        public CommentContext commentContext;

        public MessageContext messageContext;

        public LikeContext likeContext;

        private readonly ILogger log;

        public DbManager(UserContext userContext, CommentContext commentContext, MessageContext messageContext, LikeContext likeContext)
        {
            this.userContext = userContext;
            this.commentContext = commentContext;
            this.messageContext = messageContext;
            this.likeContext = likeContext;

            this.log = new Logger<DbManager>(new LoggerFactory());
        }

        public void AddUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                userName = "";

            User user = new User();
            user.Username = userName;
            user.Password = password;
        }

        public void AddMessage(string text, int userID)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Message message = new Message();
            message.Text = text;
            message.UserID = userID;
        }

        public void AddComment(string text, int userID, int messageID)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Comment comment= new Comment();
            comment.UserID = userID;
            comment.MessageID = messageID;
            comment.Text = text;
        }

        public void AddLike(int userID, int messageID)
        {
            Like like = new Like();
            like.UserID = userID;
            like.MessageID = messageID;
        }
    }
}
