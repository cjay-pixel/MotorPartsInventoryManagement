using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;

namespace MotorPartsInventoryManagement.Managers
{
    public class InventoryManager
    {
        // 🔹 Properties
        public int TransactionID { get; set; }
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public int Quantity { get; set; }
        public string StockType { get; set; }
        public string ReferenceNumber { get; set; }
        public string Remarks { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
        public int QuantityNeeded { get; set; }
        public string Status { get; set; }



        // 🔹 Stock In
        public static void StockIn(int partID, int userID, int quantity, string referenceNumber, string remarks)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_Quantity", quantity),
                new MySqlParameter("@p_ReferenceNumber", referenceNumber),
                new MySqlParameter("@p_Remarks", remarks)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_StockIn", parameters);
        }

        // 🔹 Stock Out
        public static void StockOut(int partID, int userID, int quantity, string referenceNumber, string remarks)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_Quantity", quantity),
                new MySqlParameter("@p_ReferenceNumber", referenceNumber),
                new MySqlParameter("@p_Remarks", remarks)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_StockOut", parameters);
        }

        public static void RecordDamage(int partID, int userID, int quantity, string reason)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_Quantity", quantity),
                new MySqlParameter("@p_Reason", reason)
            };
            DatabaseHelper.ExecuteStoredProcedure("sp_RecordDamage", parameters);
        }

        // 🔹 Get all stock transactions
        public static List<InventoryManager> GetAllTransactions()
        {
            var list = new List<InventoryManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetAllStockTransactions");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    TransactionID = Convert.ToInt32(row["TransactionID"]),
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    StockType = row["StockType"].ToString(),
                    ReferenceNumber = row["ReferenceNumber"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"])
                });
            }

            return list;
        }

        // Stock Adjustments

        public static void StockAdjustment(int partID, int userID, int newQuantity, string remarks)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_UserID", userID),
                new MySqlParameter("@p_NewQuantity", newQuantity),
                new MySqlParameter("@p_Remarks", remarks)
            };
            DatabaseHelper.ExecuteStoredProcedure("sp_StockAdjustment", parameters);
        }



        // 🔹 Get transactions by part
        public static List<InventoryManager> GetTransactionsByPart(int partID)
        {
            var list = new List<InventoryManager>();

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetTransactionsByPart", parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    TransactionID = Convert.ToInt32(row["TransactionID"]),
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    StockType = row["StockType"].ToString(),
                    ReferenceNumber = row["ReferenceNumber"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"])
                });
            }

            return list;
        }

        // 🔹 Get transactions by date range
        public static List<InventoryManager> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            var list = new List<InventoryManager>();

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_StartDate", startDate),
                new MySqlParameter("@p_EndDate", endDate)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetTransactionsByDateRange", parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    TransactionID = Convert.ToInt32(row["TransactionID"]),
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    StockType = row["StockType"].ToString(),
                    ReferenceNumber = row["ReferenceNumber"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"])
                });
            }

            return list;
        }



        // 🔹 Get Stock In transactions only
        public static List<InventoryManager> GetStockInTransactions()
        {
            var list = new List<InventoryManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetStockInTransactions");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    StockType = row["StockType"].ToString(),
                    ReferenceNumber = row["ReferenceNumber"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"])  // ✅ FIXED: Use "TransactionDate" (the alias from the stored procedure)
                });
            }

            return list;
        }

        // 🔹 Get Stock Out transactions only
        public static List<InventoryManager> GetStockOutTransactions()
        {
            var list = new List<InventoryManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetStockOutTransactions");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    StockType = row["StockType"].ToString(),
                    ReferenceNumber = row["ReferenceNumber"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"])  // ✅ FIXED: Use "TransactionDate" (the alias from the stored procedure)
                });
            }

            return list;
        }
        public static List<InventoryManager> GetAllDamageRecords()
        {
            var list = new List<InventoryManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetAllDamageRecords");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InventoryManager
                {
                    TransactionID = Convert.ToInt32(row["DamageID"]),
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartName = row["PartName"].ToString(),
                    SupplierName = row["Supplier"].ToString(),
                    Quantity = Convert.ToInt32(row["QuantityAffected"]),
                    Remarks = row["Reason"].ToString(),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    TransactionDate = Convert.ToDateTime(row["Date"])
                });
            }

            return list;
        }
        public static List<InventoryManager> GetLowStockItems()
        {
            var list = new List<InventoryManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetLowStockItems");

            foreach (DataRow row in dt.Rows)
            {
                int quantityOnHand = Convert.ToInt32(row["QuantityOnHand"]);
                int reorderLevel = Convert.ToInt32(row["ReorderLevel"]);
                string status;

                if (quantityOnHand == 0)
                    status = "Out of Stock";
                else if (quantityOnHand <= reorderLevel)
                    status = "Low Stock";
                else
                    status = "Available";

                list.Add(new InventoryManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    Model = row["Model"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    SupplierName = row["SupplierName"].ToString(),
                    QuantityOnHand = quantityOnHand,
                    ReorderLevel = reorderLevel,
                    QuantityNeeded = Convert.ToInt32(row["QuantityNeeded"]),
                    Status = status
                });
            }

            return list;
        }

        public static int GetLowStockCount()
        {
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetLowStockCount");

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["LowStockCount"]);
            }

            return 0;
        }

        // 🔹 Get total products count
        public static int GetTotalProductsCount()
        {
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetTotalProductsCount");

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["TotalProducts"]);
            }

            return 0;
        }

        // 🔹 Get total revenue (last 30 days by default)
        public static decimal GetTotalRevenue()
        {
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetTotalRevenue");

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["TotalRevenue"]);
            }

            return 0;
        }

        // 🔹 Get total transactions count (last 30 days by default)
        public static int GetTotalTransactionsCount()
        {
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetTotalTransactionsCount");

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["TotalTransactions"]);
            }

            return 0;
        }
        public static DashboardStats GetDashboardStats()
        {
            DashboardStats stats = new DashboardStats
            {
                LowStockCount = GetLowStockCount(),
                TotalProducts = GetTotalProductsCount(),
                TotalRevenue = GetTotalRevenue(),
                TotalTransactions = GetTotalTransactionsCount()
            };

            return stats;
        }


        public class DashboardStats
        {
            public int LowStockCount { get; set; }
            public int TotalProducts { get; set; }
            public decimal TotalRevenue { get; set; }
            public int TotalTransactions { get; set; }
        }
    }

}



