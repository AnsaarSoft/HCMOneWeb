﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TmpMsXxMstEmployee
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string SboempCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Initials { get; set; }
        public string NamePrefix { get; set; }
        public int? Manager { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int? TeamsId { get; set; }
        public string TeamsName { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? PositionId { get; set; }
        public string PositionName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? Location { get; set; }
        public string LocationName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int? UserCode { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeExtension { get; set; }
        public string OfficeMobile { get; set; }
        public string Pager { get; set; }
        public string HomePhone { get; set; }
        public string Fax { get; set; }
        public string OfficeEmail { get; set; }
        public string Wastreet { get; set; }
        public string WastreetNo { get; set; }
        public string Wablock { get; set; }
        public string Waother { get; set; }
        public string WazipCode { get; set; }
        public string Wacity { get; set; }
        public string Wastate { get; set; }
        public string Wacountry { get; set; }
        public string Hastreet { get; set; }
        public string HastreetNo { get; set; }
        public string Hablock { get; set; }
        public string Haother { get; set; }
        public string HazipCode { get; set; }
        public string Hacity { get; set; }
        public string Hastate { get; set; }
        public string Hacountry { get; set; }
        public string PriPersonName { get; set; }
        public string PriRelationShip { get; set; }
        public string PriContactNoLandLine { get; set; }
        public string PriContactNoMobile { get; set; }
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
        public string FatherName { get; set; }
        public DateTime? Dob { get; set; }
        public string GenderId { get; set; }
        public string GenderLovtype { get; set; }
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
        public string Idno { get; set; }
        public DateTime? IddateofIssue { get; set; }
        public string IdplaceofIssue { get; set; }
        public string IdissuedBy { get; set; }
        public DateTime? IdexpiryDate { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportDateofIssue { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string IncomeTaxNo { get; set; }
        public decimal? BasicSalary { get; set; }
        public string EmpCalender { get; set; }
        public string SalaryCurrency { get; set; }
        public int? PaymentMethod { get; set; }
        public string WorkIm { get; set; }
        public string PersonalIm { get; set; }
        public string PersonalEmail { get; set; }
        public string PersonalContactNo { get; set; }
        public string OrganizationalUnit { get; set; }
        public int? ReportToId { get; set; }
        public string EmployeeContractType { get; set; }
        public string HrBaseCalendar { get; set; }
        public string WindowsLogin { get; set; }
        public int? EmployeeGrade { get; set; }
        public string PreEmpMonth { get; set; }
        public string WorkPermitRef { get; set; }
        public DateTime? WorkPermitExpiryDate { get; set; }
        public DateTime? ContractExpiryDate { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public DateTime? ContrStartDate { get; set; }
        public DateTime? ContrEnddate { get; set; }
        public bool? FlgSocialSecurity { get; set; }
        public bool? FlgGratuity { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgUser { get; set; }
        public string GratuityName { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal? PercentagePaid { get; set; }
        public string AccountTitle { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public string SboUserCode { get; set; }
        public bool? IntSboTransfered { get; set; }
        public bool? IntSboPublished { get; set; }
        public string Remarks { get; set; }
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
        public string Dimension4 { get; set; }
        public string Dimension5 { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string PassportExpiryDt { get; set; }
        public string IdexpiryDt { get; set; }
        public string MedicalCardExpDt { get; set; }
        public string DrvLicCompletionDt { get; set; }
        public string DrvLicReleaseDt { get; set; }
        public string DrvLicLastDt { get; set; }
        public string VisaNo { get; set; }
        public string IqamaProfessional { get; set; }
        public string BankCardExpiryDt { get; set; }
        public string ImgPath { get; set; }
        public string RoleLovtype { get; set; }
        public string MoajibEmail { get; set; }
        public bool? FlgShopManager { get; set; }
        public bool? FlgHruser { get; set; }
        public bool? FlgProbation { get; set; }
        public bool? FlgOnLeave { get; set; }
        public bool? FlgHold { get; set; }
        public bool? FlgOtapplicable { get; set; }
        public bool? FlgSuperVisor { get; set; }
        public bool? FlgPerPiece { get; set; }
        public string InventoryEmail { get; set; }
        public DateTime? HoldDate { get; set; }
        public string HoldReasons { get; set; }
        public int? PayBandId { get; set; }
        public int? ElementHeadId { get; set; }
        public int? SuccessionId { get; set; }
        public decimal? PostProbationIncrementAmount { get; set; }
        public decimal? GosiSalary { get; set; }
        public bool? FlgTax { get; set; }
        public string WpfCatg { get; set; }
        public int? TermCount { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? GratuitySlabs { get; set; }
        public string DrivingLic { get; set; }
        public string BankBranchCode { get; set; }
        public bool? MultiLogin { get; set; }
        public int? Otslabs { get; set; }
        public string Project { get; set; }
        public bool? FlgFlexibleShift { get; set; }
        public bool? FlgEmail { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? AllowedAdvance { get; set; }
        public bool? FlgSandwich { get; set; }
        public int? Category { get; set; }
        public int? SubCategory { get; set; }
        public int? AllowanceRules { get; set; }
        public bool? FlgCompanyResidence { get; set; }
        public string CompanyAddress { get; set; }
        public string TransportMode { get; set; }
        public string RecruitmentMode { get; set; }
        public string InsuranceCategory { get; set; }
        public bool? FlgBlackListed { get; set; }
        public string DefaultOffDay { get; set; }
        public bool? FlgOffDayApplicable { get; set; }
        public int? DeductionRules { get; set; }
        public decimal? GrossSalaryHired { get; set; }
        public decimal? PerformanceAllowance { get; set; }
        public decimal? BasicGrossRatio { get; set; }
        public bool? FlgBonus { get; set; }
        public string ShiftDaysCode { get; set; }
        public int? AttendanceAllowance { get; set; }
        public string BonusCode { get; set; }
        public DateTime? EmpCardExp { get; set; }
        public int? GradeLevelId { get; set; }
        public string CandidateCast { get; set; }
        public string Sect { get; set; }
        public string CvPath { get; set; }
        public int? NoOfChildren { get; set; }
        public string Eobino { get; set; }
        public bool? FlgEobi { get; set; }
        public DateTime? RetirementDate { get; set; }
        public byte[] Imagedata { get; set; }
        public bool? MobileAllowed { get; set; }
        public int? OrgHierarchyId { get; set; }
        public decimal? BonusPoints { get; set; }
        public string Classification { get; set; }
        public string DefaultShift { get; set; }
        public string Sector { get; set; }
    }
}