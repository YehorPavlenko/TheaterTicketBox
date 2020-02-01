using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserLogin:IdentityUser
	{
		public virtual UserProfile UserProfile { get; set;}
	}
}
