using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ccaaffee.Models;

public partial class DbIs617Context : DbContext
{
    public DbIs617Context()
    {
    }

    public DbIs617Context(DbContextOptions<DbIs617Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=192.168.0.1;uid=uis61_7;Database=db_is61_7;Password=uuth4Va4;Port=3308");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.IdProducts).HasName("PRIMARY");

            entity.ToTable("drink");

            entity.Property(e => e.IdProducts).HasColumnName("id_products");
            entity.Property(e => e.DrinkSelection)
                .HasMaxLength(45)
                .HasColumnName("drink_selection");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.IdStaff).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.PassportDetails).HasColumnName("passport_details");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
