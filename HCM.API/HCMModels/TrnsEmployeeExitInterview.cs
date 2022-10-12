using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeExitInterview
    {
        public TrnsEmployeeExitInterview()
        {
            TrnsEmployeeExitInterviewAttaches = new HashSet<TrnsEmployeeExitInterviewAttach>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? GradeId { get; set; }
        public int? DeptId { get; set; }
        public int? GenderId { get; set; }
        public int? PositionId { get; set; }
        public string TypeOfContract { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDateAtSamson { get; set; }
        public DateTime? EndDateAtSamson { get; set; }
        public string WhichFactorsAttracted { get; set; }
        public string MostLikeJob { get; set; }
        public string LeastLikeJob { get; set; }
        public string ReasonOfLeaving { get; set; }
        public string Jrchallenge { get; set; }
        public string Jrworkload { get; set; }
        public string JrphysicalWorkCondition { get; set; }
        public string JropprGrowth { get; set; }
        public string JrsignificanceWork { get; set; }
        public string JrdirectionSense { get; set; }
        public string Jrsalary { get; set; }
        public string Jrbenefits { get; set; }
        public string JrjobTraining { get; set; }
        public string EeavailabilityJobDescription { get; set; }
        public string Eesupervision { get; set; }
        public string EecolleaguesAttitude { get; set; }
        public string EecoopTopManagement { get; set; }
        public string EefeedbackSystem { get; set; }
        public string EeformalTraining { get; set; }
        public string Eediscrimination { get; set; }
        public string Eeharrasment { get; set; }
        public string WouldYouRecommendFriend { get; set; }
        public string NewEmployer { get; set; }
        public string Hrcomments { get; set; }
        public string RlreasonOfLeaving { get; set; }
        public string RlforcedReason { get; set; }
        public string RlprocedureContributedToLeave { get; set; }
        public string RllocationJob { get; set; }
        public string RlcouldDoToStayWithUs { get; set; }
        public string WnwhatGoingToDo { get; set; }
        public string WnwhatSortOfJob { get; set; }
        public string WnwhatAttractNewJob { get; set; }
        public string WnnewJobDifferFromCurrent { get; set; }
        public string WnnewEmployer { get; set; }
        public string WnnewJobBenefits { get; set; }
        public string SgjobDescAccuratnt { get; set; }
        public string SggoalsClearInEmployment { get; set; }
        public string SggoodTimeWithUs { get; set; }
        public string SgbadTimeWithUs { get; set; }
        public string SgskillsUsedToAdvantage { get; set; }
        public string SgdoyouGetSupport { get; set; }
        public string SghowWeMakeFullerUseOfYourSkills { get; set; }
        public string SgwhatImprovCanBe { get; set; }
        public string SgsayAboutCommunication { get; set; }
        public string Sgchallenge { get; set; }
        public string Sgworkload { get; set; }
        public string SgphysicalWorkingCondition { get; set; }
        public string SgoppForGrowth { get; set; }
        public string SgsignificaneOfWork { get; set; }
        public string SgsenseOfDirection { get; set; }
        public string Sgsalary { get; set; }
        public string Sgbenefits { get; set; }
        public string SgjobTraining { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public string SslQ151 { get; set; }
        public string SslQ1512 { get; set; }
        public string SslQ1513 { get; set; }
        public string SslQ1514 { get; set; }
        public string SslQ1515 { get; set; }
        public string SslQ1516 { get; set; }

        public virtual MstDepartment Dept { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual MstGrading Grade { get; set; }
        public virtual MstPosition Position { get; set; }
        public virtual ICollection<TrnsEmployeeExitInterviewAttach> TrnsEmployeeExitInterviewAttaches { get; set; }
    }
}
