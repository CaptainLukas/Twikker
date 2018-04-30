using Forsthuber.Data.Data;
using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forsthuber.Data.Repositories
{
    public class Repository : IRepository
    {
        private DataBaseContext dbContext;
        
        private UserManager<ApplicationUser> userManager;

        private readonly ILogger log;

        
        public Repository(UserManager<ApplicationUser> userManager,DataBaseContext dbContext, ILogger<Repository> log)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.log = log;
        }

        public void AddUser(string email, string userName, string password)
        {
            var user = new ApplicationUser() { Email = email, UserName = userName };
            var result = userManager.CreateAsync(user, password);

            if (result.IsCompletedSuccessfully)
            {
                string newId = user.Id;
            }
        }

        public void AddMessage(string text, ApplicationUser user)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Message message = new Message();
            message.Text = text;
            message.User = user;
            message.TimeStamp = DateTime.Now;

            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
        }

        public void AddComment(string text, ApplicationUser user, Message message)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Comment comment = new Comment();
            comment.User = user;
            comment.Message = message;
            comment.Text = text;
            comment.TimeStamp = DateTime.Now;
            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
        }

        public void AddLike(string userName, int messageID)
        {
            Like like = new Like();
            ApplicationUser name = GetUserByUserName(userName);
            like.User = name ?? throw new ArgumentNullException(nameof(name));

            Message message = GetMessageById(messageID);
            like.Message = message ?? throw new ArgumentNullException(nameof(message));

            dbContext.Likes.Add(like);
            dbContext.SaveChanges();
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            foreach(ApplicationUser user in dbContext.Users)
            {
                if (user.UserName == userName)
                {
                    return user;
                }
            }

            return null;
        }

        public Message GetMessageById(int messageID)
        {
            foreach(Message message in dbContext.Messages)
            {
                if (message.MessageID == messageID)
                {
                    return message;
                }
            }
            return null;
        }

        public List<Message> GetAllMessages()
        {
            try
            {
                return dbContext.Messages
                    .Include(x => x.User)
                        .ThenInclude(u => u.Messages)
                    .Include(x => x.Comments)
                        .ThenInclude(c => c.User)
                    .Include(x => x.Likes)
                        .ThenInclude(l=>l.User).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
