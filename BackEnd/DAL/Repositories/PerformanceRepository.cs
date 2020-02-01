using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class PerformanceRepository : GenericRepository<Performance>,IPerformanceRepository
	{
		public PerformanceRepository(TheaterTicketBoxContext context):base(context) { }
		public  Performance GetTracking(int id)
		{
          return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
		}
	}
}
