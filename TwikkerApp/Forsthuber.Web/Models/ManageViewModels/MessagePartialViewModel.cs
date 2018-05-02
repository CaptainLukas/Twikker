using Forsthuber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forsthuber.Web.Models.ManageViewModels
{
    public class MessagePartialViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Message> Messages { get; set; }
    }
}
