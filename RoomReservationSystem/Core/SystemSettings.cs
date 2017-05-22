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
        public static bool _threadRunning = true;
		public static Enviroment Enviroment = Enviroment.Prod;
	}
}
