using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public AdminRepository()
        {
            connectionString = DBConnectionUtility.GetConnectedString();
            cmd = new SqlCommand();
        }
        public Admin Authenticate(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from admin where username=@username";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        return new Admin
                        {
                            AdminID = (int)reader["AdminID"],
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool DeleteAdminByID(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "delete from admin where AdminID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    conn.Open();
                    int rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
            }
            catch (SqlException se)
            {
                if (se.Class == 11)
                {
                    throw new DatabaseConnectionException("Error connecting to Database.\nName of the database is not present in the SQL server.", se);
                }
                else if (se.Class == 20)
                {
                    throw new DatabaseConnectionException("Incorrect Server Name.", se);
                }
                else
                {
                    throw new DatabaseConnectionException("An error occurred while fetching admin data.", se);
                }
                return false;
            }
        }

        public Admin GetAdminByID(int AdminID)
        {
            try
            {
                Admin admin = new Admin();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select * from Admin where AdminID=@adminID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@adminID", AdminID);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        admin.AdminID = (int)reader["AdminID"];
                        admin.FirstName = (string)reader["FirstName"];
                        admin.LastName = (string)reader["LastName"];
                        admin.Email = (string)reader["Email"];
                        admin.PhoneNumber = (string)reader["PhoneNumber"];
                        admin.UserName = (string)reader["Username"];
                        admin.Password = (string)reader["Password"];
                        admin.Role = (string)reader["Role"];
                        admin.JoinDate = (DateTime)reader["JoinDate"]; ;

                    }
                    return admin;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                return null;
            }
        
        public Admin GetAdminByUsername(string userName)
        {
            try
            {
                Admin admin = new Admin();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select * from Admin where UserName=@userName";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@adminID", userName);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        admin.AdminID = (int)reader["AdminID"];
                        admin.FirstName = (string)reader["FirstName"];
                        admin.LastName = (string)reader["LastName"];
                        admin.Email = (string)reader["Email"];
                        admin.PhoneNumber = (string)reader["PhoneNumber"];
                        admin.UserName = (string)reader["Username"];
                        admin.Password = (string)reader["Password"];
                        admin.Role = (string)reader["Role"];
                        admin.JoinDate = (DateTime)reader["JoinDate"]; ;

                    }
                    return admin;
                }
            }
            catch (SqlException se)
            {
                if (se.Class == 11)
                {
                    throw new DatabaseConnectionException("Error connecting to Database.\nName of the database is not present in the SQL server.", se);
                }
                else if (se.Class == 20)
                {
                    throw new DatabaseConnectionException("Incorrect Server Name.", se);
                }
                else
                {
                    throw new DatabaseConnectionException("An error occurred while fetching admin data.", se);
                }
                return null;
            }
        }

        

        public bool RegisterAdmin(Admin admin)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "insert into Admin( AdminID,FirstName,LastName,Email,PhoneNumber,Username,Password,Role,JoinDate) values(@id,@fName,@lName,@email,@phone,@user,@pw,@role,@join_date)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", admin.AdminID);
                    cmd.Parameters.AddWithValue("@fName", admin.FirstName);
                    cmd.Parameters.AddWithValue("@lName", admin.LastName);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@phone", admin.PhoneNumber);
                    cmd.Parameters.AddWithValue("@user", admin.UserName);
                    cmd.Parameters.AddWithValue("@pw", admin.Password);
                    cmd.Parameters.AddWithValue("@role", admin.Role);
                    cmd.Parameters.AddWithValue("@join_date", admin.JoinDate);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool UpdateAdmin(Admin adminData, string username)
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "UPDATE admin SET PhoneNumber=@phone, Role=@r, FirstName=@fname, LastName=@lname, Email=@eml WHERE Username=@uname";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@phone", adminData.PhoneNumber);
                    cmd.Parameters.AddWithValue("@r", adminData.Role);
                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@fname", adminData.FirstName);
                    cmd.Parameters.AddWithValue("@lname", adminData.LastName);
                    cmd.Parameters.AddWithValue("@eml", adminData.Email);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int updatedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine(updatedRows);
                    return updatedRows > 0;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
                return false;
            }
        
    }
}

