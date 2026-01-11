using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;

namespace MotorPartsInventoryManagement.Managers
{
    public class MotorPartsManager
    {
        // 🔹 Properties
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string ProductName { get; set; }
        public string ModelCompatibility { get; set; }
        public string Brand { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int ReorderLevel { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string Image { get; set; }

        // 🔹 Get all motor parts
        public static List<MotorPartsManager> GetAll()
        {
            var list = new List<MotorPartsManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("GetAllInventory");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MotorPartsManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    ProductName = row["PartName"].ToString(),
                    ModelCompatibility = row["ModelCompatibility"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    ReorderLevel = Convert.ToInt32(row["ReorderLevel"]),
                    CostPrice = Convert.ToDecimal(row["CostPrice"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    Quantity = Convert.ToInt32(row["QuantityOnHand"]),
                    Status = Convert.ToInt32(row["QuantityOnHand"]) > 0 ? "Available" : "Unavailable",
                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
                    Image = row["Image"].ToString()
                });
            }

            return list;
        }

        // 🔹 Get motor part by ID
        //public static MotorPartsManager GetByID(int partID)
        //{
        //    MySqlParameter[] parameters =
        //    {
        //        new MySqlParameter("@p_PartID", partID)
        //    };

        //    DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetMotorPartByID", parameters);

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
        //        return new MotorPartsManager
        //        {
        //            PartID = Convert.ToInt32(row["PartID"]),
        //            PartNumber = row["PartNumber"].ToString(),
        //            ProductName = row["PartName"].ToString(),
        //            ModelCompatibility = row["ModelCompatibility"].ToString(),
        //            Brand = row["Brand"].ToString(),
        //            CategoryID = Convert.ToInt32(row["CategoryID"]),
        //            CategoryName = row["CategoryName"].ToString(),
        //            SupplierID = Convert.ToInt32(row["SupplierID"]),
        //            SupplierName = row["SupplierName"].ToString(),
        //            ReorderLevel = Convert.ToInt32(row["ReorderLevel"]),
        //            CostPrice = Convert.ToDecimal(row["CostPrice"]),
        //            SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
        //            Quantity = Convert.ToInt32(row["QuantityOnHand"]),
        //            Status = Convert.ToInt32(row["QuantityOnHand"]) > 0 ? "Available" : "Unavailable",
        //            DateCreated = Convert.ToDateTime(row["DateCreated"]),
        //            Image = row["Image"].ToString()
        //        };
        //    }

        //    return null;
        //}

        // 🔹 Add motor part
        public static void Add(string partNumber, string partName, string model, string brand, int categoryID, int supplierID, decimal costPrice, decimal sellingPrice, int reorderLevel, int quantityOnHand, string imagePath)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", 0),
                new MySqlParameter("@p_PartNumber", partNumber),
                new MySqlParameter("@p_PartName", partName),
                new MySqlParameter("@p_Model", model),
                new MySqlParameter("@p_Brand", brand),
                new MySqlParameter("@p_CategoryID", categoryID),
                new MySqlParameter("@p_SupplierID", supplierID),
                new MySqlParameter("@p_CostPrice", costPrice),
                new MySqlParameter("@p_SellingPrice", sellingPrice),
                new MySqlParameter("@p_ReorderLevel", reorderLevel),
                new MySqlParameter("@p_QuantityOnHand", quantityOnHand),
                new MySqlParameter("@p_ImagePath", imagePath)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_SaveMotorPart", parameters);
        }

        // 🔹 Update motor part
        public static void Update(int partID, string partNumber, string partName, string model, string brand, int categoryID, int supplierID, decimal costPrice, decimal sellingPrice, int reorderLevel, int quantityOnHand, string imagePath)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_PartNumber", partNumber),
                new MySqlParameter("@p_PartName", partName),
                new MySqlParameter("@p_Model", model),
                new MySqlParameter("@p_Brand", brand),
                new MySqlParameter("@p_CategoryID", categoryID),
                new MySqlParameter("@p_SupplierID", supplierID),
                new MySqlParameter("@p_CostPrice", costPrice),
                new MySqlParameter("@p_SellingPrice", sellingPrice),
                new MySqlParameter("@p_ReorderLevel", reorderLevel),
                new MySqlParameter("@p_QuantityOnHand", quantityOnHand),
                new MySqlParameter("@p_ImagePath", imagePath)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_SaveMotorPart", parameters);
        }

        // 🔹 Delete motor part
        public static void Delete(int partID)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_DeleteMotorPart", parameters);
        }

        // 🔹 Search motor parts by keyword
        public static List<MotorPartsManager> Search(string keyword)
        {
            var list = new List<MotorPartsManager>();

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_Keyword", keyword)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_SearchMotorParts", parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MotorPartsManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    ProductName = row["PartName"].ToString(),
                    ModelCompatibility = row["ModelCompatibility"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    ReorderLevel = Convert.ToInt32(row["ReorderLevel"]),
                    CostPrice = Convert.ToDecimal(row["CostPrice"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    Quantity = Convert.ToInt32(row["QuantityOnHand"]),
                    Status = Convert.ToInt32(row["QuantityOnHand"]) > 0 ? "Available" : "Unavailable",
                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
                    Image = row["Image"].ToString()
                });
            }

            return list;
        }

        // 🔹 Get motor parts by category
        public static List<MotorPartsManager> GetByCategory(int categoryID)
        {
            var list = new List<MotorPartsManager>();

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_CategoryID", categoryID)
            };

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetMotorPartsByCategory", parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MotorPartsManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    ProductName = row["PartName"].ToString(),
                    ModelCompatibility = row["ModelCompatibility"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    ReorderLevel = Convert.ToInt32(row["ReorderLevel"]),
                    CostPrice = Convert.ToDecimal(row["CostPrice"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    Quantity = Convert.ToInt32(row["QuantityOnHand"]),
                    Status = Convert.ToInt32(row["QuantityOnHand"]) > 0 ? "Available" : "Unavailable",
                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
                    Image = row["Image"].ToString()
                });
            }

            return list;
        }

        // 🔹 Get low stock parts
        public static List<MotorPartsManager> GetLowStock()
        {
            var list = new List<MotorPartsManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("sp_GetLowStockParts");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MotorPartsManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    ProductName = row["PartName"].ToString(),
                    ModelCompatibility = row["ModelCompatibility"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    ReorderLevel = Convert.ToInt32(row["ReorderLevel"]),
                    CostPrice = Convert.ToDecimal(row["CostPrice"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    Quantity = Convert.ToInt32(row["QuantityOnHand"]),
                    Status = Convert.ToInt32(row["QuantityOnHand"]) > 0 ? "Available" : "Unavailable",
                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
                    Image = row["Image"].ToString()
                });
            }

            return list;
        }

        // 🔹 Update quantity
        public static void UpdateQuantity(int partID, int newQuantity)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_PartID", partID),
                new MySqlParameter("@p_Quantity", newQuantity)
            };

            DatabaseHelper.ExecuteStoredProcedure("sp_UpdatePartQuantity", parameters);
        }
    }
}