using Forsthuber.Data.Data;
using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        }

        public void AddComment(string text, ApplicationUser user, Message message)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Comment comment = new Comment();
            comment.User = user;
            comment.Message = message;
            comment.Text = text;
        }

        public void AddLike(ApplicationUser user, Message message)
        {
            Like like = new Like();
            like.User = user;
            like.Message = message;
        }
    }
}
