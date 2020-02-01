using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL
{
	public class SessionModel
	{
		public int Id { get; set; }
		[Required]
		public string Date { get; set; }
		public HallModel Hall { get; set; }	
		public PerformanceModel Performance {get;set;}
	
		[Required]
        public int PerformanceId { get; set; }
		[Required]
		public int HallId { get; set; }
		public ICollection<TicketModel> Tickets { get; set; }
		public SessionModel()
		{
			Tickets = new List<TicketModel>();
		}
	}
}