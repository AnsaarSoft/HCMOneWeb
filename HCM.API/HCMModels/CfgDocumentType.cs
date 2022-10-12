using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgDocumentType
    {
        public int Id { get; set; }
        public byte? DocType { get; set; }
        public string DocName { get; set; }
    }
}
