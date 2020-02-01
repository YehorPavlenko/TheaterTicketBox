using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL
{
	public class PerformanceModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		public string Director { get; set; }
		[Required]
		public string Genre { get; set; }
		
		public string PhotoPath { get; set; }
	}
}