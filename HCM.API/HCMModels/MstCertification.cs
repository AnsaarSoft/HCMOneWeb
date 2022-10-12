using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCertification
    {
        public MstCertification()
        {
            MstEmployeeCertifications = new HashSet<MstEmployeeCertification>();
            TrnsJrdetailCertifications = new HashSet<TrnsJrdetailCertification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual ICollection<MstEmployeeCertification> MstEmployeeCertifications { get; set; }
        public virtual ICollection<TrnsJrdetailCertification> TrnsJrdetailCertifications { get; set; }
    }
}
