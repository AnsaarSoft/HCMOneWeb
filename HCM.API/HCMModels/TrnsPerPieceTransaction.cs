using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerPieceTransaction
    {
        public TrnsPerPieceTransaction()
        {
            TrnsPerPieceTransactionDetails = new HashSet<TrnsPerPieceTransactionDetail>();
        }

        public int Id { get; set; }
        public int? Psid { get; set; }
        public string Pscode { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsPerPieceTransactionDetail> TrnsPerPieceTransactionDetails { get; set; }
    }
}
