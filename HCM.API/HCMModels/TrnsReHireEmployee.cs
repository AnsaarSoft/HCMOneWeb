using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsReHireEmployee
    {
        public TrnsReHireEmployee()
        {
            TrnsReHireEmployeeDetails = new HashSet<TrnsReHireEmployeeDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? DocNum { get; set; }
        public int? DocTypeId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsReHireEmployeeDetail> TrnsReHireEmployeeDetails { get; set; }
    }
}
