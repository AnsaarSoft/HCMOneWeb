using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgFormulaElement
    {
        public int Id { get; set; }
        public int? FormulaId { get; set; }
        public string Fetype { get; set; }
        public int? ElementId { get; set; }
        public decimal? Factor { get; set; }
        public string FieldName { get; set; }
        public string RowType { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual CfgFormula Formula { get; set; }
    }
}
