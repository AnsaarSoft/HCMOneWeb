using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPayrollBasicInitialization
    {
        public int Id { get; set; }
        public bool? Sapb1integration { get; set; }
        public bool? AttendanceSystem { get; set; }
        public bool? ProjectBased { get; set; }
        public bool? TaxSetup { get; set; }
        public short? WorkingDays { get; set; }
        public decimal? WorkingHours { get; set; }
        public bool? ProvidentFund { get; set; }
        public short? EligibilityValue { get; set; }
        public int? EligibilityType { get; set; }
        public bool? Gratuity { get; set; }
        public string Eobi { get; set; }
        public decimal? EoBiEmployeeValue { get; set; }
        public decimal? EoBiEmployerValue { get; set; }
        public decimal? EmployeeMaxContribution { get; set; }
        public decimal? EmployerMaxContribution { get; set; }
        public bool? Sscompany { get; set; }
        public int? SsnoOfEmployee { get; set; }
        public string Ssbasis { get; set; }
        public string SsbasisLovtype { get; set; }
        public decimal? Ssvalue { get; set; }
        public decimal? SsmaxContribution { get; set; }
        public string SboUid { get; set; }
        public string SboPwd { get; set; }
        public bool? FlgArabic { get; set; }
        public bool? FlgCostCenterGl { get; set; }
        public bool? FlgAbsent { get; set; }
        public bool? FlgBranches { get; set; }
        public bool? FlgEmployeeFilter { get; set; }
        public bool? FlgAutoNumber { get; set; }
        public bool? FlgMultipleDimension { get; set; }
        public bool? FlgA1integration { get; set; }
        public bool? FlgUnitFeature { get; set; }
        public bool? FlgSsl { get; set; }
        public bool? FlgLeaveCalendar { get; set; }
        public bool? FlgProject { get; set; }
        public bool? FlgBasicCalculation { get; set; }
        public decimal? BasicPercentage { get; set; }
        public bool? FlgPerformanceCalculation { get; set; }
        public decimal? PerformancePercentage { get; set; }
        public bool? FlgRetailRules1 { get; set; }
        public bool? FlgProcessingOnAttendance { get; set; }
        public bool? FlgJelocationWise { get; set; }
        public bool? FlgHiredGrossTaxable { get; set; }
        public bool? FlgAdjustedAttendanceProcessing { get; set; }
        public string CompanyName { get; set; }
        public bool? FlgJecurrency { get; set; }
        public bool? FlgLateInEarlyOutLeaveRules { get; set; }
        public int? LoanYears { get; set; }
        public int? ElementLoanYears { get; set; }
        public bool? FlgAfricaRegion { get; set; }
        public bool? FlgFormulaEarnings { get; set; }
        public bool? FlgSlabDeductions { get; set; }
        public int? TaxConfiguration { get; set; }
        public bool? FlgOtcapCompany { get; set; }
        public decimal? MontlyCap { get; set; }
        public decimal? DailyCap { get; set; }
        public bool? FlgPublicSectorGratuity { get; set; }
        public bool? FlgSimpleIntegration { get; set; }
        public bool? FlgLoanBackDate { get; set; }
        public bool? FlgLoanInstallmentFix { get; set; }
        public bool? FlgLoanGrossRule { get; set; }
        public bool? FlgBonusOneRule { get; set; }
        public bool? FlgIncrementTwoRule { get; set; }
        public bool? FlgLeaveGradeWise { get; set; }
        public bool? FlgMedicalRule { get; set; }
        public decimal? MedicalPercent { get; set; }
        public int? MedicalElement { get; set; }
        public bool? FlgSpecialLeaveEncashment { get; set; }
        public int? Leelement { get; set; }
        public bool? FlgSpecialGratuity { get; set; }
        public bool? FlgAttAllowance { get; set; }
        public bool? FlgEmployeeCodeSeries { get; set; }
        public bool? FlgTaxSetup { get; set; }
        public bool? FlgAttendanceSystem { get; set; }
        public bool? FlgPayrollWithSap { get; set; }
    }
}
