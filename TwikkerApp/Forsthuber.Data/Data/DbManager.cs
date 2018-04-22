using System;
using System.Collections.Generic;
using System.Text;
using Forsthuber.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Forsthuber.Data.Data
{
    public class DbManager
    {
        private readonly ILogger log;

        public DbManager()
        {
            this.log = new Logger<DbManager>(new LoggerFactory());
        }
    }
}
