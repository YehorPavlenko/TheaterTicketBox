using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Session
	{
		public int Id { get; set; }
		public DateTime? Date { get; set; }
		public int PerformanceId { get; set; }
		public virtual Performance Performance { get; set; }
		public int HallId { get; set; }
		public virtual Hall Hall { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }
		public Session()
		{
			Tickets = new List<Ticket>();
		}
	}
}
