﻿using System;
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
        public virtual DbSet<LogGrading> LogGradings { get; set; } = null!;
        public virtual DbSet<LogLeaveCalendar> LogLeaveCalendars { get; set; } = null!;
        public virtual DbSet<LogLocation> LogLocations { get; set; } = null!;
        public virtual DbSet<LogObloan> LogObloans { get; set; } = null!;
        public virtual DbSet<LogPosition> LogPositions { get; set; } = null!;
        public virtual DbSet<MstBranch> MstBranches { get; set; } = null!;
        public virtual DbSet<MstCalendar> MstCalendars { get; set; } = null!;
        public virtual DbSet<MstDepartment> MstDepartments { get; set; } = null!;
        public virtual DbSet<MstDesignation> MstDesignations { get; set; } = null!;
        public virtual DbSet<MstElement> MstElements { get; set; } = null!;
        public virtual DbSet<MstElementContribution> MstElementContributions { get; set; } = null!;
        public virtual DbSet<MstElementDeduction> MstElementDeductions { get; set; } = null!;
        public virtual DbSet<MstElementEarning> MstElementEarnings { get; set; } = null!;
        public virtual DbSet<MstGrading> MstGradings { get; set; } = null!;
        public virtual DbSet<MstLeaveCalendar> MstLeaveCalendars { get; set; } = null!;
        public virtual DbSet<MstLocation> MstLocations { get; set; } = null!;
        public virtual DbSet<MstPayroll> MstPayrolls { get; set; } = null!;
        public virtual DbSet<MstPayrollElement> MstPayrollElements { get; set; } = null!;
        public virtual DbSet<MstPayrollPeriod> MstPayrollPeriods { get; set; } = null!;
        public virtual DbSet<MstPosition> MstPositions { get; set; } = null!;
        public virtual DbSet<TrnsObloan> TrnsObloans { get; set; } = null!;

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

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
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

            modelBuilder.Entity<LogGrading>(entity =>
            {
                entity.ToTable("LogGrading");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.MaxSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogLeaveCalendar>(entity =>
            {
                entity.ToTable("LogLeaveCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
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

            modelBuilder.Entity<LogObloan>(entity =>
            {
                entity.ToTable("LogOBLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BalanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FkloanId).HasColumnName("FKLoanID");

                entity.Property(e => e.Installment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(100);

                entity.Property(e => e.RecoverdAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 6)");
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

            modelBuilder.Entity<MstElement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ElmtType).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(10);
            });

            modelBuilder.Entity<MstElementContribution>(entity =>
            {
                entity.ToTable("MstElementContribution");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicableAmountMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstElementContributions)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstElementContribution_MstElements");
            });

            modelBuilder.Entity<MstElementDeduction>(entity =>
            {
                entity.ToTable("MstElementDeduction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstElementDeductions)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstElementDeduction_MstElements");
            });

            modelBuilder.Entity<MstElementEarning>(entity =>
            {
                entity.ToTable("MstElementEarning");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstElementEarnings)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstElementEarning_MstElements");
            });

            modelBuilder.Entity<MstGrading>(entity =>
            {
                entity.ToTable("MstGrading");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinSalary).HasColumnType("numeric(18, 6)");
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

            modelBuilder.Entity<MstPayroll>(entity =>
            {
                entity.ToTable("MstPayroll");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstPeriodEndDt).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgOffDaysExcludedFromSalaryPeriod).HasColumnName("flgOffDaysExcludedFromSalaryPeriod");

                entity.Property(e => e.Gltype)
                    .HasMaxLength(10)
                    .HasColumnName("GLType");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PayrollType).HasMaxLength(10);

                entity.Property(e => e.WorkHours).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<MstPayrollElement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstPayrollElements)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstPayrollElements_MstPayroll");
            });

            modelBuilder.Entity<MstPayrollPeriod>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgLocked).HasColumnName("flgLocked");

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.FlgVisible).HasColumnName("flgVisible");

                entity.Property(e => e.PeriodName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstPayrollPeriods)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstPayrollPeriods_MstPayroll");
            });

            modelBuilder.Entity<MstPosition>(entity =>
            {
                entity.ToTable("MstPosition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<TrnsObloan>(entity =>
            {
                entity.ToTable("TrnsOBLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BalanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FkloanId).HasColumnName("FKLoanID");

                entity.Property(e => e.Installment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.Property(e => e.RecoverdAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("numeric(19, 6)")
                    .HasComputedColumnSql("([BalanceAmount]+[RecoverdAmount])", false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
