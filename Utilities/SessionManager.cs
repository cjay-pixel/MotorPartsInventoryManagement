using MotorPartsInventoryManagement.Models;

namespace MotorPartsInventoryManagement.Utilities
{
    public static class SessionManager
    {
        // Stores the currently logged-in user
        public static User CurrentUser { get; set; }

        // Check if a user is logged in
        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        // Get the current user's full name
        public static string CurrentUserName
        {
            get { return CurrentUser?.FullName ?? "Guest"; }
        }

        // Get the current user's role
        public static string CurrentUserRole
        {
            get { return CurrentUser?.Role ?? "None"; }
        }

        // Get the current user's ID
        public static int CurrentUserID
        {
            get { return CurrentUser?.UserID ?? 0; }
        }

        // Clear the current session (logout)
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