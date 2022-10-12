using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsBonu
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public decimal? Value { get; set; }
        public int? Quarter { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
