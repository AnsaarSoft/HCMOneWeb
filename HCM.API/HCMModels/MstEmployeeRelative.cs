using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeRelative
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string RelativeId { get; set; }
        public string RelativeLovtype { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public DateTime? Bod { get; set; }
        public bool? FlgDependent { get; set; }
        public string MedicalCardNo { get; set; }
        public DateTime? MedicalCardStartDate { get; set; }
        public DateTime? MedicalCardExpiryDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public int? OccupationId { get; set; }
        public string IdnoRelative { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
