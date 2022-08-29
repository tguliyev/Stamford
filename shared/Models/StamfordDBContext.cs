using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stamford.Models
{
    public partial class StamfordDBContext : DbContext
    {
        public StamfordDBContext()
        {
        }

        public StamfordDBContext(DbContextOptions<StamfordDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<ExamStudent> ExamStudents { get; set; } = null!;
        public virtual DbSet<Graduate> Graduates { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostAsset> PostAssets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=stamford.database.windows.net;Initial Catalog=StamfordDB;User ID=turalalik;Password=stamford1#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .HasColumnName("email");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("FK_Admin_Asset");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__imageId__3587F3E0");
            });

            modelBuilder.Entity<ExamStudent>(entity =>
            {
                entity.ToTable("ExamStudent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.ExamName).HasMaxLength(32);

                entity.Property(e => e.StudentName).HasMaxLength(62);
            });

            modelBuilder.Entity<Graduate>(entity =>
            {
                entity.HasIndex(e => e.ImageId, "IX_Graduates_ImageId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Graduates)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Graduates__cours__367C1819");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Graduates)
                    .HasForeignKey(d => d.ImageId);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<PostAsset>(entity =>
            {
                entity.ToTable("PostAsset");

                entity.HasIndex(e => e.Imageid, "IX_PostAsset_Imageid");

                entity.HasIndex(e => e.Postid, "IX_PostAsset_Postid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.PostAssets)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("FK__PostAsset__Image__123EB7A3");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostAssets)
                    .HasForeignKey(d => d.Postid)
                    .HasConstraintName("FK__PostAsset__Posti__114A936A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
