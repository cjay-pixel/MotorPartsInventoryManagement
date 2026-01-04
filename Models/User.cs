using System;

namespace MotorPartsInventoryManagement.Models
{
    public abstract class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        // Full name property
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        // Abstract method
        public abstract bool HasPermission(string permission);

        // Virtual method
        public virtual string GetRoleDescription()
        {
            return Role;
        }
    }

    // Admin class
    public class Admin : User
    {
        public Admin()
        {
            Role = "Admin";
        }

        public override bool HasPermission(string permission)
        {
            return true; // Admin has all permissions
        }

        public override string GetRoleDescription()
        {
            return "Administrator - Full System Access";
        }
    }

    // Cashier class
    public class Cashier : User
    {
        public Cashier()
        {
            Role = "Cashier";
        }

        public override bool HasPermission(string permission)
        {
            string[] allowedPermissions = { "SALES", "VIEW_ITEMS", "PRINT_RECEIPT" };
            return Array.Exists(allowedPermissions, p => p == permission);
        }

        public override string GetRoleDescription()
        {
            return "Cashier - Sales and Transaction Management";
        }
    }

    // Stock Staff class
    public class StockStaff : User
    {
        public StockStaff()
        {
            Role = "StockStaff";
        }

        public override bool HasPermission(string permission)
        {
            string[] allowedPermissions = { "STOCK_IN", "STOCK_OUT", "VIEW_ITEMS", "RECORD_DAMAGE", "ADJUSTMENTS" };
            return Array.Exists(allowedPermissions, p => p == permission);
        }

        public override string GetRoleDescription()
        {
            return "Stock Staff - Inventory Management";
        }
    }
}