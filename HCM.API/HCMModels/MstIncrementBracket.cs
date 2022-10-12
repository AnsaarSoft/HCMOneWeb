using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstIncrementBracket
    {
        public int Id { get; set; }
        public decimal ScoreStart { get; set; }
        public decimal ScoreEnd { get; set; }
        public decimal IncrementPercentage { get; set; }
        public bool FlgActive { get; set; }
    }
}
