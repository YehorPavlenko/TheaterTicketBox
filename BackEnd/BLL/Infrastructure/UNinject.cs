using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Ninject.Modules;

namespace BLL
{
	public class UNinject : NinjectModule
	{
		public override void Load()
		{
			Bind<IUnitOfWork>().To<UnitOfWork>();
		}
	}
}
