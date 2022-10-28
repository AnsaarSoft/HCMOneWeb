using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPayrollDefination
    {
        public CfgPayrollDefination()
        {
            AttSummaries = new HashSet<AttSummary>();
            CfgPayrollShifts = new HashSet<CfgPayrollShift>();
            CfgPeriodDates = new HashSet<CfgPeriodDate>();
            MstElementLinks = new HashSet<MstElementLink>();
            MstEmployees = new HashSet<MstEmployee>();
            TrnsBatches = new HashSet<TrnsBatch>();
            TrnsEmployeeArrears = new HashSet<TrnsEmployeeArrear>();
            TrnsEmployeeBonus = new HashSet<TrnsEmployeeBonu>();
            TrnsEmployeeElementRegisters = new HashSet<TrnsEmployeeElementRegister>();
            TrnsEmployeePerPieceProcessings = new HashSet<TrnsEmployeePerPieceProcessing>();
            TrnsEmployeeWorkDays = new HashSet<TrnsEmployeeWorkDay>();
            TrnsFinalSettelmentRegisters = new HashSet<TrnsFinalSettelmentRegister>();
            TrnsIncrementPromotions = new HashSet<TrnsIncrementPromotion>();
            TrnsJes = new HashSet<TrnsJe>();
            TrnsReHireEmployeeDetails = new HashSet<TrnsReHireEmployeeDetail>();
            TrnsSalaryProcessRegisters = new HashSet<TrnsSalaryProcessRegister>();
            TrnsSingleEntryOtrequests = new HashSet<TrnsSingleEntryOtrequest>();
            UserDataAccesses = new HashSet<UserDataAccess>();
        }

        public int Id { get; set; }
        public string PayrollName { get; set; }
        public string PayrollType { get; set; }
        public string PayrollTypeLovtype { get; set; }
        public DateTime? FirstPeriodEndDt { get; set; }
        public bool? WorkDaysType { get; set; }
        public int? WorkDays { get; set; }
        public decimal? WorkHours { get; set; }
        public string CostCenter { get; set; }
        public string Gltype { get; set; }
        public bool? FlgGratuity { get; set; }
        public int? GratuityId { get; set; }
        public bool? FlgPmcash { get; set; }
        public bool? FlgPmcheque { get; set; }
        public bool? FlgPmbankTransfer { get; set; }
        public bool? FlgTax { get; set; }
        public bool? FlgOt { get; set; }
        public int? Otvalue { get; set; }
        public int? ArearElement { get; set; }
        public int? DedArearElement { get; set; }
        public int? Leelemen { get; set; }
        public int? AddDaysEle { get; set; }
        public int? DedDaysEle { get; set; }
        public bool? FlgIsDefault { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Prefix { get; set; }
        public decimal? PayrollWiseSortOrder { get; set; }
        public bool? FlgOffDaysExcludedFromSalaryPeriod { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstGratuity Gratuity { get; set; }
        public virtual ICollection<AttSummary> AttSummaries { get; set; }
        public virtual ICollection<CfgPayrollShift> CfgPayrollShifts { get; set; }
        public virtual ICollection<CfgPeriodDate> CfgPeriodDates { get; set; }
        public virtual ICollection<MstElementLink> MstElementLinks { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<TrnsBatch> TrnsBatches { get; set; }
        public virtual ICollection<TrnsEmployeeArrear> TrnsEmployeeArrears { get; set; }
        public virtual ICollection<TrnsEmployeeBonu> TrnsEmployeeBonus { get; set; }
        public virtual ICollection<TrnsEmployeeElementRegister> TrnsEmployeeElementRegisters { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceProcessing> TrnsEmployeePerPieceProcessings { get; set; }
        public virtual ICollection<TrnsEmployeeWorkDay> TrnsEmployeeWorkDays { get; set; }
        public virtual ICollection<TrnsFinalSettelmentRegister> TrnsFinalSettelmentRegisters { get; set; }
        public virtual ICollection<TrnsIncrementPromotion> TrnsIncrementPromotions { get; set; }
        public virtual ICollection<TrnsJe> TrnsJes { get; set; }
        public virtual ICollection<TrnsReHireEmployeeDetail> TrnsReHireEmployeeDetails { get; set; }
        public virtual ICollection<TrnsSalaryProcessRegister> TrnsSalaryProcessRegisters { get; set; }
        public virtual ICollection<TrnsSingleEntryOtrequest> TrnsSingleEntryOtrequests { get; set; }
        public virtual ICollection<UserDataAccess> UserDataAccesses { get; set; }
    }
}
