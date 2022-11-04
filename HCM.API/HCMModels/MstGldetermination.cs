using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGldetermination
    {
        public MstGldetermination()
        {
            MstGldadvanceDetails = new HashSet<MstGldadvanceDetail>();
            MstGldbonusDetails = new HashSet<MstGldbonusDetail>();
            MstGldcontributions = new HashSet<MstGldcontribution>();
            MstGlddeductionDetails = new HashSet<MstGlddeductionDetail>();
            MstGldearningDetails = new HashSet<MstGldearningDetail>();
            MstGldexpDetails = new HashSet<MstGldexpDetail>();
            MstGldleaveDedDetails = new HashSet<MstGldleaveDedDetail>();
            MstGldloansDetails = new HashSet<MstGldloansDetail>();
            MstGldoverTimeDetails = new HashSet<MstGldoverTimeDetail>();
        }

        public int Id { get; set; }
        public string Gltype { get; set; }
        public int? Glvalue { get; set; }
        public string BasicSalary { get; set; }
        public string Bspayable { get; set; }
        public string ArrearsExpense { get; set; }
        public string ArrearsPayable { get; set; }
        public string LeaveEncashmentExpense { get; set; }
        public string Eosexpese { get; set; }
        public string LeaveEncashmentPayable { get; set; }
        public string Eospayable { get; set; }
        public string GratuityPayable { get; set; }
        public string IncomeTaxPayable { get; set; }
        public string GratuityExpense { get; set; }
        public string IncomeTaxExpense { get; set; }
        public string DiffDrcr { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string BasicSalaryDesc { get; set; }
        public string BspayableDesc { get; set; }
        public string ArrearsExpenseDesc { get; set; }
        public string ArrearsPayableDesc { get; set; }
        public string LeaveEncashmentExpenseDesc { get; set; }
        public string LeaveEncashmentPayableDesc { get; set; }
        public string EosexpenseDesc { get; set; }
        public string EospayableDesc { get; set; }
        public string GratuityPayableDesc { get; set; }
        public string IncomeTaxPayableDesc { get; set; }
        public string GratuityExpenseDesc { get; set; }
        public string IncomeTaxExpenseDesc { get; set; }
        public string DiffDrcrdesc { get; set; }
        public string DiffDrcrpayable { get; set; }
        public string DiffDrcrpayableDesc { get; set; }

        public virtual ICollection<MstGldadvanceDetail> MstGldadvanceDetails { get; set; }
        public virtual ICollection<MstGldbonusDetail> MstGldbonusDetails { get; set; }
        public virtual ICollection<MstGldcontribution> MstGldcontributions { get; set; }
        public virtual ICollection<MstGlddeductionDetail> MstGlddeductionDetails { get; set; }
        public virtual ICollection<MstGldearningDetail> MstGldearningDetails { get; set; }
        public virtual ICollection<MstGldexpDetail> MstGldexpDetails { get; set; }
        public virtual ICollection<MstGldleaveDedDetail> MstGldleaveDedDetails { get; set; }
        public virtual ICollection<MstGldloansDetail> MstGldloansDetails { get; set; }
        public virtual ICollection<MstGldoverTimeDetail> MstGldoverTimeDetails { get; set; }
    }
}
