using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TheaterTicketBox.Controllers
{
	[Authorize]
    public class ValueController : ApiController
    {
		public IEnumerable<string> Get()
		{
			return new string[]	 { "value1", "value2" };
		}
    }
}
