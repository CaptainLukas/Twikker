using Forsthuber.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public interface IMessageContext
    {
        DbSet<Message> Message { get; set; }

        DbSet<User> User { get; set; }

        DbSet<Like> Like { get; set; }

        DbSet<Comment> Comment { get; set; }

        void Migrate();
    }
}
