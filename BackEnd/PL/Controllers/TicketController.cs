using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
	
    public class TicketController : ApiController
    {
		private ITicketService _ticketService;
		private IMapper _mapper;
		public TicketController(ITicketService service)
		{
			_ticketService = service;
			_mapper = Mapper.Instance;
		}
		[HttpPut]
		[Authorize(Roles = "User")]
		[Route("Tickets/{Id}")]
		public IHttpActionResult UpdateTicket(TicketModel ticketModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				TicketDTO ticketDTO = _mapper.Map<TicketDTO>(ticketModel);
				_ticketService.UpdateTicket(ticketDTO);
				return Ok("Ticket was updated");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
