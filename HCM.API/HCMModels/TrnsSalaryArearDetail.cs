using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryArearDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string LineType { get; set; }
        public string LineSubType { get; set; }
        public int? LineBaseEntry { get; set; }
        public decimal? LineValue { get; set; }
        public string LineMemo { get; set; }
        public decimal? BaseValue { get; set; }
        public string BaseValueType { get; set; }
        public decimal? BaseValueCalculatedOn { get; set; }
        public decimal? NoOfDay { get; set; }
        public int? ElementId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? TaxableAmount { get; set; }
        public decimal? Othours { get; set; }
        public bool? FlgEffectOnGross { get; set; }
        public bool? FlgSalaryArear { get; set; }

        public virtual TrnsSalaryArear Fk { get; set; }
    }
}
