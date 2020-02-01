using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IUnitOfWork:IDisposable
	{
		IRepository<Hall> HallRepository { get; }
		IPerformanceRepository PerformanceRepository { get; }
		IRepository<Seat> SeatRepository { get; }
		IRepository<Session> SessionRepository { get; }
		ITicketRepository TicketRepository { get; }
		IRepository<UserProfile> UserProfileRepository { get; }
		RoleManager<UserRole> RoleRepository { get; }
		UserManager<UserLogin> UserRepository { get; }
		void Save();

	}
}
