using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.CommandBus;
using Tianyue.CommandHandler;
using Tianyue.EventBus;
using Tianyue.EventHandler;

namespace Tianyue.ServiceLocator
{
    public sealed class TianyueServiceLocator
    {

        private static ServiceLocatorProvider currentProvider;

        public static void SetLocatorProvider(ServiceLocatorProvider newProvider)
        {
            currentProvider = newProvider;
        }

        public static IServiceLocator Current
        {
            get
            {
                return currentProvider();
            }
        }



        private static ICommandBus _commandBus;
        //private static IReportDatabase _reportDatabase;
        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        static TianyueServiceLocator()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    ContainerBootstrapper.BootstrapStructureMap();
                    //_commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    //_reportDatabase = ObjectFactory.GetInstance<IReportDatabase>();
                    _isInitialized = true;
                }
            }


        }



        public static ICommandBus CommandBus
        {
            get { return _commandBus; }
        }

        //public static IReportDatabase ReportDatabase
        //{
        //    get { return _reportDatabase; }
        //}
    }


    static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {

            //ObjectFactory.Initialize(x =>
            //{
            //    x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
            //    x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
            //    x.For<IEventBus>().Use<EventBus.EventBus>();
            //    x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
            //    x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
            //    x.For<ICommandBus>().Use<CommandBus.CommandBus>();
            //    x.For<IEventBus>().Use<EventBus.EventBus>();
            //    x.For<IReportDatabase>().Use<ReportDatabase>();
            //});
        }
    }


}
