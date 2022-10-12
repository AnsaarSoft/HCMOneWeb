using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewAssessment
    {
        public TrnsInterviewAssessment()
        {
            TrnsInterviewAssessmentDetails = new HashSet<TrnsInterviewAssessmentDetail>();
        }

        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? VacancyCode { get; set; }
        public int? PositionId { get; set; }
        public string Education { get; set; }
        public string LastPositon { get; set; }
        public string OrganizationName { get; set; }
        public decimal? CurrentSalary { get; set; }
        public decimal? ExpectedSalary { get; set; }
        public int? TechnicalSkills { get; set; }
        public int? JobKnowledge { get; set; }
        public int? Experience { get; set; }
        public int? Presentation { get; set; }
        public int? Stablity { get; set; }
        public int? Creativity { get; set; }
        public int? Communication { get; set; }
        public int? Confidence { get; set; }
        public int? Adaptiblity { get; set; }
        public int? Intelligence { get; set; }
        public int? Thoroughness { get; set; }
        public int? Teamwork { get; set; }
        public int? Planning { get; set; }
        public int? Leadorship { get; set; }
        public int? Growth { get; set; }
        public int? ResourceManagement { get; set; }
        public int? DecisionMaking { get; set; }
        public string CommentsEdu { get; set; }
        public string CommentsSkills { get; set; }
        public string CommentsGeneral { get; set; }
        /// <summary>
        /// Recommended for Employment, Not Recommended, Holder for this position, Holder for other posiiton
        /// </summary>
        public string FinalAssessment { get; set; }
        public string InterviewerName { get; set; }
        public int? Designation { get; set; }
        public int? TotalScore { get; set; }
        public bool? DocStatus { get; set; }
        public int? ObtainedScore { get; set; }
        public int? InterviewCallId { get; set; }
        public string RecommendedSalary { get; set; }

        public virtual MstCandidate Candidate { get; set; }
        public virtual MstDesignation DesignationNavigation { get; set; }
        public virtual TrnsInterviewCall InterviewCall { get; set; }
        public virtual ICollection<TrnsInterviewAssessmentDetail> TrnsInterviewAssessmentDetails { get; set; }
    }
}
