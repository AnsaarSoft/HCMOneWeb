using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstForm
    {
        public int Id { get; set; }
        public int FormCode { get; set; }
        public string FormName { get; set; }
        public bool FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgPayrollForms { get; set; }
    }
}
