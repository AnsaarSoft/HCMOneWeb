using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanRequest
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? DocDate { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDesg { get; set; }
        public string EmpDept { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? BasicSalary { get; set; }
        public int? FkloanId { get; set; }
        public string LoanCode { get; set; }
        public string LoanDescription { get; set; }
        public decimal? RequestedAmount { get; set; }
        public DateTime? RequiredDate { get; set; }
        public decimal? NoOfInstallments { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public DateTime? LoanProvidedOn { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public string PaymentMode { get; set; }
        public bool? FlgStopInstallment { get; set; }
    }
}
