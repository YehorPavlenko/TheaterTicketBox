using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class TicketService : ITicketService
	{
		private IUnitOfWork _unit;
		private IMapper _mapper;
		public TicketService(IUnitOfWork unit)
		{
			_unit = unit;
			_mapper = Mapper.Instance;
		}
		public void UpdateTicket(TicketDTO ticketDTO)	
			{
            Ticket ticket = _mapper.Map<Ticket>(ticketDTO);
			Ticket DataTicket = _unit.TicketRepository.Get(ticket.Id);
			if (DataTicket == null)
			{
				throw new NotFoundException("Ticket is not found");
			}
			if (ticket.Status == "Bought")
			{
				DataTicket.Status = ticket.Status;
				DataTicket.UserProfileId = ticket.UserProfileId;
			}
			if (ticket.Status == "Canceled")
			{
				DataTicket.Status = "Free";
				DataTicket.UserProfileId = null;
			}
			if (ticket.Status == "Booking")
			{
				DataTicket.ReservationTime = DateTime.Now;
				DataTicket.ReservationTimeEnd = DataTicket.ReservationTime.AddSeconds(10);
				DataTicket.UserProfileId = ticket.UserProfileId;
				DataTicket.Status = "Booked";
			}
			_unit.TicketRepository.Update(DataTicket);
			_unit.Save();
		}

		public IEnumerable<TicketDTO> GetUserTickets(string Id)
		{
			List<Ticket> tickets = _unit.TicketRepository.GetAllQueryable().Where(t => t.UserProfileId == Id).ToList();
			List<TicketDTO> ticketsDTO = new List<TicketDTO>();
			if (tickets.Count == 0)
			{
				return ticketsDTO;
			}
			foreach (Ticket DataTicket in tickets)
			{
				if (DataTicket.Status == "Booked" && DateTime.Now > DataTicket.ReservationTimeEnd)
				{
					DataTicket.Status = "Free";
					DataTicket.UserProfileId = null;
				}
				_unit.TicketRepository.Update(DataTicket);
			}
			_unit.Save();
			foreach (Ticket tick in tickets)
			{
				if (tick.Status != "Free")
				{
					Session session = _unit.SessionRepository.Get(tick.SessionId);
					SessionDTO sessionDTO = _mapper.Map<SessionDTO>(session);
					TicketDTO t = _mapper.Map<TicketDTO>(tick);
					t.Session = sessionDTO;
					ticketsDTO.Add(t);
				}
			}
			return ticketsDTO;
		}
	}
}
