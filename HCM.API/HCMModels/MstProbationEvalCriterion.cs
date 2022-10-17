using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationEvalCriterion
    {
        public MstProbationEvalCriterion()
        {
            TrnsProbationDetails = new HashSet<TrnsProbationDetail>();
        }

        public int Id { get; set; }
        public string Year { get; set; }
        public string Attribute { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCalendar YearNavigation { get; set; }
        public virtual ICollection<TrnsProbationDetail> TrnsProbationDetails { get; set; }
    }
}
