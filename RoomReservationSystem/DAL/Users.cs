using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
    public interface IUsersForMocking
    {
        List<Dictionary<string, string>> GetAllUsersFromDatabase();
    }
	public class Users : Database, IUsersForMocking
    {
		public List<Dictionary<string, string>> GetAllUsersFromDatabase()
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

		public void Insert(string username, string email, int permission) {
			SqlConnection conn = this.OpenConnection();

			SqlCommand command = new SqlCommand("SP_InsertUser", conn) {
				CommandType = CommandType.StoredProcedure
			};

			command.Parameters.AddWithValue("Username", username);
			command.Parameters.AddWithValue("Email", email);
			command.Parameters.AddWithValue("PermissionLevel", permission);

			try {
				command.ExecuteNonQuery();
			} finally {
				this.CloseConnection();
			}
		}

        
	}
}
