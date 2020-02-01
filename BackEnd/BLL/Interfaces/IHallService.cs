using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public interface IHallService 
	{
		void CreateHall(HallDTO hallDTO);
		void RemoveHall(int id);
		void ChangeHallName(int id, string NewName);
		IEnumerable<HallDTO> GetAllHalls();
	}
}
