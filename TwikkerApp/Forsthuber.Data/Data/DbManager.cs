using System;
using System.Collections.Generic;
using System.Text;
using Forsthuber.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Forsthuber.Data.Data
{
    public class DbManager
    {
        public DbContext dbContext;

        private readonly ILogger log;

        public DbManager(DbContext dbContext)
        {
            this.dbContext = dbContext;

            this.log = new Logger<DbManager>(new LoggerFactory());
        }

        public void AddUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                userName = "";

           Login login = new Login();
           login.Nickname = userName;
           login.Password = password;
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
