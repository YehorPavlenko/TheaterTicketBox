[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PL.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PL.App_Start.NinjectWebCommon), "Stop")]

namespace PL.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Web.Common.WebHost;
	using BLL;

	using Ninject.Modules;
	using Ninject.Web.WebApi;
	using System.Web.Http;

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

		/// Stops the application.
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			//Attention!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			var pr = new INinjectModule[] { new UNinject() };
			var kernel = new StandardKernel(pr);
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				//Attension!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		// Load your modules or register your services here!

		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IUserService>().To<UserService>();
			kernel.Bind<IHallService>().To<HallService>();
			kernel.Bind<IPerformanceService>().To<PerformanceService>();
			kernel.Bind<ISessionService>().To<SessionService>();
			kernel.Bind<ITicketService>().To<TicketService>();
		}
	}
}