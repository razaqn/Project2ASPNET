using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project2.Models
{
    public class Event
    {
        private Koneksi koneksi;
        
        public Event()
        {
            koneksi = new Koneksi();
        }

        public bool Create(string eventName, string description, DateTime eventDate, string location,int Price, int Capacity,  string status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Events (EventName, EventDescription, EventDate, Location, Price, Capacity, Status) VALUES (@EventName, @Description, @EventDate, @Location, @Price, @Capacity, @Status)", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Capacity", Capacity);
                    cmd.Parameters.AddWithValue("@Status", status);

                    koneksi.OpenConnection();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public DataTable Read()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Events", koneksi.GetConnection()))
                {
                    koneksi.OpenConnection();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return dt;
        }

        public bool Update(int eventId, string eventName, string description, DateTime eventDate, string location, int Price, int Capacity)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Events SET EventName = @EventName, EventDescription = @Description, EventDate = @EventDate, Location = @Location, Price = @Price, Capacity = @Capacity WHERE EventId = @EventId", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Capacity", Capacity);

                    koneksi.OpenConnection();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public bool Delete(int eventId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Events WHERE EventId = @EventId", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);

                    koneksi.OpenConnection();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public DataTable Search(string searchTerm)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Events WHERE EventName LIKE @SearchTerm OR Description LIKE @SearchTerm OR Location LIKE @SearchTerm", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    
                    koneksi.OpenConnection();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return dt;
        }
    }
}