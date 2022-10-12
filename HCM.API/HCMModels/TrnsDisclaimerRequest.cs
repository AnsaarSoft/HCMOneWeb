using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDisclaimerRequest
    {
        public int DiscId { get; set; }
        public DateTime? DocDate { get; set; }
        public int? EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Sector { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string FinanceCustody { get; set; }
        public string ItCustody { get; set; }
        public string HrCustody { get; set; }
        public string GeneralCustody { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string PublicCustody { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public int? DocNum { get; set; }
        public string DocAprStatus { get; set; }

        public virtual MstEmployee EmployeeCodeNavigation { get; set; }
    }
}
