using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class PerformanceDTO
	{
		public const string Path = "https://localhost:44310/Photos/";
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Director { get; set; }
		public string Genre { get; set; }
		public string PhotoPath { get; set; }
	}
}
