using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class RazielNextTechContext : DbContext
{
    public RazielNextTechContext()
    {
    }

    public RazielNextTechContext(DbContextOptions<RazielNextTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Charge> Charges { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<MontoTotalTransaccionado> MontoTotalTransaccionados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=RazielNextTech; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Charge>(entity =>
        {
            entity.HasKey(e => e.IdCharge).HasName("PK__Charges__3F5548DA8BBB83B9");

            entity.Property(e => e.IdCharge)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Id_Charge");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.IdCompany)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Id_Company");
            entity.Property(e => e.PaidAt)
                .HasColumnType("date")
                .HasColumnName("Paid_at");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Charges)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Charges__Id_Comp__1CF15040");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany).HasName("PK__Companie__9DCC5B7B959330B9");

            entity.Property(e => e.IdCompany)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Id_Company");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
        });

        modelBuilder.Entity<MontoTotalTransaccionado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MontoTotalTransaccionado");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.IdCompany)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Id_Company");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(38, 10)")
                .HasColumnName("Total_Amount");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("date")
                .HasColumnName("Transaction_Date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
