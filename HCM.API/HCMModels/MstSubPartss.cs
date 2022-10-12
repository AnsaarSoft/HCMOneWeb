using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstSubPartss
    {
        public MstSubPartss()
        {
            MstSubPartsStatements = new HashSet<MstSubPartsStatement>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public int? Weightage { get; set; }
        public int? PartId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? AddedByEmployee { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }

        public virtual MstDepartment Department { get; set; }
        public virtual MstDesignation Designation { get; set; }
        public virtual MstPart Part { get; set; }
        public virtual ICollection<MstSubPartsStatement> MstSubPartsStatements { get; set; }
    }
}
