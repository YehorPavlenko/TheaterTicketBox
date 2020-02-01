using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PL
{
	public class SeatModel
	{
		public int Id { get; set; }
		[Required]
		public int HallId { get; set; } 
		[Required]
		public int RowNumber { get; set; }
		[Required]
		public int SeatNumber { get; set; }
	}
}