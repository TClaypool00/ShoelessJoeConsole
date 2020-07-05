using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }
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
                    .HasConstraintName("FK_Comments_Shoes");
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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reply_Comments");

                entity.HasOne(d => d.ReplyUser)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.ReplyUserId)
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
                    .HasConstraintName("FK_Shoes_Users");
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
