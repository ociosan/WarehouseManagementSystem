using log4net.Config;
using MassTransit.Log4NetIntegration.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace StateMachineService
{
    class Program
    {
        static int Main(string[] args)
        {
            XmlConfigurator.Configure();
            Log4NetLogWriterFactory.Use();
            Log4NetLogger.Use();

            return (int)HostFactory.Run(x => x.Service<StateMachineService>());
        }
    }
}
