using WebApplication1.ActionHandlers.Person;
using WebApplication1.Data;
using WebApplication1.Service.Commands.Common;
using WebApplication1.Service.Resources.Person;
using WebApplication1.Service.Queries.Person;
using WebApplication1.Service.Commands.Person;
using WebApplication1.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication1.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication1.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication1.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Client Services
            kernel.Bind<ICalculatorEngine>().To<CalculatorEngine>().InRequestScope();
            
            // Action Handlers
            kernel.Bind<IPersonAddActionHandler>().To<PersonAddActionHandler>().InRequestScope();
            kernel.Bind<IPersonIndexActionHandler>().To<PersonIndexActionHandler>().InRequestScope();
            kernel.Bind<IPersonRemoveActionHandler>().To<PersonRemoveActionHandler>().InRequestScope();

            // Data Access
            kernel.Bind<IDataSource>().To<DataSource>().InSingletonScope();

            // Resource Services
            kernel.Bind<IPersonResourceService>().To<PersonResourceService>().InRequestScope();
            
            // Commands / Queries
            kernel.Bind<IAddPersonDataCommand>().To<AddPersonDataCommand>().InRequestScope();
            kernel.Bind<IAllPeopleDataQuery>().To<AllPeopleDataQuery>().InRequestScope();
            kernel.Bind<IRemovePersonDataCommand>().To<RemovePersonDataCommand>().InRequestScope();
            kernel.Bind<ISaveChangesCommand>().To<SaveChangesCommand>().InRequestScope();
        }        
    }
}
