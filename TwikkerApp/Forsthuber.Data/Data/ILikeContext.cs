using Forsthuber.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public interface ILikeContext
    {
        DbSet<Like> Like { get; set; }

        DbSet<User> User { get; set; }

        DbSet<Message> Message { get; set; }

        void Migrate();
    }
}
