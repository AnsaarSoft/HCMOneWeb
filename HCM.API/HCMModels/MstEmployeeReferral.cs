using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeReferral
    {
        public MstEmployeeReferral()
        {
            MstEmployeeReferralsDetails = new HashSet<MstEmployeeReferralsDetail>();
        }

        public int InternalId { get; set; }
        public int? EmpId { get; set; }
        public int? ReferralCounts { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<MstEmployeeReferralsDetail> MstEmployeeReferralsDetails { get; set; }
    }
}
