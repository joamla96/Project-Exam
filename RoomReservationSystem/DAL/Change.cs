using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Change : Database
    {
        public List<Dictionary<string, string>> GetAllChangesFromDatabase()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_GetAllChanges", conn)
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

        public void DeleteChangeFromDatabase(int id)
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_DeleteChange", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("ID", id);

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void DeleteAllChangesFromDatabase()
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_DeleteAllChanges", conn)
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
