[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarModsHeaven.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CarModsHeaven.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CarModsHeaven.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using AutoMapper;
    using CarModsHeaven.Auth;
    using CarModsHeaven.Auth.Contracts;
    using CarModsHeaven.Data;
    using CarModsHeaven.Data.Contracts;
    using CarModsHeaven.Data.Repositories;
    using CarModsHeaven.Data.Repositories.Contracts;
    using CarModsHeaven.Providers.Contracts;
    using CarModsHeaven.Services.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IService))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IProvider))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepostory<>));
            kernel.Bind(typeof(DbContext), typeof(CarModsContext)).To<CarModsContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IMapper>().ToMethod(x => Mapper.Instance).InSingletonScope();
            kernel.Bind<IAuthProvider>().To<AuthProvider>();
        }        
    }
}
