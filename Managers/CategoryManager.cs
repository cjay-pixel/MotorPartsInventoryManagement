using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MotorPartsInventoryManagement.Database;

namespace MotorPartsInventoryManagement.Managers
{
    public class CategoryManager
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int PartsCount { get; set; }

        // 🔹 Get all categories
        public static List<CategoryManager> GetAll()
        {
            List<CategoryManager> list = new List<CategoryManager>();

            DataTable dt = DatabaseHelper.ExecuteStoredProcedureQuery("GetAllCategories");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CategoryManager
                {
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    PartsCount = Convert.ToInt32(row["PartsCount"])
                });
            }

            return list;
        }

        // 🔹 Add a new category
        public static void Add(string categoryName)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_CategoryName", categoryName)
            };
            DatabaseHelper.ExecuteStoredProcedure("AddCategory", parameters);
        }

        // 🔹 Update an existing category
        public static void Update(int categoryId, string categoryName)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_CategoryID", categoryId),
                new MySqlParameter("@p_CategoryName", categoryName)
            };

            DatabaseHelper.ExecuteStoredProcedure("UpdateCategory", parameters);
        }

        // 🔹 Delete a category
        public static void Delete(int categoryId)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@p_CategoryID", categoryId)
            };

            DatabaseHelper.ExecuteStoredProcedure("DeleteCategory", parameters);
        }
    }
}