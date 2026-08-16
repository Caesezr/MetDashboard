using System;
using System.Collections.Generic;
using MetDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MetDashboard.Data;

public partial class RealEstateDbContext : DbContext
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activelease> Activeleases { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Financialsummary> Financialsummaries { get; set; }

    public virtual DbSet<Lease> Leases { get; set; }

    public virtual DbSet<Maintenancerequest> Maintenancerequests { get; set; }

    public virtual DbSet<Openmaintenancerequest> Openmaintenancerequests { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentaudit> Paymentaudits { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Propertyowner> Propertyowners { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activelease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("activeleases");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.LeaseId).HasColumnName("lease_id");
            entity.Property(e => e.MonthlyRent)
                .HasPrecision(10)
                .HasColumnName("monthly_rent");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.TenantName)
                .HasMaxLength(101)
                .HasColumnName("tenant_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasColumnType("enum('Property Manager','Maintenance Staff','Accountant','Leasing Agent')")
                .HasColumnName("role");
        });

        modelBuilder.Entity<Financialsummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("financialsummary");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.TotalMaintenanceCost)
                .HasPrecision(32)
                .HasColumnName("total_maintenance_cost");
            entity.Property(e => e.TotalRent)
                .HasPrecision(32)
                .HasColumnName("total_rent");
        });

        modelBuilder.Entity<Lease>(entity =>
        {
            entity.HasKey(e => e.LeaseId).HasName("PRIMARY");

            entity.ToTable("lease");

            entity.HasIndex(e => new { e.LeaseStatus, e.EndDate }, "idx_lease_status");

            entity.HasIndex(e => e.PropertyId, "property_id");

            entity.HasIndex(e => e.TenantId, "tenant_id");

            entity.Property(e => e.LeaseId).HasColumnName("lease_id");
            entity.Property(e => e.DueDay)
                .HasDefaultValueSql("'1'")
                .HasColumnName("due_day");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.LeaseStatus)
                .HasDefaultValueSql("'Active'")
                .HasColumnType("enum('Active','Expired','Terminated')")
                .HasColumnName("lease_status");
            entity.Property(e => e.MonthlyRent)
                .HasPrecision(10)
                .HasColumnName("monthly_rent");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.SecurityDeposit)
                .HasPrecision(10)
                .HasColumnName("security_deposit");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");

            entity.HasOne(d => d.Property).WithMany(p => p.Leases)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("lease_ibfk_1");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Leases)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("lease_ibfk_2");
        });

        modelBuilder.Entity<Maintenancerequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("maintenancerequest");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.Status, "idx_maintenance_status");

            entity.HasIndex(e => e.PropertyId, "property_id");

            entity.HasIndex(e => e.TenantId, "tenant_id");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.CompletionDate)
                .HasColumnType("date")
                .HasColumnName("completion_date");
            entity.Property(e => e.Cost)
                .HasPrecision(10)
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("request_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Open'")
                .HasColumnType("enum('Open','In Progress','Completed')")
                .HasColumnName("status");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Maintenancerequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenancerequest_ibfk_3");

            entity.HasOne(d => d.Property).WithMany(p => p.Maintenancerequests)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("maintenancerequest_ibfk_1");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Maintenancerequests)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenancerequest_ibfk_2");
        });

        modelBuilder.Entity<Openmaintenancerequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("openmaintenancerequests");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(101)
                .HasDefaultValueSql("''")
                .HasColumnName("assigned_to");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PRIMARY");

            entity.ToTable("owner");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => new { e.Email, e.Phone }, "idx_owner_contact");

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MailingAddress)
                .HasMaxLength(255)
                .HasColumnName("mailing_address");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.PaymentDate, "idx_payment_date");

            entity.HasIndex(e => e.LeaseId, "lease_id");

            entity.HasIndex(e => e.ReceivedBy, "received_by");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.LeaseId).HasColumnName("lease_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("date")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasColumnType("enum('Credit Card','Check','Bank Transfer','Cash')")
                .HasColumnName("payment_method");
            entity.Property(e => e.ReceivedBy).HasColumnName("received_by");

            entity.HasOne(d => d.Lease).WithMany(p => p.Payments)
                .HasForeignKey(d => d.LeaseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payment_ibfk_1");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReceivedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_ibfk_2");
        });

        modelBuilder.Entity<Paymentaudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PRIMARY");

            entity.ToTable("paymentaudit");

            entity.HasIndex(e => e.PaymentId, "payment_id");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.AuditTimestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("audit_timestamp");
            entity.Property(e => e.LateFee)
                .HasPrecision(10)
                .HasColumnName("late_fee");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Payment).WithMany(p => p.Paymentaudits)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("paymentaudit_ibfk_1");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PRIMARY");

            entity.ToTable("property");

            entity.HasIndex(e => new { e.City, e.ZipCode }, "idx_property_location");

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.PropertyType)
                .HasColumnType("enum('Single Family','Apartment','Commercial','Condo')")
                .HasColumnName("property_type");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("purchase_date");
            entity.Property(e => e.PurchasePrice)
                .HasPrecision(15)
                .HasColumnName("purchase_price");
            entity.Property(e => e.SquareFeet).HasColumnName("square_feet");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.YearBuilt).HasColumnName("year_built");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Propertyowner>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.OwnerId }).HasName("PRIMARY");

            entity.ToTable("propertyowner");

            entity.HasIndex(e => e.OwnerId, "owner_id");

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.OwnershipPercentage)
                .HasPrecision(5)
                .HasColumnName("ownership_percentage");

            entity.HasOne(d => d.Owner).WithMany(p => p.Propertyowners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("propertyowner_ibfk_2");

            entity.HasOne(d => d.Property).WithMany(p => p.Propertyowners)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("propertyowner_ibfk_1");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PRIMARY");

            entity.ToTable("tenant");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => new { e.Email, e.Phone }, "idx_tenant_contact");

            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(20)
                .HasColumnName("emergency_contact");
            entity.Property(e => e.Employer)
                .HasMaxLength(100)
                .HasColumnName("employer");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
