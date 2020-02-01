using BLL;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PL.App_Start
{
	public class MyOAuthProvider : OAuthAuthorizationServerProvider
	{
		private IUserService _service;
		public MyOAuthProvider(IUserService service)
		{
			_service = service;
		}
		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
			return Task.FromResult<object>(null);
		}
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			ClaimsIdentity identity = await _service.AuthenticateAsync(context.UserName, context.Password);

			if (identity == null)
			{
				context.SetError("The user name or password is incorrect.");
				return;
			}

			context.Request.Context.Authentication.SignOut();
			context.Request.Context.Authentication.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
			context.Validated(identity);

		}
	}
}