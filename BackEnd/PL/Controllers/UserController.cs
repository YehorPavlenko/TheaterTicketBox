using AutoMapper;
using BLL;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PL.App_Start;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Http.Cors;

namespace PL.Controllers
{

	public class UserController : ApiController
	{
		private IUserService _userService;
		private ITicketService _ticketService;
		private IMapper _mapper;
		public UserController(IUserService service,ITicketService ticketService)
		{
			_userService = service;
			_ticketService = ticketService;
			_mapper = Mapper.Instance;
		}

		[HttpGet]
		[Authorize(Roles = "User")]
		[Route("Users/{Id}/Tickets")]
		public IHttpActionResult GetUserTickets(string Id)
		{
			try
			{
				IEnumerable<TicketDTO> ticketDTO = _ticketService.GetUserTickets(Id);
				List<TicketModel> tickets = new List<TicketModel>();
				foreach (TicketDTO t in ticketDTO)
				{
					TicketModel tick = _mapper.Map<TicketModel>(t);
					tickets.Add(tick);
				}
				return Ok(tickets);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		[Route("User/GetId")]
		public async Task<IHttpActionResult> GetId(string Email)
		{
			try
			{
				string res = await _userService.GetId(Email);
				return Ok(res);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}


		[HttpGet]
		[AllowAnonymous]
		[Route("User/IsAdmin")]
		public async Task<IHttpActionResult> IsAdmin(string Email)
		{
			try
			{
				bool res = await _userService.IsAdmin(Email);
				if (res == true)
				{
					return Ok(res);
				}
				return Ok(false);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpPost]
		[AllowAnonymous] 
		[Route("Registrate")]
		public async Task<IHttpActionResult> Registrate(UserRegistrationModel userModel)
			{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (!await _userService.IsExistsAsync(userModel.Email))
			{
				try
				{
					UserDTO user = _mapper.Map<UserDTO>(userModel);
					await _userService.CreateUserAsync(user);
					return Ok("You were registered");
				}
				catch (Exception ex)
				{
					return InternalServerError(ex);
				}
			}
			else
			{
				return BadRequest("This user is already created");
			}
		} 
	}
}
