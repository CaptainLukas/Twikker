using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Like
    {
        public Like()
        {

        }

        public int LikeID
        {
            get;
            set;
        }
        public Message Message { get; set; }

        public int MessageID
        {
            get;
            set;
        }

        public string UserID
        {
            get;
            set;
        }

        public ApplicationUser User { get; set; }
    }
}
