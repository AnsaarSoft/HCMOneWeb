using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeApproval
    {
        public MstEmployeeApproval()
        {
            MstEmployeeCertificationsApprovals = new HashSet<MstEmployeeCertificationsApproval>();
            MstEmployeeEducationApprovals = new HashSet<MstEmployeeEducationApproval>();
            MstEmployeeExperienceApprovals = new HashSet<MstEmployeeExperienceApproval>();
            MstEmployeeRelativesApprovals = new HashSet<MstEmployeeRelativesApproval>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Initials { get; set; }
        public string OldInitials { get; set; }
        public string NamePrefix { get; set; }
        public string OldNamePrefix { get; set; }
        public string HomePhone { get; set; }
        public string OldHomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string OldOfficePhone { get; set; }
        public string OfficeMobile { get; set; }
        public string OldOfficeMobile { get; set; }
        public string OfficeExtension { get; set; }
        public string OldOfficeExtension { get; set; }
        public string Fax { get; set; }
        public string OldFax { get; set; }
        public string OfficeEmail { get; set; }
        public string OldOfficeEmail { get; set; }
        public string Pager { get; set; }
        public string OldPager { get; set; }
        public string Wastreet { get; set; }
        public string OldWastreet { get; set; }
        public string WastreetNo { get; set; }
        public string OldWastreetNo { get; set; }
        public string Wablock { get; set; }
        public string OldWablock { get; set; }
        public string Waother { get; set; }
        public string OldWaother { get; set; }
        public string WazipCode { get; set; }
        public string OldWazipCode { get; set; }
        public string Wacity { get; set; }
        public string OldWacity { get; set; }
        public string Wastate { get; set; }
        public string OldWastate { get; set; }
        public string Hastreet { get; set; }
        public string HastreetNo { get; set; }
        public string OldHastreet { get; set; }
        public string OldHastreetNo { get; set; }
        public string Hablock { get; set; }
        public string OldHablock { get; set; }
        public string Haother { get; set; }
        public string OldHaother { get; set; }
        public string HazipCode { get; set; }
        public string OldHazipCode { get; set; }
        public string Hacity { get; set; }
        public string OldHacity { get; set; }
        public string Hastate { get; set; }
        public string OldHastate { get; set; }
        public string PriPersonName { get; set; }
        public string OldPriPersonName { get; set; }
        public string PriRelationShip { get; set; }
        public string OldPriRelationShip { get; set; }
        public string PriContactNoLandLine { get; set; }
        public string OldPriContactNoLandLine { get; set; }
        public string PriContactNoMobile { get; set; }
        public string OldPriContactNoMobile { get; set; }
        public string PriAddress { get; set; }
        public string PriCity { get; set; }
        public string PriState { get; set; }
        public string PriCountry { get; set; }
        public string SecPersonName { get; set; }
        public string SecRelationShip { get; set; }
        public string SecContactNoLandline { get; set; }
        public string SecContactNoMobile { get; set; }
        public string SecAddress { get; set; }
        public string SecCity { get; set; }
        public string SecState { get; set; }
        public string SecCountry { get; set; }
        public string OldPriAddress { get; set; }
        public string OldPriCity { get; set; }
        public string OldPriState { get; set; }
        public string OldPriCountry { get; set; }
        public string OldSecPersonName { get; set; }
        public string OldSecRelationShip { get; set; }
        public string OldSecContactNoLandline { get; set; }
        public string OldSecContactNoMobile { get; set; }
        public string OldSecAddress { get; set; }
        public string OldSecCity { get; set; }
        public string OldSecState { get; set; }
        public string OldSecCountry { get; set; }
        public string FatherName { get; set; }
        public string OldFatherName { get; set; }
        public string BloodGroupId { get; set; }
        public string BloodGroupLovtype { get; set; }
        public string MotherName { get; set; }
        public string MartialStatusId { get; set; }
        public string MartialStatusLovtype { get; set; }
        public string ReligionId { get; set; }
        public string ReligionLovtype { get; set; }
        public string SocialSecurityNo { get; set; }
        public string EmpUnion { get; set; }
        public string UnionMembershipNo { get; set; }
        public string Nationality { get; set; }
        public string OldBloodGroupId { get; set; }
        public string OldBloodGroupLovtype { get; set; }
        public string OldMotherName { get; set; }
        public string OldMartialStatusId { get; set; }
        public string OldMartialStatusLovtype { get; set; }
        public string OldReligionId { get; set; }
        public string OldReligionLovtype { get; set; }
        public string OldSocialSecurityNo { get; set; }
        public string OldEmpUnion { get; set; }
        public string OldUnionMembershipNo { get; set; }
        public string OldNationality { get; set; }
        public DateTime? IddateofIssue { get; set; }
        public string IdplaceofIssue { get; set; }
        public string IdissuedBy { get; set; }
        public DateTime? IdexpiryDate { get; set; }
        public DateTime? OldIddateofIssue { get; set; }
        public string OldIdplaceofIssue { get; set; }
        public string OldIdissuedBy { get; set; }
        public DateTime? OldIdexpiryDate { get; set; }
        public DateTime? PassportDateofIssue { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string IncomeTaxNo { get; set; }
        public DateTime? OldPassportDateofIssue { get; set; }
        public DateTime? OldPassportExpiryDate { get; set; }
        public string OldIncomeTaxNo { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string DrivingLic { get; set; }
        public string OldDrivingLic { get; set; }

        public virtual ICollection<MstEmployeeCertificationsApproval> MstEmployeeCertificationsApprovals { get; set; }
        public virtual ICollection<MstEmployeeEducationApproval> MstEmployeeEducationApprovals { get; set; }
        public virtual ICollection<MstEmployeeExperienceApproval> MstEmployeeExperienceApprovals { get; set; }
        public virtual ICollection<MstEmployeeRelativesApproval> MstEmployeeRelativesApprovals { get; set; }
    }
}
