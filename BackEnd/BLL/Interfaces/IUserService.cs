using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public interface IUserService
	{
		Task CreateUserAsync(UserDTO userDTO);
		Task<ClaimsIdentity> AuthenticateAsync(string UserName, string Password);
		Task<bool> IsExistsAsync(string Email);
		Task<string> GetId(string Email);
		Task<bool> IsAdmin(string Email);
	}
}
