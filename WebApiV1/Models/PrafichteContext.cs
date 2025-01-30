using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class PrafichteContext : DbContext
{
    public PrafichteContext()
    {
    }

    public PrafichteContext(DbContextOptions<PrafichteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.EnableDetailedErrors();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friend>(entity =>
        {
            entity.ToTable("Friend");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsAccepted).HasColumnName("isAccepted");
            entity.Property(e => e.RecieverId).HasColumnName("RecieverID");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");

            entity.HasOne(d => d.Reciever).WithMany(p => p.FriendRecievers)
                .HasForeignKey(d => d.RecieverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_User1");

            entity.HasOne(d => d.Sender).WithMany(p => p.FriendSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_User");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Image).WithMany(p => p.Groups)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_Image");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.ToTable("GroupUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupUser_Group");

            entity.HasOne(d => d.User).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupUser_User");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Path).HasMaxLength(255);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Content).HasMaxLength(2048);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Group).WithMany(p => p.Messages)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_Group");

            entity.HasOne(d => d.Image).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_Message_Image");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.PwdHash).HasMaxLength(256);
            entity.Property(e => e.PwdSalt).HasMaxLength(256);
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Image).WithMany(p => p.Users)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_User_Image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
