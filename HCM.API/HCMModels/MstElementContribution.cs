using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementContribution
    {
        public MstElementContribution()
        {
            TrnsObcontributions = new HashSet<TrnsObcontribution>();
        }

        public int Id { get; set; }
        public int? ElementId { get; set; }
        public string ContributionId { get; set; }
        public string ContributionLovtype { get; set; }
        public int? FormulaBuilderId { get; set; }
        public decimal? Employee { get; set; }
        public decimal? Employer { get; set; }
        public bool? FlgEos { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? ContTaxDiscount { get; set; }
        public bool? FlgVariableValue { get; set; }
        public decimal? MaxAppAmount { get; set; }
        public decimal? MaxEmployerContribution { get; set; }
        public decimal? MaxEmployeeContribution { get; set; }
        public int? DaysRangeFrom { get; set; }
        public int? DaysRangeTo { get; set; }
        public decimal? SalaryRangeFrom { get; set; }
        public decimal? SalaryRangeTo { get; set; }
        public string ValidOnSalary { get; set; }
        public decimal? EarnedSalary { get; set; }
        public string FormulaCode { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual ICollection<TrnsObcontribution> TrnsObcontributions { get; set; }
    }
}
