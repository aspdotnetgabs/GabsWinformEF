using GabsWinformEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.DAL
{
    static class UserRepository
    {
        private static MyDbContext _db = new MyDbContext();

        public static bool Authenticate(string userEmail, string userPassword)
        {
            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userPassword))
                return false;

            var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            if (user == null)
                return false;
            if (!user.IsActive)
                return false;

            bool valid = VerifyPasswordHash(userPassword, user.PasswordSalt, user.PasswordHash);
            if(valid)
            {
                user.LastLogin = DateTime.Now;
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
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

            user.Id = Guid.NewGuid();
            user.IsActive = true;
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
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

            if(!string.IsNullOrWhiteSpace(userPassword) || !string.IsNullOrWhiteSpace(newPassword))
            {
                var validPassword = VerifyPasswordHash(userPassword, user.PasswordSalt, user.PasswordHash);
                if(validPassword)
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

        public static User GetUserById(Guid userId)
        {
            var user = _db.Users.Find(userId);
            return user;
        }

        public static User GetUserByEmail(string userEmail)
        {
            var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            return user;
        }

        public static User Deactivate(string userEmail)
        {
            var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            user.IsActive = false;
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return user;
        }

        public static User Activate(string userEmail)
        {
            var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            user.IsActive = true;
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return user;
        }

    }
}
