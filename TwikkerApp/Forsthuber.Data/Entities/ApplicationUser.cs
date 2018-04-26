using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Messages = new List<Message>();
            this.Likes = new List<Like>();
            this.Comments = new List<Comment>();
        }

        public List<Message> Messages
        {
            get;
            set;
        }

        public List<Comment> Comments
        {
            get;
            set;
        }

        public List<Like> Likes
        {
            get;
            set;
        }
    }
}
