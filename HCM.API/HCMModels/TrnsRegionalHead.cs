using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsRegionalHead
    {
        public TrnsRegionalHead()
        {
            TrnsRegionalHeadDetails = new HashSet<TrnsRegionalHeadDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public bool? FlgSentToHr { get; set; }

        public virtual ICollection<TrnsRegionalHeadDetail> TrnsRegionalHeadDetails { get; set; }
    }
}
