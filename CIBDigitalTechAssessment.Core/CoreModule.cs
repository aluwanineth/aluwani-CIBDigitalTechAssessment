using Autofac;
using CIBDigitalTechAssessment.Core.Interfaces.Entry;
using CIBDigitalTechAssessment.Core.Interfaces.PhoneBook;
using CIBDigitalTechAssessment.Core.Services.Entry;
using CIBDigitalTechAssessment.Core.Services.PhoneBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhoneBookService>().As<ICreatePhoneBook>().InstancePerLifetimeScope();
            builder.RegisterType<PhoneBookService>().As<IGetPhoneBooks>().InstancePerLifetimeScope();
            builder.RegisterType<PhoneBookService>().As<IGetPhoneBookEntryByName>().InstancePerLifetimeScope();
            builder.RegisterType<EntryService>().As<ICreateEntry>().InstancePerLifetimeScope();
        }
    }
}
