
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private TheaterTicketBoxContext _context;
		private IRepository<Hall> _hallRepository;
		private IPerformanceRepository _performanceRepository;
		private IRepository<Seat> _seatRepository;
		private IRepository<Session> _sessionRepository;
		private ITicketRepository _ticketRepository;
		private IRepository<UserProfile> _userProfileRepository;
		private RoleManager<UserRole> _roleManager;
		private UserManager<UserLogin> _userManager;
		private bool _disposed = false;

		public UnitOfWork()
		{
			_context = new TheaterTicketBoxContext();
		}

		public IRepository<Hall> HallRepository
		{
			get
			{
				if (_hallRepository == null)
				{
					_hallRepository = new GenericRepository<Hall>(_context);
				}
				return _hallRepository;
			}
		}
		public IPerformanceRepository PerformanceRepository
		{
			get
			{
				if (_performanceRepository == null)
				{
					_performanceRepository = new PerformanceRepository(_context);
				}
				return _performanceRepository;
			}
		}

		public IRepository<Seat> SeatRepository
		{
			get
			{
				if (_seatRepository == null)
				{
					_seatRepository = new GenericRepository<Seat>(_context);
				}
				return _seatRepository;
			}
		}

		public IRepository<Session> SessionRepository
		{
			get
			{
				if (_sessionRepository == null)
				{
					_sessionRepository = new GenericRepository<Session>(_context);
				}
				return _sessionRepository;
			}
		}
		public ITicketRepository TicketRepository
		{
			get
			{
				if (_ticketRepository == null)
				{
					_ticketRepository = new TicketRepository(_context);
				}
				return _ticketRepository;
			}
		}
		public IRepository<UserProfile> UserProfileRepository
		{
			get
			{
				if (_userProfileRepository == null)
				{
					_userProfileRepository = new GenericRepository<UserProfile>(_context);
				}
				return _userProfileRepository;
			}
		}
		public RoleManager<UserRole> RoleRepository
		{
			get
			{
				if (_roleManager == null)
				{
					_roleManager = new MyRoleManager(new RoleStore<UserRole>(_context));
				}
				return _roleManager;
			}
		}
		public UserManager<UserLogin> UserRepository
		{
			get
			{
				if (_userManager == null)
				{
					_userManager = new MyUserManager(new UserStore<UserLogin>(_context));
				}
				return _userManager;
			}
		}
		public void Save()
		{
			_context.SaveChanges();
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this._disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
		}
	}
}

