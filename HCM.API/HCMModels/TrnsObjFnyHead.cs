using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObjFnyHead
    {
        public TrnsObjFnyHead()
        {
            TrnsObjFnyDetails = new HashSet<TrnsObjFnyDetail>();
        }

        public int Id { get; set; }
        public string YearId { get; set; }
        public int? EmpId { get; set; }
        public int? ObjectiveId { get; set; }
        public bool? FlgHrapproval { get; set; }
        public string FieldForCalc { get; set; }
        public string Comments { get; set; }
        public string SupervisorCalculation { get; set; }
        public string Subheading { get; set; }
        public decimal? Weightage { get; set; }
        public string KpIndicator { get; set; }
        public string Timeline { get; set; }
        public string ApprovalStatus { get; set; }
        public int? DocNumber { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string SelfProgress { get; set; }
        public string SupervisorProgress { get; set; }
        public int? TermId { get; set; }
        public string SuperVisorComments { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstObjective Objective { get; set; }
        public virtual MstCalendar Year { get; set; }
        public virtual ICollection<TrnsObjFnyDetail> TrnsObjFnyDetails { get; set; }
    }
}
