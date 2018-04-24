using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public class DbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Login> Login { get; set; }

        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

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
