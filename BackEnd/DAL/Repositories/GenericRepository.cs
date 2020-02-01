using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity :class
	{
		internal TheaterTicketBoxContext _context;
		internal DbSet<TEntity> _dbSet;
		public GenericRepository(TheaterTicketBoxContext context)
		{
			this._context = context;
			_dbSet = context.Set<TEntity>();
		}
		public virtual void Create(TEntity item)
		{
			_dbSet.Add(item);
		}

		public virtual void Delete(TEntity item)
		{
			_dbSet.Remove(item);
		}
			
		public virtual TEntity Get(int id)
		{

			 return _dbSet.Find(id);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return _dbSet;
		}

		public virtual void Update(TEntity item)
		{
			_dbSet.Attach(item);
			_context.Entry<TEntity>(item).State = EntityState.Modified;
		}

	}
}
