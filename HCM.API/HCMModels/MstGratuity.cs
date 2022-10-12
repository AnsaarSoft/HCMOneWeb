using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGratuity
    {
        public MstGratuity()
        {
            CfgPayrollDefinations = new HashSet<CfgPayrollDefination>();
            MstGratuityDetails = new HashSet<MstGratuityDetail>();
        }

        public int Id { get; set; }
        public short? Code { get; set; }
        public string BasedOn { get; set; }
        public decimal? BasedOnValue { get; set; }
        public string GratuityName { get; set; }
        public string GratuityType { get; set; }
        public string GratuityLovtype { get; set; }
        public int? GratuityBasis { get; set; }
        public string SalaryType { get; set; }
        public string SalaryLovType { get; set; }
        public string BasedOnLovtype { get; set; }
        public string YearFrom { get; set; }
        public string YearTo { get; set; }
        public decimal? Factor { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgWopleaves { get; set; }
        public bool? FlgAbsoluteYears { get; set; }
        public bool? FlgEffectiveDate { get; set; }
        public string GrtCode { get; set; }

        public virtual ICollection<CfgPayrollDefination> CfgPayrollDefinations { get; set; }
        public virtual ICollection<MstGratuityDetail> MstGratuityDetails { get; set; }
    }
}
