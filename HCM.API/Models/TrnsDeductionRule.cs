﻿using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsDeductionRule
    {
        public TrnsDeductionRule()
        {
            TrnsDeductionRulesDetails = new HashSet<TrnsDeductionRulesDetail>();
        }

        public int Id { get; set; }
        public int DocNo { get; set; }
        public string Code { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TrnsDeductionRulesDetail> TrnsDeductionRulesDetails { get; set; }
    }
}
