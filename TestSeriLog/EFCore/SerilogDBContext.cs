using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestSeriLog.model;
using TestSeriLog.Models;

namespace TestSeriLog.EFCore
{
    public class SerilogDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        public SerilogDBContext(DbContextOptions<SerilogDBContext> options) : base(options)
        {
        }
    }
}