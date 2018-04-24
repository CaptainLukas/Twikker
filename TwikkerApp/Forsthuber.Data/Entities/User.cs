﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class User
    {
        public User()
        {
            this.MessageIDs = new List<int>();
            this.LikeIDs = new List<int>();
            this.CommentIDs = new List<int>();
        }

        public int UserID
        {
            get;
            set;
        }

        public int LoginID
        {
            get;
            set;
        }

        public List<int> MessageIDs
        {
            get;
            set;
        }

        public List<int> CommentIDs
        {
            get;
            set;
        }

        public List<int> LikeIDs
        {
            get;
            set;
        }
    }
}
