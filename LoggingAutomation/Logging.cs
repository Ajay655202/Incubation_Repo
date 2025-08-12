using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace LoggingAutomation
{
    public static class Logging
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(TestLog));
        static Logging()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            log.Info("=== Test Execution Started ===");
        }
    }
}
