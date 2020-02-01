using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Hall
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int NumberOfSeats { get; set; }
		public int NumberOfRows { get; set; }
		public int NumberOfSeatsInRow { get; set; }
		public virtual ICollection<Session> Sessions { get; set; }
		public virtual ICollection<Seat> Seats { get; set; }
		public Hall()
		{
			Sessions = new List<Session>();
			Seats = new List<Seat>();
		}
	}
}
