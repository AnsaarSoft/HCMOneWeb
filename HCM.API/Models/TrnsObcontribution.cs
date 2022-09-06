﻿using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsObcontribution
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int ContributionId { get; set; }
        public int ContributionType { get; set; }
        public decimal OpeningBalance { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
