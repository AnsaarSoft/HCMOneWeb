using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsFshead
    {
        public TrnsFshead()
        {
            TrnsFinalSettelmentRegisters = new HashSet<TrnsFinalSettelmentRegister>();
        }

        public int Id { get; set; }
        public int? InternalEmpId { get; set; }
        public DateTime? ResignDt { get; set; }
        public DateTime? TerminationDt { get; set; }
        public int? PeriodCounts { get; set; }
        public int? PayrollId { get; set; }
        public int? JournalEntry { get; set; }
        public short? DocType { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? EosType { get; set; }

        public virtual MstEmployee InternalEmp { get; set; }
        public virtual ICollection<TrnsFinalSettelmentRegister> TrnsFinalSettelmentRegisters { get; set; }
    }
}
