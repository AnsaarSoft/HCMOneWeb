using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployee
    {
        public MstEmployee()
        {
            ApprovalDecisionRegisterDetails = new HashSet<ApprovalDecisionRegisterDetail>();
            ApprovalDecisionRegisters = new HashSet<ApprovalDecisionRegister>();
            AttSummaryDetails = new HashSet<AttSummaryDetail>();
            AttendanceLogs = new HashSet<AttendanceLog>();
            CfgAlertManagementEmployees = new HashSet<CfgAlertManagementEmployee>();
            EmployeeAssetAssigns = new HashSet<EmployeeAssetAssign>();
            MstAlertGroupDetails = new HashSet<MstAlertGroupDetail>();
            MstCandidates = new HashSet<MstCandidate>();
            MstEmployeeAttachments = new HashSet<MstEmployeeAttachment>();
            MstEmployeeCertifications = new HashSet<MstEmployeeCertification>();
            MstEmployeeCommittees = new HashSet<MstEmployeeCommittee>();
            MstEmployeeDocuments = new HashSet<MstEmployeeDocument>();
            MstEmployeeEducations = new HashSet<MstEmployeeEducation>();
            MstEmployeeEndOfServices = new HashSet<MstEmployeeEndOfService>();
            MstEmployeeExperiences = new HashSet<MstEmployeeExperience>();
            MstEmployeeLanguagesProficiencies = new HashSet<MstEmployeeLanguagesProficiency>();
            MstEmployeeLeaves = new HashSet<MstEmployeeLeaf>();
            MstEmployeeReferences = new HashSet<MstEmployeeReference>();
            MstEmployeeReferrals = new HashSet<MstEmployeeReferral>();
            MstEmployeeReferralsDetails = new HashSet<MstEmployeeReferralsDetail>();
            MstEmployeeRelatives = new HashSet<MstEmployeeRelative>();
            MstEmployeeSuccessorEmps = new HashSet<MstEmployeeSuccessor>();
            MstEmployeeSuccessorSuccessors = new HashSet<MstEmployeeSuccessor>();
            MstPartnerFeedbackAssigns = new HashSet<MstPartnerFeedbackAssign>();
            MstSecondments = new HashSet<MstSecondment>();
            MstStageDetails = new HashSet<MstStageDetail>();
            MstTrainingNeedAssesments = new HashSet<MstTrainingNeedAssesment>();
            MstUsers = new HashSet<MstUser>();
            NeskCfgApprovalDecisionRegisterApprovers = new HashSet<NeskCfgApprovalDecisionRegister>();
            NeskCfgApprovalDecisionRegisterEmps = new HashSet<NeskCfgApprovalDecisionRegister>();
            NeskCfgDocHierarchyDetails = new HashSet<NeskCfgDocHierarchyDetail>();
            SalaryLetters = new HashSet<SalaryLetter>();
            TrainingRequestForms = new HashSet<TrainingRequestForm>();
            TrnsAdvanceEmps = new HashSet<TrnsAdvance>();
            TrnsAdvanceManagers = new HashSet<TrnsAdvance>();
            TrnsAdvanceOriginators = new HashSet<TrnsAdvance>();
            TrnsAssistanceRequests = new HashSet<TrnsAssistanceRequest>();
            TrnsAttendanceRegisterTs = new HashSet<TrnsAttendanceRegisterT>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
            TrnsBatchesDetails = new HashSet<TrnsBatchesDetail>();
            TrnsBenchMovements = new HashSet<TrnsBenchMovement>();
            TrnsCdpheads = new HashSet<TrnsCdphead>();
            TrnsDisciplinaryActionCommittees = new HashSet<TrnsDisciplinaryActionCommittee>();
            TrnsDisciplinaryActionDetails = new HashSet<TrnsDisciplinaryActionDetail>();
            TrnsDisciplinaryActionWitnessesses = new HashSet<TrnsDisciplinaryActionWitnessess>();
            TrnsDisclaimerRequests = new HashSet<TrnsDisclaimerRequest>();
            TrnsEmpVls = new HashSet<TrnsEmpVl>();
            TrnsEmployeeAttendanceAllowanceDetails = new HashSet<TrnsEmployeeAttendanceAllowanceDetail>();
            TrnsEmployeeClearences = new HashSet<TrnsEmployeeClearence>();
            TrnsEmployeeContributionWithdraws = new HashSet<TrnsEmployeeContributionWithdraw>();
            TrnsEmployeeElementRegisters = new HashSet<TrnsEmployeeElementRegister>();
            TrnsEmployeeElements = new HashSet<TrnsEmployeeElement>();
            TrnsEmployeeExitInterviews = new HashSet<TrnsEmployeeExitInterview>();
            TrnsEmployeeNoLateAllowanceDetails = new HashSet<TrnsEmployeeNoLateAllowanceDetail>();
            TrnsEmployeeOvertimes = new HashSet<TrnsEmployeeOvertime>();
            TrnsEmployeePenalties = new HashSet<TrnsEmployeePenalty>();
            TrnsEmployeePerPieceProcessings = new HashSet<TrnsEmployeePerPieceProcessing>();
            TrnsEmployeePerPieceRates = new HashSet<TrnsEmployeePerPieceRate>();
            TrnsEmployeeProfitLossAllocations = new HashSet<TrnsEmployeeProfitLossAllocation>();
            TrnsEmployeeReHires = new HashSet<TrnsEmployeeReHire>();
            TrnsEmployeesAlerts = new HashSet<TrnsEmployeesAlert>();
            TrnsExperienceLetters = new HashSet<TrnsExperienceLetter>();
            TrnsFinalSettelmentRegisters = new HashSet<TrnsFinalSettelmentRegister>();
            TrnsFsheads = new HashSet<TrnsFshead>();
            TrnsGenericRequests = new HashSet<TrnsGenericRequest>();
            TrnsIncDetails = new HashSet<TrnsIncDetail>();
            TrnsInternalTransferEmps = new HashSet<TrnsInternalTransfer>();
            TrnsInternalTransferManagers = new HashSet<TrnsInternalTransfer>();
            TrnsInterviewCallActivities = new HashSet<TrnsInterviewCallActivity>();
            TrnsInterviewCallPanelLists = new HashSet<TrnsInterviewCallPanelList>();
            TrnsInterviewEasassetments = new HashSet<TrnsInterviewEasassetment>();
            TrnsInterviewEaspanelists = new HashSet<TrnsInterviewEaspanelist>();
            TrnsInterviewRecommendations = new HashSet<TrnsInterviewRecommendation>();
            TrnsLeavesRequests = new HashSet<TrnsLeavesRequest>();
            TrnsLoanAndAdvancePayments = new HashSet<TrnsLoanAndAdvancePayment>();
            TrnsLoanEmps = new HashSet<TrnsLoan>();
            TrnsLoanManagers = new HashSet<TrnsLoan>();
            TrnsLoanOriginators = new HashSet<TrnsLoan>();
            TrnsMarriageAssistanceRequests = new HashSet<TrnsMarriageAssistanceRequest>();
            TrnsNotificaiotnApprovalSystems = new HashSet<TrnsNotificaiotnApprovalSystem>();
            TrnsObarrears = new HashSet<TrnsObarrear>();
            TrnsObcontributions = new HashSet<TrnsObcontribution>();
            TrnsObgratuities = new HashSet<TrnsObgratuity>();
            TrnsObjFnyHeads = new HashSet<TrnsObjFnyHead>();
            TrnsObleaves = new HashSet<TrnsObleaf>();
            TrnsObloans = new HashSet<TrnsObloan>();
            TrnsObprovidentFunds = new HashSet<TrnsObprovidentFund>();
            TrnsObsalaries = new HashSet<TrnsObsalary>();
            TrnsObtaxes = new HashSet<TrnsObtax>();
            TrnsOfferLetters = new HashSet<TrnsOfferLetter>();
            TrnsPartnerAssessmentDetails = new HashSet<TrnsPartnerAssessmentDetail>();
            TrnsPartnerAssessmentHeads = new HashSet<TrnsPartnerAssessmentHead>();
            TrnsPartnerBusinessRevenueDetails = new HashSet<TrnsPartnerBusinessRevenueDetail>();
            TrnsPartnerContributionDetails = new HashSet<TrnsPartnerContributionDetail>();
            TrnsPartnerFacilitateTrainingDetails = new HashSet<TrnsPartnerFacilitateTrainingDetail>();
            TrnsPartnerFeedback360s = new HashSet<TrnsPartnerFeedback360>();
            TrnsPartnerNetProfitDetails = new HashSet<TrnsPartnerNetProfitDetail>();
            TrnsPartnerRevenueAccrualDetails = new HashSet<TrnsPartnerRevenueAccrualDetail>();
            TrnsPartnerUnAllocatedFormsDetails = new HashSet<TrnsPartnerUnAllocatedFormsDetail>();
            TrnsPartnerUnAllocatedFormsHeads = new HashSet<TrnsPartnerUnAllocatedFormsHead>();
            TrnsPeerFeedback360s = new HashSet<TrnsPeerFeedback360>();
            TrnsPerformanceAppraisal360DetailManagers = new HashSet<TrnsPerformanceAppraisal360Detail>();
            TrnsPerformanceAppraisal360DetailPeerNavigations = new HashSet<TrnsPerformanceAppraisal360Detail>();
            TrnsPerformanceAppraisal360DetailSubOrdinates = new HashSet<TrnsPerformanceAppraisal360Detail>();
            TrnsPerformanceAppraisal360s = new HashSet<TrnsPerformanceAppraisal360>();
            TrnsPerformanceAppraisalAppraisers = new HashSet<TrnsPerformanceAppraisal>();
            TrnsPerformanceAppraisalEmps = new HashSet<TrnsPerformanceAppraisal>();
            TrnsPerformanceEvaluationHeadAppraisers = new HashSet<TrnsPerformanceEvaluationHead>();
            TrnsPerformanceEvaluationHeadEmps = new HashSet<TrnsPerformanceEvaluationHead>();
            TrnsPerformanceManagements = new HashSet<TrnsPerformanceManagement>();
            TrnsPerformancePlans = new HashSet<TrnsPerformancePlan>();
            TrnsPerofrmanceEvaluationDetails = new HashSet<TrnsPerofrmanceEvaluationDetail>();
            TrnsProbationAssesHeads = new HashSet<TrnsProbationAssesHead>();
            TrnsProbationHeads = new HashSet<TrnsProbationHead>();
            TrnsReHireEmployees = new HashSet<TrnsReHireEmployee>();
            TrnsResignations = new HashSet<TrnsResignation>();
            TrnsSalaryArears = new HashSet<TrnsSalaryArear>();
            TrnsSalaryChanges = new HashSet<TrnsSalaryChange>();
            TrnsSalaryProcessRegisters = new HashSet<TrnsSalaryProcessRegister>();
            TrnsSchoolPensionRequests = new HashSet<TrnsSchoolPensionRequest>();
            TrnsSingleEntryOtdetails = new HashSet<TrnsSingleEntryOtdetail>();
            TrnsSpdaysAdjs = new HashSet<TrnsSpdaysAdj>();
            TrnsTaxAdjustments = new HashSet<TrnsTaxAdjustment>();
            TrnsTextileGroupAttendanceRegs = new HashSet<TrnsTextileGroupAttendanceReg>();
            TrnsTrainingAttendanceDetails = new HashSet<TrnsTrainingAttendanceDetail>();
            TrnsTrainingAttendances = new HashSet<TrnsTrainingAttendance>();
            TrnsTrainingEvaluations = new HashSet<TrnsTrainingEvaluation>();
            TrnsTrainingFeedbacks = new HashSet<TrnsTrainingFeedback>();
            TrnsTrainingPlanDetails = new HashSet<TrnsTrainingPlanDetail>();
            TrnsTrainingPlans = new HashSet<TrnsTrainingPlan>();
            TrnsTravelPaymentRequests = new HashSet<TrnsTravelPaymentRequest>();
            TrnsViolations = new HashSet<TrnsViolation>();
            TrnsWarningLetters = new HashSet<TrnsWarningLetter>();
        }

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
        public string ManagerName { get; set; }
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
        public bool? FlgDailyWager { get; set; }
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
        public decimal? PfloanLimit { get; set; }
        public bool? FlgPerPiece { get; set; }
        public bool? FlgCmhouseEmp { get; set; }
        public bool? FlgOcrdtransfered { get; set; }
        public string Jd { get; set; }
        public string Eid { get; set; }
        public DateTime? Eidexpiry { get; set; }
        public DateTime? VisaExpiry { get; set; }
        public string Linsurance { get; set; }
        public DateTime? LiexpiryDate { get; set; }
        public string MedicalInsurance { get; set; }
        public string MedicalNetwork { get; set; }
        public string MedicalCategory { get; set; }
        public DateTime? MedicalExpiry { get; set; }
        public DateTime? ProbationEndDate { get; set; }
        public int? ProbationPeriod { get; set; }
        public int? NoticePeriod { get; set; }
        public int? AirTicketPeriod { get; set; }
        public int? TicketGroup { get; set; }
        public DateTime? LastAirTicketDate { get; set; }
        public DateTime? NextAirTicketDate { get; set; }
        public DateTime? MedicalCardIssueDateSpouse { get; set; }
        public DateTime? MedicalCardExpiryDateSpouse { get; set; }
        public DateTime? MedicalCardExpiryDateEmployee { get; set; }
        public string BankCode { get; set; }
        public string SpouseName { get; set; }
        public string MedicalCardNoSpouse { get; set; }
        public string MedicalCardNoEmployee { get; set; }
        public bool? AirTicketToggle { get; set; }
        public bool? FlgNotInPayroll { get; set; }
        public bool? FlgPerHour { get; set; }
        public string MedicalCardIssueDateEmployee { get; set; }
        public bool? FlgOnBench { get; set; }
        public bool? FlgBenchRequestSend { get; set; }
        public bool? FlgBoardRequestSend { get; set; }
        public bool? FlgApprovedBench { get; set; }
        public bool? FlgApprovedBoard { get; set; }
        public bool? FlgSendToManager { get; set; }
        public bool? FlgManagerApproved { get; set; }
        public bool? FlgSendToRegionalHead { get; set; }
        public bool? FlgRegionalHeadApproved { get; set; }
        public bool? FlgSendToFinance { get; set; }
        public bool? FlgFinanceApproved { get; set; }
        public bool? FlgSendToHr { get; set; }
        public bool? FlgHrapproved { get; set; }
        public bool? FlgSendToIt { get; set; }
        public bool? FlgItapproved { get; set; }
        public bool? FlgSendToClearance { get; set; }
        public bool? FlgApprovedClearance { get; set; }
        public bool? FlgSendForInitiateClearance { get; set; }
        public bool? FlgMedicalExempt { get; set; }
        public string PrjCode { get; set; }
        public string PrjName { get; set; }
        public string ReHire { get; set; }
        public int? ObapprovedHours { get; set; }
        public int? OboverTimeHours { get; set; }
        public DateTime? ObasOnDate { get; set; }
        public bool? FlgReleaseRequestSend { get; set; }
        public bool? FlgReturnRequestSend { get; set; }
        public bool? FlgApprovedRelease { get; set; }
        public bool? FlgApprovedReturn { get; set; }
        public bool? FlgOnRelease { get; set; }
        public bool? FlgCeouser { get; set; }
        public string Prefix { get; set; }
        public int? SeriesNumber { get; set; }
        public string HolidayCalendar { get; set; }

        public virtual MstBranch Branch { get; set; }
        public virtual MstDepartment Department { get; set; }
        public virtual MstDesignation Designation { get; set; }
        public virtual MstGrading EmployeeGradeNavigation { get; set; }
        public virtual TrnsGratuitySlab GratuitySlabsNavigation { get; set; }
        public virtual MstLocation LocationNavigation { get; set; }
        public virtual TrnsOtslab OtslabsNavigation { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual MstPosition Position { get; set; }
        public virtual ICollection<ApprovalDecisionRegisterDetail> ApprovalDecisionRegisterDetails { get; set; }
        public virtual ICollection<ApprovalDecisionRegister> ApprovalDecisionRegisters { get; set; }
        public virtual ICollection<AttSummaryDetail> AttSummaryDetails { get; set; }
        public virtual ICollection<AttendanceLog> AttendanceLogs { get; set; }
        public virtual ICollection<CfgAlertManagementEmployee> CfgAlertManagementEmployees { get; set; }
        public virtual ICollection<EmployeeAssetAssign> EmployeeAssetAssigns { get; set; }
        public virtual ICollection<MstAlertGroupDetail> MstAlertGroupDetails { get; set; }
        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstEmployeeAttachment> MstEmployeeAttachments { get; set; }
        public virtual ICollection<MstEmployeeCertification> MstEmployeeCertifications { get; set; }
        public virtual ICollection<MstEmployeeCommittee> MstEmployeeCommittees { get; set; }
        public virtual ICollection<MstEmployeeDocument> MstEmployeeDocuments { get; set; }
        public virtual ICollection<MstEmployeeEducation> MstEmployeeEducations { get; set; }
        public virtual ICollection<MstEmployeeEndOfService> MstEmployeeEndOfServices { get; set; }
        public virtual ICollection<MstEmployeeExperience> MstEmployeeExperiences { get; set; }
        public virtual ICollection<MstEmployeeLanguagesProficiency> MstEmployeeLanguagesProficiencies { get; set; }
        public virtual ICollection<MstEmployeeLeaf> MstEmployeeLeaves { get; set; }
        public virtual ICollection<MstEmployeeReference> MstEmployeeReferences { get; set; }
        public virtual ICollection<MstEmployeeReferral> MstEmployeeReferrals { get; set; }
        public virtual ICollection<MstEmployeeReferralsDetail> MstEmployeeReferralsDetails { get; set; }
        public virtual ICollection<MstEmployeeRelative> MstEmployeeRelatives { get; set; }
        public virtual ICollection<MstEmployeeSuccessor> MstEmployeeSuccessorEmps { get; set; }
        public virtual ICollection<MstEmployeeSuccessor> MstEmployeeSuccessorSuccessors { get; set; }
        public virtual ICollection<MstPartnerFeedbackAssign> MstPartnerFeedbackAssigns { get; set; }
        public virtual ICollection<MstSecondment> MstSecondments { get; set; }
        public virtual ICollection<MstStageDetail> MstStageDetails { get; set; }
        public virtual ICollection<MstTrainingNeedAssesment> MstTrainingNeedAssesments { get; set; }
        public virtual ICollection<MstUser> MstUsers { get; set; }
        public virtual ICollection<NeskCfgApprovalDecisionRegister> NeskCfgApprovalDecisionRegisterApprovers { get; set; }
        public virtual ICollection<NeskCfgApprovalDecisionRegister> NeskCfgApprovalDecisionRegisterEmps { get; set; }
        public virtual ICollection<NeskCfgDocHierarchyDetail> NeskCfgDocHierarchyDetails { get; set; }
        public virtual ICollection<SalaryLetter> SalaryLetters { get; set; }
        public virtual ICollection<TrainingRequestForm> TrainingRequestForms { get; set; }
        public virtual ICollection<TrnsAdvance> TrnsAdvanceEmps { get; set; }
        public virtual ICollection<TrnsAdvance> TrnsAdvanceManagers { get; set; }
        public virtual ICollection<TrnsAdvance> TrnsAdvanceOriginators { get; set; }
        public virtual ICollection<TrnsAssistanceRequest> TrnsAssistanceRequests { get; set; }
        public virtual ICollection<TrnsAttendanceRegisterT> TrnsAttendanceRegisterTs { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsBatchesDetail> TrnsBatchesDetails { get; set; }
        public virtual ICollection<TrnsBenchMovement> TrnsBenchMovements { get; set; }
        public virtual ICollection<TrnsCdphead> TrnsCdpheads { get; set; }
        public virtual ICollection<TrnsDisciplinaryActionCommittee> TrnsDisciplinaryActionCommittees { get; set; }
        public virtual ICollection<TrnsDisciplinaryActionDetail> TrnsDisciplinaryActionDetails { get; set; }
        public virtual ICollection<TrnsDisciplinaryActionWitnessess> TrnsDisciplinaryActionWitnessesses { get; set; }
        public virtual ICollection<TrnsDisclaimerRequest> TrnsDisclaimerRequests { get; set; }
        public virtual ICollection<TrnsEmpVl> TrnsEmpVls { get; set; }
        public virtual ICollection<TrnsEmployeeAttendanceAllowanceDetail> TrnsEmployeeAttendanceAllowanceDetails { get; set; }
        public virtual ICollection<TrnsEmployeeClearence> TrnsEmployeeClearences { get; set; }
        public virtual ICollection<TrnsEmployeeContributionWithdraw> TrnsEmployeeContributionWithdraws { get; set; }
        public virtual ICollection<TrnsEmployeeElementRegister> TrnsEmployeeElementRegisters { get; set; }
        public virtual ICollection<TrnsEmployeeElement> TrnsEmployeeElements { get; set; }
        public virtual ICollection<TrnsEmployeeExitInterview> TrnsEmployeeExitInterviews { get; set; }
        public virtual ICollection<TrnsEmployeeNoLateAllowanceDetail> TrnsEmployeeNoLateAllowanceDetails { get; set; }
        public virtual ICollection<TrnsEmployeeOvertime> TrnsEmployeeOvertimes { get; set; }
        public virtual ICollection<TrnsEmployeePenalty> TrnsEmployeePenalties { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceProcessing> TrnsEmployeePerPieceProcessings { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceRate> TrnsEmployeePerPieceRates { get; set; }
        public virtual ICollection<TrnsEmployeeProfitLossAllocation> TrnsEmployeeProfitLossAllocations { get; set; }
        public virtual ICollection<TrnsEmployeeReHire> TrnsEmployeeReHires { get; set; }
        public virtual ICollection<TrnsEmployeesAlert> TrnsEmployeesAlerts { get; set; }
        public virtual ICollection<TrnsExperienceLetter> TrnsExperienceLetters { get; set; }
        public virtual ICollection<TrnsFinalSettelmentRegister> TrnsFinalSettelmentRegisters { get; set; }
        public virtual ICollection<TrnsFshead> TrnsFsheads { get; set; }
        public virtual ICollection<TrnsGenericRequest> TrnsGenericRequests { get; set; }
        public virtual ICollection<TrnsIncDetail> TrnsIncDetails { get; set; }
        public virtual ICollection<TrnsInternalTransfer> TrnsInternalTransferEmps { get; set; }
        public virtual ICollection<TrnsInternalTransfer> TrnsInternalTransferManagers { get; set; }
        public virtual ICollection<TrnsInterviewCallActivity> TrnsInterviewCallActivities { get; set; }
        public virtual ICollection<TrnsInterviewCallPanelList> TrnsInterviewCallPanelLists { get; set; }
        public virtual ICollection<TrnsInterviewEasassetment> TrnsInterviewEasassetments { get; set; }
        public virtual ICollection<TrnsInterviewEaspanelist> TrnsInterviewEaspanelists { get; set; }
        public virtual ICollection<TrnsInterviewRecommendation> TrnsInterviewRecommendations { get; set; }
        public virtual ICollection<TrnsLeavesRequest> TrnsLeavesRequests { get; set; }
        public virtual ICollection<TrnsLoanAndAdvancePayment> TrnsLoanAndAdvancePayments { get; set; }
        public virtual ICollection<TrnsLoan> TrnsLoanEmps { get; set; }
        public virtual ICollection<TrnsLoan> TrnsLoanManagers { get; set; }
        public virtual ICollection<TrnsLoan> TrnsLoanOriginators { get; set; }
        public virtual ICollection<TrnsMarriageAssistanceRequest> TrnsMarriageAssistanceRequests { get; set; }
        public virtual ICollection<TrnsNotificaiotnApprovalSystem> TrnsNotificaiotnApprovalSystems { get; set; }
        public virtual ICollection<TrnsObarrear> TrnsObarrears { get; set; }
        public virtual ICollection<TrnsObcontribution> TrnsObcontributions { get; set; }
        public virtual ICollection<TrnsObgratuity> TrnsObgratuities { get; set; }
        public virtual ICollection<TrnsObjFnyHead> TrnsObjFnyHeads { get; set; }
        public virtual ICollection<TrnsObleaf> TrnsObleaves { get; set; }
        public virtual ICollection<TrnsObloan> TrnsObloans { get; set; }
        public virtual ICollection<TrnsObprovidentFund> TrnsObprovidentFunds { get; set; }
        public virtual ICollection<TrnsObsalary> TrnsObsalaries { get; set; }
        public virtual ICollection<TrnsObtax> TrnsObtaxes { get; set; }
        public virtual ICollection<TrnsOfferLetter> TrnsOfferLetters { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentDetail> TrnsPartnerAssessmentDetails { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentHead> TrnsPartnerAssessmentHeads { get; set; }
        public virtual ICollection<TrnsPartnerBusinessRevenueDetail> TrnsPartnerBusinessRevenueDetails { get; set; }
        public virtual ICollection<TrnsPartnerContributionDetail> TrnsPartnerContributionDetails { get; set; }
        public virtual ICollection<TrnsPartnerFacilitateTrainingDetail> TrnsPartnerFacilitateTrainingDetails { get; set; }
        public virtual ICollection<TrnsPartnerFeedback360> TrnsPartnerFeedback360s { get; set; }
        public virtual ICollection<TrnsPartnerNetProfitDetail> TrnsPartnerNetProfitDetails { get; set; }
        public virtual ICollection<TrnsPartnerRevenueAccrualDetail> TrnsPartnerRevenueAccrualDetails { get; set; }
        public virtual ICollection<TrnsPartnerUnAllocatedFormsDetail> TrnsPartnerUnAllocatedFormsDetails { get; set; }
        public virtual ICollection<TrnsPartnerUnAllocatedFormsHead> TrnsPartnerUnAllocatedFormsHeads { get; set; }
        public virtual ICollection<TrnsPeerFeedback360> TrnsPeerFeedback360s { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360DetailManagers { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360DetailPeerNavigations { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360DetailSubOrdinates { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360> TrnsPerformanceAppraisal360s { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal> TrnsPerformanceAppraisalAppraisers { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal> TrnsPerformanceAppraisalEmps { get; set; }
        public virtual ICollection<TrnsPerformanceEvaluationHead> TrnsPerformanceEvaluationHeadAppraisers { get; set; }
        public virtual ICollection<TrnsPerformanceEvaluationHead> TrnsPerformanceEvaluationHeadEmps { get; set; }
        public virtual ICollection<TrnsPerformanceManagement> TrnsPerformanceManagements { get; set; }
        public virtual ICollection<TrnsPerformancePlan> TrnsPerformancePlans { get; set; }
        public virtual ICollection<TrnsPerofrmanceEvaluationDetail> TrnsPerofrmanceEvaluationDetails { get; set; }
        public virtual ICollection<TrnsProbationAssesHead> TrnsProbationAssesHeads { get; set; }
        public virtual ICollection<TrnsProbationHead> TrnsProbationHeads { get; set; }
        public virtual ICollection<TrnsReHireEmployee> TrnsReHireEmployees { get; set; }
        public virtual ICollection<TrnsResignation> TrnsResignations { get; set; }
        public virtual ICollection<TrnsSalaryArear> TrnsSalaryArears { get; set; }
        public virtual ICollection<TrnsSalaryChange> TrnsSalaryChanges { get; set; }
        public virtual ICollection<TrnsSalaryProcessRegister> TrnsSalaryProcessRegisters { get; set; }
        public virtual ICollection<TrnsSchoolPensionRequest> TrnsSchoolPensionRequests { get; set; }
        public virtual ICollection<TrnsSingleEntryOtdetail> TrnsSingleEntryOtdetails { get; set; }
        public virtual ICollection<TrnsSpdaysAdj> TrnsSpdaysAdjs { get; set; }
        public virtual ICollection<TrnsTaxAdjustment> TrnsTaxAdjustments { get; set; }
        public virtual ICollection<TrnsTextileGroupAttendanceReg> TrnsTextileGroupAttendanceRegs { get; set; }
        public virtual ICollection<TrnsTrainingAttendanceDetail> TrnsTrainingAttendanceDetails { get; set; }
        public virtual ICollection<TrnsTrainingAttendance> TrnsTrainingAttendances { get; set; }
        public virtual ICollection<TrnsTrainingEvaluation> TrnsTrainingEvaluations { get; set; }
        public virtual ICollection<TrnsTrainingFeedback> TrnsTrainingFeedbacks { get; set; }
        public virtual ICollection<TrnsTrainingPlanDetail> TrnsTrainingPlanDetails { get; set; }
        public virtual ICollection<TrnsTrainingPlan> TrnsTrainingPlans { get; set; }
        public virtual ICollection<TrnsTravelPaymentRequest> TrnsTravelPaymentRequests { get; set; }
        public virtual ICollection<TrnsViolation> TrnsViolations { get; set; }
        public virtual ICollection<TrnsWarningLetter> TrnsWarningLetters { get; set; }
    }
}
