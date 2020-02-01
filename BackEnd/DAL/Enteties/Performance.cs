using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Performance
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Director { get; set; }
		public string Genre { get; set; }
		public string PhotoPath { get; set; }
		public virtual ICollection<Session> Sessions { get; set; }
		public Performance()
		{
			Sessions = new List<Session>();
		}
	}
}
