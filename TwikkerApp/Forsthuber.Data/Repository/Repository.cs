using Forsthuber.Data.Data;
using Forsthuber.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Repository
{
    public class Repository : IRepository
    {
        private DbContext dbContext;

        private DbManager manager;

        private readonly ILogger log;

        public Repository(DbContext dbContext, ILogger<Repository> log)
        {
            this.dbContext = dbContext;
            this.manager = new DbManager(dbContext);
            this.log = log;
        }

        public void AddMessage(string text, int userID)
        {
            try
            {
                this.manager.AddMessage(text, userID);
                log.LogInformation("New message added.", text);
            }
            catch(Exception e)
            {
                log.LogError("Adding message failed.", e);
            }
        }
    }
}
