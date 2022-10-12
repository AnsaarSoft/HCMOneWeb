﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstBenefit
    {
        public MstBenefit()
        {
            TrnsGradeBenifits = new HashSet<TrnsGradeBenifit>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsGradeBenifit> TrnsGradeBenifits { get; set; }
    }
}
