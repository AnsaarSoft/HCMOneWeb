using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPart
    {
        public MstPart()
        {
            MstSubPartsses = new HashSet<MstSubPartss>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Weightage { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public bool? FlgQuantitative { get; set; }

        public virtual MstDepartment Department { get; set; }
        public virtual MstDesignation Designation { get; set; }
        public virtual ICollection<MstSubPartss> MstSubPartsses { get; set; }
    }
}
