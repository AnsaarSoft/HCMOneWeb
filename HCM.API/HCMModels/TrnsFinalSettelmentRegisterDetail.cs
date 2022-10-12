using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsFinalSettelmentRegisterDetail
    {
        public int Id { get; set; }
        public int Fsid { get; set; }
        public int? LineBaseEntry { get; set; }
        public string LineType { get; set; }
        public string LineSubType { get; set; }
        public decimal? LineValue { get; set; }
        public string LineMemo { get; set; }
        public decimal? BaseValue { get; set; }
        public string BaseValueType { get; set; }
        public decimal? BaseValueCalculatedOn { get; set; }
        public decimal? NoOfDay { get; set; }
        public decimal? Othours { get; set; }
        public string CreditAccount { get; set; }
        public string CreditAccountName { get; set; }
        public string DebitAccount { get; set; }
        public string DebitAccountName { get; set; }
        public decimal? CreditValue { get; set; }
        public decimal? DebitValue { get; set; }
        public bool? FlgGross { get; set; }
        public bool? FlgStandard { get; set; }
        public short? SortOrder { get; set; }
        public decimal? TaxableAmount { get; set; }
        public string CostType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgCashDed { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public string DealerCode { get; set; }

        public virtual TrnsFinalSettelmentRegister Fs { get; set; }
    }
}
