using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    class Rooms: Database
    {
        public List<Dictionary<string, string>> GetAllRooms()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_GetAllRooms", conn)
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
    }
}
