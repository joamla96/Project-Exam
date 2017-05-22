using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public enum Permission
	{
		Student, Teacher, Admin
	}

	public enum Enviroment
	{
		Prod, Dev, Test
	}

	public static class SystemSettings
	{
		
		private static Enviroment Env = Enviroment.Prod;

		public static bool _threadRunning = true;

		public static Enviroment Enviroment
		{
			get { return Env; }
			set
			{
				// When we change enviroment, change the database as well...
				if (value == Enviroment.Dev || value == Enviroment.Test)
				{
					DAL.DatabaseConn.SystemEnviroment = 1;
				}
				else { DAL.DatabaseConn.SystemEnviroment = 0; }

				Env = value;
			}
		}
	}
}
