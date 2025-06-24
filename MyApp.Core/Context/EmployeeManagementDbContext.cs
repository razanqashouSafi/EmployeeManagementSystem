using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Context
{
    public class EmployeeManagementDbContextb: DbContext
    {

        public EmployeeManagementDbContextb(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
       .HasIndex(e => e.PhoneNumber)
       .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

        }
    }
}
