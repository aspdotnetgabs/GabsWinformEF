using GabsWinformEF;
using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public int Id { get; set; }
    //Login info
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime? LastLogin { get; set; }
    public bool IsActive { get; set; } = true;
    public string Roles { get; set; } // comma-separated
    // Profile info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    // Add more user profile field here...


    // Change this to your desired default admin login and password
    private const string DEFAULT_ADMIN_LOGIN = "admin";
    // Change this to your DbContext class
    private static MyDbContext _db = new MyDbContext();

    #region UserRepository
    private static User CurrentUser = null;

    public static bool Authenticate(string userEmail, string userPassword)
    {
        CreateAdmin();

        if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userPassword))
            return false;

        var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
        if (user == null)
            return false;
        if (!user.IsActive)
            return false;

        bool valid = VerifyPasswordHash(userPassword, user.PasswordSalt, user.PasswordHash);
        if (valid)
        {
            user.LastLogin = DateTime.Now;
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            CurrentUser = user; // Set current user
            return true;
        }

        return false;
    }

    private static bool VerifyPasswordHash(string userPassword, byte[] passwordSalt, byte[] passwordHash)
    {
        // Verify PasswordHash
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPassword));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }
        }

        return true;
    }

    public static User Create(User user, string userPassword)
    {
        if (string.IsNullOrWhiteSpace(userPassword))
            return null;
        if (string.IsNullOrWhiteSpace(user.Email))
            return null;

        var userExists = _db.Users.Where(x => x.Email == user.Email).Count() > 0;


        if (userExists)
            return null;

        // Create PasswordHash
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            user.PasswordSalt = hmac.Key;
            user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPassword));
        }

        user.IsActive = true;
        _db.Users.Add(user);
        _db.SaveChanges();

        return user;
    }

    private static void CreateAdmin()
    {
        var hasUsers = _db.Users.Where(x=>x.Roles.Contains(DEFAULT_ADMIN_LOGIN)).Count() > 0;
        if (!hasUsers)
        {
            var newAdmin = new User
            {
                Email = DEFAULT_ADMIN_LOGIN,
                FirstName = "DefaultAdmin",
                LastName = "Administrator",
                Roles = DEFAULT_ADMIN_LOGIN + ",user"
            };
            Create(newAdmin, DEFAULT_ADMIN_LOGIN);
        }
    }

    public static User Update(User updateUser, string userPassword = "", string newPassword = "")
    {
        var user = _db.Users.Where(x => x.Email == updateUser.Email).FirstOrDefault();
        if (user == null)
            return null;
        else
        {
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Phone = updateUser.Phone;
        }

        if (!string.IsNullOrWhiteSpace(userPassword) || !string.IsNullOrWhiteSpace(newPassword))
        {
            var validPassword = VerifyPasswordHash(userPassword, user.PasswordSalt, user.PasswordHash);
            if (validPassword)
            {
                // Overwrite with new PasswordHash
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPassword));
                }
            }
        }

        _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        _db.SaveChanges();

        return user;
    }

    public static List<User> GetAll()
    {
        var users = _db.Users.ToList();
        return users;
    }

    public static User GetUserById(int userId)
    {
        var user = _db.Users.Find(userId);
        return user;
    }

    public static User GetUserByEmail(string userEmail)
    {
        var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
        return user;
    }

    public static User GetCurrentUser()
    {
        return CurrentUser;
    }

    public static string[] GetUserRoles(int userId)
    {
        var user = GetUserById(userId);
        if (user != null)
            return user.Roles.Split(',');
        else
            return new string[] { string.Empty };
    }

    public static string[] GetUserRoles(string userEmail)
    {
        var user = GetUserByEmail(userEmail);
        return GetUserRoles(user.Id);
    }

    public static User Deactivate(string userEmail)
    {
        var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
        if (user != null)
        {
            user.IsActive = false;
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return user;
        }
        else
            return null;

    }

    public static User Activate(string userEmail)
    {
        var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
        if (user != null)
        {
            user.IsActive = true;
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return user;
        }
        else
            return null;

    }
    #endregion

}
