using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public interface IDbContext 
    {
        DbSet<Message> Messages { get; set; }

        //DbSet<ApplicationUser> Users { get; set; }

        DbSet<Like> Likes { get; set; }

        DbSet<Comment> Comments { get; set; }

        void Migrate();
    }
}
