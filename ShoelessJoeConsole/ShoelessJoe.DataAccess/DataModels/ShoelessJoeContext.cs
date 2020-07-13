using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class ShoelessJoeContext : DbContext
    {
        public ShoelessJoeContext()
        {
        }

        public ShoelessJoeContext(DbContextOptions<ShoelessJoeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<FoodGroup> FoodGroup { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SecretConfig.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Comments__C3B4DFCA6FBDA2DE");

                entity.Property(e => e.CommentDate).HasColumnType("date");

                entity.Property(e => e.MessageBody)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MessageHead)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_Comments_Users");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comments_Shoes");
            });

            modelBuilder.Entity<FoodGroup>(entity =>
            {
                entity.Property(e => e.FoodGroups)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__Foods__856DB3EBDB51F486");

                entity.Property(e => e.FoodTitle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.FoodGroup)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Foods__FoodGroup__09746778");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.FoodTitle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__FoodI__16CE6296");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__15DA3E5D");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasKey(e => e.OrderlineId)
                    .HasName("PK__OrderLin__F8912DF267EC7FE5");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__FoodI__1209AD79");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Order__12FDD1B2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF9DCB36E7");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__0F2D40CE");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StoreId__0E391C95");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.Property(e => e.ReplyBody)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyDate).HasColumnType("date");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Reply_Comments");

                entity.HasOne(d => d.ReplyUser)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.ReplyUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reply_Users");
            });

            modelBuilder.Entity<Shoes>(entity =>
            {
                entity.HasKey(e => e.ShoeId);

                entity.HasIndex(e => e.ShoeId)
                    .HasName("UQ__Shoes__5A835BF4B6C5383A")
                    .IsUnique();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LeftSize).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Manufacter)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RightSize).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Shoes_Users");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Stores__3B82F101FDD6BF25");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Users__1788CC4D4E69B6F5")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
