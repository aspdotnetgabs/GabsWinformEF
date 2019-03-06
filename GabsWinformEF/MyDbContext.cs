﻿using GabsWinformEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnSqlServerRemote")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}