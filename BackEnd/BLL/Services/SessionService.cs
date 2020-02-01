using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class SessionService : ISessionService
	{
		private IUnitOfWork _unit;
		private IMapper _mapper;
		public SessionService(IUnitOfWork unit)
		{
			_unit = unit;
			_mapper = Mapper.Instance;
		}
		public void CreateSession(SessionDTO sessionDTO)
		{
			Session session = _mapper.Map<Session>(sessionDTO);
			List<Ticket> tickets = new List<Ticket>();
			session.Hall = _unit.HallRepository.Get(session.HallId);
			session.Performance = _unit.PerformanceRepository.Get(session.PerformanceId);
			_unit.SessionRepository.Create(session);
			_unit.Save();
			List<Seat> seats = _unit.SeatRepository.GetAll().Where(p => p.HallId == session.HallId).ToList();
			for (int i = 1; i <= session.Hall.NumberOfSeats; i++)
			 {
				Ticket ticket = new Ticket
				{
					SeatId = seats[0].Id,
					Seat = seats[0],
					SessionId = session.Id,
					Price = (decimal)(seats[0].RowNumber * 1.2 + 100),
					Status = "Free"
				};
				tickets.Add(ticket);
				seats.RemoveAt(0);
				_unit.TicketRepository.Create(ticket);
			}
			session.Tickets = tickets;
			_unit.Save();
		}
		public SessionDTO GetSession(int id)
		{
			Session session = _unit.SessionRepository.Get(id);
			if (session == null)
			{
				throw new NotFoundException("Session is not found");
			}
			foreach (Ticket DataTicket in session.Tickets)
			{
				if (DataTicket.Status == "Booked" && DateTime.Now > DataTicket.ReservationTimeEnd)
				{
					DataTicket.Status = "Free";
					DataTicket.UserProfileId = null;
				}
				_unit.TicketRepository.Update(DataTicket);
			}
			_unit.Save();
			SessionDTO sessionDTO = _mapper.Map<SessionDTO>(session);
			return sessionDTO;
		}
		public IEnumerable<SessionDTO> GetAllSessions()
		{
			IEnumerable<Session> sessions = _unit.SessionRepository.GetAll();
			List<SessionDTO> sessionsDTO = new List<SessionDTO>();
			foreach (Session s in sessions)
			{
				SessionDTO sess = _mapper.Map<SessionDTO>(s);
				sessionsDTO.Add(sess);
			}
			return sessionsDTO;
		}
		public void RemoveSession(int id)
		{
			Session session = _unit.SessionRepository.Get(id);
			if (session == null)
			{
				throw new NotFoundException("Session is not found");
			}
			List<Ticket> tickets = _unit.TicketRepository.GetAll().Where(p => p.SessionId == session.Id).ToList();
			foreach (Ticket t in tickets)
			{
				_unit.TicketRepository.Delete(t);
			}
			_unit.SessionRepository.Delete(session);
			_unit.Save();
		}
	}
}
