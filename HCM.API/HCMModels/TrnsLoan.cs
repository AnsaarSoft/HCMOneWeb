using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoan
    {
        public TrnsLoan()
        {
            TrnsLoanDetails = new HashSet<TrnsLoanDetail>();
            TrnsLoanInstallmentPlans = new HashSet<TrnsLoanInstallmentPlan>();
            TrnsLoanRegisters = new HashSet<TrnsLoanRegister>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
        public decimal? Salary { get; set; }
        public int? OriginatorId { get; set; }
        public string OriginatorName { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public bool? FlgPaid { get; set; }
        public int? TransId { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? NoOfInstallments { get; set; }
        public decimal? MarkUpRate { get; set; }
        public int? JeNum { get; set; }
        public bool? FlgPostJe { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstEmployee Manager { get; set; }
        public virtual MstEmployee Originator { get; set; }
        public virtual ICollection<TrnsLoanDetail> TrnsLoanDetails { get; set; }
        public virtual ICollection<TrnsLoanInstallmentPlan> TrnsLoanInstallmentPlans { get; set; }
        public virtual ICollection<TrnsLoanRegister> TrnsLoanRegisters { get; set; }
    }
}
