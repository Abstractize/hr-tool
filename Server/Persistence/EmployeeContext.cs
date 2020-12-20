using System;
using Microsoft.EntityFrameworkCore;
using Server.Models;

#nullable disable

namespace Server.Persistence
{
    /// <summary>
    /// Context the refers to the Employee Database that stores the Employee Information.
    /// </summary>
    public partial class EmployeeContext : DbContext
    {
        /// <summary>
        /// Creates an Employee Context.
        /// </summary>
        public EmployeeContext()
        {
        }
        /// <summary>
        /// Creates an Employee Context with the given options.
        /// </summary>
        /// <param name="options">Options of the context</param>
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Set that stores the employees.
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Set that stores the employees data.
        /// </summary>
        public virtual DbSet<EmployeeData> EmployeeData { get; set; }
        /// <summary>
        /// Set that stores the employees images.
        /// </summary>
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__51C8DD7A1B7755A0");

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeData>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeData)
                    .HasName("PK__Employee__B0719101E92DA8F3");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.EmployeeDatumIdEmployeeNavigations)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__IdEmp__6C190EBB");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.EmployeeData)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeD__IdIma__6B24EA82");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.EmployeeDatumIdManagerNavigations)
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("FK__EmployeeD__IdMan__6D0D32F4");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.IdImage)
                    .HasName("PK__Image__C8C63E4A9F3A2E7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
