using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public enum Permission { Student, Teacher, Admin }
	public enum Enviroment { Prod, Dev, Test }

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
				UpdateSystemEnvironment();
				Env = value;
			}
		}

		public static void UpdateSystemEnvironment()
		{
			if (Env	 == Enviroment.Test) { DAL.DatabaseConn.systemEnviroment = 1; }
			else { DAL.DatabaseConn.systemEnviroment = 0; }
		}
	}
}
