using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstMenu
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? MenuParent { get; set; }
        public string MenuName { get; set; }
        public int? SortNum { get; set; }
        public string MenuLink { get; set; }
        public string Icon { get; set; }
        public bool? FlgReport { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CappStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UappStamp { get; set; }
    }
}
