using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceAppraisal360Detail
    {
        public int Id { get; set; }
        public int? Ap360id { get; set; }
        public int? CompetencyId { get; set; }
        public decimal? SelfScore { get; set; }
        public int? ManagerId { get; set; }
        public decimal? ScoreManager { get; set; }
        public int? Peer { get; set; }
        public decimal? ScorePeer { get; set; }
        public int? SubOrdinateId { get; set; }
        public decimal? ScoreSo { get; set; }
        public string Customer { get; set; }
        public decimal? ScoreCustomer { get; set; }
        public string Supplier { get; set; }
        public decimal? ScoreSupplier { get; set; }
        public decimal? LineTotal { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsPerformanceAppraisal360 Ap360 { get; set; }
        public virtual TrnsCompetencyProfileDetail Competency { get; set; }
        public virtual MstEmployee Manager { get; set; }
        public virtual MstEmployee PeerNavigation { get; set; }
        public virtual MstEmployee SubOrdinate { get; set; }
    }
}
