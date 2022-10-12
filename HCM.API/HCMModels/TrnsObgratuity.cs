using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObgratuity
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public decimal? OpeningBalance { get; set; }
        public DateTime? Month { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
