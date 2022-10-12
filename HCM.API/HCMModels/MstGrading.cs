using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGrading
    {
        public MstGrading()
        {
            MstDesigLinkGrades = new HashSet<MstDesigLinkGrade>();
            MstDesignations = new HashSet<MstDesignation>();
            MstEmployees = new HashSet<MstEmployee>();
            TrnsEmployeeExitInterviews = new HashSet<TrnsEmployeeExitInterview>();
            TrnsGradeBenifits = new HashSet<TrnsGradeBenifit>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? MaxSalary { get; set; }
        public decimal? MinSalary { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string Glcode { get; set; }
        public string Gldescription { get; set; }
        public int? Pbid { get; set; }
        public string AllowanceCode { get; set; }

        public virtual ICollection<MstDesigLinkGrade> MstDesigLinkGrades { get; set; }
        public virtual ICollection<MstDesignation> MstDesignations { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<TrnsEmployeeExitInterview> TrnsEmployeeExitInterviews { get; set; }
        public virtual ICollection<TrnsGradeBenifit> TrnsGradeBenifits { get; set; }
    }
}
