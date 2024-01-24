using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendAPI.Models
{
    public partial class DishContext : DbContext
    {
        public DishContext()
        {
        }

        public DishContext(DbContextOptions<DishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UQSKA4Q;Database=Dish;Trusted_Connection=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Comment_ID");

                entity.Property(e => e.AddedBy).HasColumnName("Added_by");

                entity.Property(e => e.AddedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_time");

                entity.Property(e => e.Content).HasMaxLength(1500);

                entity.Property(e => e.DeleteBy).HasColumnName("Delete_by");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Delete_time");

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Post");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId)
                    .ValueGeneratedNever()
                    .HasColumnName("Post_ID");

                entity.Property(e => e.AddedBy).HasColumnName("Added_by");

                entity.Property(e => e.AddedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_time");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.DeleteBy).HasColumnName("Delete_by");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Delete_time");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Edit_time");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Comment");

                entity.HasOne(d => d.CommentNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Users");

                entity.HasOne(d => d.PostNavigation)
                    .WithOne(p => p.Post)
                    .HasForeignKey<Post>(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(1)
                    .HasColumnName("Role_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_ID");

                entity.Property(e => e.City).HasMaxLength(1);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Edit_time");

                entity.Property(e => e.Email).HasMaxLength(1);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(1)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(1)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Mobile).HasMaxLength(12);

                entity.Property(e => e.Passkey).HasMaxLength(1);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(1)
                    .HasColumnName("User_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
