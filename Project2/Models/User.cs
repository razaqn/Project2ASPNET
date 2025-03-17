using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class User
    {
        private Koneksi koneksi;

        public User()
        {
            koneksi = new Koneksi();
        }

        public bool Create(string username, string password, string role)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", koneksi.GetConnection()))
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

        public bool Update(int userId, string username, string password, string role)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserId = @UserId", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

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

        public bool Delete(int userId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", koneksi.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

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