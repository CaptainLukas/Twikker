﻿using Forsthuber.Data.Entities;
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
            if (dbContext.Users.Any())
            {
                return;
            }

            ApplicationUser app = new ApplicationUser();
            app.Email = "test@test.com";
            app.UserName = "Testuser";

            Message message = new Message();
            message.User = app;
            message.UserID = 3.ToString();

            repository.AddUser("Lukas@lukas.at", "123", "Passwort123");
            repository.AddUser("Test@test.at", "Test", "Passwort123");
            repository.AddUser("test@test.com", "Testuser", "Passwort123");

            repository.AddMessage("Wuff Wuff", new ApplicationUser());
            repository.AddMessage("Test Test", app);
            repository.AddMessage("12456", app);

            app = new ApplicationUser();
            app.UserName = "User2";
            app.Email = "email@email.at";
            repository.AddMessage("test test", app);

            repository.AddComment("Testuser", app, message);
        }
    }
}
