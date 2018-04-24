using Forsthuber.Data.Data;
using Forsthuber.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Repository
{
    public class Repository : IRepository
    {
        private UserContext userContext;

        private MessageContext messageContext;

        private LikeContext likeContext;

        private CommentContext commentContext;

        private DbManager manager;

        private readonly ILogger log;

        public Repository(UserContext userContext, MessageContext messageContext, LikeContext likeContext, CommentContext commentContext, ILogger<Repository> log)
        {
            this.userContext = userContext;
            this.messageContext = messageContext;
            this.likeContext = likeContext;
            this.commentContext = commentContext;
            this.manager = new DbManager(userContext, commentContext,messageContext,likeContext);
            this.log = log;
        }

        public void AddMessage(string text, int userID)
        {
            try
            {
                this.manager.AddMessage(text, userID);
                log.LogInformation("New message added.", text);
            }
            catch(Exception e)
            {
                log.LogError("Adding message failed.", e);
            }
        }
    }
}
