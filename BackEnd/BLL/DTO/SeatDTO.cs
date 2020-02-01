using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class SeatDTO
	{
		public int Id { get; set; }
		public int HallId { get; set; }
		public int RowNumber { get; set; }
		public int SeatNumber { get; set; }
	}
}
