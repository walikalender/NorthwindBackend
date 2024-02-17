using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        ILog _logger;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead(path: "log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _logger = LogManager.GetLogger(loggerRepository.Name, name);
        }
    }
}
