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

            //End of Login method

            // Get all users
            public static DataTable GetAllUsers()
            {
                try
                {
                    return DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetAllUsers");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving users: " + ex.Message);
                }
            }

            // Get user by ID
            public static DataRow GetUserByID(int userID)
            {
                try
                {
                    MySqlParameter[] parameters = {
                        new MySqlParameter("p_UserID", userID)
                    };

                    DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetUserByID", parameters);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving user: " + ex.Message);
                }
            }

            // Add user
            public static bool AddUser(string username, string password, string firstName, string lastName, string role, string status)
            {
                try
                {
                    // Map UI role names to database role names
                    string dbRole = role;
                    if (role == "Stock Staff")
                    {
                        dbRole = "StockStaff";
                    }

                    MySqlParameter[] parameters = {
                        new MySqlParameter("p_Username", username),
                        new MySqlParameter("p_Password", password),
                        new MySqlParameter("p_FirstName", firstName),
                        new MySqlParameter("p_LastName", lastName),
                        new MySqlParameter("p_Role", dbRole),
                        new MySqlParameter("p_Status", status)
                    };

                    DatabaseHelper.ExecuteStoredProcedure("sp_AddUser", parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding user: " + ex.Message);
                }
            }

            // Update user
            public static bool UpdateUser(int userID, string username, string password, string firstName, string lastName, string role, string status)
            {
                try
                {
                    // Map UI role names to database role names
                    string dbRole = role;
                    if (role == "Stock Staff")
                    {
                        dbRole = "StockStaff";
                    }

                    MySqlParameter[] parameters = {
                        new MySqlParameter("p_UserID", userID),
                        new MySqlParameter("p_Username", username),
                        new MySqlParameter("p_Password", password ?? ""), // Empty string if null (don't update password)
                        new MySqlParameter("p_FirstName", firstName),
                        new MySqlParameter("p_LastName", lastName),
                        new MySqlParameter("p_Role", dbRole),
                        new MySqlParameter("p_Status", status)
                    };

                    DatabaseHelper.ExecuteStoredProcedure("sp_UpdateUser", parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating user: " + ex.Message);
                }
            }

            // Delete user (soft delete)
            public static bool DeleteUser(int userID)
            {
                try
                {
                    MySqlParameter[] parameters = {
                        new MySqlParameter("p_UserID", userID)
                    };

                    DatabaseHelper.ExecuteStoredProcedure("sp_DeleteUser", parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting user: " + ex.Message);
                }
            }

            // Check if username exists
            public static bool UsernameExists(string username, int? excludeUserID = null)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    if (excludeUserID.HasValue)
                    {
                        query += " AND UserID != @UserID";
                    }

                    MySqlParameter[] parameters = excludeUserID.HasValue
                        ? new MySqlParameter[] {
                            new MySqlParameter("@Username", username),
                            new MySqlParameter("@UserID", excludeUserID.Value)
                        }
                        : new MySqlParameter[] {
                            new MySqlParameter("@Username", username)
                        };

                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking username: " + ex.Message);
                }
        }
    }
}