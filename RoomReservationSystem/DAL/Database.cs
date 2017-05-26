using System;
using System.Data.SqlClient;
using System.Threading;

namespace DAL {
	public abstract class Database {
		private static string _connInfo = DatabaseConn.ConnString;
		private static SqlConnection _conn;
		protected object locked;

		protected SqlConnection OpenConnection() {
			Monitor.Enter(locked);	
			if (_conn == null) {
				_conn = new SqlConnection(_connInfo);
			}

			_conn.Open();
			return _conn;
		}

		protected void CloseConnection() {
			_conn.Close();
			Monitor.Exit(locked);
		}
	}
}
