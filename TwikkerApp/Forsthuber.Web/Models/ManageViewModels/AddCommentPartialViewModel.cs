using Forsthuber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forsthuber.Web.Models.ManageViewModels
{
    public class AddCommentPartialViewModel
    {

        public int MessageID { get; set; }
        public Message Message { get; set; }

        public int Index { get; set; }
        public string Text { get; set; }

        public ApplicationUser User { get; set; }
    }
}
