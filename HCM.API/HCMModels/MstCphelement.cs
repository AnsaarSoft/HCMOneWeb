using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCphelement
    {
        public MstCphelement()
        {
            TrnsCphs = new HashSet<TrnsCph>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string ElementName { get; set; }
        public byte? Type { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsCph> TrnsCphs { get; set; }
    }
}
