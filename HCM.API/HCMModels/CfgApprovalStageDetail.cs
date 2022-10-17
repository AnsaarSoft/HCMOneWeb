using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalStageDetail
    {
        public int Id { get; set; }
        public int? Asid { get; set; }
        public string AuthorizerId { get; set; }
        public string AuthorizerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgDeleted { get; set; }
        public int? FkempId { get; set; }

        public virtual CfgApprovalStage As { get; set; }
    }
}
