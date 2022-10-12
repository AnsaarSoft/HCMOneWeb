using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSchoolPensionRequest
    {
        public TrnsSchoolPensionRequest()
        {
            TrnsSchoolPensionRequestDetails = new HashSet<TrnsSchoolPensionRequestDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Contract { get; set; }
        public string MeetRequirement { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int? TotalAmount { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsSchoolPensionRequestDetail> TrnsSchoolPensionRequestDetails { get; set; }
    }
}
