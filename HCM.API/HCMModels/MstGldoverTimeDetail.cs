﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGldoverTimeDetail
    {
        public int Id { get; set; }
        public int? Gldid { get; set; }
        public int? OvertimeId { get; set; }
        public string CostAccount { get; set; }
        public string CostAcctDisplay { get; set; }
        public string BalancingAccount { get; set; }
        public string BalancingAcctDisplay { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstGldetermination Gld { get; set; }
    }
}
