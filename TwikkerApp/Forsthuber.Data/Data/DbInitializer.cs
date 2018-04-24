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

        private DbManager manager;

        public DbInitializer(DbContext dbContext)
        {
            manager = new DbManager(dbContext);
            this.log = new Logger<DbManager>(new LoggerFactory());
        }

        public void Seed(DbContext dbContext)
        {
            if (dbContext.User.Any())
            {
                return;
            }

            manager.AddUser("Lukas", "123");
            manager.AddUser("Test", "Test");
            manager.AddUser("Hund", "Wuff");

            manager.AddMessage("Wuff Wuff", 3);
            manager.AddMessage("Test Test", 1);
            manager.AddMessage("12456", 1);
            manager.AddMessage("test test", 2);

            manager.AddComment("Wuff Wuff Wuff", 3, 1);
            manager.AddComment("Hallo test", 2, 3);
            manager.AddComment("Hallo", 1, 3);

            manager.AddLike(1, 1);
            manager.AddLike(1, 2);
            manager.AddLike(1, 3);
            manager.AddLike(1, 4);

            manager.AddLike(2, 3);
            manager.AddLike(2, 4);

            manager.AddLike(3, 1);
            manager.AddLike(3, 3);
        }
    }
}
