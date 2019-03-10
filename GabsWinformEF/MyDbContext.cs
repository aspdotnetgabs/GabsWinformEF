using GabsWinformEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF
{
    class StudentAppDbContext : DbContext
    {
        public StudentAppDbContext() : base("StudentDb")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
