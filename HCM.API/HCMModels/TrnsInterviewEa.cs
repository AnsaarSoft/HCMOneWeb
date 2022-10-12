using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewEa
    {
        public TrnsInterviewEa()
        {
            TrnsInterviewEasassetments = new HashSet<TrnsInterviewEasassetment>();
            TrnsInterviewEaspanelists = new HashSet<TrnsInterviewEaspanelist>();
            TrnsInterviewEasscoreBoards = new HashSet<TrnsInterviewEasscoreBoard>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public string DocStatus { get; set; }
        public int? InterviewId { get; set; }
        public decimal? AssetmentScore { get; set; }
        public decimal? KnowledgeSkillScore { get; set; }
        public string Result { get; set; }
        public bool? FlgSelected { get; set; }
        public decimal? BudgetSalary { get; set; }
        public decimal? RecommendedSalary { get; set; }
        public decimal? ApprovedSalary { get; set; }
        public string ContractType { get; set; }
        public string ContractTypeLov { get; set; }
        public byte? ProbationValue { get; set; }
        public string ProbationUnit { get; set; }
        public bool? FlgAccepted { get; set; }
        public bool? FlgContract { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsInterviewCall Interview { get; set; }
        public virtual ICollection<TrnsInterviewEasassetment> TrnsInterviewEasassetments { get; set; }
        public virtual ICollection<TrnsInterviewEaspanelist> TrnsInterviewEaspanelists { get; set; }
        public virtual ICollection<TrnsInterviewEasscoreBoard> TrnsInterviewEasscoreBoards { get; set; }
    }
}
