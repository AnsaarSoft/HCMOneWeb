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

        public virtual DbSet<LogBranch> LogBranches { get; set; }
        public virtual DbSet<LogCalendar> LogCalendars { get; set; }
        public virtual DbSet<LogDepartment> LogDepartments { get; set; }
        public virtual DbSet<LogDesignation> LogDesignations { get; set; }
        public virtual DbSet<LogGrading> LogGradings { get; set; }
        public virtual DbSet<LogLeaveCalendar> LogLeaveCalendars { get; set; }
        public virtual DbSet<LogLocation> LogLocations { get; set; }
        public virtual DbSet<LogObloan> LogObloans { get; set; }
        public virtual DbSet<LogPosition> LogPositions { get; set; }
        public virtual DbSet<MstAdvance> MstAdvances { get; set; }
        public virtual DbSet<MstAttendanceRule> MstAttendanceRules { get; set; }
        public virtual DbSet<MstBonu> MstBonus { get; set; }
        public virtual DbSet<MstBranch> MstBranches { get; set; }
        public virtual DbSet<MstCalendar> MstCalendars { get; set; }
        public virtual DbSet<MstCity> MstCities { get; set; }
        public virtual DbSet<MstCountry> MstCountries { get; set; }
        public virtual DbSet<MstDeductionRule> MstDeductionRules { get; set; }
        public virtual DbSet<MstDepartment> MstDepartments { get; set; }
        public virtual DbSet<MstDesignation> MstDesignations { get; set; }
        public virtual DbSet<MstElement> MstElements { get; set; }
        public virtual DbSet<MstEmailConfig> MstEmailConfigs { get; set; }
        public virtual DbSet<MstEmployee> MstEmployees { get; set; }
        public virtual DbSet<MstEmployeeAttachment> MstEmployeeAttachments { get; set; }
        public virtual DbSet<MstGrading> MstGradings { get; set; }
        public virtual DbSet<MstGratuity> MstGratuities { get; set; }
        public virtual DbSet<MstGratuityDetail> MstGratuityDetails { get; set; }
        public virtual DbSet<MstLeaveCalendar> MstLeaveCalendars { get; set; }
        public virtual DbSet<MstLeaveDeduction> MstLeaveDeductions { get; set; }
        public virtual DbSet<MstLeaveType> MstLeaveTypes { get; set; }
        public virtual DbSet<MstLeavesAllocation> MstLeavesAllocations { get; set; }
        public virtual DbSet<MstLoan> MstLoans { get; set; }
        public virtual DbSet<MstLocation> MstLocations { get; set; }
        public virtual DbSet<MstLove> MstLoves { get; set; }
        public virtual DbSet<MstOverTime> MstOverTimes { get; set; }
        public virtual DbSet<MstPayroll> MstPayrolls { get; set; }
        public virtual DbSet<MstPayrollBasicInitialization> MstPayrollBasicInitializations { get; set; }
        public virtual DbSet<MstPayrollElement> MstPayrollElements { get; set; }
        public virtual DbSet<MstPayrollPeriod> MstPayrollPeriods { get; set; }
        public virtual DbSet<MstPosition> MstPositions { get; set; }
        public virtual DbSet<MstShift> MstShifts { get; set; }
        public virtual DbSet<MstShiftsDetail> MstShiftsDetails { get; set; }
        public virtual DbSet<MstState> MstStates { get; set; }
        public virtual DbSet<MstTaxSetup> MstTaxSetups { get; set; }
        public virtual DbSet<MstTaxSetupDetail> MstTaxSetupDetails { get; set; }
        public virtual DbSet<MstUser> MstUsers { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual DbSet<TrnsDeductionRule> TrnsDeductionRules { get; set; }
        public virtual DbSet<TrnsDeductionRulesDetail> TrnsDeductionRulesDetails { get; set; }
        public virtual DbSet<TrnsEmployeeBonu> TrnsEmployeeBonus { get; set; }
        public virtual DbSet<TrnsEmployeeBonusDetail> TrnsEmployeeBonusDetails { get; set; }
        public virtual DbSet<TrnsHolidayCalendar> TrnsHolidayCalendars { get; set; }
        public virtual DbSet<TrnsHolidayCalendarDetail> TrnsHolidayCalendarDetails { get; set; }
        public virtual DbSet<TrnsObSalaryAdj> TrnsObSalaryAdjs { get; set; }
        public virtual DbSet<TrnsObcontribution> TrnsObcontributions { get; set; }
        public virtual DbSet<TrnsObgratuity> TrnsObgratuities { get; set; }
        public virtual DbSet<TrnsObleaf> TrnsObleaves { get; set; }
        public virtual DbSet<TrnsObloan> TrnsObloans { get; set; }
        public virtual DbSet<TrnsObsalary> TrnsObsalaries { get; set; }
        public virtual DbSet<TrnsObtax> TrnsObtaxes { get; set; }
        public virtual DbSet<TrnsTempAttendance> TrnsTempAttendances { get; set; }

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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogCalendar>(entity =>
            {
                entity.ToTable("LogCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogDesignation>(entity =>
            {
                entity.ToTable("LogDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<LogGrading>(entity =>
            {
                entity.ToTable("LogGrading");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

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

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.LogUser).HasMaxLength(200);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<MstAdvance>(entity =>
            {
                entity.ToTable("MstAdvance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAttendanceRule>(entity =>
            {
                entity.ToTable("MstAttendanceRule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.SandwichLeaveType).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBonu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BonusPercentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MinimumMonthsDuration).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MstBranch>(entity =>
            {
                entity.ToTable("MstBranch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCalendar>(entity =>
            {
                entity.ToTable("MstCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCity>(entity =>
            {
                entity.ToTable("MstCity");

                entity.Property(e => e.CityCode).HasMaxLength(50);

                entity.Property(e => e.CityName).HasMaxLength(150);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstCities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstCity_MstCountry");
            });

            modelBuilder.Entity<MstCountry>(entity =>
            {
                entity.ToTable("MstCountry");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode).HasMaxLength(10);

                entity.Property(e => e.CountryName).HasMaxLength(40);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);
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

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDesignation>(entity =>
            {
                entity.ToTable("MstDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstElement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicableAmountMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ElmtType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmployeeContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

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

            modelBuilder.Entity<MstEmployee>(entity =>
            {
                entity.ToTable("MstEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNo).HasMaxLength(200);

                entity.Property(e => e.AccountTitle).HasMaxLength(100);

                entity.Property(e => e.AccountType).HasMaxLength(10);

                entity.Property(e => e.AllowedAdvance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ArabicName).HasMaxLength(150);

                entity.Property(e => e.BankBranch).HasMaxLength(150);

                entity.Property(e => e.BankBranchCode).HasMaxLength(10);

                entity.Property(e => e.BankCardExpiryDt).HasMaxLength(100);

                entity.Property(e => e.BankCode).HasMaxLength(100);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BasicGrossRatio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.BloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BloodGroupLOVType");

                entity.Property(e => e.BonusCode).HasMaxLength(50);

                entity.Property(e => e.BonusPoints).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CandidateCast)
                    .HasMaxLength(50)
                    .HasColumnName("candidate_cast");

                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ContrEnddate).HasColumnType("datetime");

                entity.Property(e => e.ContrStartDate).HasColumnType("datetime");

                entity.Property(e => e.ContractExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CvPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cv_path");

                entity.Property(e => e.DefaultOffDay).HasMaxLength(50);

                entity.Property(e => e.DefaultShift).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.DrivingLic)
                    .HasMaxLength(50)
                    .HasColumnName("Driving_lic");

                entity.Property(e => e.DrvLicCompletionDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicLastDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicReleaseDt).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EID");

                entity.Property(e => e.Eidexpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("EIDExpiry");

                entity.Property(e => e.ElementHeadId).HasColumnName("ElementHeadID");

                entity.Property(e => e.EmpCardExp)
                    .HasColumnType("datetime")
                    .HasColumnName("empCardExp");

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpUnion).HasMaxLength(10);

                entity.Property(e => e.EmployeeContractType).HasMaxLength(20);

                entity.Property(e => e.EnglishName).HasMaxLength(300);

                entity.Property(e => e.Eobino)
                    .HasMaxLength(50)
                    .HasColumnName("EOBINo");

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgBlackListed).HasColumnName("flgBlackListed");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgCmhouseEmp).HasColumnName("FlgCMHouseEmp");

                entity.Property(e => e.FlgCompanyResidence).HasColumnName("flgCompanyResidence");

                entity.Property(e => e.FlgDailyWager).HasColumnName("flgDailyWager");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgEobi).HasColumnName("flgEOBI");

                entity.Property(e => e.FlgFlexibleShift).HasColumnName("flgFlexibleShift");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgHold).HasColumnName("flgHold");

                entity.Property(e => e.FlgHrapproved).HasColumnName("FlgHRApproved");

                entity.Property(e => e.FlgHruser).HasColumnName("flgHRUser");

                entity.Property(e => e.FlgItapproved).HasColumnName("FlgITApproved");

                entity.Property(e => e.FlgNotInPayroll).HasColumnName("flgNotInPayroll");

                entity.Property(e => e.FlgOcrdtransfered).HasColumnName("flgOCRDTransfered");

                entity.Property(e => e.FlgOffDayApplicable).HasColumnName("flgOffDayApplicable");

                entity.Property(e => e.FlgOnLeave).HasColumnName("flgOnLeave");

                entity.Property(e => e.FlgOtapplicable).HasColumnName("flgOTApplicable");

                entity.Property(e => e.FlgPerHour).HasColumnName("flgPerHour");

                entity.Property(e => e.FlgPerPiece).HasColumnName("flgPerPiece");

                entity.Property(e => e.FlgProbation).HasColumnName("flgProbation");

                entity.Property(e => e.FlgSandwich).HasColumnName("flgSandwich");

                entity.Property(e => e.FlgSendToHr).HasColumnName("FlgSendToHR");

                entity.Property(e => e.FlgSendToIt).HasColumnName("FlgSendToIT");

                entity.Property(e => e.FlgShopManager).HasColumnName("flgShopManager");

                entity.Property(e => e.FlgSocialSecurity).HasColumnName("flgSocialSecurity");

                entity.Property(e => e.FlgSuperVisor).HasColumnName("flgSuperVisor");

                entity.Property(e => e.FlgTax).HasColumnName("flgTax");

                entity.Property(e => e.FlgUser).HasColumnName("flgUser");

                entity.Property(e => e.GenderId)
                    .HasMaxLength(10)
                    .HasColumnName("GenderID");

                entity.Property(e => e.GenderLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("GenderLOVType");

                entity.Property(e => e.GosiSalary).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.GradeLevelId).HasColumnName("GradeLevelID");

                entity.Property(e => e.GratuityName).HasMaxLength(50);

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.GrossSalaryHired).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Hablock)
                    .HasMaxLength(50)
                    .HasColumnName("HABlock");

                entity.Property(e => e.Hacity)
                    .HasMaxLength(100)
                    .HasColumnName("HACity");

                entity.Property(e => e.Hacountry)
                    .HasMaxLength(100)
                    .HasColumnName("HACountry");

                entity.Property(e => e.Haother)
                    .HasMaxLength(500)
                    .HasColumnName("HAOther");

                entity.Property(e => e.Hastate)
                    .HasMaxLength(100)
                    .HasColumnName("HAState");

                entity.Property(e => e.Hastreet)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreet");

                entity.Property(e => e.HastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreetNo");

                entity.Property(e => e.HazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("HAZipCode");

                entity.Property(e => e.HoldDate).HasColumnType("datetime");

                entity.Property(e => e.HoldReasons).HasMaxLength(500);

                entity.Property(e => e.HolidayCalendar).HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.HrBaseCalendar).HasMaxLength(20);

                entity.Property(e => e.IddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("IDDateofIssue");

                entity.Property(e => e.IdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDExpiryDate");

                entity.Property(e => e.IdexpiryDt)
                    .HasMaxLength(100)
                    .HasColumnName("IDExpiryDt");

                entity.Property(e => e.IdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("IDIssuedBy");

                entity.Property(e => e.Idno)
                    .HasMaxLength(20)
                    .HasColumnName("IDNo");

                entity.Property(e => e.IdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("IDPlaceofIssue");

                entity.Property(e => e.Imagedata)
                    .HasMaxLength(3000)
                    .IsFixedLength();

                entity.Property(e => e.ImgPath).HasMaxLength(600);

                entity.Property(e => e.IncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.InsuranceCategory).HasMaxLength(50);

                entity.Property(e => e.InventoryEmail).HasMaxLength(500);

                entity.Property(e => e.IqamaProfessional).HasMaxLength(200);

                entity.Property(e => e.Jd).HasColumnName("JD");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.LastAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LiexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LIExpiryDate");

                entity.Property(e => e.Linsurance)
                    .HasMaxLength(100)
                    .HasColumnName("LInsurance");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName).HasMaxLength(300);

                entity.Property(e => e.MartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("MartialStatusID");

                entity.Property(e => e.MartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("MartialStatusLOVType");

                entity.Property(e => e.MedicalCardExpDt).HasMaxLength(100);

                entity.Property(e => e.MedicalCardExpiryDateEmployee).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardExpiryDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardIssueDateEmployee).HasMaxLength(100);

                entity.Property(e => e.MedicalCardIssueDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardNoEmployee)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MedicalCardNoSpouse).HasMaxLength(100);

                entity.Property(e => e.MedicalCategory).HasMaxLength(100);

                entity.Property(e => e.MedicalExpiry).HasColumnType("datetime");

                entity.Property(e => e.MedicalInsurance).HasMaxLength(100);

                entity.Property(e => e.MedicalNetwork).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MoajibEmail).HasMaxLength(500);

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.MultiLogin).HasColumnName("Multi_Login");

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.NextAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.OfficeEmail).HasMaxLength(100);

                entity.Property(e => e.OfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OfficePhone).HasMaxLength(30);

                entity.Property(e => e.OrganizationalUnit).HasMaxLength(50);

                entity.Property(e => e.Otslabs).HasColumnName("OTSlabs");

                entity.Property(e => e.PassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDt).HasMaxLength(100);

                entity.Property(e => e.PassportNo).HasMaxLength(100);

                entity.Property(e => e.PayBandId).HasColumnName("PayBandID");

                entity.Property(e => e.PaymentMode).HasMaxLength(10);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PercentagePaid).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerformanceAllowance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PersonalContactNo).HasMaxLength(100);

                entity.Property(e => e.PersonalEmail).HasMaxLength(100);

                entity.Property(e => e.PersonalIm)
                    .HasMaxLength(100)
                    .HasColumnName("PersonalIM");

                entity.Property(e => e.PfloanLimit)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PFLoanLimit");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PostProbationIncrementAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("postProbationIncrementAmount");

                entity.Property(e => e.PreEmpMonth).HasMaxLength(20);

                entity.Property(e => e.PriAddress).HasMaxLength(100);

                entity.Property(e => e.PriCity).HasMaxLength(20);

                entity.Property(e => e.PriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.PriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.PriCountry).HasMaxLength(20);

                entity.Property(e => e.PriPersonName).HasMaxLength(100);

                entity.Property(e => e.PriRelationShip).HasMaxLength(20);

                entity.Property(e => e.PriState).HasMaxLength(20);

                entity.Property(e => e.ProbationEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProfitCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.RecruitmentMode).HasMaxLength(50);

                entity.Property(e => e.ReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("ReligionID");

                entity.Property(e => e.ReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ReligionLOVType");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.ReportToId).HasColumnName("ReportToID");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.RetirementDate).HasColumnType("date");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(150)
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("RoleLOVType");

                entity.Property(e => e.RoleName).HasMaxLength(300);

                entity.Property(e => e.SalaryCurrency).HasMaxLength(5);

                entity.Property(e => e.SboUserCode).HasMaxLength(50);

                entity.Property(e => e.SboempCode)
                    .HasMaxLength(30)
                    .HasColumnName("SBOEmpCode");

                entity.Property(e => e.SecAddress).HasMaxLength(100);

                entity.Property(e => e.SecCity).HasMaxLength(20);

                entity.Property(e => e.SecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.SecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.SecCountry).HasMaxLength(20);

                entity.Property(e => e.SecPersonName).HasMaxLength(100);

                entity.Property(e => e.SecRelationShip).HasMaxLength(20);

                entity.Property(e => e.SecState).HasMaxLength(20);

                entity.Property(e => e.Sect)
                    .HasMaxLength(50)
                    .HasColumnName("sect");

                entity.Property(e => e.Sector).HasMaxLength(100);

                entity.Property(e => e.ShiftDaysCode).HasMaxLength(50);

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.SpouseName).HasMaxLength(250);

                entity.Property(e => e.SuccessionId).HasColumnName("SuccessionID");

                entity.Property(e => e.TeamsId).HasColumnName("TeamsID");

                entity.Property(e => e.TeamsName).HasMaxLength(50);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TransportMode).HasMaxLength(50);

                entity.Property(e => e.UnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.VisaExpiry).HasColumnType("datetime");

                entity.Property(e => e.VisaNo).HasMaxLength(30);

                entity.Property(e => e.Wablock)
                    .HasMaxLength(50)
                    .HasColumnName("WABlock");

                entity.Property(e => e.Wacity)
                    .HasMaxLength(100)
                    .HasColumnName("WACity");

                entity.Property(e => e.Wacountry)
                    .HasMaxLength(100)
                    .HasColumnName("WACountry");

                entity.Property(e => e.Waother)
                    .HasMaxLength(500)
                    .HasColumnName("WAOther");

                entity.Property(e => e.Wastate)
                    .HasMaxLength(100)
                    .HasColumnName("WAState");

                entity.Property(e => e.Wastreet)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreet");

                entity.Property(e => e.WastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreetNo");

                entity.Property(e => e.WazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("WAZipCode");

                entity.Property(e => e.WindowsLogin).HasMaxLength(20);

                entity.Property(e => e.WorkIm)
                    .HasMaxLength(100)
                    .HasColumnName("WorkIM");

                entity.Property(e => e.WorkPermitExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.WorkPermitRef).HasMaxLength(20);

                entity.Property(e => e.WpfCatg)
                    .HasMaxLength(30)
                    .HasColumnName("Wpf_Catg");
            });

            modelBuilder.Entity<MstEmployeeAttachment>(entity =>
            {
                entity.ToTable("MstEmployeeAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FileName).HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeAttachments)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeAttachment_MstEmployee");
            });

            modelBuilder.Entity<MstGrading>(entity =>
            {
                entity.ToTable("MstGrading");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstGratuity>(entity =>
            {
                entity.ToTable("MstGratuity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasedOn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BasedOnValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.FlgAbsoluteYears).HasColumnName("flgAbsoluteYears");

                entity.Property(e => e.FlgEffectiveDate).HasColumnName("flgEffectiveDate");

                entity.Property(e => e.FlgWopleaves).HasColumnName("flgWOPLeaves");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);
            });

            modelBuilder.Entity<MstGratuityDetail>(entity =>
            {
                entity.ToTable("MstGratuityDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.DaysCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FromPoints).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToPoints).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstGratuityDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstGratuityDetail_MstGratuity");
            });

            modelBuilder.Entity<MstLeaveCalendar>(entity =>
            {
                entity.ToTable("MstLeaveCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLeaveDeduction>(entity =>
            {
                entity.ToTable("MstLeaveDeduction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<MstLeaveType>(entity =>
            {
                entity.ToTable("MstLeaveType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionId).HasColumnName("DeductionID");

                entity.Property(e => e.DeductionType).HasMaxLength(10);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgEncash).HasColumnName("flgEncash");

                entity.Property(e => e.LeaveCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.MstLeaveTypes)
                    .HasForeignKey(d => d.DeductionId)
                    .HasConstraintName("FK_MstLeaveType_MstLeaveDeduction");
            });

            modelBuilder.Entity<MstLeavesAllocation>(entity =>
            {
                entity.ToTable("MstLeavesAllocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CarryForwardDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgLeaveCollapse).HasColumnName("flgLeaveCollapse");

                entity.Property(e => e.LeaveBalance)
                    .HasColumnType("numeric(26, 6)")
                    .HasComputedColumnSql("(([LeavesCarryForward]+[LeavesEntitled])-[LeavesUsed])", false);

                entity.Property(e => e.LeaveCollapseDate).HasColumnType("datetime");

                entity.Property(e => e.LeavesCarryForward).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LeavesEntitled).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.LeavesUsed).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstLeavesAllocations)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstLeavesAllocation_MstLeaveType");
            });

            modelBuilder.Entity<MstLoan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLocation>(entity =>
            {
                entity.ToTable("MstLocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
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

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Expression).HasMaxLength(1000);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.FlgFormula).HasColumnName("flgFormula");

                entity.Property(e => e.Hours).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MonthDays).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerDayCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PerMonthCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);
            });

            modelBuilder.Entity<MstPayroll>(entity =>
            {
                entity.ToTable("MstPayroll");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstPeriodEndDt).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgOffDaysExcludedFromSalaryPeriod).HasColumnName("flgOffDaysExcludedFromSalaryPeriod");

                entity.Property(e => e.Gltype)
                    .HasMaxLength(10)
                    .HasColumnName("GLType");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PayrollType).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstShift>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionRuleId).HasColumnName("DeductionRuleID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgHoliDayOverTime).HasColumnName("flgHoliDayOverTime");

                entity.Property(e => e.FlgOffDayOverTime).HasColumnName("flgOffDayOverTime");

                entity.Property(e => e.FlgOtwrkHrs).HasColumnName("flgOTWrkHrs");

                entity.Property(e => e.FlgOverTime).HasColumnName("flgOverTime");

                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstShiftsDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BreakTime).HasMaxLength(20);

                entity.Property(e => e.BufferEndTime).HasMaxLength(20);

                entity.Property(e => e.BufferStartTime).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EndGraceTime).HasMaxLength(20);

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgExpectedIn).HasColumnName("flgExpectedIn");

                entity.Property(e => e.FlgExpectedOut).HasColumnName("flgExpectedOut");

                entity.Property(e => e.FlgOutOverlap).HasColumnName("flgOutOverlap");

                entity.Property(e => e.StartGraceTime).HasMaxLength(20);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstShiftsDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_MstShiftsDetails_MstShifts");
            });

            modelBuilder.Entity<MstState>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.StateName).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstStates)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstStates_MstCountry");
            });

            modelBuilder.Entity<MstTaxSetup>(entity =>
            {
                entity.ToTable("MstTaxSetup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountOnTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MaxSalaryDisc).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinTaxSalaryF).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstTaxSetupDetail>(entity =>
            {
                entity.ToTable("MstTaxSetupDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FixTerm).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TaxValue).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.ToTable("PasswordReset");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.EncryptKey)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TrnsAttendanceRegister>(entity =>
            {
                entity.ToTable("TrnsAttendanceRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateDay)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EarlyInMin).HasMaxLength(10);

                entity.Property(e => e.EarlyOutMin).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgIsNewLeave).HasColumnName("flgIsNewLeave");

                entity.Property(e => e.FlgModified).HasColumnName("flgModified");

                entity.Property(e => e.FlgOffDay).HasColumnName("flgOffDay");

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.FlgProcessed).HasColumnName("flgProcessed");

                entity.Property(e => e.LateInMin).HasMaxLength(10);

                entity.Property(e => e.LateOutMin).HasMaxLength(10);

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeaveDedRule).HasMaxLength(50);

                entity.Property(e => e.LeaveHour).HasMaxLength(10);

                entity.Property(e => e.Othour)
                    .HasMaxLength(10)
                    .HasColumnName("OTHour");

                entity.Property(e => e.Ottype).HasColumnName("OTType");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PreTimeIn).HasMaxLength(10);

                entity.Property(e => e.PreTimeOut).HasMaxLength(10);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.TimeIn).HasMaxLength(10);

                entity.Property(e => e.TimeOut).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkHour).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsAttendanceRegister_MstEmployee");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsAttendanceRegister_MstPayrollPeriods");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsAttendanceRegister_MstShifts");
            });

            modelBuilder.Entity<TrnsDeductionRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TrnsDeductionRulesDetail>(entity =>
            {
                entity.ToTable("TrnsDeductionRulesDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsDeductionRulesDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsDeductionRulesDetail_TrnsDeductionRules");
            });

            modelBuilder.Entity<TrnsEmployeeBonu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PaysInPeriodId).HasColumnName("PaysInPeriodID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsEmployeeBonusDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeBonusDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalculatedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NetSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Percentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryRange).HasMaxLength(100);

                entity.Property(e => e.SlabCode).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeeBonusDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsEmployeeBonusDetail_TrnsEmployeeBonus");
            });

            modelBuilder.Entity<TrnsHolidayCalendar>(entity =>
            {
                entity.ToTable("TrnsHolidayCalendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TrnsHolidayCalendarDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsHolidayCalendarDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsHolidayCalendarDetails_TrnsHolidayCalendar");
            });

            modelBuilder.Entity<TrnsObSalaryAdj>(entity =>
            {
                entity.ToTable("TrnsObSalaryAdj");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObcontribution>(entity =>
            {
                entity.ToTable("TrnsOBContribution");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.ContributionId).HasColumnName("ContributionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObgratuity>(entity =>
            {
                entity.ToTable("TrnsOBGratuity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObleaf>(entity =>
            {
                entity.ToTable("TrnsOBLeaves");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.LeaveUsed).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeavesCarryForward).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeavesEntitled).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsObleaves)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsOBLeaves_MstLeaveType");
            });

            modelBuilder.Entity<TrnsObloan>(entity =>
            {
                entity.ToTable("TrnsOBLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BalanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FkloanId).HasColumnName("FKLoanID");

                entity.Property(e => e.Installment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.Property(e => e.RecoverdAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("numeric(19, 6)")
                    .HasComputedColumnSql("([BalanceAmount]+[RecoverdAmount])", false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObsalary>(entity =>
            {
                entity.ToTable("TrnsOBSalary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObtax>(entity =>
            {
                entity.ToTable("TrnsOBTax");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsTempAttendance>(entity =>
            {
                entity.ToTable("TrnsTempAttendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.FlgProcessed).HasColumnName("flgProcessed");

                entity.Property(e => e.InOut)
                    .HasMaxLength(10)
                    .HasColumnName("In_Out");

                entity.Property(e => e.PunchedDate).HasColumnType("datetime");

                entity.Property(e => e.PunchedTime).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
