using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLeaveRequestHistory
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public byte? OrderId { get; set; }
        public string ApproverName { get; set; }
        public bool? FlgAction { get; set; }
        public string StatusId { get; set; }
        public string StatusLovtype { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsLeavesRequest Request { get; set; }
    }
}
