using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstSubPartsStatement
    {
        public MstSubPartsStatement()
        {
            PerformanceStatementTermAttachments = new HashSet<PerformanceStatementTermAttachment>();
        }

        public int Id { get; set; }
        public string Statement { get; set; }
        public int? Weightage { get; set; }
        public bool? FlgActive { get; set; }
        public int? SubPartId { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? ChkFirstEval { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public string HowToAchieve { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string Unit { get; set; }
        public decimal? Budget { get; set; }
        public int? EmpId { get; set; }

        public virtual MstDepartment Department { get; set; }
        public virtual MstDesignation Designation { get; set; }
        public virtual MstSubPartss SubPart { get; set; }
        public virtual ICollection<PerformanceStatementTermAttachment> PerformanceStatementTermAttachments { get; set; }
    }
}
