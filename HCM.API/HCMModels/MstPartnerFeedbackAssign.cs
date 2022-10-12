using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerFeedbackAssign
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? FeedbackId { get; set; }
        public int? EmpId { get; set; }
        public string FunctionName { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstPartnerFeedback Feedback { get; set; }
        public virtual MstCalendar Year { get; set; }
    }
}
