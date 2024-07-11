using Microsoft.EntityFrameworkCore;

namespace TestLogin.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
        
        public DbSet<Account> Account { get; set; }
    }
}
