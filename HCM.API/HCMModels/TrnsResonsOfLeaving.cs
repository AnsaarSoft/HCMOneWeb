using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsResonsOfLeaving
    {
        public int Id { get; set; }
        public int? ExitInterviewId { get; set; }
        public string RlreasonOfLeaving { get; set; }
        public string RlforcedReason { get; set; }
        public string RlprocedureContributedToLeave { get; set; }
        public string RllocationJob { get; set; }
        public string RlcouldDoToStayWithUs { get; set; }
        public string WnwhatGoingToDo { get; set; }
        public string WnwhatSortOfJob { get; set; }
        public string WnwhatAttractNewJob { get; set; }
        public string WnnewJobDifferFromCurrent { get; set; }
        public string WnnewJobBenefits { get; set; }
        public string SgjobDescAccuratnt { get; set; }
        public string SggoalsClearInEmployment { get; set; }
        public string SggoodTimeWithUs { get; set; }
        public string SgbadTimeWithUs { get; set; }
        public string SgskillsUsedToAdvantage { get; set; }
        public string SgdoyouGetSupport { get; set; }
        public string SghowWeMakeFullerUseOfYourSkills { get; set; }
        public string SgsayAboutCommunication { get; set; }
        public string SgwhatImprovCanBe { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
    }
}
