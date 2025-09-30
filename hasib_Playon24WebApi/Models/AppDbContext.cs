using Microsoft.EntityFrameworkCore;

namespace hasib_Playon24WebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee -> Department (nullable FK)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);

            // Attendance -> Employee
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeID)
                .OnDelete(DeleteBehavior.NoAction);

            // Unique constraint on Attendance (EmployeeID, AttendanceDate)
            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.EmployeeID, a.AttendanceDate })
                .IsUnique();
        }
    }
}
