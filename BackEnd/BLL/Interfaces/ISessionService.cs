using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public interface ISessionService 
	{
		void CreateSession(SessionDTO sessionDTO);
		void RemoveSession(int id);
		IEnumerable<SessionDTO> GetAllSessions();
        SessionDTO GetSession(int id);
	}
}
