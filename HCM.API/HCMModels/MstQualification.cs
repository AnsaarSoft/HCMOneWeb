using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstQualification
    {
        public MstQualification()
        {
            MstEmployeeEducations = new HashSet<MstEmployeeEducation>();
            TrnsJrdetailEducations = new HashSet<TrnsJrdetailEducation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public string Ftsprof { get; set; }

        public virtual ICollection<MstEmployeeEducation> MstEmployeeEducations { get; set; }
        public virtual ICollection<TrnsJrdetailEducation> TrnsJrdetailEducations { get; set; }
    }
}
