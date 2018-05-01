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


        public Repository(UserManager<ApplicationUser> userManager, DataBaseContext dbContext, ILogger<Repository> log)
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
            if (GetUserByUserName(userName) == null || GetMessageById(messageID) == null)
                return;

            Like like = new Like();
            like.User = GetUserByUserName(userName);
            like.Message = GetMessageById(messageID);

            dbContext.Likes.Add(like);
            dbContext.SaveChanges();
        }

        public void AddLikeComment(string userName, int commentID)
        {
            if (GetUserByUserName(userName) == null || GetCommentById(commentID) == null)
                return;

            LikeComment likeComment = new LikeComment();
            likeComment.ApplicationUser = GetUserByUserName(userName);
            likeComment.Comment = GetCommentById(commentID);

            dbContext.LikeComments.Add(likeComment);
            dbContext.SaveChanges();
        }

        public void DeleteComment(int commentID)
        {
            if (GetCommentById(commentID) == null)
                return;

            dbContext.Comments.Remove(GetCommentById(commentID));
            dbContext.SaveChanges();
        }

        public void DeleteMessage(int messageID)
        {
            if (GetMessageById(messageID) == null)
                return;

            dbContext.Messages.Remove(GetMessageById(messageID));
            dbContext.SaveChanges();
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            foreach (ApplicationUser user in dbContext.Users)
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
            foreach (Message message in dbContext.Messages)
            {
                if (message.MessageID == messageID)
                {
                    return message;
                }
            }

            return null;
        }

        public Comment GetCommentById(int commentID)
        {
            foreach (Comment comment in dbContext.Comments)
            {
                if (comment.CommentID == commentID)
                {
                    return comment;
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
                    .Include(x=>x.Comments)
                        .ThenInclude(c => c.Likes)
                        .ThenInclude(l => l.ApplicationUser)
                    .Include(x => x.Likes)
                        .ThenInclude(l => l.User)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
