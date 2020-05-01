using MassTransit.EntityFrameworkIntegration;
using MassTransit.Internals.Reflection;
using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineSagaDBContext
{
    public class StateMachineInstanceMap : SagaClassMapping<StateInstance>
    {
        public StateMachineInstanceMap()
        {
            Property(x => x.CorrelationId);
            Property(x => x.CurrentState).HasMaxLength(128);
            Property(x => x.CreatedDate);
            Property(x => x.UpdatedDate);

            HasKey(x => x.CorrelationId, config => config.IsClustered(false));
            HasIndex(x => x.UserId).HasName("IX_School_UserId").IsUnique(true).IsClustered(true);
        }
    }
}
