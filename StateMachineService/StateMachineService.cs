using MassTransit;
using MassTransit.EntityFrameworkIntegration.Saga;
using MassTransit.RabbitMqTransport;
using MassTransit.Saga;
using StateMachine;
using StateMachineSagaDBContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace StateMachineService
{
    class StateMachineService : ServiceControl
    {
        private static readonly LogWriter theLogWriter = HostLogger.Get<StateMachineService>();
        private IBusControl theBusControl;
        ISagaRepository<StateInstance> theStateInstance;
        private static string rabbitMQHostUrl;
        private static string rabbitMQUsername;
        private static string rabbitMQPassword;
        private static string changeStateQueueName;

        public bool Start(HostControl theHostControl)
        {
            rabbitMQHostUrl = ConfigurationManager.AppSettings["RabbitMQHost"];
            rabbitMQUsername = ConfigurationManager.AppSettings["RabbitMQUsername"];
            rabbitMQPassword = ConfigurationManager.AppSettings["RabbitMQPassword"];
            changeStateQueueName = ConfigurationManager.AppSettings["changestatequeuename"];


            theLogWriter.Info($"Creating Service {nameof(StateMachineService)}...");

            DelegateSagaDbContextFactory<StateInstance> delegateSagaDbContextFactory = 
                new DelegateSagaDbContextFactory<StateInstance>(() => new MachineSagaDBContext("defaultDatabase"));

            theStateInstance = new EntityFrameworkSagaRepository<StateInstance>(delegateSagaDbContextFactory, System.Data.IsolationLevel.ReadCommitted);

            theBusControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                IRabbitMqHost theRabbitHost = cfg.Host(new Uri(rabbitMQHostUrl), host =>
                {
                    host.Username(rabbitMQUsername);
                    host.Username(rabbitMQPassword);
                });

                //EndpointConvention.Map<AssignCarrierToOrder>(new Uri(string.Concat(rabbitMQHostUrl, "Here is the queue")));

                cfg.ReceiveEndpoint(changeStateQueueName, e =>
                {
                   e.PrefetchCount = 16;
                   e.UseInMemoryOutbox();

                    var machine = new StateMachine.StateMachine();
                    e.StateMachineSaga(machine, theStateInstance);

                });

            });

            theLogWriter.Info($"Service {nameof(StateMachineService)} created and ready to flight :D");
            theBusControl.Start();
            return true;
        }
        
        public bool Stop(HostControl theHostControl)
        {
            theLogWriter.Info($"Stopping Service {nameof(StateMachineService)}");
            theBusControl?.Stop();
            return true;
        }
    }
}
