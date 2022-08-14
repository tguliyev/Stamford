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
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamStudent> ExamStudents { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupStudent> GroupStudents { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostAsset> PostAssets { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

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

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.Scheduleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Schedule");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.Subjectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Subject");
            });

            modelBuilder.Entity<ExamStudent>(entity =>
            {
                entity.ToTable("ExamStudent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamStudents)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamStudent_Exam");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ExamStudents)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamStudent_Student");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Startdate).HasColumnType("datetime");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.Subjectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Teacher");
            });

            modelBuilder.Entity<GroupStudent>(entity =>
            {
                entity.ToTable("GroupStudent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupStudent_Group");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupStudent_Student");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<PostAsset>(entity =>
            {
                entity.ToTable("PostAsset");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lessontime).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Group");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Fullname).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.Username).HasMaxLength(25);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Asset");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.Fullname).HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(13);

                entity.Property(e => e.Username).HasMaxLength(30);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Asset");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
