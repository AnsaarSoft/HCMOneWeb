using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeReferralsDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public int? ReferralEmpId { get; set; }
        public bool FlgActive { get; set; }

        public virtual MstEmployeeReferral Fk { get; set; }
        public virtual MstEmployee ReferralEmp { get; set; }
    }
}
