using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class HallDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int NumberOfSeats { get; set; }
		public int NumberOfRows { get; set; }
		public int NumberOfSeatsInRow { get; set; }
		public ICollection<SeatDTO> Seats { get; set; }
		public HallDTO()
		{
			Seats = new List<SeatDTO>();
		}

	}
}
