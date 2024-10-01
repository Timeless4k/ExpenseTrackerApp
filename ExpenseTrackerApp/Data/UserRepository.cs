using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Data
{
    public class UserRepository
    {
        private readonly ExpenseContext _context;

        public UserRepository(ExpenseContext context)
        {
            _context = context;
        }

        // Method to create a new user (Sign-Up)
        public bool CreateUser(string firstName, string lastName, string email, string password)
        {
            // Check if the user with the same email already exists
            if (_context.Users.Any(u => u.Email == email))
            {
                return false; // Email already exists
            }

            // Hash the password before saving to the database
            string passwordHash = HashPassword(password);

            // Create a new user object
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = passwordHash
            };

            // Add the user to the context and save changes
            _context.Users.Add(user);
            _context.SaveChanges();

            return true; // User created successfully
        }

        // Method to validate user credentials (Login) using email and password
        public User GetUserByEmailAndPassword(string email, string password)
        {
            // Fetch the user by email
            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            // If user doesn't exist or password doesn't match, return null
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null; // Credentials are invalid
            }

            return user; // Return the valid user
        }

        // Private method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Private method to verify if the entered password matches the stored hash
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}
