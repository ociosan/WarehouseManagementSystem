using MassTransit.EntityFrameworkIntegration;
using StateMachine;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineSagaDBContext
{
    public class MachineSagaDBContext : SagaDbContext<StateInstance,StateMachineInstanceMap>
    {
        public MachineSagaDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        { }

        public MachineSagaDBContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        { }

        public MachineSagaDBContext(ObjectContext objectContext, bool dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext)
        { }

        public MachineSagaDBContext(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
        { }

        public MachineSagaDBContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
        { }

        protected MachineSagaDBContext() : base()
        { }

        protected MachineSagaDBContext(DbCompiledModel model) : base(model)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
