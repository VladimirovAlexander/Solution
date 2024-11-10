using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Solution.Models;

namespace Solution.Data;

public partial class SolutionDbContext : DbContext
{

    public SolutionDbContext(DbContextOptions<SolutionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobHistory> JobHistories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Region> Regions { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("COUNTRIES_pkey");

            entity.ToTable("COUNTRIES");

            entity.Property(e => e.CountryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CountryName)
                .HasMaxLength(40)
                .HasColumnName("COUNTRY_NAME");
            entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

            entity.HasOne(d => d.Region).WithMany(p => p.Countries)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("REGIONS_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("DEPARTMENTS_pkey");

            entity.ToTable("DEPARTMENTS");

            entity.Property(e => e.DepartmentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("DEPARTMENTS_LOCATION_ID_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("DEPARTMENTS_MANAGER_ID_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("EMPLOYEES_pkey");

            entity.ToTable("EMPLOYEES");

            entity.Property(e => e.EmployeeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.CommissionPct).HasColumnName("COMMISSION_PCT");
            entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.HireDate).HasColumnName("HIRE_DATE");
            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.Salary).HasColumnName("SALARY");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("DEPARTMENTS_fkey");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JOB_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("EMPLOYEES_MANAGER_ID_fkey");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("JOBS_pkey");

            entity.ToTable("JOBS");

            entity.Property(e => e.JobId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("JOB_ID");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(35)
                .HasColumnName("JOB_TITLE");
            entity.Property(e => e.MaxSalary).HasColumnName("MAX_SALARY");
            entity.Property(e => e.MinSalary).HasColumnName("MIN_SALARY");
        });

        modelBuilder.Entity<JobHistory>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.StartDate }).HasName("JOB_HISTORY_pkey");

            entity.ToTable("JOB_HISTORY");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.StartDate).HasColumnName("START_DATE");
            entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.EndDate).HasColumnName("END_DATE");
            entity.Property(e => e.JobId).HasColumnName("JOB_ID");

            entity.HasOne(d => d.Department).WithMany(p => p.JobHistories)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("JOB_HISTORY_DEPARTMENT_ID_fkey");

            entity.HasOne(d => d.Job).WithMany(p => p.JobHistories)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JOBS_fkey");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("LOCATIONS_pkey");

            entity.ToTable("LOCATIONS");

            entity.Property(e => e.LocationId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("CITY");
            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(12)
                .HasColumnName("POSTAL_CODE");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(25)
                .HasColumnName("STATE_PROVINCE");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(40)
                .HasColumnName("STREET_ADDRESS");

            entity.HasOne(d => d.Country).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("LOCATIONS_COUNTRY_ID_fkey");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("REGIONS_pkey");

            entity.ToTable("REGIONS");

            entity.Property(e => e.RegionId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("REGION_ID");
            entity.Property(e => e.RegionName)
                .HasMaxLength(25)
                .HasColumnName("REGION_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
