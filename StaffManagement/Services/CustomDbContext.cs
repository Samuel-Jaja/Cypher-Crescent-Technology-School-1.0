using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.Services
{
    public class CustomDbContext:DbContext
    {
        public CustomDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Samuel Jaja\Desktop\Dbase\aspnetcoredatabase.db");
            base.OnConfiguring(optionsBuilder);

            
        }
        public DbSet<Staff> StaffList { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
