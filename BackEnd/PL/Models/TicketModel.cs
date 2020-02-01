
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PL
{
	public class TicketModel
	{
		public int Id { get; set; }
		[Required]
		public int SessionId { get; set; }
		[Required]
		public SeatModel Seat { get; set; }
		public SessionModel Session { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public string UserProfileId { get; set; }
		
	}
}