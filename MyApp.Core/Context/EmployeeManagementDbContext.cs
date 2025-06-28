
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Models;

namespace MyApp.Core.Context
{
    public class EmployeeManagementDbContextb: DbContext
    {

        public EmployeeManagementDbContextb(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
       .Property(e => e.Salary)
       .HasColumnType("decimal(18,2)");  

            base.OnModelCreating(modelBuilder);
        }
    }
}
