using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SyncTrader.Models;

public partial class SyncTraderDbTestContext : DbContext
{
    public SyncTraderDbTestContext()
    {
    }

    public SyncTraderDbTestContext(DbContextOptions<SyncTraderDbTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<Broker> Brokers { get; set; }

    public virtual DbSet<LoggingAction> LoggingActions { get; set; }

    public virtual DbSet<StatusAction> StatusActions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=JUANPC\\SQLEXPRESS;Initial Catalog=SyncTraderDB_Test;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Action__FFE3F4D9AA221950");

            entity.ToTable("Action");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CompanyId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderTime).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.ActionType).WithMany(p => p.Actions)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Action_ActionType");

            entity.HasOne(d => d.Status).WithMany(p => p.Actions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Action_StatusAction");

            entity.HasOne(d => d.User).WithMany(p => p.Actions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Action_User");
        });

        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PK__ActionTy__62FE4C645B2F3320");

            entity.ToTable("ActionType");

            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeNameBroker)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Broker>(entity =>
        {
            entity.HasKey(e => e.BrokerId).HasName("PK__Broker__5D1D9A502C1952CA");

            entity.ToTable("Broker");

            entity.HasIndex(e => e.UserId, "UQ__Broker__1788CC4D92A7A0DA").IsUnique();

            entity.Property(e => e.ApiBroker)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.Broker)
                .HasForeignKey<Broker>(d => d.UserId)
                .HasConstraintName("FK_Broker_User");
        });

        modelBuilder.Entity<LoggingAction>(entity =>
        {
            entity.HasKey(e => e.LoggingActionsId).HasName("PK__LoggingA__FF87668E1B63E5D3");

            entity.ToTable("LoggingAction");

            entity.HasIndex(e => e.ActionId, "UQ__LoggingA__FFE3F4D890D58245").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ErrorAction)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Action).WithOne(p => p.LoggingAction)
                .HasForeignKey<LoggingAction>(d => d.ActionId)
                .HasConstraintName("FK_LoggingActions_Action");

            entity.HasOne(d => d.User).WithMany(p => p.LoggingActions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoggingActions_User");
        });

        modelBuilder.Entity<StatusAction>(entity =>
        {
            entity.HasKey(e => e.StatusActionId).HasName("PK__StatusAc__9CBAC6B32DE1D50C");

            entity.ToTable("StatusAction");

            entity.Property(e => e.StatusActionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C44A5690C");

            entity.ToTable("User");

            entity.HasIndex(e => e.BrokerId, "UQ__User__5D1D9A519A10535D").IsUnique();

            entity.Property(e => e.ActuallyUser).HasDefaultValue(true);
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.BrokerNavigation).WithOne(p => p.UserNavigation)
                .HasForeignKey<User>(d => d.BrokerId)
                .HasConstraintName("FK_User_Broker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
