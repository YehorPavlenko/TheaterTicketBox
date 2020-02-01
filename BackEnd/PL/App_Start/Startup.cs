using BLL;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(PL.App_Start.Startup))]
namespace PL.App_Start
{
	public class Startup
	{
		private IUserService _service;
		public Startup()
		{
			IKernel kernel = new StandardKernel(new UNinject());
			kernel.Bind<IUserService>().To<UserService>();
			_service = kernel.Get<IUserService>();
		}
		public void Configuration(IAppBuilder app)
		{
			app.UseCors(CorsOptions.AllowAll);
			app.UseStaticFiles(new StaticFileOptions()
			{
				RequestPath = new PathString("/Photos"),
				FileSystem = new PhysicalFileSystem(HttpContext.Current.Server.MapPath("~/Photos"))
			});
			ConfigureOAuth(app);
		
			
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = new MyOAuthProvider(_service),
				AllowInsecureHttp = true
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

		}
	}
}