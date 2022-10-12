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

        public virtual CfgApprovalStage As { get; set; }
    }
}
