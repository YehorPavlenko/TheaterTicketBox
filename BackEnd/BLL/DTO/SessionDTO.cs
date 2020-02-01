using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class SessionDTO
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public HallDTO Hall { get; set; }
		public PerformanceDTO Performance { get; set; }
		public int PerformanceId { get; set; }
		public int HallId { get; set; }
		public ICollection<TicketDTO> Tickets { get; set; }
		public SessionDTO()
		{
			Tickets = new List<TicketDTO>();
		}

	}
}
