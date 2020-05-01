using Automatonymous;
using System;

namespace StateMachine
{
    public class StateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int UserId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
