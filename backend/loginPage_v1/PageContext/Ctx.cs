using loginPage_v1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace loginPage_v1.PageContext
{
    public class Ctx : DbContext
    {
        public Ctx() : base("pagedb") { }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersBook> UsersBooks { get; set; }
    }
}