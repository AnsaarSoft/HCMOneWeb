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
        public virtual DbSet<LogGrading> LogGradings { get; set; } = null!;
        public virtual DbSet<LogLeaveCalendar> LogLeaveCalendars { get; set; } = null!;
        public virtual DbSet<LogLocation> LogLocations { get; set; } = null!;
        public virtual DbSet<LogObloan> LogObloans { get; set; } = null!;
        public virtual DbSet<LogPosition> LogPositions { get; set; } = null!;
        public virtual DbSet<MstAdvance> MstAdvances { get; set; } = null!;
        public virtual DbSet<MstAttendanceRule> MstAttendanceRules { get; set; } = null!;
        public virtual DbSet<MstBranch> MstBranches { get; set; } = null!;
        public virtual DbSet<MstCalendar> MstCalendars { get; set; } = null!;
        public virtual DbSet<MstDeductionRule> MstDeductionRules { get; set; } = null!;
        public virtual DbSet<MstDepartment> MstDepartments { get; set; } = null!;
        public virtual DbSet<MstDesignation> MstDesignations { get; set; } = null!;
        public virtual DbSet<MstElement> MstElements { get; set; } = null!;
        public virtual DbSet<MstEmailConfig> MstEmailConfigs { get; set; } = null!;
        public virtual DbSet<MstGrading> MstGradings { get; set; } = null!;
        public virtual DbSet<MstLeaveCalendar> MstLeaveCalendars { get; set; } = null!;
        public virtual DbSet<MstLeaveDeduction> MstLeaveDeductions { get; set; } = null!;
        public virtual DbSet<MstLeaveType> MstLeaveTypes { get; set; } = null!;
        public virtual DbSet<MstLeavesAllocated> MstLeavesAllocateds { get; set; } = null!;
        public virtual DbSet<MstLoan> MstLoans { get; set; } = null!;
        public virtual DbSet<MstLocation> MstLocations { get; set; } = null!;
        public virtual DbSet<MstLove> MstLoves { get; set; } = null!;
        public virtual DbSet<MstOverTime> MstOverTimes { get; set; } = null!;
        public virtual DbSet<MstPayroll> MstPayrolls { get; set; } = null!;
        public virtual DbSet<MstPayrollBasicInitialization> MstPayrollBasicInitializations { get; set; } = null!;
        public virtual DbSet<MstPayrollElement> MstPayrollElements { get; set; } = null!;
        public virtual DbSet<MstPayrollPeriod> MstPayrollPeriods { get; set; } = null!;
        public virtual DbSet<MstPosition> MstPositions { get; set; } = null!;
        public virtual DbSet<MstShift> MstShifts { get; set; } = null!;
        public virtual DbSet<MstShiftsDetail> MstShiftsDetails { get; set; } = null!;
        public virtual DbSet<MstTaxSetup> MstTaxSetups { get; set; } = null!;
        public virtual DbSet<MstTaxSetupDetail> MstTaxSetupDetails { get; set; } = null!;
        public virtual DbSet<MstUser> MstUsers { get; set; } = null!;
        public virtual DbSet<TrnsDeductionRule> TrnsDeductionRules { get; set; } = null!;
        public virtual DbSet<TrnsDeductionRulesDetail> TrnsDeductionRulesDetails { get; set; } = null!;
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

            modelBuilder.Entity<MstAdvance>(entity =>
            {
                entity.ToTable("MstAdvance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");
            });

            modelBuilder.Entity<MstAttendanceRule>(entity =>
            {
                entity.ToTable("MstAttendanceRule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefaultLeaveType).HasMaxLength(50);

                entity.Property(e => e.FlgDeductGpAfterStartTime).HasColumnName("flgDeductGpAfterStartTime");

                entity.Property(e => e.FlgDeductGpAfterTimeEnd).HasColumnName("flgDeductGpAfterTimeEnd");

                entity.Property(e => e.FlgDeductGpBeforeStartTime).HasColumnName("flgDeductGpBeforeStartTime");

                entity.Property(e => e.FlgDeductGpBeforeTimeEnd).HasColumnName("flgDeductGpBeforeTimeEnd");

                entity.Property(e => e.FlgSandwichLeavesDoubleSide).HasColumnName("flgSandwichLeavesDoubleSide");

                entity.Property(e => e.FlgSandwichLeavesSingleSide).HasColumnName("flgSandwichLeavesSingleSide");

                entity.Property(e => e.GpAfterStartTime).HasMaxLength(50);

                entity.Property(e => e.GpAfterTimeEnd).HasMaxLength(50);

                entity.Property(e => e.GpBeforeStartTime).HasMaxLength(50);

                entity.Property(e => e.GpBeforeTimeEnd).HasMaxLength(50);
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

            modelBuilder.Entity<MstDeductionRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.Value).HasMaxLength(50);
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

                entity.Property(e => e.ApplicableAmountMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ElmtType).HasMaxLength(10);

                entity.Property(e => e.EmployeeContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);
            });

            modelBuilder.Entity<MstEmailConfig>(entity =>
            {
                entity.ToTable("MstEmailConfig");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromEmail).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Smtport).HasColumnName("SMTPort");

                entity.Property(e => e.Smtpserver)
                    .HasMaxLength(100)
                    .HasColumnName("SMTPServer");

                entity.Property(e => e.TestEmail).HasMaxLength(50);
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

            modelBuilder.Entity<MstLeaveDeduction>(entity =>
            {
                entity.ToTable("MstLeaveDeduction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<MstLeaveType>(entity =>
            {
                entity.ToTable("MstLeaveType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DeductionId).HasColumnName("DeductionID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgEncash).HasColumnName("flgEncash");

                entity.Property(e => e.LeaveCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeaveType).HasMaxLength(10);

                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.MstLeaveTypes)
                    .HasForeignKey(d => d.DeductionId)
                    .HasConstraintName("FK_MstLeaveType_MstLeaveDeduction");
            });

            modelBuilder.Entity<MstLeavesAllocated>(entity =>
            {
                entity.ToTable("MstLeavesAllocated");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CarryForwardDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgLeaveCollapse).HasColumnName("flgLeaveCollapse");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveCollapseDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveId).HasColumnName("LeaveID");

                entity.Property(e => e.LeavesAllowed).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.LeavesCarryForward).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.LeavesEntitled).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.LeavesUsed).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.MstLeavesAllocateds)
                    .HasForeignKey(d => d.LeaveId)
                    .HasConstraintName("FK_MstLeavesAllocated_MstLeaveType");
            });

            modelBuilder.Entity<MstLoan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");
            });

            modelBuilder.Entity<MstLocation>(entity =>
            {
                entity.ToTable("MstLocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");
            });

            modelBuilder.Entity<MstLove>(entity =>
            {
                entity.ToTable("MstLOVE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Language).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<MstOverTime>(entity =>
            {
                entity.ToTable("MstOverTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Expression).HasMaxLength(1000);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.FlgFormula).HasColumnName("flgFormula");

                entity.Property(e => e.Hours).HasMaxLength(10);

                entity.Property(e => e.MonthDays).HasMaxLength(10);

                entity.Property(e => e.PerDayCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PerMonthCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);
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

            modelBuilder.Entity<MstPayrollBasicInitialization>(entity =>
            {
                entity.ToTable("MstPayrollBasicInitialization");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.FlgAbsent).HasColumnName("flgAbsent");

                entity.Property(e => e.FlgAttendanceSystem).HasColumnName("flgAttendanceSystem");

                entity.Property(e => e.FlgEmployeeCodeSeries).HasColumnName("flgEmployeeCodeSeries");

                entity.Property(e => e.FlgLateInEarlyOutLeaveRules).HasColumnName("flgLateInEarlyOutLeaveRules");

                entity.Property(e => e.FlgLeaveCalendar).HasColumnName("flgLeaveCalendar");

                entity.Property(e => e.FlgMultipleDimension).HasColumnName("flgMultipleDimension");

                entity.Property(e => e.FlgPayrollWithSap).HasColumnName("flgPayrollWithSAP");

                entity.Property(e => e.FlgProcessingOnAttendance).HasColumnName("flgProcessingOnAttendance");

                entity.Property(e => e.FlgTaxSetup).HasColumnName("flgTaxSetup");

                entity.Property(e => e.Sapb1integration).HasColumnName("SAPB1Integration");
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

                entity.Property(e => e.FkcalId).HasColumnName("FKCalID");

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

            modelBuilder.Entity<MstShift>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DeductionRuleId).HasColumnName("DeductionRuleID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgHoliDayOverTime).HasColumnName("flgHoliDayOverTime");

                entity.Property(e => e.FlgOffDayOverTime).HasColumnName("flgOffDayOverTime");

                entity.Property(e => e.FlgOtwrkHrs).HasColumnName("flgOTWrkHrs");

                entity.Property(e => e.FlgOverTime).HasColumnName("flgOverTime");

                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");
            });

            modelBuilder.Entity<MstShiftsDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BreakTime).HasMaxLength(20);

                entity.Property(e => e.BufferEndTime).HasMaxLength(20);

                entity.Property(e => e.BufferStartTime).HasMaxLength(20);

                entity.Property(e => e.Day).HasMaxLength(20);

                entity.Property(e => e.Duration).HasMaxLength(20);

                entity.Property(e => e.EndGraceTime).HasMaxLength(20);

                entity.Property(e => e.EndTime).HasMaxLength(10);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgExpectedIn).HasColumnName("flgExpectedIn");

                entity.Property(e => e.FlgExpectedOut).HasColumnName("flgExpectedOut");

                entity.Property(e => e.FlgOutOverlap).HasColumnName("flgOutOverlap");

                entity.Property(e => e.StartGraceTime).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasMaxLength(10);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstShiftsDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstShiftsDetails_MstShifts");
            });

            modelBuilder.Entity<MstTaxSetup>(entity =>
            {
                entity.ToTable("MstTaxSetup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscountOnTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MaxSalaryDisc).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinTaxSalaryF).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<MstTaxSetupDetail>(entity =>
            {
                entity.ToTable("MstTaxSetupDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FixTerm).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TaxCode).HasMaxLength(20);

                entity.Property(e => e.TaxValue).HasColumnType("numeric(6, 3)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstTaxSetupDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstTaxSetupDetail_MstTaxSetup");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.ToTable("MstUser");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgPasswordRequest).HasColumnName("flgPasswordRequest");

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.UserCode).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            modelBuilder.Entity<TrnsDeductionRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);
            });

            modelBuilder.Entity<TrnsDeductionRulesDetail>(entity =>
            {
                entity.ToTable("TrnsDeductionRulesDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsDeductionRulesDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsDeductionRulesDetail_TrnsDeductionRules");
            });

            modelBuilder.Entity<TrnsObloan>(entity =>
            {
                entity.ToTable("TrnsOBLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BalanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

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
