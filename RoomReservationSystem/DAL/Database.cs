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
	}
}
