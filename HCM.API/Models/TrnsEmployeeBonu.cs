using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsEmployeeBonu
    {
        public TrnsEmployeeBonu()
        {
            TrnsEmployeeBonusDetails = new HashSet<TrnsEmployeeBonusDetail>();
        }

        public int Id { get; set; }
        public int? DocumentNo { get; set; }
        public int? CalendarId { get; set; }
        public int? PayrollId { get; set; }
        public int? PaysInPeriodId { get; set; }
        public int? ElementType { get; set; }
        public string Status { get; set; }
        public int? PaymentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TrnsEmployeeBonusDetail> TrnsEmployeeBonusDetails { get; set; }
    }
}
