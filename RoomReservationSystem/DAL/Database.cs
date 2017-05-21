using System;
using System.Data.SqlClient;

namespace DAL {
	public abstract class Database {
		private static string _connInfo = @"Server=ealdb1.eal.local; Database=ejl73_db; User Id=ejl73_usr; Password=Baz1nga73";
		private static SqlConnection _conn;

		protected SqlConnection OpenConnection() {
			if (_conn == null) {
				_conn = new SqlConnection(_connInfo);
			}

			_conn.Open();
			return _conn;
		}

		protected void CloseConnection() {
			_conn.Close();
		}
	}
}
