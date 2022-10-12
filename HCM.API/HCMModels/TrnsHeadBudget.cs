using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsHeadBudget
    {
        public TrnsHeadBudget()
        {
            TrnsHeadBudgetDetails = new HashSet<TrnsHeadBudgetDetail>();
        }

        public int Id { get; set; }
        public int? Location { get; set; }
        public string LocationName { get; set; }
        public int? DocNum { get; set; }
        public string Description { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public DateTime? FromDt { get; set; }
        public DateTime? ToDt { get; set; }
        public int? Company { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstLocation LocationNavigation { get; set; }
        public virtual ICollection<TrnsHeadBudgetDetail> TrnsHeadBudgetDetails { get; set; }
    }
}
