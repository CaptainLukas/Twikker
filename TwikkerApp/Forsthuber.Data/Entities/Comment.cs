using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Comment
    {
        public Comment()
        {
            this.Text = "";
        }

        public int CommentID
        {
            get;
            set;
        }

        public int MessageID
        {
            get;
            set;
        }

        public Message Message
        {
            get;set;
        }

        public int UserID
        {
            get;
            set;
        }

        public ApplicationUser User { get; set; }

        public string Text
        {
            get;
            set;
        }
    }
}
