using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace BLL
{
	public class UserService : IUserService
	{
		private IUnitOfWork _unit;
		private IMapper _mapper;
		public UserService(IUnitOfWork unit)
		{
			_unit = unit;
			_mapper = Mapper.Instance;
		}
		public async Task CreateUserAsync(UserDTO userDTO)
		{
			UserLogin user = await _unit.UserRepository.FindByEmailAsync(userDTO.Email);
			if (user == null)
			{
				user = new UserLogin
				{
					Email = userDTO.Email,
					UserName = userDTO.Email,
					PhoneNumber =userDTO.PhoneNumber,
				};
				await _unit.UserRepository.CreateAsync(user, userDTO.Password);
				await _unit.UserRepository.AddToRoleAsync(user.Id, "User");
				UserProfile profile = _mapper.Map<UserProfile>(userDTO);
				profile.Id = user.Id;
				_unit.UserProfileRepository.Create(profile);
				_unit.Save();
			}
		}
		public async Task<ClaimsIdentity> AuthenticateAsync(string UserName,string Password)
		{
			ClaimsIdentity claim = null;
			UserLogin user = await _unit.UserRepository.FindAsync(UserName, Password);
			if (user != null)
				claim = await _unit.UserRepository.CreateIdentityAsync(user,DefaultAuthenticationTypes.ExternalBearer);
			return claim;
		}

		public async Task<bool> IsAdmin(string Email)
		{
			UserLogin user = await _unit.UserRepository.FindByEmailAsync(Email);
			if (user == null)
			{
				throw new NotFoundException("A user with that email doesn`t exist");
			}
			if (user.Roles.Count == 1)
			{
				return false;
			}
			else return true;
		}
		public async Task<string> GetId(string Email)
		{
			UserLogin user = await _unit.UserRepository.FindByEmailAsync(Email);
			if (user == null)
			{
				throw new NotFoundException("A user with that email doesn`t exist");
			}
			return user.Id;
		}
		public async Task<bool> IsExistsAsync(string Email)
		{
			UserLogin user = await _unit.UserRepository.FindByEmailAsync(Email);
			if (user == null)
			{
				return false;
			}
			else return true;
		}
	}
}
