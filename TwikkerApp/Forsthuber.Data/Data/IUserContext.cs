using Forsthuber.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public interface IUserContext
    {
        DbSet<User> User { get; set; }

        DbSet<Message> Message { get; set; }

        DbSet<Comment> Comment { get; set; }

        DbSet<Like> Like { get; set; }

        void Migrate();
    }
}
