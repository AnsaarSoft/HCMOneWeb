using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstElementContribution
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string? ValueType { get; set; }
        public decimal? Value { get; set; }
        public bool? FlgProcessInPayroll { get; set; }
        public bool? FlgStandardElement { get; set; }
        public bool? FlgEffectOnGross { get; set; }
        public bool? FlgProbationApplicable { get; set; }
        public bool? FlgNotTaxable { get; set; }
        public bool? FlgEos { get; set; }
        public bool? FlgVariableValue { get; set; }
        public bool? FlgPropotionate { get; set; }
        public decimal? EmployeeContribution { get; set; }
        public decimal? EmployerContribution { get; set; }
        public decimal? EmployeeContributionMax { get; set; }
        public decimal? EmployerContributionMax { get; set; }
        public decimal? ApplicableAmountMax { get; set; }

        public virtual MstElement? Fk { get; set; }
    }
}
