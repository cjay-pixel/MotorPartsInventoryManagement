using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;

namespace MotorPartsInventoryManagement.Managers
{
    public class SupplierManager
    {
        // 🔹 Properties
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        // 🔹 Get all suppliers
        public static List<SupplierManager> GetAll()
        {
            var list = new List<SupplierManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("GetAllSuppliers");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SupplierManager
                {
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    ContactFirstName = row["ContactFirstName"].ToString(),
                    ContactLastName = row["ContactLastName"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    Status = row["Status"].ToString(),
                    DateCreated = Convert.ToDateTime(row["DateCreated"])
                });
            }

            return list;
        }

        // 🔹 Add supplier
        public static void Add(string supplierName, string firstName, string lastName, string address, string phone, string email, string status)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_SupplierName", supplierName),
                new MySqlParameter("@p_ContactFirstName", firstName),
                new MySqlParameter("@p_ContactLastName", lastName),
                new MySqlParameter("@p_Address", address),
                new MySqlParameter("@p_Phone", phone),
                new MySqlParameter("@p_Email", email),
                new MySqlParameter("@p_Status", status)
            };

            DatabaseHelper.ExecuteStoredProcedure("AddSupplier", parameters);
        }

        // 🔹 Update supplier
        public static void Update(int supplierId, string supplierName, string firstName, string lastName, string address, string phone, string email, string status)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_SupplierID", supplierId),
                new MySqlParameter("@p_SupplierName", supplierName),
                new MySqlParameter("@p_ContactFirstName", firstName),
                new MySqlParameter("@p_ContactLastName", lastName),
                new MySqlParameter("@p_Address", address),
                new MySqlParameter("@p_Phone", phone),
                new MySqlParameter("@p_Email", email),
                new MySqlParameter("@p_Status", status)
            };

            DatabaseHelper.ExecuteStoredProcedure("UpdateSupplier", parameters);
        }

        // 🔹 Deactivate supplier
        public static void Deactivate(int supplierId)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_SupplierID", supplierId)
            };

            DatabaseHelper.ExecuteStoredProcedure("DeactivateSupplier", parameters);
        }
    }
}
