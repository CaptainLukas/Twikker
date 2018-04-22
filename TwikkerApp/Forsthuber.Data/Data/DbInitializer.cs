using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Data
{
    public class DbInitializer
    {
        private readonly ILogger log;

        private DbManager manager;

        public DbInitializer()
        {
            manager = new DbManager();
            this.log = new Logger<DbManager>(new LoggerFactory());
        }
    }
}
