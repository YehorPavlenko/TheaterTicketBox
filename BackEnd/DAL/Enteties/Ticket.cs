using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Ticket
	{
		public int Id { get; set; }
		public int SessionId { get; set; }
		public int SeatId { get; set; }
		public virtual Seat Seat { get; set; }
		public decimal Price { get; set; }
		public string Status { get; set; }
		public DateTime ReservationTime { get; set; }
		public DateTime ReservationTimeEnd { get; set; }
		public string UserProfileId { get; set; }
	}
}
