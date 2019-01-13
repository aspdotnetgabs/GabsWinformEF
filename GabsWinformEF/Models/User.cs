using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class User
    {
        public Guid Id { get; set; }
        //Login info
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        // Profile info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }
    }

    class PasswordValidation
    {
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool ValidationStatus { get; set; }
        public string ValidationMessage { get; set; }
    }
}
