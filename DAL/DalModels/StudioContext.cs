using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace DAL.DalModels;

public partial class StudioContext : DbContext
{
    public StudioContext()
    {
    }

    public StudioContext(DbContextOptions<StudioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\פרויקט\\data\\MyDataBase.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC073E989228");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Meeting__3214EC074D0B8F55");

            entity.ToTable("Meeting");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CustomersId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.WorkerId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Customers).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.CustomersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meeting_ToTable");

            entity.HasOne(d => d.Worker).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meeting_ToTable_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC070A4010F4");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.WorkerId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Worker).WithMany(p => p.Roles)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_ToTable");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workers__3214EC07BE07369B");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RoleId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Role).WithMany(p => p.Workers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workers_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
