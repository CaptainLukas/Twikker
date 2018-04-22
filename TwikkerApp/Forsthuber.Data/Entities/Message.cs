using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Message
    {
        public Message()
        {
            this.LikeIDs = new List<int>();
            this.CommentIDs = new List<int>();
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

        public List<int> LikeIDs
        {
            get;
            set;
        }

        public List<int> CommentIDs
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
