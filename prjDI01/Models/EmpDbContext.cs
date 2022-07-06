using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prjDI01.Models
{
    public partial class EmpDbContext : DbContext
    {
        public EmpDbContext()
        {
        }

        public EmpDbContext(DbContextOptions<EmpDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TEmployee> TEmployees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\asp.net-Core\\prjDI01\\App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEmployee>(entity =>
            {
                entity.HasKey(e => e.FEmpId)
                    .HasName("PK__tEmploye__C4A26E9C695F6030");

                entity.ToTable("tEmployee");

                entity.Property(e => e.FEmpId)
                    .HasMaxLength(50)
                    .HasColumnName("fEmpId");

                entity.Property(e => e.FEmploymentDate)
                    .HasColumnType("date")
                    .HasColumnName("fEmploymentDate");

                entity.Property(e => e.FGender)
                    .HasMaxLength(50)
                    .HasColumnName("fGender");

                entity.Property(e => e.FMail)
                    .HasMaxLength(50)
                    .HasColumnName("fMail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FSalary).HasColumnName("fSalary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
