using System;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;
using MotorPartsInventoryManagement.Models;

namespace MotorPartsInventoryManagement.Managers
{
    internal class UserManager
    {
        // Login method using stored procedure
        public static User Login(string username, string password)
        {
            try
            {
                MySqlParameter[] parameters = {
                    new MySqlParameter("p_Username", username),
                    new MySqlParameter("p_Password", password)
                };

                DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_UserLogin", parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string role = row["ROLE"].ToString();

                    User user = null;

                    // Create appropriate user object based on role
                    switch (role)
                    {
                        case "Admin":
                            user = new Admin();
                            break;
                        case "Cashier":
                            user = new Cashier();
                            break;
                        case "StockStaff":
                            user = new StockStaff();
                            break;
                    }

                    if (user != null)
                    {
                        user.UserID = Convert.ToInt32(row["UserID"]);
                        user.Username = row["Username"].ToString();
                        user.FirstName = row["FirstName"].ToString();
                        user.LastName = row["LastName"].ToString();
                        user.Role = role;
                        user.Status = row["STATUS"].ToString();
                    }

                    return user;
                }

                return null; // Login failed
            }
            catch (Exception ex)
            {
                throw new Exception("Login error: " + ex.Message);
            }
        }
    }
}