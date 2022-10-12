using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCompany
    {
        public int Tid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string AppVersion { get; set; }
        public string Dbversion { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string EmailCompany { get; set; }
        public string CompType { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public int? StateId { get; set; }
        public string WebSite { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string CompanyLogoPath { get; set; }
    }
}
