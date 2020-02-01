using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BLL;
using Microsoft.AspNet.Identity;

namespace TheaterTicketBox.Controllers
{
	public class UserController : ApiController
    {
		private IUserService _userService;
		private  IMapper _mapper;
		public UserController(IUserService service)
		{
			_userService = service;
			_mapper = Mapper.Instance;
		}
		[HttpPost]
		[Route("Registrate")]
		public async Task<IHttpActionResult> Registrate(UserRegistrationModel userModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			UserDTO user = _mapper.Map<UserDTO>(userModel);
			await _userService.Create(user);
			return Ok();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_userService.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}
