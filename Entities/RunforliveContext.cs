using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RunForLive.Entities;

public partial class RunforliveContext : DbContext
{
    public RunforliveContext()
    {
    }

    public RunforliveContext(DbContextOptions<RunforliveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Event> Events { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("account");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.District)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("district");
            entity.Property(e => e.Dob)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dob");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Province)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("province");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.Ward)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ward");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__event__3213E83FE131C997");

            entity.ToTable("event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CloseTime).HasColumnName("close_time");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasColumnName("event_name");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("img_path");
            entity.Property(e => e.OpenDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("open_date");
            entity.Property(e => e.OpenTime)
                .HasDefaultValueSql("(CONVERT([time],getdate()))")
                .HasColumnName("open_time");
            entity.Property(e => e.Place)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("place");
            entity.Property(e => e.ScopePrice)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("scope_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
