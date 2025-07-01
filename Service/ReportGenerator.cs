using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarConnectApp.Entity;
using CarConnectApp.Util;
using CarConnectApp.CustomExceptions;

namespace CarConnectApp.Service
{
    public class ReportGenerator
    {
        private readonly string connectionString;

        public ReportGenerator()
        {
            connectionString = DBConnUtil.GetConnectionString();
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reservations.Add(MapReservation(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Error fetching reservations: " + ex.Message);
            }

            return reservations;
        }

        public List<Reservation> GetReservationsByCustomer(int customerId)
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation WHERE CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reservations.Add(MapReservation(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Error fetching customer reservations: " + ex.Message);
            }

            return reservations;
        }

        public List<Reservation> GetReservationsByVehicle(int vehicleId)
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation WHERE VehicleID = @VehicleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reservations.Add(MapReservation(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Error fetching vehicle reservations: " + ex.Message);
            }

            return reservations;
        }

        private Reservation MapReservation(SqlDataReader reader)
        {
            return new Reservation
            {
                ReservationID = Convert.ToInt32(reader["ReservationID"]),
                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                VehicleID = Convert.ToInt32(reader["VehicleID"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                Status = reader["Status"].ToString()
            };
        }
    }
}
