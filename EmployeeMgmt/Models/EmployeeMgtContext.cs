using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgmt.Models;

public partial class EmployeeMgtContext : DbContext
{
    public EmployeeMgtContext()
    {
    }

    public EmployeeMgtContext(DbContextOptions<EmployeeMgtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=USBLRSNAGASO1\\SQLEXPRESS;Database=EmployeeMgt;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptid).HasName("PK__Departme__BE2C1AEE0FD3BC4E");

            entity.ToTable("Department");

            entity.Property(e => e.Deptid)
                .ValueGeneratedNever()
                .HasColumnName("deptid");
            entity.Property(e => e.Deptname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Employee__A9D10535B7F162A6");

            entity.ToTable("Employee");

            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfJoining)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_joining");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Manager)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Employee__dept_i__4E88ABD4");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => e.Epid).HasName("PK__Employee__3AF3FC78E77C9768");

            entity.Property(e => e.Epid)
                .ValueGeneratedNever()
                .HasColumnName("epid");
            entity.Property(e => e.Empemail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empemail");
            entity.Property(e => e.ProjId).HasColumnName("proj_id");

            entity.HasOne(d => d.EmpemailNavigation).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.Empemail)
                .HasConstraintName("FK__EmployeeP__empem__5165187F");

            entity.HasOne(d => d.Proj).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjId)
                .HasConstraintName("FK__EmployeeP__proj___52593CB8");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("PK__Project__11EC39DD241AF5D9");

            entity.ToTable("Project");

            entity.Property(e => e.Projectid)
                .ValueGeneratedNever()
                .HasColumnName("projectid");
            entity.Property(e => e.Did).HasColumnName("did");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("duration");
            entity.Property(e => e.Projectname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("projectname");

            entity.HasOne(d => d.DidNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Did)
                .HasConstraintName("FK__Project__did__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
