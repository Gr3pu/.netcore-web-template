using System;
using System.Collections.Generic;
using System.Text;

namespace CTApp.Data
{
	public interface IUnitOfWork
	{
		void Commit();
		void Rollback();
	}
}
