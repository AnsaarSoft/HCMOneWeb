using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObcontribution
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ContributionId { get; set; }
        public int ContributionType { get; set; }
        public decimal? Balance { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public DateTime? Month { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstElementContribution Contribution { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
