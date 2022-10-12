using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class SalaryDeduction
    {
        public int Id { get; set; }
        public decimal Deduction1 { get; set; }
        public decimal Deduction2 { get; set; }
        public decimal Deduction3 { get; set; }
        public decimal Deduction4 { get; set; }
        public decimal Deduction5 { get; set; }
    }
}
