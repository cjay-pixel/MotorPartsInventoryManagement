using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MotorPartsInventoryManagement.Database
{
    internal class DatabaseHelper
    {
        // Get connection string from App.config
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        }

        // Get connection
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnectionString());
        }

        // Test connection
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }

        // Execute Non-Query (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database query error: " + ex.Message);
            }
        }

        // Execute Stored Procedure (Non-Query)
        public static int ExecuteStoredProcedure(string procedureName, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Stored procedure error: " + ex.Message);
            }
        }

        // Execute Query and Return DataTable
        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Query execution error: " + ex.Message);
            }
        }

        // Execute Stored Procedure and Return DataTable
        public static DataTable ExecuteStoredProcedureQuery(string procedureName, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Stored procedure query error: " + ex.Message);
            }
        }

        // Execute Scalar (returns single value)
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Scalar query error: " + ex.Message);
            }
        }
    }
}