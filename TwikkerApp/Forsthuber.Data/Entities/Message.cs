using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Message
    {
        public Message()
        {

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

        public int LikeID
        {
            get;
            set;
        }

        public int CommentID
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
