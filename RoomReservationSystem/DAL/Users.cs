using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
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

            SqlCommand command = new SqlCommand("SP_GetAllUsers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader[i].ToString());
                        }
                        result.Add(row);
                    }
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public List<Dictionary<string, string>> GetUserFromDatabase(string username)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_GetUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("Username", username);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader[i].ToString());
                        }
                        result.Add(row);
                    }
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public void InsertUserToDatabase(string username, string email, int permission)
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_InsertUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("PermissionLevel", permission);

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void DeleteUserFromDatabase(string username)
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_DeleteUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("Username", username);

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void DeleteAllUserFromDatabase()
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_DeleteAllUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };


            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.CloseConnection();
            }

        }
    }
}
