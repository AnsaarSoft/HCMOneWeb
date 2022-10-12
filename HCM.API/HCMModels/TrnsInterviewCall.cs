using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewCall
    {
        public TrnsInterviewCall()
        {
            TrnsInterviewAssessments = new HashSet<TrnsInterviewAssessment>();
            TrnsInterviewCallActivities = new HashSet<TrnsInterviewCallActivity>();
            TrnsInterviewCallPanelLists = new HashSet<TrnsInterviewCallPanelList>();
            TrnsInterviewEas = new HashSet<TrnsInterviewEa>();
            TrnsInterviewRecommendations = new HashSet<TrnsInterviewRecommendation>();
        }

        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string CallStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public int? VacancyNo { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Scheduling { get; set; }
        public DateTime? SchDate { get; set; }
        public int? Location { get; set; }
        public string ReminderUnit { get; set; }
        public string Reminder { get; set; }
        public int? Status { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string InterviewTime { get; set; }
        public int? InterviewNo { get; set; }

        public virtual MstCandidate Candidate { get; set; }
        public virtual ICollection<TrnsInterviewAssessment> TrnsInterviewAssessments { get; set; }
        public virtual ICollection<TrnsInterviewCallActivity> TrnsInterviewCallActivities { get; set; }
        public virtual ICollection<TrnsInterviewCallPanelList> TrnsInterviewCallPanelLists { get; set; }
        public virtual ICollection<TrnsInterviewEa> TrnsInterviewEas { get; set; }
        public virtual ICollection<TrnsInterviewRecommendation> TrnsInterviewRecommendations { get; set; }
    }
}
