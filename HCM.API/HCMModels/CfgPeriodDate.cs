using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPeriodDate
    {
        public CfgPeriodDate()
        {
            AttSummaries = new HashSet<AttSummary>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
            TrnsBatches = new HashSet<TrnsBatch>();
            TrnsEmployeeArrears = new HashSet<TrnsEmployeeArrear>();
            TrnsEmployeeBonus = new HashSet<TrnsEmployeeBonu>();
            TrnsEmployeeElementDetails = new HashSet<TrnsEmployeeElementDetail>();
            TrnsEmployeeElementRegisters = new HashSet<TrnsEmployeeElementRegister>();
            TrnsEmployeeOvertimes = new HashSet<TrnsEmployeeOvertime>();
            TrnsEmployeePerPieceProcessings = new HashSet<TrnsEmployeePerPieceProcessing>();
            TrnsEmployeeWorkDays = new HashSet<TrnsEmployeeWorkDay>();
            TrnsFinalSettelmentRegisters = new HashSet<TrnsFinalSettelmentRegister>();
            TrnsJes = new HashSet<TrnsJe>();
            TrnsSalaryChanges = new HashSet<TrnsSalaryChange>();
            TrnsSalaryProcessRegisters = new HashSet<TrnsSalaryProcessRegister>();
            TrnsSingleEntryOtrequests = new HashSet<TrnsSingleEntryOtrequest>();
            TrnsSpdaysAdjs = new HashSet<TrnsSpdaysAdj>();
            TrnsTextileGroupAttendanceRegs = new HashSet<TrnsTextileGroupAttendanceReg>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public string PeriodName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PeriodControlLovtype { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public int? FkcalId { get; set; }
        public string CalCode { get; set; }
        public bool? FlgLocked { get; set; }
        public bool? FlgPosted { get; set; }
        public bool? FlgVisible { get; set; }

        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual ICollection<AttSummary> AttSummaries { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsBatch> TrnsBatches { get; set; }
        public virtual ICollection<TrnsEmployeeArrear> TrnsEmployeeArrears { get; set; }
        public virtual ICollection<TrnsEmployeeBonu> TrnsEmployeeBonus { get; set; }
        public virtual ICollection<TrnsEmployeeElementDetail> TrnsEmployeeElementDetails { get; set; }
        public virtual ICollection<TrnsEmployeeElementRegister> TrnsEmployeeElementRegisters { get; set; }
        public virtual ICollection<TrnsEmployeeOvertime> TrnsEmployeeOvertimes { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceProcessing> TrnsEmployeePerPieceProcessings { get; set; }
        public virtual ICollection<TrnsEmployeeWorkDay> TrnsEmployeeWorkDays { get; set; }
        public virtual ICollection<TrnsFinalSettelmentRegister> TrnsFinalSettelmentRegisters { get; set; }
        public virtual ICollection<TrnsJe> TrnsJes { get; set; }
        public virtual ICollection<TrnsSalaryChange> TrnsSalaryChanges { get; set; }
        public virtual ICollection<TrnsSalaryProcessRegister> TrnsSalaryProcessRegisters { get; set; }
        public virtual ICollection<TrnsSingleEntryOtrequest> TrnsSingleEntryOtrequests { get; set; }
        public virtual ICollection<TrnsSpdaysAdj> TrnsSpdaysAdjs { get; set; }
        public virtual ICollection<TrnsTextileGroupAttendanceReg> TrnsTextileGroupAttendanceRegs { get; set; }
    }
}
