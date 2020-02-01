using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL
{
	public class UserModel
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public ICollection<TicketModel> Tickets { get; set; }
		public UserModel()
		{
			Tickets = new List<TicketModel>();
		}

	}
}