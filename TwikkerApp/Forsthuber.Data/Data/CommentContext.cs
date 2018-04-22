using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public class CommentContext : IdentityDbContext<ApplicationUser>, ICommentContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }

        public CommentContext(DbContextOptions<CommentContext> options) : base(options) { }

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
