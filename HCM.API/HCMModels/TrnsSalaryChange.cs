using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryChange
    {
        public int Id { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public int? NewDesgId { get; set; }
        public int? EmpId { get; set; }
        public int? ManagerId { get; set; }
        public decimal? OldBasicSalary { get; set; }
        public decimal? NewBasicSalary { get; set; }
        public decimal? OldGrossSalary { get; set; }
        public decimal? NewGrossSalary { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public string DocStatus { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Notes { get; set; }
        public int? PayInPeriodId { get; set; }
        public int? ArrearElementId { get; set; }
        public int? PayBandOld { get; set; }
        public string PayBandDescOld { get; set; }
        public int? PayBandNew { get; set; }
        public string PayBandDescNew { get; set; }
        public int? GradingOld { get; set; }
        public int? GradingNew { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? NewDesignationLevel { get; set; }
        public decimal? PromotionIncrement { get; set; }
        public int? OldDesigId { get; set; }

        public virtual MstElement ArrearElement { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual MstDesignation NewDesg { get; set; }
        public virtual CfgPeriodDate PayInPeriod { get; set; }
    }
}
