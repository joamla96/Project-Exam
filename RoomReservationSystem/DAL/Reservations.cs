using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public interface IReservationsForMocking
    {
        List<Dictionary<string, string>> GetAllReservationsFromDatabase();
    }

    public class Reservations : Database, IReservationsForMocking
    {
        public List<Dictionary<string, string>> GetAllReservationsFromDatabase()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_GetAllReservations", conn)
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

        public List<Dictionary<string, string>> GetReservationFromDatabase(string id)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_GetReservation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("ID", id);

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

        public void DeleteReservationFromDatabase(string username, DateTime from, DateTime to)
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_DeleteReservation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("DateFrom", from);
            command.Parameters.AddWithValue("DateTo", to);

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void StoreReservationIntoDatabase(Dictionary<string, string> reservationinfo)
        {
            SqlConnection conn = this.OpenConnection();

            SqlCommand command = new SqlCommand("SP_InsertReservation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@PeopleNr", reservationinfo["PeopleNr"]));
            command.Parameters.Add(new SqlParameter("@DateTo", reservationinfo["DateTo"]));
            command.Parameters.Add(new SqlParameter("@DateFrom", reservationinfo["DateFrom"]));
            command.Parameters.Add(new SqlParameter("@Building", reservationinfo["Building"]));
            command.Parameters.Add(new SqlParameter("@FloorNr", reservationinfo["FloorNr"]));
            command.Parameters.Add(new SqlParameter("@Nr", reservationinfo["Nr"]));
            command.Parameters.Add(new SqlParameter("@Username", reservationinfo["Username"]));

            try
            {
                SqlDataReader reader = command.ExecuteReader();
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
