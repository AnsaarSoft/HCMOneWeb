using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeCertification
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? CertificationId { get; set; }
        public string CertificationName { get; set; }
        public string AwardedBy { get; set; }
        public string AwardStatus { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Validated { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual MstCertification Certification { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
