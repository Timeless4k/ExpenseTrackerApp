using System;
using ExpenseTrackerApp.Models; // Assuming User is in the Models namespace

namespace ExpenseTrackerApp.Controllers
{
    public static class SessionManager
    {
        // A property to hold the currently logged-in user
        private static User _currentUser;

        // Getter for the current user
        public static User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    throw new InvalidOperationException("No user is currently logged in.");
                }
                return _currentUser;
            }
        }

        // Method to set the current user during login
        public static void SetCurrentUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _currentUser = user;
        }

        // Method to clear the session (logout)
        public static void Logout()
        {
            _currentUser = null; // Clear the current user
        }

        // Check if a user is logged in
        public static bool IsLoggedIn()
        {
            return _currentUser != null;
        }
    }
}
