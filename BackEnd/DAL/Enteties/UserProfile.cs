using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserProfile
	{
		[Key]
		[ForeignKey("UserLogin")]
		public string Id { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public virtual UserLogin UserLogin { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }

		public UserProfile()
		{
			Tickets = new List<Ticket>();
		}
	}
}
