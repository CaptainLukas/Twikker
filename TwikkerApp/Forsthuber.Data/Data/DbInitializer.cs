using Forsthuber.Data.Entities;
using Forsthuber.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forsthuber.Data.Data
{
    public class DbInitializer
    {
        private readonly ILogger log;
        private Repository repository;
        
        public DbInitializer(DataBaseContext dbContext, Repository repository)
        {
            this.repository = repository;
            this.log = new Logger<DbInitializer>(new LoggerFactory());
        }

        public void Seed(DataBaseContext dbContext)
        {
            if (dbContext.User.Any())
            {
                return;
            }
            ApplicationUser app = new ApplicationUser();
            app.Email = "test@test.com";
            app.UserName = "Penisuser";

            repository.AddUser("Lukas", "123", "Penis");
            repository.AddUser("Test", "Test", "Penis");
            repository.AddUser("test@test.com", "Penisuser", "Penis");

            repository.AddMessage("Wuff Wuff", new ApplicationUser());
            repository.AddMessage("Test Test", app);
            repository.AddMessage("12456", app);

            app = new ApplicationUser();
            app.UserName = "User2";
            app.Email = "email@email.at";
            repository.AddMessage("test test", app);

            //repository.AddComment("Penisuser", app, 1);
            //repository.AddComment("Hallo test", 2, 3);
            //repository.AddComment("Hallo", 1, 3);

            //repository.AddLike(1, 1);
            //repository.AddLike(1, 2);
            //repository.AddLike(1, 3);
            //repository.AddLike(1, 4);
            
            //repository.AddLike(2, 3);
            //repository.AddLike(2, 4);

            //repository.AddLike(3, 1);
            //repository.AddLike(3, 3);
        }
    }
}
