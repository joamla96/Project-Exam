using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public enum Permision
	{
		Admin, Teacher, Student
	}
    public class Class1
    {
		public Permision PermissionLevel { get {
				return Permision.Admin;
			}
		}
	}
}
