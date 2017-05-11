using Core;
using System;
using System.Data.SqlClient;

namespace DAL {
	public abstract class Database {
		private static string ConnInfo = @"Server=ealdb1.eal.local; Database=ejl73_db; User Id=ejl73_usr; Password=Baz1nga73";
		private static SqlConnection Conn;

		protected SqlConnection OpenConnection() {
			if (Conn == null) {
				Conn = new SqlConnection(ConnInfo);
			}

			Conn.Open();
			return Conn;
		}

		protected void CloseConnection() {
			Conn.Close();
		}

		protected Permission ConvertIntToPermission(int permissionlevel) {
			Permission permission = Permission.Student;
			switch(permissionlevel) {
				default: throw new Exception("Invalid Permission Level");
				case 0: permission = Permission.Student; break;
				case 1: permission = Permission.Teacher; break;
				case 2: permission = Permission.Admin; break;
			}
			return permission;
		}
	}
}
