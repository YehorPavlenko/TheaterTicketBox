using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
	{
		public TicketRepository(TheaterTicketBoxContext context) : base(context) { }

		public IQueryable<Ticket> GetAllQueryable()
		{
			return _dbSet;
		}
	}
}
