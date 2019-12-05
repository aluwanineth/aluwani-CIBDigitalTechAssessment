using Autofac;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhoneBookRepository>().As<IPhoneBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EntryRepository>().As<IEntryRepository>().InstancePerLifetimeScope();
        }
    }
}
