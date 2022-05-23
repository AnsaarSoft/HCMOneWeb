using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCM.API.Models
{
    public partial class WebHCMOneContext : DbContext
    {
        public WebHCMOneContext()
        {
        }

        public WebHCMOneContext(DbContextOptions<WebHCMOneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogBranch> LogBranches { get; set; } = null!;
        public virtual DbSet<LogCalendar> LogCalendars { get; set; } = null!;
        public virtual DbSet<LogDepartment> LogDepartments { get; set; } = null!;
        public virtual DbSet<LogDesignation> LogDesignations { get; set; } = null!;
        public virtual DbSet<LogLeaveCalendar> LogLeaveCalendars { get; set; } = null!;
        public virtual DbSet<LogLocation> LogLocations { get; set; } = null!;
        public virtual DbSet<LogPosition> LogPositions { get; set; } = null!;
        public virtual DbSet<MstBranch> MstBranches { get; set; } = null!;
        public virtual DbSet<MstCalendar> MstCalendars { get; set; } = null!;
        public virtual DbSet<MstDepartment> MstDepartments { get; set; } = null!;
        public virtual DbSet<MstDesignation> MstDesignations { get; set; } = null!;
        public virtual DbSet<MstLeaveCalendar> MstLeaveCalendars { get; set; } = null!;
        public virtual DbSet<MstLocation> MstLocations { get; set; } = null!;
        public virtual DbSet<MstPosition> MstPositions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RDP-DEV-10;Database=WebHCMOne;User ID=DEV;Password=@Sql123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogBranch>(entity =>
            {
                entity.ToTable("LogBranch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogCalendar>(entity =>
            {
                entity.ToTable("LogCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateddBy).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            });

            modelBuilder.Entity<LogDepartment>(entity =>
            {
                entity.ToTable("LogDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogDesignation>(entity =>
            {
                entity.ToTable("LogDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogLeaveCalendar>(entity =>
            {
                entity.ToTable("LogLeaveCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateddBy).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            });

            modelBuilder.Entity<LogLocation>(entity =>
            {
                entity.ToTable("LogLocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogPosition>(entity =>
            {
                entity.ToTable("LogPosition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<MstBranch>(entity =>
            {
                entity.ToTable("MstBranch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<MstCalendar>(entity =>
            {
                entity.ToTable("MstCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDepartment>(entity =>
            {
                entity.ToTable("MstDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<MstDesignation>(entity =>
            {
                entity.ToTable("MstDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<MstLeaveCalendar>(entity =>
            {
                entity.ToTable("MstLeaveCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLocation>(entity =>
            {
                entity.ToTable("MstLocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<MstPosition>(entity =>
            {
                entity.ToTable("MstPosition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
