using BLL;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(TheaterTicketBox.App_Start.StartUp))]
namespace TheaterTicketBox.App_Start
{
	public class StartUp
	{
		private IUserService _service;
		public StartUp()
		{
			IKernel kernel = new StandardKernel(new BLL.Ninject());
			kernel.Bind<IUserService>().To<UserService>();
			_service = kernel.Get<IUserService>();
		}
		public void Configuration(IAppBuilder app)
		{
			ConfigureOAuth(app);
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
			GlobalConfiguration.Configure(WebApiConfig.Register);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			AutoMapperConfig.Initialize();
		}
		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
				Provider = new MyOAuthProvider(_service)
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

		}

	}
}