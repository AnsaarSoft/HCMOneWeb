using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeClearenceDetail
    {
        public int Id { get; set; }
        public int? ParentTableId { get; set; }
        public int? AssetId { get; set; }
        public string AssetName { get; set; }
        public bool? Returned { get; set; }
        public string Remarks { get; set; }

        public virtual TrnsEmployeeClearence ParentTable { get; set; }
    }
}
