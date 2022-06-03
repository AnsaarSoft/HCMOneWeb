using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstElement
    {
        public MstElement()
        {
            MstElementContributions = new HashSet<MstElementContribution>();
            MstElementDeductions = new HashSet<MstElementDeduction>();
            MstElementEarnings = new HashSet<MstElementEarning>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ElmtType { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool? FlgActive { get; set; }

        public virtual ICollection<MstElementContribution> MstElementContributions { get; set; }
        public virtual ICollection<MstElementDeduction> MstElementDeductions { get; set; }
        public virtual ICollection<MstElementEarning> MstElementEarnings { get; set; }
    }
}
