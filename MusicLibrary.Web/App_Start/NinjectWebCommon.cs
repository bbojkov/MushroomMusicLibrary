using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using MusicLibrary.Data;
using MusicLibrary.Services;
using MusicLibrary.Web.NinjectBindingsModules;
using WebFormsMvp.Binder;
using MusicLibrary.Models.Factories;
using MusicLibrary.Models.Contracts;
using MusicLibrary.Models;
using Ninject.Extensions.Factory;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MusicLibrary.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MusicLibrary.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MusicLibrary.Web.App_Start
{
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
            kernel.Load(new MvpNinjectModule());

            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();

            kernel.Bind(typeof(IMusicLibraryContext), typeof(IMusicLibraryBaseContext))
                .To<MusicLibraryContext>().InRequestScope();

            //kernel.Bind<IBandService>().To<BandService>();
            //kernel.Bind<IGenreService>().To<GenreService>();
            //kernel.Bind<IUserService>().To<UserService>();

            kernel.Bind(r => r
            .FromAssemblyContaining<IBandService>()
            .SelectAllClasses()
            .BindAllInterfaces());

            kernel.Bind(x => x
            .FromAssemblyContaining<IBandFactory>()
            .SelectAllInterfaces()
            .EndingWith("Factory")
            .BindToFactory());

        }
    }
}
