using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElement
    {
        public MstElement()
        {
            CfgFormulaElements = new HashSet<CfgFormulaElement>();
            CfgLeaveMatrices = new HashSet<CfgLeaveMatrix>();
            MstElementContributions = new HashSet<MstElementContribution>();
            MstElementDeductions = new HashSet<MstElementDeduction>();
            MstElementEarnings = new HashSet<MstElementEarning>();
            MstElementInformations = new HashSet<MstElementInformation>();
            MstElementLinks = new HashSet<MstElementLink>();
            MstReferralSchemes = new HashSet<MstReferralScheme>();
            MstRetroElementDetails = new HashSet<MstRetroElementDetail>();
            TrnsBatches = new HashSet<TrnsBatch>();
            TrnsEmployeeAttendanceAllowances = new HashSet<TrnsEmployeeAttendanceAllowance>();
            TrnsEmployeeElementDetail1s = new HashSet<TrnsEmployeeElementDetail1>();
            TrnsEmployeeElementDetails = new HashSet<TrnsEmployeeElementDetail>();
            TrnsEmployeeElementRegisterDetails = new HashSet<TrnsEmployeeElementRegisterDetail>();
            TrnsSalaryChanges = new HashSet<TrnsSalaryChange>();
        }

        public int Id { get; set; }
        public string ElementName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ElmtType { get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }
        public decimal? Value { get; set; }
        public string ElmtTypeLovType { get; set; }
        public string TypeLovType { get; set; }
        public bool? FlgProcessInPayroll { get; set; }
        public bool? FlgStandardElement { get; set; }
        public bool? FlgEffectOnGross { get; set; }
        public bool? FlgProbationApplicable { get; set; }
        public bool FlgConfirmDateProcessing { get; set; }
        public bool? FlgVgross { get; set; }
        public bool? FlgGosi { get; set; }
        public bool? FlgConBatch { get; set; }
        public bool? FlgPerformance { get; set; }
        public bool? FlgShiftDays { get; set; }
        public bool? FlgAttendanceAllowance { get; set; }
        public bool? FlgRemainingAmount { get; set; }
        public bool? FlgEmployeeBonus { get; set; }
        public bool? FlgQueryable { get; set; }
        public bool? FlgOldAgeBenifit { get; set; }
        public bool? FlgPfloan { get; set; }
        public bool? FlgRunningTotal { get; set; }
        public bool? FlgGradeDep { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgCash { get; set; }
        public bool? FlgPerDay { get; set; }
        public bool? FlgSalaryArear { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgBonus { get; set; }
        public decimal? EmployeeContribution { get; set; }
        public decimal? EmployerContribution { get; set; }
        public decimal? EmployeeContributionMax { get; set; }
        public decimal? EmployerContributionMax { get; set; }
        public decimal? ApplicableAmountMax { get; set; }
        public bool? FlgNotTaxable { get; set; }
        public bool? FlgEos { get; set; }
        public bool? FlgVariableValue { get; set; }
        public bool? FlgPropotionate { get; set; }

        public virtual ICollection<CfgFormulaElement> CfgFormulaElements { get; set; }
        public virtual ICollection<CfgLeaveMatrix> CfgLeaveMatrices { get; set; }
        public virtual ICollection<MstElementContribution> MstElementContributions { get; set; }
        public virtual ICollection<MstElementDeduction> MstElementDeductions { get; set; }
        public virtual ICollection<MstElementEarning> MstElementEarnings { get; set; }
        public virtual ICollection<MstElementInformation> MstElementInformations { get; set; }
        public virtual ICollection<MstElementLink> MstElementLinks { get; set; }
        public virtual ICollection<MstReferralScheme> MstReferralSchemes { get; set; }
        public virtual ICollection<MstRetroElementDetail> MstRetroElementDetails { get; set; }
        public virtual ICollection<TrnsBatch> TrnsBatches { get; set; }
        public virtual ICollection<TrnsEmployeeAttendanceAllowance> TrnsEmployeeAttendanceAllowances { get; set; }
        public virtual ICollection<TrnsEmployeeElementDetail1> TrnsEmployeeElementDetail1s { get; set; }
        public virtual ICollection<TrnsEmployeeElementDetail> TrnsEmployeeElementDetails { get; set; }
        public virtual ICollection<TrnsEmployeeElementRegisterDetail> TrnsEmployeeElementRegisterDetails { get; set; }
        public virtual ICollection<TrnsSalaryChange> TrnsSalaryChanges { get; set; }
    }
}
