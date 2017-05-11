using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Core;
using System.Data;

namespace DAL {
	public class Users : Database {
		public List<User> GetAllUsers() {
			List<Dictionary<string, string>> usersInfo = this.GetAllUsersFromDatabase();
			List<User> users = new List<User>();

			foreach(Dictionary<string, string> userInfo in usersInfo) {
				int permissionLevel = int.Parse(userInfo["PermissionLevel"]);
				User newUser = new User(userInfo["Username"], userInfo["Email"], this.ConvertIntToPermission(permissionLevel));
				users.Add(newUser);
			}

			return users;
		}

		private List<Dictionary<string, string>> GetAllUsersFromDatabase() {
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
