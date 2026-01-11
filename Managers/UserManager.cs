using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;
using MotorPartsInventoryManagement.Models;

namespace MotorPartsInventoryManagement.Managers
{
    public class UserManager
    {
        // 🔹 Properties
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        // 🔹 Login method
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

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Login error: " + ex.Message);
            }
        }

        // 🔹 Get all users
        public static List<UserManager> GetAll()
        {
            var list = new List<UserManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("GetAllUsers");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserManager
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Role = row["ROLE"].ToString(),
                    Status = row["STATUS"].ToString(),
                    DateCreated = Convert.ToDateTime(row["DateCreated"])
                });
            }

            return list;
        }

        // 🔹 Get user by ID
        public static UserManager GetByID(int userID)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetUserByID", parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new UserManager
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Role = row["ROLE"].ToString(),
                    Status = row["STATUS"].ToString(),
                    DateCreated = Convert.ToDateTime(row["DateCreated"])
                };
            }

            return null;
        }

        // 🔹 Add user
        public static void Add(string username, string password, string firstName, string lastName, string role, string status)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_Username", username),
                new MySqlParameter("@p_Password", password),
                new MySqlParameter("@p_FirstName", firstName),
                new MySqlParameter("@p_LastName", lastName),
                new MySqlParameter("@p_Role", role),
                new MySqlParameter("@p_Status", status)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_AddUser", parameters);
        }

        // 🔹 Update user
        public static void Update(int userID, string username, string firstName, string lastName, string role, string status)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_Username", username),
                new MySqlParameter("@p_FirstName", firstName),
                new MySqlParameter("@p_LastName", lastName),
                new MySqlParameter("@p_Role", role),
                new MySqlParameter("@p_Status", status)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_UpdateUser", parameters);
        }

        // 🔹 Update password
        public static void UpdatePassword(int userID, string newPassword)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_NewPassword", newPassword)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_UpdateUserPassword", parameters);
        }

        // 🔹 Delete user (soft delete)
        public static void Delete(int userID)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_DeleteUser", parameters);
        }

        // 🔹 Deactivate user
        public static void Deactivate(int userID)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_DeactivateUser", parameters);
        }

        // 🔹 Activate user
        public static void Activate(int userID)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_UserID", userID)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_ActivateUser", parameters);
        }

        // 🔹 Check if username exists
        public static bool UsernameExists(string username, int excludeUserID = 0)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_Username", username),
                new MySqlParameter("@p_ExcludeUserID", excludeUserID)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_CheckUsernameExists", parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Exists"]) > 0;
            }

            return false;
        }

        // 🔹 Hash password (simple implementation - consider using BCrypt or similar)
        //private static string HashPassword(string password)
        //{
        //    // IMPORTANT: This is a simple hash. For production, use BCrypt.Net or similar
        //    using (var sha256 = System.Security.Cryptography.SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        return Convert.ToBase64String(bytes);
        //    }
        //}
    }
}