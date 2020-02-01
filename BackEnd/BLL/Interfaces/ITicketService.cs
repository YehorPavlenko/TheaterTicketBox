using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public interface ITicketService
	{
		void UpdateTicket(TicketDTO ticketDTO);
		IEnumerable<TicketDTO> GetUserTickets(string Id);
	}
}
