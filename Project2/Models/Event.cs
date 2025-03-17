using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class Event
    {
        private Koneksi koneksi;

        public Event()
        {
            koneksi = new Koneksi();
        }

        public bool Create(string eventName, string description, DateTime eventDate, string location, string status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Events (EventName, Description, EventDate, Location, Status) VALUES (@EventName, @Description, @EventDate, @Location, @Status)", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@Location", location);
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

        public bool Update(int eventId, string eventName, string description, DateTime eventDate, string location, string status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Events SET EventName = @EventName, Description = @Description, EventDate = @EventDate, Location = @Location, Status = @Status WHERE EventId = @EventId", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@Location", location);
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
    }
}