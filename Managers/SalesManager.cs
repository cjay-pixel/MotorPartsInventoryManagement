using MotorPartsInventoryManagement.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPartsInventoryManagement.Managers
{
    public class SalesManager
    {
        // 🔹 Properties
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
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
                    Brand = row["Brand"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    TotalStock = Convert.ToInt32(row["TotalStock"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    ImagePath = row["ImagePath"].ToString()
                });
            }

            return list;
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