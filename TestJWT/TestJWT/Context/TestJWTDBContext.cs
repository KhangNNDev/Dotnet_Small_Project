using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestJWT.Data.Models;

namespace TestJWT.Context
{
    public class TestJWTDBContext : DbContext
    {
        public TestJWTDBContext(DbContextOptions<TestJWTDBContext> options)
        : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}