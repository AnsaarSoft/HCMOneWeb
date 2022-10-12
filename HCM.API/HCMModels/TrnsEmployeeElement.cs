using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElement
    {
        public TrnsEmployeeElement()
        {
            TrnsEmployeeElementAdvances = new HashSet<TrnsEmployeeElementAdvance>();
            TrnsEmployeeElementDetails = new HashSet<TrnsEmployeeElementDetail>();
            TrnsEmployeeElementLoans = new HashSet<TrnsEmployeeElementLoan>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Employee { get; set; }
        public virtual ICollection<TrnsEmployeeElementAdvance> TrnsEmployeeElementAdvances { get; set; }
        public virtual ICollection<TrnsEmployeeElementDetail> TrnsEmployeeElementDetails { get; set; }
        public virtual ICollection<TrnsEmployeeElementLoan> TrnsEmployeeElementLoans { get; set; }
    }
}
