using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class LikeComment
    {
        public LikeComment()
        {

        }

        public int LikeCommentID { get; set; }

        public string UserID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Comment Comment { get; set; }

        public int CommentID { get; set; }
    }
}
