using Automatonymous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Logging;

namespace StateMachine
{
    public partial class StateMachine : MassTransitStateMachine<StateInstance>
    {

        public StateMachine()
        {
            InstanceState(x => x.CurrentState);

            
        }
    }
}
