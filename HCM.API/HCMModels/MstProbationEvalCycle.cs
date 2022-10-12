using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationEvalCycle
    {
        public MstProbationEvalCycle()
        {
            TrnsProbationAssesHeads = new HashSet<TrnsProbationAssesHead>();
            TrnsProbationCategorryCycleAttachments = new HashSet<TrnsProbationCategorryCycleAttachment>();
            TrnsProbationHeads = new HashSet<TrnsProbationHead>();
        }

        public int Id { get; set; }
        public int? Year { get; set; }
        public int? Duration { get; set; }
        public string Description { get; set; }
        public int? NotificationDays { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCalendar YearNavigation { get; set; }
        public virtual ICollection<TrnsProbationAssesHead> TrnsProbationAssesHeads { get; set; }
        public virtual ICollection<TrnsProbationCategorryCycleAttachment> TrnsProbationCategorryCycleAttachments { get; set; }
        public virtual ICollection<TrnsProbationHead> TrnsProbationHeads { get; set; }
    }
}
