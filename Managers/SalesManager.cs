using MotorPartsInventoryManagement.Database;
using MotorPartsInventoryManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MotorPartsInventoryManagement.Managers
{
    public class SalesManager
    {
        // 🔹 Properties
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string MotorCompatibility { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public int TotalStock { get; set; }
        public decimal SellingPrice { get; set; }
        public string ImagePath { get; set; }

        // 🔹 Get all products for sales (grouped by product name, combined stock)
        public static List<SalesManager> GetAll()
        {
            List<SalesManager> list = new List<SalesManager>();
            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("GetSaleProducts");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SalesManager
                {
                    PartID = Convert.ToInt32(row["PartID"]),
                    PartNumber = row["PartNumber"].ToString(),
                    PartName = row["PartName"].ToString(),
                    MotorCompatibility = row["MotorCompatibility"].ToString(),
                    Brand = row["Brand"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    TotalStock = Convert.ToInt32(row["TotalStock"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    ImagePath = row["ImagePath"].ToString()
                });
            }

            return list;
        }

        public static DataTable GetTodaysSales()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("GetTodaysSales", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static int ProcessSale(int userID, decimal totalAmount, decimal discountAmount, List<CartItem> cartItems)
        {
            try
            {
                // Convert cart items to JSON format for stored procedure
                var saleItemsJson = ConvertCartItemsToJson(cartItems);

                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@p_UserID", userID),
                    new MySqlParameter("@p_TotalAmount", totalAmount),
                    new MySqlParameter("@p_DiscountAmount", discountAmount),
                    new MySqlParameter("@p_SaleItems", saleItemsJson),
                    new MySqlParameter("@p_SaleID", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    }
                };

                DatabaseHelper.ExecuteStoredProcedure("sp_ProcessSale", parameters);

                // Get the output SaleID
                int saleID = Convert.ToInt32(parameters[4].Value);
                return saleID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing sale: " + ex.Message);
            }
        }

        private static string ConvertCartItemsToJson(List<CartItem> cartItems)
        {
            var items = cartItems.Select(item => new
            {
                PartID = item.PartID,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Subtotal = item.Subtotal
            }).ToList();

            return JsonConvert.SerializeObject(items);
        }

        // 🔹 Search products for sales
        public static List<SalesManager> Search(string keyword)
        {
            List<SalesManager> allProducts = GetAll();

            if (string.IsNullOrWhiteSpace(keyword))
                return allProducts;

            keyword = keyword.ToLower();

            return allProducts.Where(p =>
                p.PartName.ToLower().Contains(keyword) ||
                p.PartNumber.ToLower().Contains(keyword) ||
                p.Brand.ToLower().Contains(keyword) ||
                p.CategoryName.ToLower().Contains(keyword)
            ).ToList();
        }

        // 🔹 Filter by category
        public static List<SalesManager> FilterByCategory(string categoryName)
        {
            List<SalesManager> allProducts = GetAll();

            if (string.IsNullOrWhiteSpace(categoryName) || categoryName == "All")
                return allProducts;

            return allProducts.Where(p => p.CategoryName == categoryName).ToList();
        }

        // 🔹 Get available categories
        public static List<string> GetCategories()
        {
            List<SalesManager> allProducts = GetAll();
            return allProducts.Select(p => p.CategoryName).Distinct().OrderBy(c => c).ToList();
        }
    }
}