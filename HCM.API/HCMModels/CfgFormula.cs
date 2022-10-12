using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgFormula
    {
        public CfgFormula()
        {
            CfgFormulaElements = new HashSet<CfgFormulaElement>();
        }

        public int Id { get; set; }
        public string Formula { get; set; }
        public bool? WithBasic { get; set; }
        public decimal? BasicFactor { get; set; }

        public virtual ICollection<CfgFormulaElement> CfgFormulaElements { get; set; }
    }
}
