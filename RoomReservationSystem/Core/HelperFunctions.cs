using System;

namespace Core {
	public static class HelperFunctions {
		public static Permission ConvertIntToPermission(int permissionlevel) {
			Permission permission = Permission.Student;
			switch (permissionlevel) {
				default: throw new Exception("Invalid Permission Level");
				case 0: permission = Permission.Student; break;
				case 1: permission = Permission.Teacher; break;
				case 2: permission = Permission.Admin; break;
			}
			return permission;
		}
	}
}
