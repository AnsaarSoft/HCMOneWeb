using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LgTrnsLoanDetail
    {
        public int Id { get; set; }
        public int? LdetailId { get; set; }
        public int LnAid { get; set; }
        public int? LoanType { get; set; }
        public decimal? RequestedAmount { get; set; }
        public decimal? Installments { get; set; }
        public DateTime? RequiredDate { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public decimal? ApprovedInstallment { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgStopRecovery { get; set; }
        public bool? FlgVoid { get; set; }
        public decimal? RecoveredAmount { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public DateTime? InsertionDate { get; set; }
    }
}
