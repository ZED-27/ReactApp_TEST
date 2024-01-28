using Microsoft.EntityFrameworkCore;
using ReactApp_v9.Models;

namespace ReactApp_v9.Data
{
    public class PhoneDbContext : DbContext
    {
        public DbSet<Phone> Phones => Set<Phone>();
        public PhoneDbContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Phones.db");
        }
    }
}
