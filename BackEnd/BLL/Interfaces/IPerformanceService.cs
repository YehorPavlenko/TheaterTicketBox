using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public interface IPerformanceService
	{
		void CratePerformance(PerformanceDTO performanceDTO);
		void RemovePerformance(int id);
		IEnumerable<PerformanceDTO> GetAllPerformances();
		PerformanceDTO GetPerformance(int id);
		PerformanceDTO GetPerformanceTracking(int id);
		void UpdatePerformance(PerformanceDTO performanceDTO);
	
	}
}
