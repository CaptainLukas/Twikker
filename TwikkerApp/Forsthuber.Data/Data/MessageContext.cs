using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public class MessageContext : IdentityDbContext<ApplicationUser>, IMessageContext
    {
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}
