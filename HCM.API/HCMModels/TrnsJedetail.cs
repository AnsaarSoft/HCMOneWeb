using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJedetail
    {
        public int Id { get; set; }
        public int? Jeid { get; set; }
        public string AcctCode { get; set; }
        public string AcctName { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public string CostCenter { get; set; }
        public string BranchName { get; set; }
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
        public string Dimension4 { get; set; }
        public string Dimension5 { get; set; }
        public string Project { get; set; }
        public int? LocationId { get; set; }
        public string Fcurrency { get; set; }

        public virtual TrnsJe Je { get; set; }
    }
}
