using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeTransfer
    {
        public TrnsEmployeeTransfer()
        {
            TrnsEmployeeTransferDetails = new HashSet<TrnsEmployeeTransferDetail>();
        }

        public int Id { get; set; }
        public int? DoNum { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? StatusRec { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsEmployeeTransferDetail> TrnsEmployeeTransferDetails { get; set; }
    }
}
