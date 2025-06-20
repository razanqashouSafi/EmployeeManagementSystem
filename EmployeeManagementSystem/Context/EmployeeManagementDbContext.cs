﻿using EmployeeManagementSystem.Models;
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

            
        }
    }
}
