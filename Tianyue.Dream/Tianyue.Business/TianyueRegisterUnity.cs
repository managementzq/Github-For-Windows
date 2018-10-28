using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Repository.Configuration;
using Tianyue.Repository.Contract.Configuration;
using Tianyue.ServiceLocator;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace Tianyue.Business
{
    public class TianyueRegisterUnity
    {
        public static void RegistTianyue()
        {
            var container = new UnityContainer();

            container.AddNewExtension<Interception>();

            //#region 注册注入的接口实例

            //病人信息-指定接口拦截

            ////病人信息-指定接口拦截
            //container.RegisterType<IUserRepository, UserRepository>("meePat",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());
            container.RegisterType<IPermissionRepository, PermissionRepository>("PermissionUnity",
              new ContainerControlledLifetimeManager(),
              new Interceptor<InterfaceInterceptor>());




            ////字典
            //container.RegisterType<IDictRepository, DictRepository>("meeDict",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////报表
            //container.RegisterType<IReportRepository, ReportRepository>("meeReport",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////床位
            //container.RegisterType<IBedRepository, BedRepository>("meeBed",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////用户信息
            //container.RegisterType<IUserRepository, UserRepository>("meeUser",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            //container.RegisterType<IExUserRepository, ExUserRepository>("exUser",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////通用信息
            //container.RegisterType<ICommonRepository, CommonRepository>("meeComm",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());
            //container.RegisterType<IExCommonRepository, ExCommonRepository>("exComm",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////菜单 MenuDoctor
            //container.RegisterType<IDoctorRepository, DoctorRepository>("meeDoc",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            //container.RegisterType<IExDoctorRepository, ExDoctorRepository>("exDoc",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////会诊
            //container.RegisterType<IConsultationRepository, ConsultationRepository>("meeConsl",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////EMR
            //container.RegisterType<IEMRRepository, EMRRepository>("meeEMR",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());
            //container.RegisterType<IExEmrRepository, ExEmrRepository>("exEmr",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());
            ////临床数据
            //container.RegisterType<IClinicDataRepository, ClinicDataRepository>("meeClinicData",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////交接班 HandOver
            //container.RegisterType<IHandOverRepository, HandOverRepository>("meeHandOver",
            //    new ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////时间轴 TimeLine
            //container.RegisterType<IQCRepository, QCRepository>("meeTimeLine",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            ////输液 Infusion
            //container.RegisterType<IInfusionRepository, InfusionRepository>("meeInfusion",
            //   new ContainerControlledLifetimeManager(),
            //   new Interceptor<InterfaceInterceptor>(),
            //   new InterceptionBehavior<ExceptionLoggingBehavior>());

            //container.RegisterType<IExInfusionRepository, ExInfusionRepository>("exInfusion",
            //  new ContainerControlledLifetimeManager(),
            //  new Interceptor<InterfaceInterceptor>(),
            //  new InterceptionBehavior<ExceptionLoggingBehavior>());

            //container.RegisterType<IClinicDataRepository, ClinicDataRepository>("meeClinicData",
            //  new ContainerControlledLifetimeManager(),
            //  new Interceptor<InterfaceInterceptor>(),
            //  new InterceptionBehavior<ExceptionLoggingBehavior>());

            //#endregion 注册注入的接口实例

            var locator = new UnityServiceLocator(container);
            TianyueServiceLocator.SetLocatorProvider(() => locator);
        }

        ///// <summary>
        ///// ECIS4.0注册
        ///// </summary>
        //public static void RegistTianyue()
        //{
        //    ////ILogger log = LogManager.GetCurrentClassLogger();
        //    //var container = new UnityContainer();
        //    //container.RegisterInstance(log, new ContainerControlledLifetimeManager());

        //    //var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = @"config\unity.config" };
        //    //var configuration =
        //    //    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        //    //var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
        //    //container.LoadConfiguration(unitySection);
        //    //container.AddNewExtension<EnterpriseLibraryCoreExtension>();
        //    //var provider = new UnityServiceLocator(container);
        //    //Microsoft.Practices.ServiceLocation.ServiceLocator.SetLocatorProvider(() => provider);
        //}
    }
}
