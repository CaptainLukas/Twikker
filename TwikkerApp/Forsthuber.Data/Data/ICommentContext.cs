using Forsthuber.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public interface ICommentContext
    {
        DbSet<Comment> Comment { get; set; }

        DbSet<User> User { get; set; }

        DbSet<Message> Message { get; set; }

        void Migrate();
    }
}
