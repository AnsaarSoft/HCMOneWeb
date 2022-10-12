using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPosition
    {
        public MstPosition()
        {
            MstEmployees = new HashSet<MstEmployee>();
            TrnsEmployeeExitInterviews = new HashSet<TrnsEmployeeExitInterview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public string Attachment { get; set; }
        public int? SbodocEntry { get; set; }
        public int? TypeId { get; set; }
        public int? ParentId { get; set; }
        public int? DepartmentId { get; set; }
        public int? MinGradeId { get; set; }
        public int? MaxGradeId { get; set; }

        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<TrnsEmployeeExitInterview> TrnsEmployeeExitInterviews { get; set; }
    }
}
