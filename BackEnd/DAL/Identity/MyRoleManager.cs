using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace DAL
{
	public class MyRoleManager : RoleManager<UserRole>
	{
		public MyRoleManager(IRoleStore<UserRole, string> store) : base(store)
		{
		}
	}
}
