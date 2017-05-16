using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
    public interface IUsers
    {
        List<Dictionary<string, string>> GetAllUsers();
    }
	public class Users : Database
    {
		public List<Dictionary<string, string>> GetAllUsers()
        {
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

			SqlConnection conn = this.OpenConnection();

			SqlCommand command = new SqlCommand("SP_GetAllUsers", conn) {
				CommandType = CommandType.StoredProcedure
			};

			try {
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					while(reader.Read()) {
						Dictionary<string, string> row = new Dictionary<string, string>();
						for (int i = 0; i < reader.FieldCount; i++) {
							row.Add(reader.GetName(i), reader[i].ToString());
						}
						result.Add(row);
					}
				}
			} finally {
				this.CloseConnection();
			}

			return result;
		}
	}
}
