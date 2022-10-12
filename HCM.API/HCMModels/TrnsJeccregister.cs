using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJeccregister
    {
        public int Id { get; set; }
        public int? SalaryId { get; set; }
        public int? Jeid { get; set; }
        public string DebitAccountCode { get; set; }
        public string DebitAccountName { get; set; }
        public string CreditAccountCode { get; set; }
        public string CreditAccountName { get; set; }
        public decimal? LineValue { get; set; }
        public decimal? NewLineValue { get; set; }
        public string CostCenter { get; set; }

        public virtual TrnsSalaryProcessRegister Salary { get; set; }
    }
}
