using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GabsWinformEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabsWinformEF.DAL
{
    class UserFirebaseRepository
    {
        private readonly IFirebaseClient _client;
        private readonly string _firebaseEndpoint;

        public UserFirebaseRepository(string apiKey, string databaseURL, string firebaseEndpoint)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = apiKey,
                BasePath = databaseURL
            };

            _client = new FirebaseClient(config);
            _firebaseEndpoint = firebaseEndpoint;
        }

        private  MyDbContext _db = new MyDbContext();

        public  bool Authenticate(string userEmail, string userPassword)
        {
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
                return true;
            }

            return false;
        }

        private  bool VerifyPasswordHash(string userPassword, byte[] passwordSalt, byte[] passwordHash)
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

        public async Task<User> Create(User user, string userPassword)
        {
            if (string.IsNullOrWhiteSpace(userPassword))
                return null;
            if (string.IsNullOrWhiteSpace(user.Email))
                return null;

            try
            {
                FirebaseResponse responseGet = await _client.GetAsync(_firebaseEndpoint);
                var users = responseGet.ResultAs<List<User>>(); //The response will contain the data being retreived
                var userExists = users.Where(x => x.Email == user.Email).Count() > 0;
                if (userExists)
                {
                    MessageBox.Show("User already exist");
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Create PasswordHash
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPassword));
            }

            user.Id = Guid.NewGuid();
            user.IsActive = true;

            SetResponse responseSet = await _client.SetAsync(_firebaseEndpoint, user);
            var userResult = responseSet.ResultAs<User>();

            return userResult;
        }

        public  User Update(User updateUser, string userPassword = "", string newPassword = "")
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

        public  List<User> GetAll()
        {
            var users = _db.Users.ToList();
            return users;
        }

        public  User GetUserById(Guid userId)
        {
            var user = _db.Users.Find(userId);
            return user;
        }

        public  User GetUserByEmail(string userEmail)
        {
            var user = _db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            return user;
        }

    }
}
