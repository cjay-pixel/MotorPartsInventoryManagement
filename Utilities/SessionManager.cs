using MotorPartsInventoryManagement.Models;

namespace MotorPartsInventoryManagement.Utilities
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool HasPermission(string permission)
        {
            if (!IsLoggedIn) return false;
            return CurrentUser.HasPermission(permission);
        }
    }
}