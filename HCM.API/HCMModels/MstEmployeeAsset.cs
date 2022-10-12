using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeAsset
    {
        public MstEmployeeAsset()
        {
            EmployeeAssetAssigns = new HashSet<EmployeeAssetAssign>();
        }

        public int Id { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string AssetTyp { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Imei { get; set; }
        public string Color { get; set; }
        public string Screen { get; set; }
        public string Hdd { get; set; }
        public string Ram { get; set; }
        public string SerialNo { get; set; }
        public string ChasisNo { get; set; }
        public string EnginNo { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info4 { get; set; }
        public string Info3 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Updateddate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Active { get; set; }
        public bool? FlgAssigned { get; set; }
        public string Vehicletype { get; set; }
        public string Cc { get; set; }
        public string AuthoritytoDrive { get; set; }
        public string Processor { get; set; }
        public string Accessories { get; set; }
        public string Otherspecifications { get; set; }
        public string Remarks { get; set; }
        public DateTime? TaxPaidUpto { get; set; }
        public DateTime? WarrantyTill { get; set; }

        public virtual ICollection<EmployeeAssetAssign> EmployeeAssetAssigns { get; set; }
    }
}
