using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPasswordSetup
    {
        public int Id { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public int? NoOfDigit { get; set; }
        public int? NoOfCharacters { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
    }
}
