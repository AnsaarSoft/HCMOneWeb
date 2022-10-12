using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeLanguagesProficiency
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }
        public string Speaking { get; set; }
        public int? EmpId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLanguage1 Language { get; set; }
    }
}
