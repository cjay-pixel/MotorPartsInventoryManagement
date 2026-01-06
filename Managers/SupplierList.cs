using System;
using System.Collections.Generic;
using System.Data;
using MotorPartsInventoryManagement.Database;

namespace MotorPartsInventoryManagement.Managers
{
    public class SupplierList
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        // 🔹 Load ALL suppliers
        public static List<SupplierList> GetAll()
        {
            List<SupplierList> list = new List<SupplierList>();

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery(
                "GetAllSuppliers"
            );

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SupplierList
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
    }
}
