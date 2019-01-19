﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GabsWinformEF.Models;
using Newtonsoft.Json;
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
                var users = GetAll();
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

            SetResponse responseSet = await _client.SetAsync(_firebaseEndpoint + "/" + user.Id, user);
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

        public List<User> GetAll()
        {
            FirebaseResponse responseGet = _client.GetAsync(_firebaseEndpoint).Result;
            var result = responseGet.ResultAs<Dictionary<string,User>>(); //The response will contain the data being retreived
            var users = result.Select(s => s.Value).ToList();
            return users;
        }

        public IFirebaseClient GetFirebaseClient()
        {
            return _client;
        }

        public static async Task<EventStreamResponse> Listen(IFirebaseClient firebaseClient, string firebaseEndpoint)
        {
            EventStreamResponse response = await firebaseClient.OnAsync(firebaseEndpoint,
            added: (sender, args, d) =>
            {
                //Debug.WriteLine("ADDED " + args.Data + " -> 2\n");
            },
            changed: (sender, args, d) =>
            {
                //Debug.WriteLine("CHANGED " + args.Data);
            },
            removed: (sender, arg, ds) =>
            {
                // Debug.WriteLine("REMOVED " + args.Path);
            });

            return response;

            //Call dispose to stop listening for events
            //response.Dispose();
        }

        public void StopListening(EventStreamResponse eventResponse)
        {
            eventResponse.Dispose();
        }
    }
}
