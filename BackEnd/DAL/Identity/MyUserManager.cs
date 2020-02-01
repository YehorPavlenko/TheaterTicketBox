using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DAL
{
	public class MyUserManager : UserManager<UserLogin>
	{
		public MyUserManager(IUserStore<UserLogin> store) : base(store)
		{ } 
	}
}
