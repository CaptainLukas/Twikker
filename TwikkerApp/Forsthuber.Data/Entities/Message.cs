﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Message
    {
        public Message()
        {
            this.Likes = new List<Like>();
            this.Comments = new List<Comment>();
        }

        public int MessageID
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public ApplicationUser User
        {
            get;
            set;
        }

        public List<Like> Likes
        {
            get;
            set;
        }

        public List<Comment> Comments
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }
    }
}
