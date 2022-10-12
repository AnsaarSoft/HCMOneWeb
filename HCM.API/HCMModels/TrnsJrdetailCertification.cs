using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJrdetailCertification
    {
        public int Id { get; set; }
        public int? Jrid { get; set; }
        public int? CertificationType { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCertification CertificationTypeNavigation { get; set; }
        public virtual TrnsJobRequisition Jr { get; set; }
    }
}
