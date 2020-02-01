	using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL
{
	public class HallModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }
		[Required]
		public int NumberOfSeats { get; set; }
		[Required]
		public int NumberOfRows { get; set; }
		[Required]
		public int NumberOfSeatsInRow { get; set; }

		public ICollection<SeatModel> Seats { get; set; }
		public HallModel()
		{
			Seats = new List<SeatModel>();
		}

	}
}