using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCM.API.HCMModels
{
    public partial class HCMOneContext : DbContext
    {
        public HCMOneContext()
        {
        }

        public HCMOneContext(DbContextOptions<HCMOneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalDecisionRegister> ApprovalDecisionRegisters { get; set; }
        public virtual DbSet<ApprovalDecisionRegisterDetail> ApprovalDecisionRegisterDetails { get; set; }
        public virtual DbSet<AttCfg> AttCfgs { get; set; }
        public virtual DbSet<AttDevUser> AttDevUsers { get; set; }
        public virtual DbSet<AttDevice> AttDevices { get; set; }
        public virtual DbSet<AttScan> AttScans { get; set; }
        public virtual DbSet<AttSummary> AttSummaries { get; set; }
        public virtual DbSet<AttSummaryDetail> AttSummaryDetails { get; set; }
        public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; }
        public virtual DbSet<CfgAlertManagement> CfgAlertManagements { get; set; }
        public virtual DbSet<CfgAlertManagementDepartment> CfgAlertManagementDepartments { get; set; }
        public virtual DbSet<CfgAlertManagementEmployee> CfgAlertManagementEmployees { get; set; }
        public virtual DbSet<CfgAlertManagementGroup> CfgAlertManagementGroups { get; set; }
        public virtual DbSet<CfgApprovalDecisionRegister> CfgApprovalDecisionRegisters { get; set; }
        public virtual DbSet<CfgApprovalStage> CfgApprovalStages { get; set; }
        public virtual DbSet<CfgApprovalStageDetail> CfgApprovalStageDetails { get; set; }
        public virtual DbSet<CfgApprovalTemplate> CfgApprovalTemplates { get; set; }
        public virtual DbSet<CfgApprovalTemplateDocument> CfgApprovalTemplateDocuments { get; set; }
        public virtual DbSet<CfgApprovalTemplateOriginator> CfgApprovalTemplateOriginators { get; set; }
        public virtual DbSet<CfgApprovalTemplateStage> CfgApprovalTemplateStages { get; set; }
        public virtual DbSet<CfgAttandanceSetting> CfgAttandanceSettings { get; set; }
        public virtual DbSet<CfgConnectionSetUp> CfgConnectionSetUps { get; set; }
        public virtual DbSet<CfgDbempRight> CfgDbempRights { get; set; }
        public virtual DbSet<CfgDbhostOffice> CfgDbhostOffices { get; set; }
        public virtual DbSet<CfgDbsetting> CfgDbsettings { get; set; }
        public virtual DbSet<CfgDocumentStageRegister> CfgDocumentStageRegisters { get; set; }
        public virtual DbSet<CfgDocumentType> CfgDocumentTypes { get; set; }
        public virtual DbSet<CfgEmailSetting> CfgEmailSettings { get; set; }
        public virtual DbSet<CfgEmpCodeGeneration> CfgEmpCodeGenerations { get; set; }
        public virtual DbSet<CfgEmployeeInformationDettail> CfgEmployeeInformationDettails { get; set; }
        public virtual DbSet<CfgEmployeeShift> CfgEmployeeShifts { get; set; }
        public virtual DbSet<CfgFormula> CfgFormulas { get; set; }
        public virtual DbSet<CfgFormulaElement> CfgFormulaElements { get; set; }
        public virtual DbSet<CfgHostOfficeDocType> CfgHostOfficeDocTypes { get; set; }
        public virtual DbSet<CfgIncomeTaxMarginalSetup> CfgIncomeTaxMarginalSetups { get; set; }
        public virtual DbSet<CfgLeaveMatrix> CfgLeaveMatrices { get; set; }
        public virtual DbSet<CfgPayrollBasicInitialization> CfgPayrollBasicInitializations { get; set; }
        public virtual DbSet<CfgPayrollDefination> CfgPayrollDefinations { get; set; }
        public virtual DbSet<CfgPayrollShift> CfgPayrollShifts { get; set; }
        public virtual DbSet<CfgPerformancePeriod> CfgPerformancePeriods { get; set; }
        public virtual DbSet<CfgPerformancePeriodDetail> CfgPerformancePeriodDetails { get; set; }
        public virtual DbSet<CfgPeriodDate> CfgPeriodDates { get; set; }
        public virtual DbSet<CfgReportViewer> CfgReportViewers { get; set; }
        public virtual DbSet<CfgSeries> CfgSeries { get; set; }
        public virtual DbSet<CfgTaxDetail> CfgTaxDetails { get; set; }
        public virtual DbSet<CfgTaxSetup> CfgTaxSetups { get; set; }
        public virtual DbSet<CnfHistory> CnfHistories { get; set; }
        public virtual DbSet<Cnotifiy> Cnotifiys { get; set; }
        public virtual DbSet<CompetencyLevelSetup> CompetencyLevelSetups { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual DbSet<DocumentTemplateDetail> DocumentTemplateDetails { get; set; }
        public virtual DbSet<DynamicApprovalHierarchy> DynamicApprovalHierarchies { get; set; }
        public virtual DbSet<EmailQueue> EmailQueues { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<EmployeeAssetAssign> EmployeeAssetAssigns { get; set; }
        public virtual DbSet<EmployeeAssetAssignment> EmployeeAssetAssignments { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<LgAdvance> LgAdvances { get; set; }
        public virtual DbSet<LgArrear> LgArrears { get; set; }
        public virtual DbSet<LgBonu> LgBonus { get; set; }
        public virtual DbSet<LgBranch> LgBranches { get; set; }
        public virtual DbSet<LgCalender> LgCalenders { get; set; }
        public virtual DbSet<LgCandidate> LgCandidates { get; set; }
        public virtual DbSet<LgCertification> LgCertifications { get; set; }
        public virtual DbSet<LgCompany> LgCompanies { get; set; }
        public virtual DbSet<LgCompetancy> LgCompetancies { get; set; }
        public virtual DbSet<LgCompetancyGroup> LgCompetancyGroups { get; set; }
        public virtual DbSet<LgDepartment> LgDepartments { get; set; }
        public virtual DbSet<LgDesignation> LgDesignations { get; set; }
        public virtual DbSet<LgExpense> LgExpenses { get; set; }
        public virtual DbSet<LgGratuity> LgGratuities { get; set; }
        public virtual DbSet<LgInstitute> LgInstitutes { get; set; }
        public virtual DbSet<LgJobDesignation> LgJobDesignations { get; set; }
        public virtual DbSet<LgJobTitle> LgJobTitles { get; set; }
        public virtual DbSet<LgLeaveDeduction> LgLeaveDeductions { get; set; }
        public virtual DbSet<LgLeaveType> LgLeaveTypes { get; set; }
        public virtual DbSet<LgLoan> LgLoans { get; set; }
        public virtual DbSet<LgLocation> LgLocations { get; set; }
        public virtual DbSet<LgMemberShip> LgMemberShips { get; set; }
        public virtual DbSet<LgOccupationType> LgOccupationTypes { get; set; }
        public virtual DbSet<LgOverTime> LgOverTimes { get; set; }
        public virtual DbSet<LgPosition> LgPositions { get; set; }
        public virtual DbSet<LgQualification> LgQualifications { get; set; }
        public virtual DbSet<LgRecognition> LgRecognitions { get; set; }
        public virtual DbSet<LgRelation> LgRelations { get; set; }
        public virtual DbSet<LgRetroElementSet> LgRetroElementSets { get; set; }
        public virtual DbSet<LgRole> LgRoles { get; set; }
        public virtual DbSet<LgShift> LgShifts { get; set; }
        public virtual DbSet<LgSkill> LgSkills { get; set; }
        public virtual DbSet<LgTeam> LgTeams { get; set; }
        public virtual DbSet<LgTrnsAdvance> LgTrnsAdvances { get; set; }
        public virtual DbSet<LgTrnsLoan> LgTrnsLoans { get; set; }
        public virtual DbSet<LgTrnsLoanDetail> LgTrnsLoanDetails { get; set; }
        public virtual DbSet<LgUser> LgUsers { get; set; }
        public virtual DbSet<LgVacancyType> LgVacancyTypes { get; set; }
        public virtual DbSet<LogDisbursment> LogDisbursments { get; set; }
        public virtual DbSet<LogEmployeeElement> LogEmployeeElements { get; set; }
        public virtual DbSet<LogEmployeeElementDetail> LogEmployeeElementDetails { get; set; }
        public virtual DbSet<LogTaxDetail> LogTaxDetails { get; set; }
        public virtual DbSet<MenuDatum> MenuData { get; set; }
        public virtual DbSet<MenuHead> MenuHeads { get; set; }
        public virtual DbSet<MenuHead1> MenuHeads1 { get; set; }
        public virtual DbSet<MstAdvance> MstAdvances { get; set; }
        public virtual DbSet<MstAirTicketConfig> MstAirTicketConfigs { get; set; }
        public virtual DbSet<MstAirTicketGroup> MstAirTicketGroups { get; set; }
        public virtual DbSet<MstAlertGroup> MstAlertGroups { get; set; }
        public virtual DbSet<MstAlertGroupDetail> MstAlertGroupDetails { get; set; }
        public virtual DbSet<MstAppraisal> MstAppraisals { get; set; }
        public virtual DbSet<MstAppraisalGrade> MstAppraisalGrades { get; set; }
        public virtual DbSet<MstAppraisalLog> MstAppraisalLogs { get; set; }
        public virtual DbSet<MstAppraisalTerm> MstAppraisalTerms { get; set; }
        public virtual DbSet<MstArrear> MstArrears { get; set; }
        public virtual DbSet<MstAssestment> MstAssestments { get; set; }
        public virtual DbSet<MstAssestmentCriterion> MstAssestmentCriteria { get; set; }
        public virtual DbSet<MstAssetCategory> MstAssetCategories { get; set; }
        public virtual DbSet<MstAssignRole> MstAssignRoles { get; set; }
        public virtual DbSet<MstAttachment> MstAttachments { get; set; }
        public virtual DbSet<MstAttachment1> MstAttachments1 { get; set; }
        public virtual DbSet<MstAttendanceAllowance> MstAttendanceAllowances { get; set; }
        public virtual DbSet<MstAttendanceAutoSaveConfiguration> MstAttendanceAutoSaveConfigurations { get; set; }
        public virtual DbSet<MstAttendanceRule> MstAttendanceRules { get; set; }
        public virtual DbSet<MstBenefit> MstBenefits { get; set; }
        public virtual DbSet<MstBonu> MstBonus { get; set; }
        public virtual DbSet<MstBonusYearly> MstBonusYearlies { get; set; }
        public virtual DbSet<MstBranch> MstBranches { get; set; }
        public virtual DbSet<MstCalendar> MstCalendars { get; set; }
        public virtual DbSet<MstCandidate> MstCandidates { get; set; }
        public virtual DbSet<MstCandidateAttachment> MstCandidateAttachments { get; set; }
        public virtual DbSet<MstCandidateEducation> MstCandidateEducations { get; set; }
        public virtual DbSet<MstCandidateOtherInfo> MstCandidateOtherInfos { get; set; }
        public virtual DbSet<MstCandidatePastExperience> MstCandidatePastExperiences { get; set; }
        public virtual DbSet<MstCandidateQualification> MstCandidateQualifications { get; set; }
        public virtual DbSet<MstCandidateReference> MstCandidateReferences { get; set; }
        public virtual DbSet<MstCategory> MstCategories { get; set; }
        public virtual DbSet<MstCertification> MstCertifications { get; set; }
        public virtual DbSet<MstCity> MstCities { get; set; }
        public virtual DbSet<MstClassification> MstClassifications { get; set; }
        public virtual DbSet<MstCoachingDoc> MstCoachingDocs { get; set; }
        public virtual DbSet<MstCommitmentAllowancePolicy> MstCommitmentAllowancePolicies { get; set; }
        public virtual DbSet<MstCommitteeSetup> MstCommitteeSetups { get; set; }
        public virtual DbSet<MstCompany> MstCompanies { get; set; }
        public virtual DbSet<MstCompanyDetail> MstCompanyDetails { get; set; }
        public virtual DbSet<MstCompetancy> MstCompetancies { get; set; }
        public virtual DbSet<MstCompetencyGroup> MstCompetencyGroups { get; set; }
        public virtual DbSet<MstContractor> MstContractors { get; set; }
        public virtual DbSet<MstCostCentre> MstCostCentres { get; set; }
        public virtual DbSet<MstCountry> MstCountries { get; set; }
        public virtual DbSet<MstCphelement> MstCphelements { get; set; }
        public virtual DbSet<MstCurrency> MstCurrencies { get; set; }
        public virtual DbSet<MstDeductionRule> MstDeductionRules { get; set; }
        public virtual DbSet<MstDeductionRuleSup> MstDeductionRuleSups { get; set; }
        public virtual DbSet<MstDepartment> MstDepartments { get; set; }
        public virtual DbSet<MstDesigLinkCompetency> MstDesigLinkCompetencies { get; set; }
        public virtual DbSet<MstDesigLinkGrade> MstDesigLinkGrades { get; set; }
        public virtual DbSet<MstDesignation> MstDesignations { get; set; }
        public virtual DbSet<MstDesignationLevel> MstDesignationLevels { get; set; }
        public virtual DbSet<MstDetailTraningBudget> MstDetailTraningBudgets { get; set; }
        public virtual DbSet<MstDimension> MstDimensions { get; set; }
        public virtual DbSet<MstDisciplinaryActionsType> MstDisciplinaryActionsTypes { get; set; }
        public virtual DbSet<MstDocumentCheckList> MstDocumentCheckLists { get; set; }
        public virtual DbSet<MstDocumentNumberSeries> MstDocumentNumberSeries { get; set; }
        public virtual DbSet<MstElement> MstElements { get; set; }
        public virtual DbSet<MstElementContribution> MstElementContributions { get; set; }
        public virtual DbSet<MstElementDeduction> MstElementDeductions { get; set; }
        public virtual DbSet<MstElementEarning> MstElementEarnings { get; set; }
        public virtual DbSet<MstElementFormulaBuilder> MstElementFormulaBuilders { get; set; }
        public virtual DbSet<MstElementInformation> MstElementInformations { get; set; }
        public virtual DbSet<MstElementLink> MstElementLinks { get; set; }
        public virtual DbSet<MstElementQueryRegister> MstElementQueryRegisters { get; set; }
        public virtual DbSet<MstElementsPerRate> MstElementsPerRates { get; set; }
        public virtual DbSet<MstEmail> MstEmails { get; set; }
        public virtual DbSet<MstEmailConfig> MstEmailConfigs { get; set; }
        public virtual DbSet<MstEmpFingerRegister> MstEmpFingerRegisters { get; set; }
        public virtual DbSet<MstEmployee> MstEmployees { get; set; }
        public virtual DbSet<MstEmployeeApproval> MstEmployeeApprovals { get; set; }
        public virtual DbSet<MstEmployeeAsset> MstEmployeeAssets { get; set; }
        public virtual DbSet<MstEmployeeAttachment> MstEmployeeAttachments { get; set; }
        public virtual DbSet<MstEmployeeCertification> MstEmployeeCertifications { get; set; }
        public virtual DbSet<MstEmployeeCertificationsApproval> MstEmployeeCertificationsApprovals { get; set; }
        public virtual DbSet<MstEmployeeCodeSeries> MstEmployeeCodeSeries { get; set; }
        public virtual DbSet<MstEmployeeCommittee> MstEmployeeCommittees { get; set; }
        public virtual DbSet<MstEmployeeDocument> MstEmployeeDocuments { get; set; }
        public virtual DbSet<MstEmployeeEducation> MstEmployeeEducations { get; set; }
        public virtual DbSet<MstEmployeeEducationApproval> MstEmployeeEducationApprovals { get; set; }
        public virtual DbSet<MstEmployeeEndOfService> MstEmployeeEndOfServices { get; set; }
        public virtual DbSet<MstEmployeeExitClearnce> MstEmployeeExitClearnces { get; set; }
        public virtual DbSet<MstEmployeeExperience> MstEmployeeExperiences { get; set; }
        public virtual DbSet<MstEmployeeExperienceApproval> MstEmployeeExperienceApprovals { get; set; }
        public virtual DbSet<MstEmployeeLanguagesProficiency> MstEmployeeLanguagesProficiencies { get; set; }
        public virtual DbSet<MstEmployeeLeaf> MstEmployeeLeaves { get; set; }
        public virtual DbSet<MstEmployeeLog> MstEmployeeLogs { get; set; }
        public virtual DbSet<MstEmployeeLog1> MstEmployeeLogs1 { get; set; }
        public virtual DbSet<MstEmployeeReference> MstEmployeeReferences { get; set; }
        public virtual DbSet<MstEmployeeReferral> MstEmployeeReferrals { get; set; }
        public virtual DbSet<MstEmployeeReferralsDetail> MstEmployeeReferralsDetails { get; set; }
        public virtual DbSet<MstEmployeeRelative> MstEmployeeRelatives { get; set; }
        public virtual DbSet<MstEmployeeRelativesApproval> MstEmployeeRelativesApprovals { get; set; }
        public virtual DbSet<MstEmployeeSuccessor> MstEmployeeSuccessors { get; set; }
        public virtual DbSet<MstEmployeeTest> MstEmployeeTests { get; set; }
        public virtual DbSet<MstExpense> MstExpenses { get; set; }
        public virtual DbSet<MstForm> MstForms { get; set; }
        public virtual DbSet<MstFormula> MstFormulas { get; set; }
        public virtual DbSet<MstFt> MstFts { get; set; }
        public virtual DbSet<MstGenericRequest> MstGenericRequests { get; set; }
        public virtual DbSet<MstGldadvanceDetail> MstGldadvanceDetails { get; set; }
        public virtual DbSet<MstGldbonusDetail> MstGldbonusDetails { get; set; }
        public virtual DbSet<MstGldcontribution> MstGldcontributions { get; set; }
        public virtual DbSet<MstGlddeductionDetail> MstGlddeductionDetails { get; set; }
        public virtual DbSet<MstGldearningDetail> MstGldearningDetails { get; set; }
        public virtual DbSet<MstGldepartmentWise> MstGldepartmentWises { get; set; }
        public virtual DbSet<MstGldetermination> MstGldeterminations { get; set; }
        public virtual DbSet<MstGldexpDetail> MstGldexpDetails { get; set; }
        public virtual DbSet<MstGldleaveDedDetail> MstGldleaveDedDetails { get; set; }
        public virtual DbSet<MstGldloansDetail> MstGldloansDetails { get; set; }
        public virtual DbSet<MstGldoverTimeDetail> MstGldoverTimeDetails { get; set; }
        public virtual DbSet<MstGoalsRuless> MstGoalsRulesses { get; set; }
        public virtual DbSet<MstGrading> MstGradings { get; set; }
        public virtual DbSet<MstGratuity> MstGratuities { get; set; }
        public virtual DbSet<MstGratuityDetail> MstGratuityDetails { get; set; }
        public virtual DbSet<MstGroup> MstGroups { get; set; }
        public virtual DbSet<MstHierarchySetup> MstHierarchySetups { get; set; }
        public virtual DbSet<MstHoliday> MstHolidays { get; set; }
        public virtual DbSet<MstHolidayDetail> MstHolidayDetails { get; set; }
        public virtual DbSet<MstIncrementBracket> MstIncrementBrackets { get; set; }
        public virtual DbSet<MstInstitute> MstInstitutes { get; set; }
        public virtual DbSet<MstInterviewAssessmentCategory> MstInterviewAssessmentCategories { get; set; }
        public virtual DbSet<MstInterviewAssessmentQuestion> MstInterviewAssessmentQuestions { get; set; }
        public virtual DbSet<MstJobDesignation> MstJobDesignations { get; set; }
        public virtual DbSet<MstJobTitle> MstJobTitles { get; set; }
        public virtual DbSet<MstKpirule> MstKpirules { get; set; }
        public virtual DbSet<MstLanguage> MstLanguages { get; set; }
        public virtual DbSet<MstLanguage1> MstLanguages1 { get; set; }
        public virtual DbSet<MstLeaveCalendar> MstLeaveCalendars { get; set; }
        public virtual DbSet<MstLeaveConditionalDeduction> MstLeaveConditionalDeductions { get; set; }
        public virtual DbSet<MstLeaveDeduction> MstLeaveDeductions { get; set; }
        public virtual DbSet<MstLeaveType> MstLeaveTypes { get; set; }
        public virtual DbSet<MstLoan> MstLoans { get; set; }
        public virtual DbSet<MstLocation> MstLocations { get; set; }
        public virtual DbSet<MstLove> MstLoves { get; set; }
        public virtual DbSet<MstMemberShip> MstMemberShips { get; set; }
        public virtual DbSet<MstMenuList> MstMenuLists { get; set; }
        public virtual DbSet<MstMpp> MstMpps { get; set; }
        public virtual DbSet<MstNoficationCategory> MstNoficationCategories { get; set; }
        public virtual DbSet<MstObjective> MstObjectives { get; set; }
        public virtual DbSet<MstOccupationType> MstOccupationTypes { get; set; }
        public virtual DbSet<MstOverTime> MstOverTimes { get; set; }
        public virtual DbSet<MstPart> MstParts { get; set; }
        public virtual DbSet<MstPartnerFeedback> MstPartnerFeedbacks { get; set; }
        public virtual DbSet<MstPartnerFeedbackAssign> MstPartnerFeedbackAssigns { get; set; }
        public virtual DbSet<MstPartnerFeedbackDetail> MstPartnerFeedbackDetails { get; set; }
        public virtual DbSet<MstPartnerFeedbackStmnt> MstPartnerFeedbackStmnts { get; set; }
        public virtual DbSet<MstPartnerFeedbackStmntDetail> MstPartnerFeedbackStmntDetails { get; set; }
        public virtual DbSet<MstPartnerPerformanceCategory> MstPartnerPerformanceCategories { get; set; }
        public virtual DbSet<MstPartnerPerformanceSubCat> MstPartnerPerformanceSubCats { get; set; }
        public virtual DbSet<MstPartnerPerformanceSubCatDetail> MstPartnerPerformanceSubCatDetails { get; set; }
        public virtual DbSet<MstPartnerPerformanceTerm> MstPartnerPerformanceTerms { get; set; }
        public virtual DbSet<MstPasswordSetup> MstPasswordSetups { get; set; }
        public virtual DbSet<MstPayBand> MstPayBands { get; set; }
        public virtual DbSet<MstPenaltyRule> MstPenaltyRules { get; set; }
        public virtual DbSet<MstPerformanceAssessmentCriterion> MstPerformanceAssessmentCriteria { get; set; }
        public virtual DbSet<MstPerformanceBasedPolicy> MstPerformanceBasedPolicies { get; set; }
        public virtual DbSet<MstPerformanceRating> MstPerformanceRatings { get; set; }
        public virtual DbSet<MstPerformanceTerm> MstPerformanceTerms { get; set; }
        public virtual DbSet<MstPosition> MstPositions { get; set; }
        public virtual DbSet<MstProbationCategory> MstProbationCategories { get; set; }
        public virtual DbSet<MstProbationCategoryChildDesignation> MstProbationCategoryChildDesignations { get; set; }
        public virtual DbSet<MstProbationEvalCriterion> MstProbationEvalCriteria { get; set; }
        public virtual DbSet<MstProbationEvalCycle> MstProbationEvalCycles { get; set; }
        public virtual DbSet<MstProbationStatement> MstProbationStatements { get; set; }
        public virtual DbSet<MstProbationStatementsChildDesignation> MstProbationStatementsChildDesignations { get; set; }
        public virtual DbSet<MstProfitCenter> MstProfitCenters { get; set; }
        public virtual DbSet<MstProject> MstProjects { get; set; }
        public virtual DbSet<MstQualification> MstQualifications { get; set; }
        public virtual DbSet<MstRecognition> MstRecognitions { get; set; }
        public virtual DbSet<MstRecruiter> MstRecruiters { get; set; }
        public virtual DbSet<MstReferralScheme> MstReferralSchemes { get; set; }
        public virtual DbSet<MstRelation> MstRelations { get; set; }
        public virtual DbSet<MstReport> MstReports { get; set; }
        public virtual DbSet<MstRetroElementDetail> MstRetroElementDetails { get; set; }
        public virtual DbSet<MstRetroElementSet> MstRetroElementSets { get; set; }
        public virtual DbSet<MstRole> MstRoles { get; set; }
        public virtual DbSet<MstSecondment> MstSecondments { get; set; }
        public virtual DbSet<MstSector> MstSectors { get; set; }
        public virtual DbSet<MstSetting> MstSettings { get; set; }
        public virtual DbSet<MstShift> MstShifts { get; set; }
        public virtual DbSet<MstShiftBreak> MstShiftBreaks { get; set; }
        public virtual DbSet<MstShiftDay> MstShiftDays { get; set; }
        public virtual DbSet<MstShiftDetail> MstShiftDetails { get; set; }
        public virtual DbSet<MstSkill> MstSkills { get; set; }
        public virtual DbSet<MstSpecialDay> MstSpecialDays { get; set; }
        public virtual DbSet<MstStage> MstStages { get; set; }
        public virtual DbSet<MstStageDetail> MstStageDetails { get; set; }
        public virtual DbSet<MstState> MstStates { get; set; }
        public virtual DbSet<MstStation> MstStations { get; set; }
        public virtual DbSet<MstSubCategory> MstSubCategories { get; set; }
        public virtual DbSet<MstSubPartsStatement> MstSubPartsStatements { get; set; }
        public virtual DbSet<MstSubPartss> MstSubPartsses { get; set; }
        public virtual DbSet<MstTeam> MstTeams { get; set; }
        public virtual DbSet<MstTrainingAttachment> MstTrainingAttachments { get; set; }
        public virtual DbSet<MstTrainingBudget> MstTrainingBudgets { get; set; }
        public virtual DbSet<MstTrainingCategory> MstTrainingCategories { get; set; }
        public virtual DbSet<MstTrainingCourse> MstTrainingCourses { get; set; }
        public virtual DbSet<MstTrainingEvaluationCategory> MstTrainingEvaluationCategories { get; set; }
        public virtual DbSet<MstTrainingFeedback> MstTrainingFeedbacks { get; set; }
        public virtual DbSet<MstTrainingNeedAssesment> MstTrainingNeedAssesments { get; set; }
        public virtual DbSet<MstTrainingProvider> MstTrainingProviders { get; set; }
        public virtual DbSet<MstTrainingStatement> MstTrainingStatements { get; set; }
        public virtual DbSet<MstTrainingStatementAttach> MstTrainingStatementAttaches { get; set; }
        public virtual DbSet<MstTrainingVenue> MstTrainingVenues { get; set; }
        public virtual DbSet<MstTravelExpense> MstTravelExpenses { get; set; }
        public virtual DbSet<MstUser> MstUsers { get; set; }
        public virtual DbSet<MstUserBranchMapping> MstUserBranchMappings { get; set; }
        public virtual DbSet<MstUserFunction> MstUserFunctions { get; set; }
        public virtual DbSet<MstUserRoleRight> MstUserRoleRights { get; set; }
        public virtual DbSet<MstUsersAuth> MstUsersAuths { get; set; }
        public virtual DbSet<MstVacancyType> MstVacancyTypes { get; set; }
        public virtual DbSet<MstWarningLetter> MstWarningLetters { get; set; }
        public virtual DbSet<Mulg> Mulgs { get; set; }
        public virtual DbSet<NeskCfgApprovalDecisionRegister> NeskCfgApprovalDecisionRegisters { get; set; }
        public virtual DbSet<NeskCfgDocHierarchy> NeskCfgDocHierarchies { get; set; }
        public virtual DbSet<NeskCfgDocHierarchyDetail> NeskCfgDocHierarchyDetails { get; set; }
        public virtual DbSet<NeskTrnsAttendanceRegister> NeskTrnsAttendanceRegisters { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<PerformanceStatementTermAttachment> PerformanceStatementTermAttachments { get; set; }
        public virtual DbSet<PfLoanAmtView> PfLoanAmtViews { get; set; }
        public virtual DbSet<RoosterInput> RoosterInputs { get; set; }
        public virtual DbSet<RoosterInput61> RoosterInput61s { get; set; }
        public virtual DbSet<RoosterTable> RoosterTables { get; set; }
        public virtual DbSet<RoosterTable61> RoosterTable61s { get; set; }
        public virtual DbSet<SalaryDeduction> SalaryDeductions { get; set; }
        public virtual DbSet<SalaryEarning> SalaryEarnings { get; set; }
        public virtual DbSet<SalaryEmployerContrbution> SalaryEmployerContrbutions { get; set; }
        public virtual DbSet<SalaryLetter> SalaryLetters { get; set; }
        public virtual DbSet<SendEmail> SendEmails { get; set; }
        public virtual DbSet<StdElement> StdElements { get; set; }
        public virtual DbSet<StdElements2> StdElements2s { get; set; }
        public virtual DbSet<TblRpt> TblRpts { get; set; }
        public virtual DbSet<TmpEmp> TmpEmps { get; set; }
        public virtual DbSet<TmpMsXxMstEmployee> TmpMsXxMstEmployees { get; set; }
        public virtual DbSet<TmpVlBal> TmpVlBals { get; set; }
        public virtual DbSet<TrainingRequestForm> TrainingRequestForms { get; set; }
        public virtual DbSet<TrnDisciplinaryAppeal> TrnDisciplinaryAppeals { get; set; }
        public virtual DbSet<TrnsActivityLog> TrnsActivityLogs { get; set; }
        public virtual DbSet<TrnsAdvance> TrnsAdvances { get; set; }
        public virtual DbSet<TrnsAdvancePaymentBatch> TrnsAdvancePaymentBatches { get; set; }
        public virtual DbSet<TrnsAdvancePaymentBatchDetail> TrnsAdvancePaymentBatchDetails { get; set; }
        public virtual DbSet<TrnsAdvancePettyCashClaimsDetail> TrnsAdvancePettyCashClaimsDetails { get; set; }
        public virtual DbSet<TrnsAdvancePettyCashReconcile> TrnsAdvancePettyCashReconciles { get; set; }
        public virtual DbSet<TrnsAdvancePettyCashRequest> TrnsAdvancePettyCashRequests { get; set; }
        public virtual DbSet<TrnsAdvanceReceived> TrnsAdvanceReceiveds { get; set; }
        public virtual DbSet<TrnsAdvanceRegister> TrnsAdvanceRegisters { get; set; }
        public virtual DbSet<TrnsAdvanceRequest> TrnsAdvanceRequests { get; set; }
        public virtual DbSet<TrnsAppealEvidence> TrnsAppealEvidences { get; set; }
        public virtual DbSet<TrnsAppraisalResult> TrnsAppraisalResults { get; set; }
        public virtual DbSet<TrnsAssistanceRequest> TrnsAssistanceRequests { get; set; }
        public virtual DbSet<TrnsAttendancePosted> TrnsAttendancePosteds { get; set; }
        public virtual DbSet<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual DbSet<TrnsAttendanceRegisterDetail> TrnsAttendanceRegisterDetails { get; set; }
        public virtual DbSet<TrnsAttendanceRegisterT> TrnsAttendanceRegisterTs { get; set; }
        public virtual DbSet<TrnsBatch> TrnsBatches { get; set; }
        public virtual DbSet<TrnsBatchesDetail> TrnsBatchesDetails { get; set; }
        public virtual DbSet<TrnsBenchMovement> TrnsBenchMovements { get; set; }
        public virtual DbSet<TrnsBenchMovementDetail> TrnsBenchMovementDetails { get; set; }
        public virtual DbSet<TrnsBonu> TrnsBonus { get; set; }
        public virtual DbSet<TrnsCdpdetail> TrnsCdpdetails { get; set; }
        public virtual DbSet<TrnsCdphead> TrnsCdpheads { get; set; }
        public virtual DbSet<TrnsCeoremark> TrnsCeoremarks { get; set; }
        public virtual DbSet<TrnsCompetencyProfile> TrnsCompetencyProfiles { get; set; }
        public virtual DbSet<TrnsCompetencyProfileDetail> TrnsCompetencyProfileDetails { get; set; }
        public virtual DbSet<TrnsCph> TrnsCphs { get; set; }
        public virtual DbSet<TrnsDeductionRule> TrnsDeductionRules { get; set; }
        public virtual DbSet<TrnsDeductionRulesDetail> TrnsDeductionRulesDetails { get; set; }
        public virtual DbSet<TrnsDeptShift> TrnsDeptShifts { get; set; }
        public virtual DbSet<TrnsDeptShiftDetail> TrnsDeptShiftDetails { get; set; }
        public virtual DbSet<TrnsDisciplinaryActionCommittee> TrnsDisciplinaryActionCommittees { get; set; }
        public virtual DbSet<TrnsDisciplinaryActionDetail> TrnsDisciplinaryActionDetails { get; set; }
        public virtual DbSet<TrnsDisciplinaryActionEvidence> TrnsDisciplinaryActionEvidences { get; set; }
        public virtual DbSet<TrnsDisciplinaryActionRequest> TrnsDisciplinaryActionRequests { get; set; }
        public virtual DbSet<TrnsDisciplinaryActionWitnessess> TrnsDisciplinaryActionWitnessesses { get; set; }
        public virtual DbSet<TrnsDisciplinaryAppealEvidence> TrnsDisciplinaryAppealEvidences { get; set; }
        public virtual DbSet<TrnsDisclaimerRequest> TrnsDisclaimerRequests { get; set; }
        public virtual DbSet<TrnsDutyResumption> TrnsDutyResumptions { get; set; }
        public virtual DbSet<TrnsElementPerRate> TrnsElementPerRates { get; set; }
        public virtual DbSet<TrnsElementPerRateDetail> TrnsElementPerRateDetails { get; set; }
        public virtual DbSet<TrnsEmpElementHead> TrnsEmpElementHeads { get; set; }
        public virtual DbSet<TrnsEmpPercent> TrnsEmpPercents { get; set; }
        public virtual DbSet<TrnsEmpTransferSummary> TrnsEmpTransferSummaries { get; set; }
        public virtual DbSet<TrnsEmpVl> TrnsEmpVls { get; set; }
        public virtual DbSet<TrnsEmpVldetail> TrnsEmpVldetails { get; set; }
        public virtual DbSet<TrnsEmployeeArrear> TrnsEmployeeArrears { get; set; }
        public virtual DbSet<TrnsEmployeeArrearsDetail> TrnsEmployeeArrearsDetails { get; set; }
        public virtual DbSet<TrnsEmployeeAttendanceAllowance> TrnsEmployeeAttendanceAllowances { get; set; }
        public virtual DbSet<TrnsEmployeeAttendanceAllowanceDetail> TrnsEmployeeAttendanceAllowanceDetails { get; set; }
        public virtual DbSet<TrnsEmployeeBonu> TrnsEmployeeBonus { get; set; }
        public virtual DbSet<TrnsEmployeeBonusDetail> TrnsEmployeeBonusDetails { get; set; }
        public virtual DbSet<TrnsEmployeeClearence> TrnsEmployeeClearences { get; set; }
        public virtual DbSet<TrnsEmployeeClearenceDetail> TrnsEmployeeClearenceDetails { get; set; }
        public virtual DbSet<TrnsEmployeeClearenceHierarchy> TrnsEmployeeClearenceHierarchies { get; set; }
        public virtual DbSet<TrnsEmployeeContributionWithdraw> TrnsEmployeeContributionWithdraws { get; set; }
        public virtual DbSet<TrnsEmployeeElement> TrnsEmployeeElements { get; set; }
        public virtual DbSet<TrnsEmployeeElementAdvance> TrnsEmployeeElementAdvances { get; set; }
        public virtual DbSet<TrnsEmployeeElementDetail> TrnsEmployeeElementDetails { get; set; }
        public virtual DbSet<TrnsEmployeeElementDetail1> TrnsEmployeeElementDetails1 { get; set; }
        public virtual DbSet<TrnsEmployeeElementLoan> TrnsEmployeeElementLoans { get; set; }
        public virtual DbSet<TrnsEmployeeElementRegister> TrnsEmployeeElementRegisters { get; set; }
        public virtual DbSet<TrnsEmployeeElementRegisterDetail> TrnsEmployeeElementRegisterDetails { get; set; }
        public virtual DbSet<TrnsEmployeeExitInterview> TrnsEmployeeExitInterviews { get; set; }
        public virtual DbSet<TrnsEmployeeExitInterviewAttach> TrnsEmployeeExitInterviewAttaches { get; set; }
        public virtual DbSet<TrnsEmployeeHiring> TrnsEmployeeHirings { get; set; }
        public virtual DbSet<TrnsEmployeeLoan> TrnsEmployeeLoans { get; set; }
        public virtual DbSet<TrnsEmployeeNoLateAllowance> TrnsEmployeeNoLateAllowances { get; set; }
        public virtual DbSet<TrnsEmployeeNoLateAllowanceDetail> TrnsEmployeeNoLateAllowanceDetails { get; set; }
        public virtual DbSet<TrnsEmployeeOvertime> TrnsEmployeeOvertimes { get; set; }
        public virtual DbSet<TrnsEmployeeOvertimeDetail> TrnsEmployeeOvertimeDetails { get; set; }
        public virtual DbSet<TrnsEmployeePenalty> TrnsEmployeePenalties { get; set; }
        public virtual DbSet<TrnsEmployeePerPieceProcessing> TrnsEmployeePerPieceProcessings { get; set; }
        public virtual DbSet<TrnsEmployeePerPieceProcessingDetail> TrnsEmployeePerPieceProcessingDetails { get; set; }
        public virtual DbSet<TrnsEmployeePerPieceRate> TrnsEmployeePerPieceRates { get; set; }
        public virtual DbSet<TrnsEmployeePerPieceRateDetail> TrnsEmployeePerPieceRateDetails { get; set; }
        public virtual DbSet<TrnsEmployeePerformance> TrnsEmployeePerformances { get; set; }
        public virtual DbSet<TrnsEmployeePerformanceDetail> TrnsEmployeePerformanceDetails { get; set; }
        public virtual DbSet<TrnsEmployeeProfitLossAllocation> TrnsEmployeeProfitLossAllocations { get; set; }
        public virtual DbSet<TrnsEmployeeReHire> TrnsEmployeeReHires { get; set; }
        public virtual DbSet<TrnsEmployeeTransfer> TrnsEmployeeTransfers { get; set; }
        public virtual DbSet<TrnsEmployeeTransferDetail> TrnsEmployeeTransferDetails { get; set; }
        public virtual DbSet<TrnsEmployeeTravellExpence> TrnsEmployeeTravellExpences { get; set; }
        public virtual DbSet<TrnsEmployeeWddetail> TrnsEmployeeWddetails { get; set; }
        public virtual DbSet<TrnsEmployeeWorkDay> TrnsEmployeeWorkDays { get; set; }
        public virtual DbSet<TrnsEmployeesAlert> TrnsEmployeesAlerts { get; set; }
        public virtual DbSet<TrnsExperienceLetter> TrnsExperienceLetters { get; set; }
        public virtual DbSet<TrnsFinalSettelmentRegister> TrnsFinalSettelmentRegisters { get; set; }
        public virtual DbSet<TrnsFinalSettelmentRegisterDetail> TrnsFinalSettelmentRegisterDetails { get; set; }
        public virtual DbSet<TrnsFshead> TrnsFsheads { get; set; }
        public virtual DbSet<TrnsGenericRequest> TrnsGenericRequests { get; set; }
        public virtual DbSet<TrnsGradeBenifit> TrnsGradeBenifits { get; set; }
        public virtual DbSet<TrnsGratuitySlab> TrnsGratuitySlabs { get; set; }
        public virtual DbSet<TrnsGratuitySlabsDetail> TrnsGratuitySlabsDetails { get; set; }
        public virtual DbSet<TrnsGrevianceRequest> TrnsGrevianceRequests { get; set; }
        public virtual DbSet<TrnsHeadBudget> TrnsHeadBudgets { get; set; }
        public virtual DbSet<TrnsHeadBudgetDetail> TrnsHeadBudgetDetails { get; set; }
        public virtual DbSet<TrnsIncDetail> TrnsIncDetails { get; set; }
        public virtual DbSet<TrnsIncrementPromotion> TrnsIncrementPromotions { get; set; }
        public virtual DbSet<TrnsInternalTransfer> TrnsInternalTransfers { get; set; }
        public virtual DbSet<TrnsInterviewAssessment> TrnsInterviewAssessments { get; set; }
        public virtual DbSet<TrnsInterviewAssessmentDetail> TrnsInterviewAssessmentDetails { get; set; }
        public virtual DbSet<TrnsInterviewCall> TrnsInterviewCalls { get; set; }
        public virtual DbSet<TrnsInterviewCallActivity> TrnsInterviewCallActivities { get; set; }
        public virtual DbSet<TrnsInterviewCallPanelList> TrnsInterviewCallPanelLists { get; set; }
        public virtual DbSet<TrnsInterviewEa> TrnsInterviewEas { get; set; }
        public virtual DbSet<TrnsInterviewEasassetment> TrnsInterviewEasassetments { get; set; }
        public virtual DbSet<TrnsInterviewEaspanelist> TrnsInterviewEaspanelists { get; set; }
        public virtual DbSet<TrnsInterviewEasscoreBoard> TrnsInterviewEasscoreBoards { get; set; }
        public virtual DbSet<TrnsInterviewRecommendation> TrnsInterviewRecommendations { get; set; }
        public virtual DbSet<TrnsJe> TrnsJes { get; set; }
        public virtual DbSet<TrnsJea1> TrnsJea1s { get; set; }
        public virtual DbSet<TrnsJeccregister> TrnsJeccregisters { get; set; }
        public virtual DbSet<TrnsJedetail> TrnsJedetails { get; set; }
        public virtual DbSet<TrnsJobAdvertising> TrnsJobAdvertisings { get; set; }
        public virtual DbSet<TrnsJobRequisition> TrnsJobRequisitions { get; set; }
        public virtual DbSet<TrnsJrdetailCertification> TrnsJrdetailCertifications { get; set; }
        public virtual DbSet<TrnsJrdetailCompetancy> TrnsJrdetailCompetancies { get; set; }
        public virtual DbSet<TrnsJrdetailEducation> TrnsJrdetailEducations { get; set; }
        public virtual DbSet<TrnsJrdetailSkill> TrnsJrdetailSkills { get; set; }
        public virtual DbSet<TrnsKpi> TrnsKpis { get; set; }
        public virtual DbSet<TrnsLeaveRequestHistory> TrnsLeaveRequestHistories { get; set; }
        public virtual DbSet<TrnsLeavesRequest> TrnsLeavesRequests { get; set; }
        public virtual DbSet<TrnsLoan> TrnsLoans { get; set; }
        public virtual DbSet<TrnsLoanAndAdvancePayment> TrnsLoanAndAdvancePayments { get; set; }
        public virtual DbSet<TrnsLoanAndAdvancePaymentDetail> TrnsLoanAndAdvancePaymentDetails { get; set; }
        public virtual DbSet<TrnsLoanDetail> TrnsLoanDetails { get; set; }
        public virtual DbSet<TrnsLoanInstallmentPlan> TrnsLoanInstallmentPlans { get; set; }
        public virtual DbSet<TrnsLoanMarkupRateDetail> TrnsLoanMarkupRateDetails { get; set; }
        public virtual DbSet<TrnsLoanReceived> TrnsLoanReceiveds { get; set; }
        public virtual DbSet<TrnsLoanRegister> TrnsLoanRegisters { get; set; }
        public virtual DbSet<TrnsLoanRequest> TrnsLoanRequests { get; set; }
        public virtual DbSet<TrnsLstslab> TrnsLstslabs { get; set; }
        public virtual DbSet<TrnsLstslabDetail> TrnsLstslabDetails { get; set; }
        public virtual DbSet<TrnsLstslabPeriod> TrnsLstslabPeriods { get; set; }
        public virtual DbSet<TrnsMarriageAssistanceRequest> TrnsMarriageAssistanceRequests { get; set; }
        public virtual DbSet<TrnsMedical> TrnsMedicals { get; set; }
        public virtual DbSet<TrnsNotificaiotnApprovalSystem> TrnsNotificaiotnApprovalSystems { get; set; }
        public virtual DbSet<TrnsObSalaryAdj> TrnsObSalaryAdjs { get; set; }
        public virtual DbSet<TrnsObarrear> TrnsObarrears { get; set; }
        public virtual DbSet<TrnsObcontribution> TrnsObcontributions { get; set; }
        public virtual DbSet<TrnsObdisbursement> TrnsObdisbursements { get; set; }
        public virtual DbSet<TrnsObgratuity> TrnsObgratuities { get; set; }
        public virtual DbSet<TrnsObjFnyDetail> TrnsObjFnyDetails { get; set; }
        public virtual DbSet<TrnsObjFnyHead> TrnsObjFnyHeads { get; set; }
        public virtual DbSet<TrnsObjFnyHeadTemp> TrnsObjFnyHeadTemps { get; set; }
        public virtual DbSet<TrnsObjFnyProgress> TrnsObjFnyProgresses { get; set; }
        public virtual DbSet<TrnsObleaf> TrnsObleaves { get; set; }
        public virtual DbSet<TrnsObloan> TrnsObloans { get; set; }
        public virtual DbSet<TrnsObprovidentFund> TrnsObprovidentFunds { get; set; }
        public virtual DbSet<TrnsObsalary> TrnsObsalaries { get; set; }
        public virtual DbSet<TrnsObtax> TrnsObtaxes { get; set; }
        public virtual DbSet<TrnsOfferLetter> TrnsOfferLetters { get; set; }
        public virtual DbSet<TrnsOtslab> TrnsOtslabs { get; set; }
        public virtual DbSet<TrnsOtslabDetail> TrnsOtslabDetails { get; set; }
        public virtual DbSet<TrnsOvertime> TrnsOvertimes { get; set; }
        public virtual DbSet<TrnsPartnerAssessmentDetail> TrnsPartnerAssessmentDetails { get; set; }
        public virtual DbSet<TrnsPartnerAssessmentHead> TrnsPartnerAssessmentHeads { get; set; }
        public virtual DbSet<TrnsPartnerBusinessRevenue> TrnsPartnerBusinessRevenues { get; set; }
        public virtual DbSet<TrnsPartnerBusinessRevenueDetail> TrnsPartnerBusinessRevenueDetails { get; set; }
        public virtual DbSet<TrnsPartnerContributionDetail> TrnsPartnerContributionDetails { get; set; }
        public virtual DbSet<TrnsPartnerContributionPool> TrnsPartnerContributionPools { get; set; }
        public virtual DbSet<TrnsPartnerFacilitateTrainingDetail> TrnsPartnerFacilitateTrainingDetails { get; set; }
        public virtual DbSet<TrnsPartnerFacilitateTrainingHead> TrnsPartnerFacilitateTrainingHeads { get; set; }
        public virtual DbSet<TrnsPartnerFeedback360> TrnsPartnerFeedback360s { get; set; }
        public virtual DbSet<TrnsPartnerNetProfit> TrnsPartnerNetProfits { get; set; }
        public virtual DbSet<TrnsPartnerNetProfitDetail> TrnsPartnerNetProfitDetails { get; set; }
        public virtual DbSet<TrnsPartnerPerformanceFinalPosting> TrnsPartnerPerformanceFinalPostings { get; set; }
        public virtual DbSet<TrnsPartnerRevenueAccrual> TrnsPartnerRevenueAccruals { get; set; }
        public virtual DbSet<TrnsPartnerRevenueAccrualDetail> TrnsPartnerRevenueAccrualDetails { get; set; }
        public virtual DbSet<TrnsPartnerUnAllocatedFormsDetail> TrnsPartnerUnAllocatedFormsDetails { get; set; }
        public virtual DbSet<TrnsPartnerUnAllocatedFormsHead> TrnsPartnerUnAllocatedFormsHeads { get; set; }
        public virtual DbSet<TrnsPayeslab> TrnsPayeslabs { get; set; }
        public virtual DbSet<TrnsPayeslabDetail> TrnsPayeslabDetails { get; set; }
        public virtual DbSet<TrnsPeerFeedback360> TrnsPeerFeedback360s { get; set; }
        public virtual DbSet<TrnsPerformanceAppraisal> TrnsPerformanceAppraisals { get; set; }
        public virtual DbSet<TrnsPerformanceAppraisal360> TrnsPerformanceAppraisal360s { get; set; }
        public virtual DbSet<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360Details { get; set; }
        public virtual DbSet<TrnsPerformanceAppraisalDetail> TrnsPerformanceAppraisalDetails { get; set; }
        public virtual DbSet<TrnsPerformanceEvaluationHead> TrnsPerformanceEvaluationHeads { get; set; }
        public virtual DbSet<TrnsPerformanceManagement> TrnsPerformanceManagements { get; set; }
        public virtual DbSet<TrnsPerformancePlan> TrnsPerformancePlans { get; set; }
        public virtual DbSet<TrnsPerformancePlanDetail> TrnsPerformancePlanDetails { get; set; }
        public virtual DbSet<TrnsPerofrmanceEvaluationDetail> TrnsPerofrmanceEvaluationDetails { get; set; }
        public virtual DbSet<TrnsProbationAssesDetail> TrnsProbationAssesDetails { get; set; }
        public virtual DbSet<TrnsProbationAssesHead> TrnsProbationAssesHeads { get; set; }
        public virtual DbSet<TrnsProbationCategorryCycleAttachment> TrnsProbationCategorryCycleAttachments { get; set; }
        public virtual DbSet<TrnsProbationDetail> TrnsProbationDetails { get; set; }
        public virtual DbSet<TrnsProbationHead> TrnsProbationHeads { get; set; }
        public virtual DbSet<TrnsPromotionAdvice> TrnsPromotionAdvices { get; set; }
        public virtual DbSet<TrnsQuarterTaxAdj> TrnsQuarterTaxAdjs { get; set; }
        public virtual DbSet<TrnsQuarterTaxAdjDetail> TrnsQuarterTaxAdjDetails { get; set; }
        public virtual DbSet<TrnsReHireEmployee> TrnsReHireEmployees { get; set; }
        public virtual DbSet<TrnsReHireEmployeeDetail> TrnsReHireEmployeeDetails { get; set; }
        public virtual DbSet<TrnsRegionalHead> TrnsRegionalHeads { get; set; }
        public virtual DbSet<TrnsRegionalHeadDetail> TrnsRegionalHeadDetails { get; set; }
        public virtual DbSet<TrnsRejectedObj> TrnsRejectedObjs { get; set; }
        public virtual DbSet<TrnsResignation> TrnsResignations { get; set; }
        public virtual DbSet<TrnsResonsOfLeaving> TrnsResonsOfLeavings { get; set; }
        public virtual DbSet<TrnsSalaryArear> TrnsSalaryArears { get; set; }
        public virtual DbSet<TrnsSalaryArearDetail> TrnsSalaryArearDetails { get; set; }
        public virtual DbSet<TrnsSalaryChange> TrnsSalaryChanges { get; set; }
        public virtual DbSet<TrnsSalaryClassification> TrnsSalaryClassifications { get; set; }
        public virtual DbSet<TrnsSalaryDisbursement> TrnsSalaryDisbursements { get; set; }
        public virtual DbSet<TrnsSalaryDisbursement1> TrnsSalaryDisbursement1s { get; set; }
        public virtual DbSet<TrnsSalaryProcessRegister> TrnsSalaryProcessRegisters { get; set; }
        public virtual DbSet<TrnsSalaryProcessRegisterDetail> TrnsSalaryProcessRegisterDetails { get; set; }
        public virtual DbSet<TrnsSchoolPensionRequest> TrnsSchoolPensionRequests { get; set; }
        public virtual DbSet<TrnsSchoolPensionRequestDetail> TrnsSchoolPensionRequestDetails { get; set; }
        public virtual DbSet<TrnsScore> TrnsScores { get; set; }
        public virtual DbSet<TrnsSduae> TrnsSduaes { get; set; }
        public virtual DbSet<TrnsShiftsDaysRegister> TrnsShiftsDaysRegisters { get; set; }
        public virtual DbSet<TrnsSingleEntryOtdetail> TrnsSingleEntryOtdetails { get; set; }
        public virtual DbSet<TrnsSingleEntryOtrequest> TrnsSingleEntryOtrequests { get; set; }
        public virtual DbSet<TrnsSpdaysAdj> TrnsSpdaysAdjs { get; set; }
        public virtual DbSet<TrnsTaxAdjustment> TrnsTaxAdjustments { get; set; }
        public virtual DbSet<TrnsTaxAdjustmentDetail> TrnsTaxAdjustmentDetails { get; set; }
        public virtual DbSet<TrnsTempAttendance> TrnsTempAttendances { get; set; }
        public virtual DbSet<TrnsTextileGroupAttendanceReg> TrnsTextileGroupAttendanceRegs { get; set; }
        public virtual DbSet<TrnsTrainingAttendance> TrnsTrainingAttendances { get; set; }
        public virtual DbSet<TrnsTrainingAttendanceAttachment> TrnsTrainingAttendanceAttachments { get; set; }
        public virtual DbSet<TrnsTrainingAttendanceDetail> TrnsTrainingAttendanceDetails { get; set; }
        public virtual DbSet<TrnsTrainingEvaluation> TrnsTrainingEvaluations { get; set; }
        public virtual DbSet<TrnsTrainingEvaluationDetail> TrnsTrainingEvaluationDetails { get; set; }
        public virtual DbSet<TrnsTrainingFeedback> TrnsTrainingFeedbacks { get; set; }
        public virtual DbSet<TrnsTrainingFeedbackDetail> TrnsTrainingFeedbackDetails { get; set; }
        public virtual DbSet<TrnsTrainingPlan> TrnsTrainingPlans { get; set; }
        public virtual DbSet<TrnsTrainingPlanDetail> TrnsTrainingPlanDetails { get; set; }
        public virtual DbSet<TrnsTravelPaymentRequest> TrnsTravelPaymentRequests { get; set; }
        public virtual DbSet<TrnsVacancyApplication> TrnsVacancyApplications { get; set; }
        public virtual DbSet<TrnsVacancyAssessmentStatement> TrnsVacancyAssessmentStatements { get; set; }
        public virtual DbSet<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
        public virtual DbSet<TrnsVacancyStatus> TrnsVacancyStatuses { get; set; }
        public virtual DbSet<TrnsViolation> TrnsViolations { get; set; }
        public virtual DbSet<TrnsVlEntitlement> TrnsVlEntitlements { get; set; }
        public virtual DbSet<TrnsWarningLetter> TrnsWarningLetters { get; set; }
        public virtual DbSet<TrnsWorkInQuarter> TrnsWorkInQuarters { get; set; }
        public virtual DbSet<TrnsleaveEncashment> TrnsleaveEncashments { get; set; }
        public virtual DbSet<VacancyEmailNotification> VacancyEmailNotifications { get; set; }
        public virtual DbSet<ViewApprovalTemplate> ViewApprovalTemplates { get; set; }
        public virtual DbSet<ViewDeptHiearcy> ViewDeptHiearcies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PK-LHR-MME-133;Database=HCMOne;User ID=sa;Password=super;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovalDecisionRegister>(entity =>
            {
                entity.ToTable("ApprovalDecisionRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocHierarchyId).HasColumnName("DocHierarchyID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LineStatusId)
                    .HasMaxLength(150)
                    .HasColumnName("LineStatusID");

                entity.Property(e => e.LineStatusLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("LineStatusLOVType");

                entity.Property(e => e.PendingAtStageId).HasColumnName("PendingAtStageID");

                entity.Property(e => e.Remarks).HasMaxLength(350);

                entity.Property(e => e.StageDescription).HasMaxLength(150);

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.DocHierarchy)
                    .WithMany(p => p.ApprovalDecisionRegisters)
                    .HasForeignKey(d => d.DocHierarchyId)
                    .HasConstraintName("FK_ApprovalDecisionRegister_DocumentTemplate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApprovalDecisionRegisters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_ApprovalDecisionRegister_MstEmployee");
            });

            modelBuilder.Entity<ApprovalDecisionRegisterDetail>(entity =>
            {
                entity.ToTable("ApprovalDecisionRegisterDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionTakenDate).HasColumnType("datetime");

                entity.Property(e => e.Adid).HasColumnName("ADID");

                entity.Property(e => e.ApprovalStatus).HasMaxLength(150);

                entity.Property(e => e.ApprovedInstallment).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ApprovedSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ChangedAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApprovalDecisionRegisterDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_ApprovalDecisionRegisterDetail_MstEmployee");
            });

            modelBuilder.Entity<AttCfg>(entity =>
            {
                entity.ToTable("attCfg");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FlgOnStart).HasColumnName("flgOnStart");
            });

            modelBuilder.Entity<AttDevUser>(entity =>
            {
                entity.HasKey(e => e.DevUsrId);

                entity.ToTable("attDevUsers");

                entity.Property(e => e.DevUsrId).HasColumnName("devUsrId");

                entity.Property(e => e.DevIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("devIP");

                entity.Property(e => e.DeviceId).HasColumnName("deviceId");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empName");

                entity.Property(e => e.Enabled)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("enabled");

                entity.Property(e => e.EnrollNum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("enrollNum");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.ReadDat)
                    .HasColumnType("datetime")
                    .HasColumnName("readDat");

                entity.Property(e => e.UserTemplate)
                    .HasMaxLength(6000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.AttDevUsers)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_attDevUsers_attDevUsers");
            });

            modelBuilder.Entity<AttDevice>(entity =>
            {
                entity.ToTable("attDevices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaudRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CommKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("commKey");

                entity.Property(e => e.CommPort)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("commPort");

                entity.Property(e => e.Dela)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Modal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Port)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timeout)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttScan>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("attScans");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.DeviceDept)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceIp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnrolmentId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatchDt).HasColumnType("datetime");

                entity.Property(e => e.Io)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IO");

                entity.Property(e => e.ScanDt).HasColumnType("datetime");

                entity.Property(e => e.Verify)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttSummary>(entity =>
            {
                entity.ToTable("attSummary");

                entity.Property(e => e.AttSummaryId).HasColumnName("attSummaryID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.PeriodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.AttSummaries)
                    .HasForeignKey(d => d.LeaveId)
                    .HasConstraintName("FK_attSummary_MstLeaveType");

                entity.HasOne(d => d.Overtime)
                    .WithMany(p => p.AttSummaries)
                    .HasForeignKey(d => d.OvertimeId)
                    .HasConstraintName("FK_attSummary_MstOverTime");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.AttSummaries)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_attSummary_attSummary");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.AttSummaries)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_attSummary_CfgPeriodDates");
            });

            modelBuilder.Entity<AttSummaryDetail>(entity =>
            {
                entity.HasKey(e => e.AttSumDetailId);

                entity.ToTable("attSummaryDetail");

                entity.Property(e => e.AttSumDetailId).HasColumnName("attSumDetailId");

                entity.Property(e => e.AdjDays)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("adjDays");

                entity.Property(e => e.AdjHrs)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("adjHrs");

                entity.Property(e => e.AttSummaryId).HasColumnName("attSummaryId");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empCode");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("empName");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.HrsRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SourceId).HasColumnName("sourceId");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sourceType");

                entity.HasOne(d => d.AttSummary)
                    .WithMany(p => p.AttSummaryDetails)
                    .HasForeignKey(d => d.AttSummaryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_attSummaryDetail_attSummary");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.AttSummaryDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_attSummaryDetail_MstEmployee");
            });

            modelBuilder.Entity<AttendanceLog>(entity =>
            {
                entity.ToTable("AttendanceLog");

                entity.Property(e => e.AndroidDocNum).HasMaxLength(100);

                entity.Property(e => e.AttendanceDate).HasMaxLength(200);

                entity.Property(e => e.CheckInLang).HasMaxLength(200);

                entity.Property(e => e.CheckInLat).HasMaxLength(200);

                entity.Property(e => e.CheckInRemarks).HasMaxLength(200);

                entity.Property(e => e.CheckInTime).HasMaxLength(200);

                entity.Property(e => e.CheckOutLang).HasMaxLength(200);

                entity.Property(e => e.CheckOutLat).HasMaxLength(200);

                entity.Property(e => e.CheckOutRemarks).HasMaxLength(200);

                entity.Property(e => e.CheckOutTime).HasMaxLength(200);

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(50)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(50)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.ProjectIn).HasMaxLength(260);

                entity.Property(e => e.ProjectOut).HasMaxLength(260);

                entity.Property(e => e.RejecterDept).HasMaxLength(25);

                entity.Property(e => e.RejecterDesignation).HasMaxLength(25);

                entity.Property(e => e.RejecterName).HasMaxLength(25);

                entity.Property(e => e.RejecterRemarks).HasMaxLength(500);

                entity.Property(e => e.SiteIn).HasMaxLength(260);

                entity.Property(e => e.SiteOut).HasMaxLength(260);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(200);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.AttendanceLogs)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Attendanc__EmpID__2B01DA7A");
            });

            modelBuilder.Entity<CfgAlertManagement>(entity =>
            {
                entity.ToTable("CfgAlertManagement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EBody)
                    .HasMaxLength(500)
                    .HasColumnName("eBody");

                entity.Property(e => e.ESubject)
                    .HasMaxLength(100)
                    .HasColumnName("eSubject");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgMessage).HasColumnName("flgMessage");

                entity.Property(e => e.FrequencyUnit).HasMaxLength(10);

                entity.Property(e => e.FrequencyValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.NextExecutionTime).HasColumnType("datetime");

                entity.Property(e => e.Priority).HasMaxLength(10);

                entity.Property(e => e.PriorityLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("PriorityLOVType");

                entity.Property(e => e.QueryName).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<CfgAlertManagementDepartment>(entity =>
            {
                entity.ToTable("CfgAlertManagementDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amid).HasColumnName("AMID");

                entity.Property(e => e.DeptName).HasMaxLength(100);

                entity.Property(e => e.FlgActive)
                    .HasMaxLength(10)
                    .HasColumnName("flgActive")
                    .IsFixedLength();

                entity.Property(e => e.FlgEmail)
                    .HasMaxLength(10)
                    .HasColumnName("flgEmail")
                    .IsFixedLength();

                entity.Property(e => e.FlgNotification)
                    .HasMaxLength(10)
                    .HasColumnName("flgNotification")
                    .IsFixedLength();

                entity.HasOne(d => d.Am)
                    .WithMany(p => p.CfgAlertManagementDepartments)
                    .HasForeignKey(d => d.Amid)
                    .HasConstraintName("FK_CfgAlertManagementDepartment_CfgAlertManagement");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.CfgAlertManagementDepartments)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_CfgAlertManagementDepartment_MstDepartment");
            });

            modelBuilder.Entity<CfgAlertManagementEmployee>(entity =>
            {
                entity.ToTable("CfgAlertManagementEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amid).HasColumnName("AMID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FlgActive)
                    .HasMaxLength(10)
                    .HasColumnName("flgActive")
                    .IsFixedLength();

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgNotification).HasColumnName("flgNotification");

                entity.HasOne(d => d.Am)
                    .WithMany(p => p.CfgAlertManagementEmployees)
                    .HasForeignKey(d => d.Amid)
                    .HasConstraintName("FK_CfgAlertManagementEmployee_CfgAlertManagement");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.CfgAlertManagementEmployees)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_CfgAlertManagementEmployee_MstEmployee");
            });

            modelBuilder.Entity<CfgAlertManagementGroup>(entity =>
            {
                entity.ToTable("CfgAlertManagementGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amid).HasColumnName("AMID");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgNotification).HasColumnName("flgNotification");

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.HasOne(d => d.Am)
                    .WithMany(p => p.CfgAlertManagementGroups)
                    .HasForeignKey(d => d.Amid)
                    .HasConstraintName("FK_CfgAlertManagementGroup_CfgAlertManagement");

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.CfgAlertManagementGroups)
                    .HasForeignKey(d => d.GroupCode)
                    .HasConstraintName("FK_CfgAlertManagementGroup_MstAlertGroup");
            });

            modelBuilder.Entity<CfgApprovalDecisionRegister>(entity =>
            {
                entity.ToTable("CfgApprovalDecisionRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalTempName).HasMaxLength(150);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.DocHierarchyId).HasColumnName("DocHierarchyID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(150);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LineStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("LineStatusID");

                entity.Property(e => e.LineStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("LineStatusLOVType");

                entity.Property(e => e.PendingAtStageId).HasColumnName("PendingAtStageID");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.StageName).HasMaxLength(100);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<CfgApprovalStage>(entity =>
            {
                entity.ToTable("CfgApprovalStage");

                entity.HasIndex(e => e.StageName, "IX_CfgApprovalStage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StageDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StageName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CfgApprovalStageDetail>(entity =>
            {
                entity.ToTable("CfgApprovalStageDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Asid).HasColumnName("ASID");

                entity.Property(e => e.AuthorizerId)
                    .HasMaxLength(10)
                    .HasColumnName("AuthorizerID");

                entity.Property(e => e.AuthorizerName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FkempId).HasColumnName("FKEmpID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.As)
                    .WithMany(p => p.CfgApprovalStageDetails)
                    .HasForeignKey(d => d.Asid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CfgApprovalStageDetail_CfgApprovalStage");
            });

            modelBuilder.Entity<CfgApprovalTemplate>(entity =>
            {
                entity.ToTable("CfgApprovalTemplate");

                entity.HasIndex(e => e.Name, "IX_CfgApprovalTemplate")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<CfgApprovalTemplateDocument>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Atid).HasColumnName("ATID");

                entity.Property(e => e.FlgAdvance).HasColumnName("flgAdvance");

                entity.Property(e => e.FlgAppraisal).HasColumnName("flgAppraisal");

                entity.Property(e => e.FlgCandidate).HasColumnName("flgCandidate");

                entity.Property(e => e.FlgEmpHiring).HasColumnName("flgEmpHiring");

                entity.Property(e => e.FlgEmpLeave).HasColumnName("flgEmpLeave");

                entity.Property(e => e.FlgEmpTransfer).HasColumnName("flgEmpTransfer");

                entity.Property(e => e.FlgJobRequisition).HasColumnName("flgJobRequisition");

                entity.Property(e => e.FlgLoan).HasColumnName("flgLoan");

                entity.Property(e => e.FlgResignation).HasColumnName("flgResignation");

                entity.HasOne(d => d.At)
                    .WithMany(p => p.CfgApprovalTemplateDocuments)
                    .HasForeignKey(d => d.Atid)
                    .HasConstraintName("FK_CfgApprovalTemplateDocuments_CfgApprovalTemplate");
            });

            modelBuilder.Entity<CfgApprovalTemplateOriginator>(entity =>
            {
                entity.ToTable("CfgApprovalTemplateOriginator");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Atid).HasColumnName("ATID");

                entity.HasOne(d => d.At)
                    .WithMany(p => p.CfgApprovalTemplateOriginators)
                    .HasForeignKey(d => d.Atid)
                    .HasConstraintName("FK_CfgApprovalTemplateOriginator_CfgApprovalTemplate");
            });

            modelBuilder.Entity<CfgApprovalTemplateStage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Atid).HasColumnName("ATID");

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.StageName).HasMaxLength(150);

                entity.HasOne(d => d.At)
                    .WithMany(p => p.CfgApprovalTemplateStages)
                    .HasForeignKey(d => d.Atid)
                    .HasConstraintName("FK_CfgApprovalTemplateStages_CfgApprovalTemplate");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.CfgApprovalTemplateStages)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_CfgApprovalTemplateStages_CfgApprovalStage");
            });

            modelBuilder.Entity<CfgAttandanceSetting>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.MachineType).HasMaxLength(50);

                entity.Property(e => e.TimeType).HasMaxLength(50);

                entity.Property(e => e.TimeValue).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<CfgConnectionSetUp>(entity =>
            {
                entity.ToTable("cfgConnectionSetUp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CfgDateIn)
                    .HasMaxLength(50)
                    .HasColumnName("cfgDateIn");

                entity.Property(e => e.CfgDateOut)
                    .HasMaxLength(50)
                    .HasColumnName("cfgDateOut");

                entity.Property(e => e.CfgEmpId)
                    .HasMaxLength(50)
                    .HasColumnName("cfgEmpID");

                entity.Property(e => e.CfgInOut)
                    .HasMaxLength(50)
                    .HasColumnName("cfgIn_Out");

                entity.Property(e => e.CfgTimeIn)
                    .HasMaxLength(50)
                    .HasColumnName("cfgTimeIn");

                entity.Property(e => e.CfgTimeOut)
                    .HasMaxLength(50)
                    .HasColumnName("cfgTimeOut");

                entity.Property(e => e.Dbname)
                    .HasMaxLength(50)
                    .HasColumnName("DBName");

                entity.Property(e => e.FileLocation).HasMaxLength(250);

                entity.Property(e => e.FlgAccess).HasColumnName("flgAccess");

                entity.Property(e => e.FlgSqlServer).HasColumnName("flgSqlServer");

                entity.Property(e => e.MachineType).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.ServerName).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<CfgDbempRight>(entity =>
            {
                entity.ToTable("CfgDBEmpRights");

                entity.Property(e => e.Dbid).HasColumnName("DBId");

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CfgDbhostOffice>(entity =>
            {
                entity.HasKey(e => e.HostOfficeId);

                entity.ToTable("cfgDBHostOffice");

                entity.Property(e => e.HostOfficeId).HasColumnName("HostOfficeID");

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HostOfficeName).HasMaxLength(50);
            });

            modelBuilder.Entity<CfgDbsetting>(entity =>
            {
                entity.ToTable("CfgDBSettings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DatabaseName).HasMaxLength(50);

                entity.Property(e => e.DbdisplayName)
                    .HasMaxLength(50)
                    .HasColumnName("DBDisplayName");

                entity.Property(e => e.Dbpassword)
                    .HasMaxLength(60)
                    .HasColumnName("DBPassword");

                entity.Property(e => e.DbuserName)
                    .HasMaxLength(20)
                    .HasColumnName("DBUserName");

                entity.Property(e => e.ServerName).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<CfgDocumentStageRegister>(entity =>
            {
                entity.ToTable("CfgDocumentStageRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FlgCurrentStage).HasColumnName("flgCurrentStage");

                entity.Property(e => e.StageDecision).HasMaxLength(2);

                entity.HasOne(d => d.ApprovalTempNavigation)
                    .WithMany(p => p.CfgDocumentStageRegisters)
                    .HasForeignKey(d => d.ApprovalTemp)
                    .HasConstraintName("FK_CfgDocumentStageRegister_CfgApprovalTemplate");

                entity.HasOne(d => d.TempStagesNavigation)
                    .WithMany(p => p.CfgDocumentStageRegisters)
                    .HasForeignKey(d => d.TempStages)
                    .HasConstraintName("FK_CfgDocumentStageRegister_CfgApprovalStage");
            });

            modelBuilder.Entity<CfgDocumentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocName).HasMaxLength(50);
            });

            modelBuilder.Entity<CfgEmailSetting>(entity =>
            {
                entity.ToTable("cfgEmailSettings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("date")
                    .HasColumnName("dateUpdated");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FromAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fromAddress");

                entity.Property(e => e.FromPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fromPassword");

                entity.Property(e => e.Sae).HasColumnName("SAE");

                entity.Property(e => e.SmtpHost)
                    .HasMaxLength(50)
                    .HasColumnName("smtpHost");

                entity.Property(e => e.SmtpPort)
                    .HasMaxLength(5)
                    .HasColumnName("smtpPort");

                entity.Property(e => e.SmtpTimeout)
                    .HasMaxLength(50)
                    .HasColumnName("smtpTimeout");

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .HasColumnName("subject");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updatedBy");
            });

            modelBuilder.Entity<CfgEmpCodeGeneration>(entity =>
            {
                entity.ToTable("cfgEmpCodeGeneration");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(250);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CfgEmployeeInformationDettail>(entity =>
            {
                entity.ToTable("CfgEmployeeInformationDettail");

                entity.Property(e => e.AdvanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ApplicableAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<CfgEmployeeShift>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("cfgEmployeeShifts");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.ShiftCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<CfgFormula>(entity =>
            {
                entity.ToTable("cfgFormula");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasicFactor).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Formula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WithBasic).HasColumnName("withBasic");
            });

            modelBuilder.Entity<CfgFormulaElement>(entity =>
            {
                entity.ToTable("cfgFormulaElements");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Factor).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Fetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FEType");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormulaId).HasColumnName("formulaId");

                entity.Property(e => e.RowType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.CfgFormulaElements)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_cfgFormulaElements_MstElements");

                entity.HasOne(d => d.Formula)
                    .WithMany(p => p.CfgFormulaElements)
                    .HasForeignKey(d => d.FormulaId)
                    .HasConstraintName("FK_cfgFormulaElements_cfgFormula");
            });

            modelBuilder.Entity<CfgHostOfficeDocType>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("CfgHostOfficeDocType");

                entity.Property(e => e.DocType).HasMaxLength(50);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CfgIncomeTaxMarginalSetup>(entity =>
            {
                entity.ToTable("CfgIncomeTaxMarginalSetup");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MaxAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<CfgLeaveMatrix>(entity =>
            {
                entity.ToTable("CfgLeaveMatrix");

                entity.Property(e => e.Fkelement).HasColumnName("FKElement");

                entity.Property(e => e.FkleaveType).HasColumnName("FKLeaveType");

                entity.Property(e => e.FlgStatus).HasColumnName("flgStatus");

                entity.HasOne(d => d.FkelementNavigation)
                    .WithMany(p => p.CfgLeaveMatrices)
                    .HasForeignKey(d => d.Fkelement)
                    .HasConstraintName("FK_CfgLeaveMatrix_MstElements");

                entity.HasOne(d => d.FkleaveTypeNavigation)
                    .WithMany(p => p.CfgLeaveMatrices)
                    .HasForeignKey(d => d.FkleaveType)
                    .HasConstraintName("FK_CfgLeaveMatrix_MstLeaveType");
            });

            modelBuilder.Entity<CfgPayrollBasicInitialization>(entity =>
            {
                entity.ToTable("CfgPayrollBasicInitialization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BasicPercentage).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.DailyCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeMaxContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerMaxContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EoBiEmployeeValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EoBiEmployerValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Eobi)
                    .HasMaxLength(10)
                    .HasColumnName("EOBI")
                    .IsFixedLength();

                entity.Property(e => e.FlgA1integration).HasColumnName("flgA1Integration");

                entity.Property(e => e.FlgAbsent).HasColumnName("flgAbsent");

                entity.Property(e => e.FlgAdjustedAttendanceProcessing).HasColumnName("flgAdjustedAttendanceProcessing");

                entity.Property(e => e.FlgAfricaRegion).HasColumnName("flgAfricaRegion");

                entity.Property(e => e.FlgArabic).HasColumnName("flgArabic");

                entity.Property(e => e.FlgAttAllowance).HasColumnName("flgAttAllowance");

                entity.Property(e => e.FlgAttendanceSystem).HasColumnName("flgAttendanceSystem");

                entity.Property(e => e.FlgAutoNumber).HasColumnName("flgAutoNumber");

                entity.Property(e => e.FlgBasicCalculation).HasColumnName("flgBasicCalculation");

                entity.Property(e => e.FlgBonusOneRule).HasColumnName("flgBonusOneRule");

                entity.Property(e => e.FlgBranches).HasColumnName("flgBranches");

                entity.Property(e => e.FlgCostCenterGl).HasColumnName("flgCostCenterGL");

                entity.Property(e => e.FlgEmployeeCodeSeries).HasColumnName("flgEmployeeCodeSeries");

                entity.Property(e => e.FlgEmployeeFilter).HasColumnName("flgEmployeeFilter");

                entity.Property(e => e.FlgFormulaEarnings).HasColumnName("flgFormulaEarnings");

                entity.Property(e => e.FlgHiredGrossTaxable).HasColumnName("flgHiredGrossTaxable");

                entity.Property(e => e.FlgIncrementTwoRule).HasColumnName("flgIncrementTwoRule");

                entity.Property(e => e.FlgJecurrency).HasColumnName("flgJECurrency");

                entity.Property(e => e.FlgJelocationWise).HasColumnName("flgJELocationWise");

                entity.Property(e => e.FlgLateInEarlyOutLeaveRules).HasColumnName("flgLateInEarlyOutLeaveRules");

                entity.Property(e => e.FlgLeaveCalendar).HasColumnName("flgLeaveCalendar");

                entity.Property(e => e.FlgLeaveGradeWise).HasColumnName("flgLeaveGradeWise");

                entity.Property(e => e.FlgLoanBackDate).HasColumnName("flgLoanBackDate");

                entity.Property(e => e.FlgLoanGrossRule).HasColumnName("flgLoanGrossRule");

                entity.Property(e => e.FlgLoanInstallmentFix).HasColumnName("flgLoanInstallmentFix");

                entity.Property(e => e.FlgMedicalRule).HasColumnName("flgMedicalRule");

                entity.Property(e => e.FlgMultipleDimension).HasColumnName("flgMultipleDimension");

                entity.Property(e => e.FlgOtcapCompany).HasColumnName("flgOTCapCompany");

                entity.Property(e => e.FlgPayrollWithSap).HasColumnName("flgPayrollWithSap");

                entity.Property(e => e.FlgPerformanceCalculation).HasColumnName("flgPerformanceCalculation");

                entity.Property(e => e.FlgProcessingOnAttendance).HasColumnName("flgProcessingOnAttendance");

                entity.Property(e => e.FlgProject).HasColumnName("flgProject");

                entity.Property(e => e.FlgPublicSectorGratuity).HasColumnName("flgPublicSectorGratuity");

                entity.Property(e => e.FlgRetailRules1).HasColumnName("flgRetailRules1");

                entity.Property(e => e.FlgSimpleIntegration).HasColumnName("flgSimpleIntegration");

                entity.Property(e => e.FlgSlabDeductions).HasColumnName("flgSlabDeductions");

                entity.Property(e => e.FlgSpecialGratuity).HasColumnName("flgSpecialGratuity");

                entity.Property(e => e.FlgSpecialLeaveEncashment).HasColumnName("flgSpecialLeaveEncashment");

                entity.Property(e => e.FlgSsl).HasColumnName("flgSSL");

                entity.Property(e => e.FlgTaxSetup).HasColumnName("flgTaxSetup");

                entity.Property(e => e.FlgUnitFeature).HasColumnName("flgUnitFeature");

                entity.Property(e => e.Leelement).HasColumnName("LEElement");

                entity.Property(e => e.MedicalPercent).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MontlyCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerformancePercentage).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Sapb1integration).HasColumnName("SAPB1Integration");

                entity.Property(e => e.SboPwd).HasMaxLength(50);

                entity.Property(e => e.SboUid)
                    .HasMaxLength(50)
                    .HasColumnName("SboUID");

                entity.Property(e => e.Ssbasis)
                    .HasMaxLength(10)
                    .HasColumnName("SSBasis");

                entity.Property(e => e.SsbasisLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("SSBasisLOVType");

                entity.Property(e => e.Sscompany).HasColumnName("SSCompany");

                entity.Property(e => e.SsmaxContribution)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("SSMaxContribution");

                entity.Property(e => e.SsnoOfEmployee).HasColumnName("SSNoOfEmployee");

                entity.Property(e => e.Ssvalue)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("SSValue");

                entity.Property(e => e.WorkingHours).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<CfgPayrollDefination>(entity =>
            {
                entity.ToTable("CfgPayrollDefination");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FirstPeriodEndDt).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgIsDefault).HasColumnName("flgIsDefault");

                entity.Property(e => e.FlgOffDaysExcludedFromSalaryPeriod).HasColumnName("flgOffDaysExcludedFromSalaryPeriod");

                entity.Property(e => e.FlgOt).HasColumnName("flgOT");

                entity.Property(e => e.FlgPmbankTransfer).HasColumnName("flgPMBankTransfer");

                entity.Property(e => e.FlgPmcash).HasColumnName("flgPMCash");

                entity.Property(e => e.FlgPmcheque).HasColumnName("flgPMCheque");

                entity.Property(e => e.FlgTax).HasColumnName("flgTax");

                entity.Property(e => e.Gltype)
                    .HasMaxLength(10)
                    .HasColumnName("GLType");

                entity.Property(e => e.GratuityId).HasColumnName("GratuityID");

                entity.Property(e => e.Leelemen).HasColumnName("LEElemen");

                entity.Property(e => e.Otvalue).HasColumnName("OTValue");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PayrollType).HasMaxLength(10);

                entity.Property(e => e.PayrollTypeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("PayrollTypeLOVType");

                entity.Property(e => e.PayrollWiseSortOrder).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.WorkDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkHours)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Gratuity)
                    .WithMany(p => p.CfgPayrollDefinations)
                    .HasForeignKey(d => d.GratuityId)
                    .HasConstraintName("FK_CfgPayrollDefination_MstGratuity");
            });

            modelBuilder.Entity<CfgPayrollShift>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.CfgPayrollShifts)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_CfgPayrollShifts_CfgPayrollDefination");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.CfgPayrollShifts)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_CfgPayrollShifts_MstShifts");
            });

            modelBuilder.Entity<CfgPerformancePeriod>(entity =>
            {
                entity.ToTable("CfgPerformancePeriod");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<CfgPerformancePeriodDetail>(entity =>
            {
                entity.ToTable("CfgPerformancePeriodDetail");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PlanDate).HasColumnType("datetime");

                entity.Property(e => e.Ppcid).HasColumnName("PPCID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.PlanNoNavigation)
                    .WithMany(p => p.CfgPerformancePeriodDetails)
                    .HasForeignKey(d => d.PlanNo)
                    .HasConstraintName("FK_CfgPerformancePeriodDetail_TrnsPerformancePlan");

                entity.HasOne(d => d.Ppc)
                    .WithMany(p => p.CfgPerformancePeriodDetails)
                    .HasForeignKey(d => d.Ppcid)
                    .HasConstraintName("FK_CfgPerformancePeriodDetail_CfgPerformancePeriod");
            });

            modelBuilder.Entity<CfgPeriodDate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FkcalId).HasColumnName("FKCalID");

                entity.Property(e => e.FlgLocked).HasColumnName("flgLocked");

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.FlgVisible).HasColumnName("flgVisible");

                entity.Property(e => e.PeriodControlLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("PeriodControlLOVType");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.CfgPeriodDates)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_CfgPeriodDates_CfgPayrollDefination");
            });

            modelBuilder.Entity<CfgReportViewer>(entity =>
            {
                entity.ToTable("CfgReportViewer");

                entity.Property(e => e.WebReportServerUrl)
                    .HasMaxLength(250)
                    .HasColumnName("WebReportServerURL");
            });

            modelBuilder.Entity<CfgSeries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.SeriesName).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<CfgTaxDetail>(entity =>
            {
                entity.ToTable("CfgTaxDetail");

                entity.Property(e => e.AdditionalDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FixTerm).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TaxCode).HasMaxLength(20);

                entity.Property(e => e.TaxValue).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.CfgTaxDetails)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_CfgTaxDetail_CfgTaxSetup");
            });

            modelBuilder.Entity<CfgTaxSetup>(entity =>
            {
                entity.ToTable("CfgTaxSetup");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountOnTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MaxSalaryDisc).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinTaxSalaryF).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.SalaryYearNavigation)
                    .WithMany(p => p.CfgTaxSetups)
                    .HasForeignKey(d => d.SalaryYear)
                    .HasConstraintName("FK_CfgTaxSetup_MstCalendar");
            });

            modelBuilder.Entity<CnfHistory>(entity =>
            {
                entity.ToTable("CnfHistory");

                entity.Property(e => e.Col1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Col_1");

                entity.Property(e => e.Col2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Col_2");

                entity.Property(e => e.Col3)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Col_3");

                entity.Property(e => e.Col4)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Col_4");

                entity.Property(e => e.Col5)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Col_5");
            });

            modelBuilder.Entity<Cnotifiy>(entity =>
            {
                entity.ToTable("CNotifiy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<CompetencyLevelSetup>(entity =>
            {
                entity.ToTable("CompetencyLevelSetup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetencyLevelCode).HasMaxLength(50);

                entity.Property(e => e.CompetencyLevelName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.ToTable("DocumentTemplate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.DocDesc).HasMaxLength(150);

                entity.Property(e => e.FlgFollowHierarchy).HasColumnName("flg_FollowHierarchy");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DocumentTemplateDetail>(entity =>
            {
                entity.ToTable("DocumentTemplateDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentHierarchyId).HasColumnName("DocumentHierarchyID");

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.HasOne(d => d.DocumentHierarchy)
                    .WithMany(p => p.DocumentTemplateDetails)
                    .HasForeignKey(d => d.DocumentHierarchyId)
                    .HasConstraintName("FK_DocumentTemplateDetail_DocumentTemplate");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.DocumentTemplateDetails)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_DocumentTemplateDetail_MstStages");
            });

            modelBuilder.Entity<DynamicApprovalHierarchy>(entity =>
            {
                entity.ToTable("DynamicApprovalHierarchy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(80);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MovingTo).HasMaxLength(20);

                entity.Property(e => e.RegionalHeadId).HasColumnName("RegionalHeadID");

                entity.Property(e => e.RegionalHeadName).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<EmailQueue>(entity =>
            {
                entity.ToTable("EmailQueue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentFileName).IsUnicode(false);

                entity.Property(e => e.AttachmentFilePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bcc).IsUnicode(false);

                entity.Property(e => e.Cc)
                    .IsUnicode(false)
                    .HasColumnName("CC");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DontSendBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.FromEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyTo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyToName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SentOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ToEmail).IsUnicode(false);

                entity.Property(e => e.ToName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.EmailQueues)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK_EmailQueue_EmailTemplates");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BccEmails)
                    .IsUnicode(false)
                    .HasColumnName("BCcEmails");

                entity.Property(e => e.Ccemails)
                    .IsUnicode(false)
                    .HasColumnName("CCEmails");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.NotificationDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subject)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ToEmails).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAssetAssign>(entity =>
            {
                entity.ToTable("EmployeeAssetAssign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateRecovered).HasColumnType("datetime");

                entity.Property(e => e.EmployeeRecoverId).HasColumnName("EmployeeRecoverID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.EmployeeAssetAssigns)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_EmployeeAssetAssign_MstEmployee");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.EmployeeAssetAssigns)
                    .HasForeignKey(d => d.EmployeeCode)
                    .HasConstraintName("FK_EmployeeAssetAssign_EmployeeAssetAssign");
            });

            modelBuilder.Entity<EmployeeAssetAssignment>(entity =>
            {
                entity.ToTable("EmployeeAssetAssignment");

                entity.Property(e => e.AssetClass).HasMaxLength(255);

                entity.Property(e => e.AssetGroupId).HasMaxLength(50);

                entity.Property(e => e.AssetId).HasMaxLength(50);

                entity.Property(e => e.AssignDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateRecovered).HasColumnType("date");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmployeeRecoverId).HasColumnName("EmployeeRecoverID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeDetail");

                entity.Property(e => e.Branch).HasMaxLength(300);

                entity.Property(e => e.Department).HasMaxLength(500);

                entity.Property(e => e.Designation).HasMaxLength(300);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobTitle).HasMaxLength(30);

                entity.Property(e => e.Location).HasMaxLength(300);
            });

            modelBuilder.Entity<LgAdvance>(entity =>
            {
                entity.ToTable("LgAdvance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgArrear>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgBonu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgBranch>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCalender>(entity =>
            {
                entity.ToTable("LgCalender");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCandidate>(entity =>
            {
                entity.ToTable("LgCandidate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(50);

                entity.Property(e => e.OldValue).HasMaxLength(50);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCertification>(entity =>
            {
                entity.ToTable("LgCertification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCompany>(entity =>
            {
                entity.ToTable("LgCompany");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCompetancy>(entity =>
            {
                entity.ToTable("LgCompetancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgCompetancyGroup>(entity =>
            {
                entity.ToTable("LgCompetancyGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgDepartment>(entity =>
            {
                entity.ToTable("LgDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.NewValue).HasMaxLength(50);

                entity.Property(e => e.OldValue).HasMaxLength(50);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgDesignation>(entity =>
            {
                entity.ToTable("LgDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgExpense>(entity =>
            {
                entity.ToTable("LgExpense");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgGratuity>(entity =>
            {
                entity.ToTable("LgGratuity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgInstitute>(entity =>
            {
                entity.ToTable("LgInstitute");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgJobDesignation>(entity =>
            {
                entity.ToTable("LgJobDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgJobTitle>(entity =>
            {
                entity.ToTable("LgJobTitle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgLeaveDeduction>(entity =>
            {
                entity.ToTable("LgLeaveDeduction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgLeaveType>(entity =>
            {
                entity.ToTable("LgLeaveType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgLoan>(entity =>
            {
                entity.ToTable("LgLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgLocation>(entity =>
            {
                entity.ToTable("LgLocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgMemberShip>(entity =>
            {
                entity.ToTable("LgMemberShip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgOccupationType>(entity =>
            {
                entity.ToTable("LgOccupationType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgOverTime>(entity =>
            {
                entity.ToTable("LgOverTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgPosition>(entity =>
            {
                entity.ToTable("LgPosition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgQualification>(entity =>
            {
                entity.ToTable("LgQualification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgRecognition>(entity =>
            {
                entity.ToTable("LgRecognition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgRelation>(entity =>
            {
                entity.ToTable("LgRelation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgRetroElementSet>(entity =>
            {
                entity.ToTable("LgRetroElementSet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgRole>(entity =>
            {
                entity.ToTable("LgRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgShift>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgSkill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgTeam>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgTrnsAdvance>(entity =>
            {
                entity.ToTable("LgTrnsAdvance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Designation).HasMaxLength(30);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgPaid).HasColumnName("flgPaid");

                entity.Property(e => e.FlgStop).HasColumnName("flgStop");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName).HasMaxLength(100);

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.OriginatorId).HasColumnName("OriginatorID");

                entity.Property(e => e.OriginatorName).HasMaxLength(100);

                entity.Property(e => e.RemainingAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransId).HasColumnName("TransID");

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<LgTrnsLoan>(entity =>
            {
                entity.ToTable("LgTrnsLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName).HasMaxLength(100);

                entity.Property(e => e.MarkUpRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfInstallments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.OriginatorId).HasColumnName("OriginatorID");

                entity.Property(e => e.OriginatorName).HasMaxLength(100);

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransId).HasColumnName("TransID");

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<LgTrnsLoanDetail>(entity =>
            {
                entity.ToTable("LgTrnsLoanDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ApprovedInstallment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgStopRecovery).HasColumnName("flgStopRecovery");

                entity.Property(e => e.FlgVoid).HasColumnName("flgVoid");

                entity.Property(e => e.InsertionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("insertionDate");

                entity.Property(e => e.Installments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LdetailId).HasColumnName("LDetailID");

                entity.Property(e => e.LnAid).HasColumnName("LnAID");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.ReceivedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RecoveredAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<LgUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(100);

                entity.Property(e => e.OldValue).HasMaxLength(100);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LgVacancyType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.LineTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.NewValue).HasMaxLength(250);

                entity.Property(e => e.OldValue).HasMaxLength(250);

                entity.Property(e => e.Userid).HasMaxLength(10);
            });

            modelBuilder.Entity<LogDisbursment>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("LogDisbursment");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.Attachement).HasMaxLength(500);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EntrySource).HasMaxLength(50);

                entity.Property(e => e.EntryType).HasMaxLength(50);

                entity.Property(e => e.LogStatus).HasMaxLength(50);

                entity.Property(e => e.OpdocEntry).HasColumnName("OPDocEntry");

                entity.Property(e => e.Opseries).HasColumnName("OPSeries");

                entity.Property(e => e.PaidLocation).HasMaxLength(500);

                entity.Property(e => e.PayrollName).HasMaxLength(50);

                entity.Property(e => e.PeriodName).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<LogEmployeeElement>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("LogEmployeeElement");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<LogEmployeeElementDetail>(entity =>
            {
                entity.ToTable("LogEmployeeElementDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ElementType).HasMaxLength(30);

                entity.Property(e => e.EmpContr).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(200)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.EmplrContr).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgModified).HasColumnName("flgModified");

                entity.Property(e => e.FlgOneTimeConsumed).HasColumnName("flgOneTimeConsumed");

                entity.Property(e => e.FlgPayroll).HasColumnName("flgPayroll");

                entity.Property(e => e.FlgRetro).HasColumnName("flgRetro");

                entity.Property(e => e.FlgStandard).HasColumnName("flgStandard");

                entity.Property(e => e.FlgTaxable).HasColumnName("flgTaxable");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.RetroAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(30);
            });

            modelBuilder.Entity<LogTaxDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .HasName("PK_lgTaxDetails");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.AlreadyProcessedIncome).HasMaxLength(100);

                entity.Property(e => e.BasicSalary).HasMaxLength(100);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(200);

                entity.Property(e => e.ExpectedTaxAmount).HasMaxLength(100);

                entity.Property(e => e.ExpectedTaxAmountI).HasMaxLength(100);

                entity.Property(e => e.ExpectedYearlySalary).HasMaxLength(100);

                entity.Property(e => e.ExpectedYearlySalaryI).HasMaxLength(100);

                entity.Property(e => e.GrossSalary).HasMaxLength(100);

                entity.Property(e => e.IncentiveAmount).HasMaxLength(100);

                entity.Property(e => e.IncentiveTax).HasMaxLength(100);

                entity.Property(e => e.LogType).HasMaxLength(100);

                entity.Property(e => e.Obsalary)
                    .HasMaxLength(100)
                    .HasColumnName("OBSalary");

                entity.Property(e => e.Obtax)
                    .HasMaxLength(100)
                    .HasColumnName("OBTax");

                entity.Property(e => e.PeriodName).HasMaxLength(100);

                entity.Property(e => e.ProjectedIncome).HasMaxLength(100);

                entity.Property(e => e.SalaryOnlyTax).HasMaxLength(100);

                entity.Property(e => e.SlabCode).HasMaxLength(100);

                entity.Property(e => e.SlabCodeI).HasMaxLength(100);

                entity.Property(e => e.SlabFix).HasMaxLength(100);

                entity.Property(e => e.SlabFixI).HasMaxLength(100);

                entity.Property(e => e.SlabMax).HasMaxLength(100);

                entity.Property(e => e.SlabMaxI).HasMaxLength(100);

                entity.Property(e => e.SlabMin).HasMaxLength(100);

                entity.Property(e => e.SlabMinI).HasMaxLength(100);

                entity.Property(e => e.SlabPer).HasMaxLength(100);

                entity.Property(e => e.SlabPerI).HasMaxLength(100);

                entity.Property(e => e.TaxAdjustmentMonthly).HasMaxLength(100);

                entity.Property(e => e.TaxAdjustmentYearly).HasMaxLength(100);

                entity.Property(e => e.TaxableOt)
                    .HasMaxLength(100)
                    .HasColumnName("TaxableOT");

                entity.Property(e => e.TaxableSalary).HasMaxLength(100);

                entity.Property(e => e.TaxableWop)
                    .HasMaxLength(100)
                    .HasColumnName("TaxableWOP");

                entity.Property(e => e.TotalTaxValue).HasMaxLength(100);
            });

            modelBuilder.Entity<MenuDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anthorization)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuHead>(entity =>
            {
                entity.ToTable("MenuHead");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Navigation).IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SortOrder).HasColumnName("sortOrder");
            });

            modelBuilder.Entity<MenuHead1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MenuHead$");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<MstAdvance>(entity =>
            {
                entity.ToTable("MstAdvance");

                entity.Property(e => e.AllowanceId).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DedElementId).HasColumnName("DedElementID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EarElementId).HasColumnName("EarElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.FlgPettyCash).HasColumnName("flgPettyCash");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UserId).HasMaxLength(250);
            });

            modelBuilder.Entity<MstAirTicketConfig>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstAirTicketConfig");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstAirTicketGroup>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstAirTicketGroup");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstAlertGroup>(entity =>
            {
                entity.ToTable("MstAlertGroup");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GroupCode).HasMaxLength(100);

                entity.Property(e => e.GroupName).HasMaxLength(150);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAlertGroupDetail>(entity =>
            {
                entity.ToTable("MstAlertGroupDetail");

                entity.Property(e => e.AlertGroupId).HasColumnName("AlertGroupID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AlertGroup)
                    .WithMany(p => p.MstAlertGroupDetails)
                    .HasForeignKey(d => d.AlertGroupId)
                    .HasConstraintName("FK_MstAlertGroupDetail_MstAlertGroupDetail");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstAlertGroupDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstAlertGroupDetail_MstEmployee");
            });

            modelBuilder.Entity<MstAppraisal>(entity =>
            {
                entity.ToTable("MstAppraisal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryA)
                    .HasMaxLength(50)
                    .HasColumnName("Category_A")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CategoryB)
                    .HasMaxLength(50)
                    .HasColumnName("Category_B")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CategoryC)
                    .HasMaxLength(50)
                    .HasColumnName("Category_C")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CategoryD)
                    .HasMaxLength(50)
                    .HasColumnName("Category_D")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(50)
                    .HasColumnName("createdby");

                entity.Property(e => e.IncrementPercent)
                    .HasMaxLength(50)
                    .HasColumnName("incrementPercent");

                entity.Property(e => e.TenC)
                    .HasMaxLength(50)
                    .HasColumnName("tenC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updatedDate");

                entity.Property(e => e.WppfAmount)
                    .HasMaxLength(50)
                    .HasColumnName("wppfAmount");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<MstAppraisalGrade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("grade");

                entity.Property(e => e.Max)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("max");

                entity.Property(e => e.Min)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("min");

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<MstAppraisalLog>(entity =>
            {
                entity.ToTable("MstAppraisalLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate");

                entity.Property(e => e.DeparmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("deparmentName");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.FiscalYear).HasColumnName("fiscalYear");

                entity.Property(e => e.FlgAppraisalDone).HasColumnName("flgAppraisalDone");
            });

            modelBuilder.Entity<MstAppraisalTerm>(entity =>
            {
                entity.HasKey(e => e.TermId);

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.TermDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("termDesc");

                entity.Property(e => e.TermNumber).HasColumnName("termNumber");

                entity.Property(e => e.YearId).HasColumnName("yearId");
            });

            modelBuilder.Entity<MstArrear>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstAssestment>(entity =>
            {
                entity.ToTable("MstAssestment");

                entity.HasIndex(e => e.Code, "IX_MstAssestment")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assestment).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstAssestmentCriterion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssestmentId).HasColumnName("AssestmentID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.Criteria).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Marks)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.MinMarks)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Assestment)
                    .WithMany(p => p.MstAssestmentCriteria)
                    .HasForeignKey(d => d.AssestmentId)
                    .HasConstraintName("FK_MstAssestmentCriteria_MstAssestment");
            });

            modelBuilder.Entity<MstAssetCategory>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("MstAssetCategory");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAssignRole>(entity =>
            {
                entity.ToTable("MstAssignRole");

                entity.Property(e => e.AuthorizationType).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<MstAttachment>(entity =>
            {
                entity.ToTable("MstAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAttachment1>(entity =>
            {
                entity.ToTable("MstAttachments");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Path1Link).HasMaxLength(500);

                entity.Property(e => e.Path2Link).HasMaxLength(500);

                entity.Property(e => e.Path3Link).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAttendanceAllowance>(entity =>
            {
                entity.ToTable("MstAttendanceAllowance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElementType).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LeaveType).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<MstAttendanceAutoSaveConfiguration>(entity =>
            {
                entity.ToTable("MstAttendanceAutoSaveConfiguration");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAttendanceRule>(entity =>
            {
                entity.ToTable("MstAttendanceRule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefaultLeaveType).HasMaxLength(50);

                entity.Property(e => e.FlgDeductGpAfterStartTime).HasColumnName("flgDeductGpAfterStartTime");

                entity.Property(e => e.FlgDeductGpAfterTimeEnd).HasColumnName("flgDeductGpAfterTimeEnd");

                entity.Property(e => e.FlgDeductGpBeforeStartTime).HasColumnName("flgDeductGpBeforeStartTime");

                entity.Property(e => e.FlgDeductGpBeforeTimeEnd).HasColumnName("flgDeductGpBeforeTimeEnd");

                entity.Property(e => e.FlgEarlyInOt).HasColumnName("FlgEarlyInOT");

                entity.Property(e => e.FlgMissingTimePenalty).HasColumnName("flgMissingTimePenalty");

                entity.Property(e => e.FlgSandwichLeaves).HasColumnName("flgSandwichLeaves");

                entity.Property(e => e.FlgSandwichLeavesDoubleSide).HasColumnName("flgSandwichLeavesDoubleSide");

                entity.Property(e => e.FlgSandwichLeavesSingleSide).HasColumnName("flgSandwichLeavesSingleSide");

                entity.Property(e => e.FlgTimeBaseDeductionRules).HasColumnName("flgTimeBaseDeductionRules");

                entity.Property(e => e.FlgWopoverFlow).HasColumnName("FlgWOPOverFlow");

                entity.Property(e => e.GpAfterStartTime).HasMaxLength(50);

                entity.Property(e => e.GpAfterTimeEnd).HasMaxLength(50);

                entity.Property(e => e.GpBeforeStartTime).HasMaxLength(50);

                entity.Property(e => e.GpBeforeTimeEnd).HasMaxLength(50);

                entity.Property(e => e.LateInCountLeaveType).HasMaxLength(50);

                entity.Property(e => e.LeaveTypeWop)
                    .HasMaxLength(50)
                    .HasColumnName("LeaveTypeWOP");

                entity.Property(e => e.MptleaveType)
                    .HasMaxLength(50)
                    .HasColumnName("MPTLeaveType");

                entity.Property(e => e.SandwichLeaveType).HasMaxLength(50);

                entity.Property(e => e.ShortLeaveCount).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<MstBenefit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBonu>(entity =>
            {
                entity.Property(e => e.BonusPercentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.DocCode).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MinimumMonthsDuration).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ValueLOVType");

                entity.Property(e => e.ValueType).HasMaxLength(10);
            });

            modelBuilder.Entity<MstBonusYearly>(entity =>
            {
                entity.ToTable("MstBonusYearly");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BonusPercentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(2000);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocCode).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MinimumMonthsDuration).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType).HasMaxLength(100);
            });

            modelBuilder.Entity<MstBranch>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Prefix).HasMaxLength(150);

                entity.Property(e => e.RegionalHead).HasMaxLength(10);

                entity.Property(e => e.SapdocEntry).HasColumnName("SAPDocEntry");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<MstCalendar>(entity =>
            {
                entity.ToTable("MstCalendar");

                entity.HasIndex(e => e.Code, "IX_MstCalendar")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstCandidate>(entity =>
            {
                entity.ToTable("MstCandidate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("date")
                    .HasColumnName("applicationDate");

                entity.Property(e => e.Attachment).HasMaxLength(400);

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(50)
                    .HasColumnName("bankAccount");

                entity.Property(e => e.BankName)
                    .HasMaxLength(150)
                    .HasColumnName("bankName");

                entity.Property(e => e.Bankbranch)
                    .HasMaxLength(50)
                    .HasColumnName("bankbranch");

                entity.Property(e => e.Citizenship)
                    .HasMaxLength(50)
                    .HasColumnName("citizenship");

                entity.Property(e => e.CountryofBirth)
                    .HasMaxLength(50)
                    .HasColumnName("countryofBirth");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("currentSalary");

                entity.Property(e => e.CvPath)
                    .HasMaxLength(200)
                    .HasColumnName("cv_path");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.DocStatus)
                    .HasColumnName("docStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email1).HasMaxLength(80);

                entity.Property(e => e.Email2).HasMaxLength(80);

                entity.Property(e => e.ExpOrTrainee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength()
                    .HasComment("E=Experienced, T=Trainee, Default value N=Not selected");

                entity.Property(e => e.ExpectedSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("expectedSalary");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Extension)
                    .HasMaxLength(100)
                    .HasColumnName("extension");

                entity.Property(e => e.FatherDesg).HasMaxLength(100);

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.FatherOrg).HasMaxLength(100);

                entity.Property(e => e.FatherTele).HasMaxLength(20);

                entity.Property(e => e.Fax).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.HBlock)
                    .HasMaxLength(100)
                    .HasColumnName("hBlock");

                entity.Property(e => e.HBuildingFloor)
                    .HasMaxLength(100)
                    .HasColumnName("hBuildingFloor");

                entity.Property(e => e.HCity)
                    .HasMaxLength(100)
                    .HasColumnName("hCity");

                entity.Property(e => e.HCountry)
                    .HasMaxLength(100)
                    .HasColumnName("hCountry");

                entity.Property(e => e.HCounty)
                    .HasMaxLength(100)
                    .HasColumnName("hCounty");

                entity.Property(e => e.HState)
                    .HasMaxLength(100)
                    .HasColumnName("hState");

                entity.Property(e => e.HStreet)
                    .HasMaxLength(100)
                    .HasColumnName("hStreet");

                entity.Property(e => e.HStreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("hStreetNo");

                entity.Property(e => e.HZipCode)
                    .HasMaxLength(100)
                    .HasColumnName("hZipCode");

                entity.Property(e => e.HomePhone).HasMaxLength(20);

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(200)
                    .HasColumnName("imgPath");

                entity.Property(e => e.InterviewDecided)
                    .HasColumnName("interviewDecided")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsShortListed)
                    .HasColumnName("isShortListed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Last5passwords)
                    .HasMaxLength(500)
                    .HasColumnName("last5passwords");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.LineManager).HasColumnName("lineManager");

                entity.Property(e => e.MartialStatus)
                    .HasMaxLength(50)
                    .HasColumnName("martialStatus");

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.MobilePhone).HasMaxLength(20);

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .HasColumnName("nicNo");

                entity.Property(e => e.NoOfChildren).HasColumnName("noOfChildren");

                entity.Property(e => e.OfficePhone)
                    .HasMaxLength(30)
                    .HasColumnName("officePhone");

                entity.Property(e => e.Pager).HasMaxLength(20);

                entity.Property(e => e.PassportExpiry)
                    .HasColumnType("date")
                    .HasColumnName("passportExpiry");

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(50)
                    .HasColumnName("passportNo");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Passwordexpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("passwordexpiry");

                entity.Property(e => e.PersonalTitle)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredLocName).HasMaxLength(200);

                entity.Property(e => e.PriorityAea)
                    .HasColumnName("PriorityAEA")
                    .HasComment("");

                entity.Property(e => e.PriorityAia).HasColumnName("PriorityAIA");

                entity.Property(e => e.PriorityBea)
                    .HasColumnName("PriorityBEA")
                    .HasComment("");

                entity.Property(e => e.PriorityBia).HasColumnName("PriorityBIA");

                entity.Property(e => e.RecommendedSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("recommendedSalary");

                entity.Property(e => e.ReferedById).HasColumnName("ReferedByID");

                entity.Property(e => e.ReferedByName).HasMaxLength(100);

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.ResetCount).HasColumnName("resetCount");

                entity.Property(e => e.StaffingStatus)
                    .HasMaxLength(50)
                    .HasColumnName("staffingStatus");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserCode)
                    .HasMaxLength(50)
                    .HasColumnName("userCode");

                entity.Property(e => e.WBlock)
                    .HasMaxLength(100)
                    .HasColumnName("wBlock");

                entity.Property(e => e.WBuildingFloor)
                    .HasMaxLength(100)
                    .HasColumnName("wBuildingFloor");

                entity.Property(e => e.WCity)
                    .HasMaxLength(100)
                    .HasColumnName("wCity");

                entity.Property(e => e.WCountry)
                    .HasMaxLength(100)
                    .HasColumnName("wCountry");

                entity.Property(e => e.WCounty)
                    .HasMaxLength(100)
                    .HasColumnName("wCounty");

                entity.Property(e => e.WState)
                    .HasMaxLength(100)
                    .HasColumnName("wState");

                entity.Property(e => e.WStreet)
                    .HasMaxLength(100)
                    .HasColumnName("wStreet");

                entity.Property(e => e.WStreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("wStreetNo");

                entity.Property(e => e.WZipCode)
                    .HasMaxLength(100)
                    .HasColumnName("wZipCode");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_MstCandidate_MstEmployee");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK_MstCandidate_MstBranches");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_MstCandidate_MstDepartment");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK_MstCandidate_MstDesignation");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_MstCandidate_MstLocation");

                entity.HasOne(d => d.VacancyNoNavigation)
                    .WithMany(p => p.MstCandidates)
                    .HasForeignKey(d => d.VacancyNo)
                    .HasConstraintName("FK_MstCandidate_TrnsVacancyRequest");
            });

            modelBuilder.Entity<MstCandidateAttachment>(entity =>
            {
                entity.ToTable("MstCandidate_Attachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.AttachmentPath).HasMaxLength(100);

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");
            });

            modelBuilder.Entity<MstCandidateEducation>(entity =>
            {
                entity.ToTable("MstCandidate_Education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accaaffiliate).HasColumnName("ACCAAffiliate");

                entity.Property(e => e.Accafinalist).HasColumnName("ACCAfinalist");

                entity.Property(e => e.AwardedQualification)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("awardedQualification");

                entity.Property(e => e.CandidateRef).HasColumnName("candidateRef");

                entity.Property(e => e.Cmaqualified).HasColumnName("CMAQualified");

                entity.Property(e => e.DateofFirstAttempt).HasColumnType("date");

                entity.Property(e => e.DateofLastAttempt).HasColumnType("date");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("fromDate");

                entity.Property(e => e.Ftsid).HasColumnName("FTSID");

                entity.Property(e => e.Ftsname)
                    .HasMaxLength(100)
                    .HasColumnName("FTSName");

                entity.Property(e => e.Icapafc).HasColumnName("ICAPAFC");

                entity.Property(e => e.Icapcaf).HasColumnName("ICAPCAF");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.InstituteName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("instituteName");

                entity.Property(e => e.MarksGrades)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marks_grades");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.QualificationId).HasColumnName("qualificationID");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subject");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("toDate");

                entity.HasOne(d => d.CandidateRefNavigation)
                    .WithMany(p => p.MstCandidateEducations)
                    .HasForeignKey(d => d.CandidateRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstCandidate_Education_MstCandidate");
            });

            modelBuilder.Entity<MstCandidateOtherInfo>(entity =>
            {
                entity.ToTable("MstCandidate_OtherInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailDate).HasColumnType("datetime");

                entity.Property(e => e.CandidateRef).HasColumnName("candidateRef");

                entity.Property(e => e.CareeaGoal)
                    .HasMaxLength(1000)
                    .HasColumnName("careeaGoal");

                entity.Property(e => e.Clientlimitation)
                    .HasMaxLength(1)
                    .HasColumnName("clientlimitation")
                    .IsFixedLength();
            });

            modelBuilder.Entity<MstCandidatePastExperience>(entity =>
            {
                entity.ToTable("MstCandidate_PastExperience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CandidateRef).HasColumnName("candidateRef");

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Company)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.Department).HasMaxLength(80);

                entity.Property(e => e.Duties)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("duties");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("fromDate");

                entity.Property(e => e.IsPresent).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSalary)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("lastSalary");

                entity.Property(e => e.Notes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.NoticePeriod).HasColumnName("noticePeriod");

                entity.Property(e => e.Position)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("toDate");

                entity.HasOne(d => d.CandidateRefNavigation)
                    .WithMany(p => p.MstCandidatePastExperiences)
                    .HasForeignKey(d => d.CandidateRef)
                    .HasConstraintName("FK_MstCandidate_PastExperience_MstCandidate");
            });

            modelBuilder.Entity<MstCandidateQualification>(entity =>
            {
                entity.ToTable("MstCandidate_Qualification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwardStatus)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("awardStatus");

                entity.Property(e => e.Awardedby)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("awardedby");

                entity.Property(e => e.CandidateRef).HasColumnName("candidateRef");

                entity.Property(e => e.CertificationId).HasColumnName("certificationID");

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Ftsid)
                    .HasMaxLength(20)
                    .HasColumnName("FTSID");

                entity.Property(e => e.Ftsname)
                    .HasMaxLength(20)
                    .HasColumnName("FTSName");

                entity.Property(e => e.Notes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.Validated)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("validated");

                entity.HasOne(d => d.CandidateRefNavigation)
                    .WithMany(p => p.MstCandidateQualifications)
                    .HasForeignKey(d => d.CandidateRef)
                    .HasConstraintName("FK_MstCandidate_Qualification_MstCandidate");
            });

            modelBuilder.Entity<MstCandidateReference>(entity =>
            {
                entity.ToTable("MstCandidate_References");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_ID");

                entity.Property(e => e.ContactNumber).HasMaxLength(11);

                entity.Property(e => e.Designation).HasMaxLength(80);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Organization).HasMaxLength(150);

                entity.Property(e => e.RelationshipWithCandidate)
                    .HasMaxLength(50)
                    .HasColumnName("Relationship_with_candidate");

                entity.Property(e => e.RemarksFromReference)
                    .HasMaxLength(250)
                    .HasColumnName("Remarks_from_Reference");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MstCandidateReferences)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstCandidate_References_MstCandidate");
            });

            modelBuilder.Entity<MstCategory>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstCategory");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstCertification>(entity =>
            {
                entity.ToTable("MstCertification");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstCity>(entity =>
            {
                entity.ToTable("MstCity");

                entity.Property(e => e.CityCode).HasMaxLength(50);

                entity.Property(e => e.CityName).HasMaxLength(150);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstCities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_MstCity_MstCountry");
            });

            modelBuilder.Entity<MstClassification>(entity =>
            {
                entity.ToTable("MstClassification");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstCoachingDoc>(entity =>
            {
                entity.ToTable("MstCoachingDoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionSteps).HasMaxLength(500);

                entity.Property(e => e.Activities).HasMaxLength(500);

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.MileStones).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCommitmentAllowancePolicy>(entity =>
            {
                entity.ToTable("MstCommitmentAllowancePolicy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby).HasMaxLength(20);

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCommitteeSetup>(entity =>
            {
                entity.ToTable("MstCommitteeSetup");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstCompany>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.ToTable("MstCompany");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.AppVersion).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CompType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyAddress).HasMaxLength(250);

                entity.Property(e => e.CompanyLogoPath)
                    .HasMaxLength(200)
                    .HasColumnName("Company_Logo_Path");

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Dbversion)
                    .HasMaxLength(50)
                    .HasColumnName("DBVersion");

                entity.Property(e => e.EmailCompany).HasMaxLength(20);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.Phone1).HasMaxLength(20);

                entity.Property(e => e.Phone2).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(100);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<MstCompanyDetail>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.ToTable("MstCompanyDetail");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.BuildNo).HasMaxLength(20);

                entity.Property(e => e.CompanyName).HasMaxLength(100);
            });

            modelBuilder.Entity<MstCompetancy>(entity =>
            {
                entity.ToTable("MstCompetancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetencyLevelId).HasColumnName("CompetencyLevelID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.CompetencyLevel)
                    .WithMany(p => p.MstCompetancies)
                    .HasForeignKey(d => d.CompetencyLevelId)
                    .HasConstraintName("FK_MstCompetancy_CompetencyLevelSetup");
            });

            modelBuilder.Entity<MstCompetencyGroup>(entity =>
            {
                entity.ToTable("MstCompetencyGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompGroup).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(4)
                    .HasColumnName("GroupID");

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstContractor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCostCentre>(entity =>
            {
                entity.ToTable("MstCostCentre");

                entity.Property(e => e.CostCentreCode).HasMaxLength(150);

                entity.Property(e => e.CostCentreDesc).HasMaxLength(150);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCountry>(entity =>
            {
                entity.ToTable("MstCountry");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode).HasMaxLength(10);

                entity.Property(e => e.CountryName).HasMaxLength(40);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);
            });

            modelBuilder.Entity<MstCphelement>(entity =>
            {
                entity.ToTable("MstCPHElement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Create_By");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.ElementName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_Date");
            });

            modelBuilder.Entity<MstCurrency>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("MstCurrency");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(30);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(5);
            });

            modelBuilder.Entity<MstDeductionRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<MstDeductionRuleSup>(entity =>
            {
                entity.ToTable("MstDeductionRuleSup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<MstDepartment>(entity =>
            {
                entity.ToTable("MstDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code).HasMaxLength(300);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeptName).HasMaxLength(500);

                entity.Property(e => e.DeptPrefix).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.SapdocEntry).HasColumnName("SAPDocEntry");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstDesigLinkCompetency>(entity =>
            {
                entity.ToTable("MstDesigLinkCompetency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetencyLevelId).HasColumnName("CompetencyLevelID");

                entity.Property(e => e.CompetencySetupId).HasColumnName("CompetencySetupID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CompetencyLevel)
                    .WithMany(p => p.MstDesigLinkCompetencies)
                    .HasForeignKey(d => d.CompetencyLevelId)
                    .HasConstraintName("FK_MstDesigLinkCompetency_MstDesigLinkCompetency");

                entity.HasOne(d => d.CompetencySetup)
                    .WithMany(p => p.MstDesigLinkCompetencies)
                    .HasForeignKey(d => d.CompetencySetupId)
                    .HasConstraintName("FK_MstDesigLinkCompetency_MstDesignation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstDesigLinkCompetencies)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstDesigLinkCompetency_MstDesignation1");
            });

            modelBuilder.Entity<MstDesigLinkGrade>(entity =>
            {
                entity.ToTable("MstDesigLinkGrade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstDesigLinkGrades)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstDesigLinkGrade_MstDesignation");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.MstDesigLinkGrades)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_MstDesigLinkGrade_MstGrading");
            });

            modelBuilder.Entity<MstDesignation>(entity =>
            {
                entity.ToTable("MstDesignation");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.SbodocEntry).HasColumnName("SBODocEntry");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.MstDesignations)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_MstDesignation_MstGrading");
            });

            modelBuilder.Entity<MstDesignationLevel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DesignationId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDetailTraningBudget>(entity =>
            {
                entity.ToTable("MstDetailTraningBudget");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accomodation).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AccomodationTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CategoryCode).HasMaxLength(50);

                entity.Property(e => e.CategoryDeacription).HasMaxLength(100);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LocalTransPerDay).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.LunchPerDay).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LunchTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PlanDescription).HasMaxLength(50);

                entity.Property(e => e.TaDaPerDay).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TaDaTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransportTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TravellingFare).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TravellingTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VenueDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<MstDimension>(entity =>
            {
                entity.ToTable("MstDimension");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDisciplinaryActionsType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Fine).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Poi)
                    .HasMaxLength(1000)
                    .HasColumnName("POI");

                entity.Property(e => e.TypeOfOffence).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");
            });

            modelBuilder.Entity<MstDocumentCheckList>(entity =>
            {
                entity.ToTable("MstDocumentCheckList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(100)
                    .HasColumnName("Document_Name");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");
            });

            modelBuilder.Entity<MstDocumentNumberSeries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FkformCode).HasColumnName("FKFormCode");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FormName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstElement>(entity =>
            {
                entity.Property(e => e.ApplicableAmountMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ElementName).HasMaxLength(100);

                entity.Property(e => e.ElmtType).HasMaxLength(10);

                entity.Property(e => e.ElmtTypeLovType).HasMaxLength(20);

                entity.Property(e => e.EmployeeContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerContributionMax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgAttendanceAllowance).HasColumnName("flgAttendanceAllowance");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgCash).HasColumnName("flgCash");

                entity.Property(e => e.FlgConBatch).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlgConfirmDateProcessing).HasColumnName("flgConfirmDateProcessing");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgEmployeeBonus).HasColumnName("flgEmployeeBonus");

                entity.Property(e => e.FlgEos).HasColumnName("flgEos");

                entity.Property(e => e.FlgGradeDep).HasColumnName("flgGradeDep");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgOldAgeBenifit).HasColumnName("flgOldAgeBenifit");

                entity.Property(e => e.FlgPerDay).HasColumnName("flgPerDay");

                entity.Property(e => e.FlgPfloan).HasColumnName("flgPFLoan");

                entity.Property(e => e.FlgProbationApplicable).HasColumnName("flgProbationApplicable");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgQueryable).HasColumnName("flgQueryable");

                entity.Property(e => e.FlgRemainingAmount).HasColumnName("flgRemainingAmount");

                entity.Property(e => e.FlgRunningTotal).HasColumnName("flgRunningTotal");

                entity.Property(e => e.FlgSalaryArear).HasColumnName("flgSalaryArear");

                entity.Property(e => e.FlgShiftDays).HasColumnName("flgShiftDays");

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.FlgVgross).HasColumnName("flgVGross");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.Property(e => e.TypeLovType).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);
            });

            modelBuilder.Entity<MstElementContribution>(entity =>
            {
                entity.ToTable("MstElementContribution");

                entity.Property(e => e.ContTaxDiscount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ContributionId)
                    .HasMaxLength(10)
                    .HasColumnName("ContributionID");

                entity.Property(e => e.ContributionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ContributionLOVType");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EarnedSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Employee).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Employer).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FormulaBuilderId).HasColumnName("FormulaBuilderID");

                entity.Property(e => e.FormulaCode).HasMaxLength(50);

                entity.Property(e => e.MaxAppAmount)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxEmployeeContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MaxEmployerContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryRangeFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryRangeTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.ValidOnSalary).HasMaxLength(50);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstElementContributions)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstElementContribution_MstElements");
            });

            modelBuilder.Entity<MstElementDeduction>(entity =>
            {
                entity.ToTable("MstElementDeduction");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionType).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgAdditionalEntryAllowed).HasColumnName("flgAdditionalEntryAllowed");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgMultipleEntryAllowed).HasColumnName("flgMultipleEntryAllowed");

                entity.Property(e => e.FlgNonTaxable).HasColumnName("flgNonTaxable");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgSlabWise).HasColumnName("flgSlabWise");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.FormulaBuilderId).HasColumnName("FormulaBuilderID");

                entity.Property(e => e.FormulaCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.Property(e => e.ValueTypeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ValueTypeLOVType");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstElementDeductions)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstElementDeduction_MstElements");
            });

            modelBuilder.Entity<MstElementEarning>(entity =>
            {
                entity.ToTable("MstElementEarning");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgAdditionalEntryAllowed).HasColumnName("flgAdditionalEntryAllowed");

                entity.Property(e => e.FlgEos).HasColumnName("flgEOS");

                entity.Property(e => e.FlgLeaveEncashment).HasColumnName("flgLeaveEncashment");

                entity.Property(e => e.FlgMultipleEntryAllowed).HasColumnName("flgMultipleEntryAllowed");

                entity.Property(e => e.FlgNotTaxable).HasColumnName("flgNotTaxable");

                entity.Property(e => e.FlgPropotionate).HasColumnName("flgPropotionate");

                entity.Property(e => e.FlgVariableValue).HasColumnName("flgVariableValue");

                entity.Property(e => e.FormulaCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.Property(e => e.ValueTypeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ValueTypeLOVType");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstElementEarnings)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstElementEarning_MstElements");
            });

            modelBuilder.Entity<MstElementFormulaBuilder>(entity =>
            {
                entity.ToTable("MstElementFormulaBuilder");

                entity.Property(e => e.Calculation).HasMaxLength(10);

                entity.Property(e => e.CalculationLovType).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EarningElementId).HasColumnName("EarningElementID");

                entity.Property(e => e.FlgBasicSalary).HasColumnName("flgBasicSalary");

                entity.Property(e => e.FlgGeneralValue).HasColumnName("flgGeneralValue");

                entity.Property(e => e.FlgGlobal).HasColumnName("flgGlobal");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueLovType).HasMaxLength(20);

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.HasOne(d => d.EarningElement)
                    .WithMany(p => p.MstElementFormulaBuilders)
                    .HasForeignKey(d => d.EarningElementId)
                    .HasConstraintName("FK_MstElementFormulaBuilder_MstElementEarning");
            });

            modelBuilder.Entity<MstElementInformation>(entity =>
            {
                entity.ToTable("MstElementInformation");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgTaxable).HasColumnName("flgTaxable");

                entity.Property(e => e.TaxableIncome).HasMaxLength(10);

                entity.Property(e => e.TaxableIncomeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("TaxableIncomeLOVType");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstElementInformations)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstElementInformation_MstElements");
            });

            modelBuilder.Entity<MstElementLink>(entity =>
            {
                entity.ToTable("MstElementLink");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstElementLinks)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_MstElementLink_MstElements");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.MstElementLinks)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_MstElementLink_CfgPayrollDefination");
            });

            modelBuilder.Entity<MstElementQueryRegister>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstElementQueryRegister");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ElementCode).HasMaxLength(50);

                entity.Property(e => e.QueryName).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MstElementsPerRate>(entity =>
            {
                entity.ToTable("MstElementsPerRate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DayWeek).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ElemFunction).HasMaxLength(50);

                entity.Property(e => e.ElemType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ElemValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.ValueType).HasMaxLength(50);
            });

            modelBuilder.Entity<MstEmail>(entity =>
            {
                entity.ToTable("MstEmail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Ceoemail)
                    .HasMaxLength(50)
                    .HasColumnName("CEOEmail");

                entity.Property(e => e.Hremail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("HREmail");
            });

            modelBuilder.Entity<MstEmailConfig>(entity =>
            {
                entity.ToTable("MstEmailConfig");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromEmail).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Smtport).HasColumnName("SMTPort");

                entity.Property(e => e.Smtpserver)
                    .HasMaxLength(100)
                    .HasColumnName("SMTPServer");

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.Property(e => e.TestEmail).HasMaxLength(50);
            });

            modelBuilder.Entity<MstEmpFingerRegister>(entity =>
            {
                entity.ToTable("MstEmpFingerRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstEmployee>(entity =>
            {
                entity.ToTable("MstEmployee");

                entity.HasIndex(e => e.EmpId, "IX_MstEmployeeUniqueEmpID")
                    .IsUnique();

                entity.HasIndex(e => e.SboempCode, "IX_MstEmployeeUniqueSBOEmpCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNo).HasMaxLength(200);

                entity.Property(e => e.AccountTitle).HasMaxLength(100);

                entity.Property(e => e.AccountType).HasMaxLength(10);

                entity.Property(e => e.AllowedAdvance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ArabicName).HasMaxLength(150);

                entity.Property(e => e.BankBranch).HasMaxLength(150);

                entity.Property(e => e.BankBranchCode).HasMaxLength(10);

                entity.Property(e => e.BankCardExpiryDt).HasMaxLength(100);

                entity.Property(e => e.BankCode).HasMaxLength(100);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BasicGrossRatio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.BloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BloodGroupLOVType");

                entity.Property(e => e.BonusCode).HasMaxLength(50);

                entity.Property(e => e.BonusPoints).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.CandidateCast)
                    .HasMaxLength(50)
                    .HasColumnName("candidate_cast");

                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ContrEnddate).HasColumnType("datetime");

                entity.Property(e => e.ContrStartDate).HasColumnType("datetime");

                entity.Property(e => e.ContractExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CvPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cv_path");

                entity.Property(e => e.DefaultOffDay).HasMaxLength(50);

                entity.Property(e => e.DefaultShift).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.DrivingLic)
                    .HasMaxLength(50)
                    .HasColumnName("Driving_lic");

                entity.Property(e => e.DrvLicCompletionDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicLastDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicReleaseDt).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EID");

                entity.Property(e => e.Eidexpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("EIDExpiry");

                entity.Property(e => e.ElementHeadId).HasColumnName("ElementHeadID");

                entity.Property(e => e.EmpCalender).HasMaxLength(50);

                entity.Property(e => e.EmpCardExp)
                    .HasColumnType("datetime")
                    .HasColumnName("empCardExp");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpUnion).HasMaxLength(10);

                entity.Property(e => e.EmployeeContractType).HasMaxLength(20);

                entity.Property(e => e.EnglishName).HasMaxLength(300);

                entity.Property(e => e.Eobino)
                    .HasMaxLength(50)
                    .HasColumnName("EOBINo");

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgBlackListed).HasColumnName("flgBlackListed");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgCeouser).HasColumnName("flgCEOUser");

                entity.Property(e => e.FlgCmhouseEmp).HasColumnName("FlgCMHouseEmp");

                entity.Property(e => e.FlgCompanyResidence).HasColumnName("flgCompanyResidence");

                entity.Property(e => e.FlgDailyWager).HasColumnName("flgDailyWager");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgEobi).HasColumnName("flgEOBI");

                entity.Property(e => e.FlgFlexibleShift).HasColumnName("flgFlexibleShift");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgHold).HasColumnName("flgHold");

                entity.Property(e => e.FlgHrapproved).HasColumnName("FlgHRApproved");

                entity.Property(e => e.FlgHruser).HasColumnName("flgHRUser");

                entity.Property(e => e.FlgItapproved).HasColumnName("FlgITApproved");

                entity.Property(e => e.FlgNotInPayroll).HasColumnName("flgNotInPayroll");

                entity.Property(e => e.FlgOcrdtransfered).HasColumnName("flgOCRDTransfered");

                entity.Property(e => e.FlgOffDayApplicable).HasColumnName("flgOffDayApplicable");

                entity.Property(e => e.FlgOnLeave).HasColumnName("flgOnLeave");

                entity.Property(e => e.FlgOtapplicable).HasColumnName("flgOTApplicable");

                entity.Property(e => e.FlgPerHour).HasColumnName("flgPerHour");

                entity.Property(e => e.FlgPerPiece).HasColumnName("flgPerPiece");

                entity.Property(e => e.FlgProbation).HasColumnName("flgProbation");

                entity.Property(e => e.FlgSandwich).HasColumnName("flgSandwich");

                entity.Property(e => e.FlgSendToHr).HasColumnName("FlgSendToHR");

                entity.Property(e => e.FlgSendToIt).HasColumnName("FlgSendToIT");

                entity.Property(e => e.FlgShopManager).HasColumnName("flgShopManager");

                entity.Property(e => e.FlgSocialSecurity).HasColumnName("flgSocialSecurity");

                entity.Property(e => e.FlgSuperVisor).HasColumnName("flgSuperVisor");

                entity.Property(e => e.FlgTax).HasColumnName("flgTax");

                entity.Property(e => e.FlgUser).HasColumnName("flgUser");

                entity.Property(e => e.GenderId)
                    .HasMaxLength(10)
                    .HasColumnName("GenderID");

                entity.Property(e => e.GenderLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("GenderLOVType");

                entity.Property(e => e.GosiSalary).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.GradeLevelId).HasColumnName("GradeLevelID");

                entity.Property(e => e.GratuityName).HasMaxLength(50);

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.GrossSalaryHired).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Hablock)
                    .HasMaxLength(50)
                    .HasColumnName("HABlock");

                entity.Property(e => e.Hacity)
                    .HasMaxLength(100)
                    .HasColumnName("HACity");

                entity.Property(e => e.Hacountry)
                    .HasMaxLength(100)
                    .HasColumnName("HACountry");

                entity.Property(e => e.Haother)
                    .HasMaxLength(500)
                    .HasColumnName("HAOther");

                entity.Property(e => e.Hastate)
                    .HasMaxLength(100)
                    .HasColumnName("HAState");

                entity.Property(e => e.Hastreet)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreet");

                entity.Property(e => e.HastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreetNo");

                entity.Property(e => e.HazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("HAZipCode");

                entity.Property(e => e.HoldDate).HasColumnType("datetime");

                entity.Property(e => e.HoldReasons).HasMaxLength(500);

                entity.Property(e => e.HolidayCalendar).HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.HrBaseCalendar).HasMaxLength(20);

                entity.Property(e => e.IddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("IDDateofIssue");

                entity.Property(e => e.IdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDExpiryDate");

                entity.Property(e => e.IdexpiryDt)
                    .HasMaxLength(100)
                    .HasColumnName("IDExpiryDt");

                entity.Property(e => e.IdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("IDIssuedBy");

                entity.Property(e => e.Idno)
                    .HasMaxLength(20)
                    .HasColumnName("IDNo");

                entity.Property(e => e.IdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("IDPlaceofIssue");

                entity.Property(e => e.Imagedata)
                    .HasMaxLength(3000)
                    .IsFixedLength();

                entity.Property(e => e.ImgPath).HasMaxLength(600);

                entity.Property(e => e.IncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.Initials).HasMaxLength(30);

                entity.Property(e => e.InsuranceCategory).HasMaxLength(50);

                entity.Property(e => e.InventoryEmail).HasMaxLength(500);

                entity.Property(e => e.IqamaProfessional).HasMaxLength(200);

                entity.Property(e => e.Jd).HasColumnName("JD");

                entity.Property(e => e.JobTitle).HasMaxLength(100);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.LastAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LiexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LIExpiryDate");

                entity.Property(e => e.Linsurance)
                    .HasMaxLength(100)
                    .HasColumnName("LInsurance");

                entity.Property(e => e.LocationName).HasMaxLength(500);

                entity.Property(e => e.ManagerName).HasMaxLength(300);

                entity.Property(e => e.MartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("MartialStatusID");

                entity.Property(e => e.MartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("MartialStatusLOVType");

                entity.Property(e => e.MedicalCardExpDt).HasMaxLength(100);

                entity.Property(e => e.MedicalCardExpiryDateEmployee).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardExpiryDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardIssueDateEmployee).HasMaxLength(100);

                entity.Property(e => e.MedicalCardIssueDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardNoEmployee)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MedicalCardNoSpouse).HasMaxLength(100);

                entity.Property(e => e.MedicalCategory).HasMaxLength(100);

                entity.Property(e => e.MedicalExpiry).HasColumnType("datetime");

                entity.Property(e => e.MedicalInsurance).HasMaxLength(100);

                entity.Property(e => e.MedicalNetwork).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MoajibEmail).HasMaxLength(500);

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.MultiLogin).HasColumnName("Multi_Login");

                entity.Property(e => e.NamePrefix).HasMaxLength(30);

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.NextAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.ObapprovedHours).HasColumnName("OBApprovedHours");

                entity.Property(e => e.ObasOnDate)
                    .HasColumnType("date")
                    .HasColumnName("OBAsOnDate");

                entity.Property(e => e.OboverTimeHours).HasColumnName("OBOverTimeHours");

                entity.Property(e => e.OfficeEmail).HasMaxLength(100);

                entity.Property(e => e.OfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OfficePhone).HasMaxLength(30);

                entity.Property(e => e.OrganizationalUnit).HasMaxLength(50);

                entity.Property(e => e.Otslabs).HasColumnName("OTSlabs");

                entity.Property(e => e.Pager).HasMaxLength(30);

                entity.Property(e => e.PassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDt).HasMaxLength(100);

                entity.Property(e => e.PassportNo).HasMaxLength(100);

                entity.Property(e => e.PayBandId).HasColumnName("PayBandID");

                entity.Property(e => e.PaymentMode).HasMaxLength(10);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PercentagePaid).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerformanceAllowance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PersonalContactNo).HasMaxLength(100);

                entity.Property(e => e.PersonalEmail).HasMaxLength(100);

                entity.Property(e => e.PersonalIm)
                    .HasMaxLength(100)
                    .HasColumnName("PersonalIM");

                entity.Property(e => e.PfloanLimit)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PFLoanLimit");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName).HasMaxLength(500);

                entity.Property(e => e.PostProbationIncrementAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("postProbationIncrementAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PreEmpMonth).HasMaxLength(20);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.PriAddress).HasMaxLength(100);

                entity.Property(e => e.PriCity).HasMaxLength(20);

                entity.Property(e => e.PriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.PriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.PriCountry).HasMaxLength(20);

                entity.Property(e => e.PriPersonName).HasMaxLength(100);

                entity.Property(e => e.PriRelationShip).HasMaxLength(20);

                entity.Property(e => e.PriState).HasMaxLength(20);

                entity.Property(e => e.PrjCode).HasMaxLength(50);

                entity.Property(e => e.PrjName).HasMaxLength(50);

                entity.Property(e => e.ProbationEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProfitCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.ReHire).HasMaxLength(5);

                entity.Property(e => e.RecruitmentMode).HasMaxLength(50);

                entity.Property(e => e.ReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("ReligionID");

                entity.Property(e => e.ReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ReligionLOVType");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.ReportToId).HasColumnName("ReportToID");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.RetirementDate).HasColumnType("date");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(150)
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("RoleLOVType");

                entity.Property(e => e.RoleName).HasMaxLength(300);

                entity.Property(e => e.SalaryCurrency).HasMaxLength(5);

                entity.Property(e => e.SboUserCode).HasMaxLength(50);

                entity.Property(e => e.SboempCode)
                    .HasMaxLength(30)
                    .HasColumnName("SBOEmpCode");

                entity.Property(e => e.SecAddress).HasMaxLength(100);

                entity.Property(e => e.SecCity).HasMaxLength(20);

                entity.Property(e => e.SecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.SecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.SecCountry).HasMaxLength(20);

                entity.Property(e => e.SecPersonName).HasMaxLength(100);

                entity.Property(e => e.SecRelationShip).HasMaxLength(20);

                entity.Property(e => e.SecState).HasMaxLength(20);

                entity.Property(e => e.Sect)
                    .HasMaxLength(50)
                    .HasColumnName("sect");

                entity.Property(e => e.Sector).HasMaxLength(100);

                entity.Property(e => e.ShiftDaysCode).HasMaxLength(50);

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.SpouseName).HasMaxLength(250);

                entity.Property(e => e.SuccessionId).HasColumnName("SuccessionID");

                entity.Property(e => e.TeamsId).HasColumnName("TeamsID");

                entity.Property(e => e.TeamsName).HasMaxLength(50);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TransportMode).HasMaxLength(50);

                entity.Property(e => e.UnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.VisaExpiry).HasColumnType("datetime");

                entity.Property(e => e.VisaNo).HasMaxLength(30);

                entity.Property(e => e.Wablock)
                    .HasMaxLength(50)
                    .HasColumnName("WABlock");

                entity.Property(e => e.Wacity)
                    .HasMaxLength(100)
                    .HasColumnName("WACity");

                entity.Property(e => e.Wacountry)
                    .HasMaxLength(100)
                    .HasColumnName("WACountry");

                entity.Property(e => e.Waother)
                    .HasMaxLength(500)
                    .HasColumnName("WAOther");

                entity.Property(e => e.Wastate)
                    .HasMaxLength(100)
                    .HasColumnName("WAState");

                entity.Property(e => e.Wastreet)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreet");

                entity.Property(e => e.WastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreetNo");

                entity.Property(e => e.WazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("WAZipCode");

                entity.Property(e => e.WindowsLogin).HasMaxLength(20);

                entity.Property(e => e.WorkIm)
                    .HasMaxLength(100)
                    .HasColumnName("WorkIM");

                entity.Property(e => e.WorkPermitExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.WorkPermitRef).HasMaxLength(20);

                entity.Property(e => e.WpfCatg)
                    .HasMaxLength(30)
                    .HasColumnName("Wpf_Catg");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_MstEmployee_MstBranches");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_MstEmployee_MstDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstEmployee_MstDesignation");

                entity.HasOne(d => d.EmployeeGradeNavigation)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.EmployeeGrade)
                    .HasConstraintName("FK_MstEmployee_MstEmployee");

                entity.HasOne(d => d.GratuitySlabsNavigation)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.GratuitySlabs)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstEmployee_TrnsGratuitySlabs");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_MstEmployee_MstLocation");

                entity.HasOne(d => d.OtslabsNavigation)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.Otslabs)
                    .HasConstraintName("FK_MstEmployee_TrnsOTSlab");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_MstEmployee_CfgPayrollDefination");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.MstEmployees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_MstEmployee_MstPosition");
            });

            modelBuilder.Entity<MstEmployeeApproval>(entity =>
            {
                entity.ToTable("MstEmployeeApproval");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BloodGroupLOVType");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.DrivingLic)
                    .HasMaxLength(100)
                    .HasColumnName("Driving_lic");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpUnion).HasMaxLength(10);

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.Hablock)
                    .HasMaxLength(50)
                    .HasColumnName("HABlock");

                entity.Property(e => e.Hacity)
                    .HasMaxLength(100)
                    .HasColumnName("HACity");

                entity.Property(e => e.Haother)
                    .HasMaxLength(500)
                    .HasColumnName("HAOther");

                entity.Property(e => e.Hastate)
                    .HasMaxLength(100)
                    .HasColumnName("HAState");

                entity.Property(e => e.Hastreet)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreet");

                entity.Property(e => e.HastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreetNo");

                entity.Property(e => e.HazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("HAZipCode");

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.IddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("IDDateofIssue");

                entity.Property(e => e.IdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDExpiryDate");

                entity.Property(e => e.IdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("IDIssuedBy");

                entity.Property(e => e.IdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("IDPlaceofIssue");

                entity.Property(e => e.IncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.Initials).HasMaxLength(30);

                entity.Property(e => e.MartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("MartialStatusID");

                entity.Property(e => e.MartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("MartialStatusLOVType");

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.NamePrefix).HasMaxLength(30);

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.OfficeEmail).HasMaxLength(30);

                entity.Property(e => e.OfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OfficePhone).HasMaxLength(30);

                entity.Property(e => e.OldBloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("OldBloodGroupID");

                entity.Property(e => e.OldBloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("OldBloodGroupLOVType");

                entity.Property(e => e.OldDrivingLic)
                    .HasMaxLength(100)
                    .HasColumnName("OldDriving_lic");

                entity.Property(e => e.OldEmpUnion).HasMaxLength(10);

                entity.Property(e => e.OldFatherName).HasMaxLength(100);

                entity.Property(e => e.OldFax).HasMaxLength(30);

                entity.Property(e => e.OldHablock)
                    .HasMaxLength(50)
                    .HasColumnName("OldHABlock");

                entity.Property(e => e.OldHacity)
                    .HasMaxLength(100)
                    .HasColumnName("OldHACity");

                entity.Property(e => e.OldHaother)
                    .HasMaxLength(500)
                    .HasColumnName("OldHAOther");

                entity.Property(e => e.OldHastate)
                    .HasMaxLength(100)
                    .HasColumnName("OldHAState");

                entity.Property(e => e.OldHastreet)
                    .HasMaxLength(100)
                    .HasColumnName("OldHAStreet");

                entity.Property(e => e.OldHastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("OldHAStreetNo");

                entity.Property(e => e.OldHazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("OldHAZipCode");

                entity.Property(e => e.OldHomePhone).HasMaxLength(30);

                entity.Property(e => e.OldIddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("OldIDDateofIssue");

                entity.Property(e => e.OldIdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("OldIDExpiryDate");

                entity.Property(e => e.OldIdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("OldIDIssuedBy");

                entity.Property(e => e.OldIdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("OldIDPlaceofIssue");

                entity.Property(e => e.OldIncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.OldInitials).HasMaxLength(30);

                entity.Property(e => e.OldMartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("OldMartialStatusID");

                entity.Property(e => e.OldMartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("OldMartialStatusLOVType");

                entity.Property(e => e.OldMotherName).HasMaxLength(100);

                entity.Property(e => e.OldNamePrefix).HasMaxLength(30);

                entity.Property(e => e.OldNationality).HasMaxLength(20);

                entity.Property(e => e.OldOfficeEmail).HasMaxLength(30);

                entity.Property(e => e.OldOfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OldOfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OldOfficePhone).HasMaxLength(30);

                entity.Property(e => e.OldPager).HasMaxLength(30);

                entity.Property(e => e.OldPassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.OldPassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OldPriAddress).HasMaxLength(100);

                entity.Property(e => e.OldPriCity).HasMaxLength(20);

                entity.Property(e => e.OldPriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.OldPriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.OldPriCountry).HasMaxLength(20);

                entity.Property(e => e.OldPriPersonName).HasMaxLength(100);

                entity.Property(e => e.OldPriRelationShip).HasMaxLength(20);

                entity.Property(e => e.OldPriState).HasMaxLength(20);

                entity.Property(e => e.OldReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("OldReligionID");

                entity.Property(e => e.OldReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("OldReligionLOVType");

                entity.Property(e => e.OldSecAddress).HasMaxLength(100);

                entity.Property(e => e.OldSecCity).HasMaxLength(20);

                entity.Property(e => e.OldSecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.OldSecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.OldSecCountry).HasMaxLength(20);

                entity.Property(e => e.OldSecPersonName).HasMaxLength(100);

                entity.Property(e => e.OldSecRelationShip).HasMaxLength(20);

                entity.Property(e => e.OldSecState).HasMaxLength(20);

                entity.Property(e => e.OldSocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.OldUnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.OldWablock)
                    .HasMaxLength(50)
                    .HasColumnName("OldWABlock");

                entity.Property(e => e.OldWacity)
                    .HasMaxLength(100)
                    .HasColumnName("OldWACity");

                entity.Property(e => e.OldWaother)
                    .HasMaxLength(500)
                    .HasColumnName("OldWAOther");

                entity.Property(e => e.OldWastate)
                    .HasMaxLength(100)
                    .HasColumnName("OldWAState");

                entity.Property(e => e.OldWastreet)
                    .HasMaxLength(100)
                    .HasColumnName("OldWAStreet");

                entity.Property(e => e.OldWastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("OldWAStreetNo");

                entity.Property(e => e.OldWazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("OldWAZipCode");

                entity.Property(e => e.Pager).HasMaxLength(30);

                entity.Property(e => e.PassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PriAddress).HasMaxLength(100);

                entity.Property(e => e.PriCity).HasMaxLength(20);

                entity.Property(e => e.PriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.PriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.PriCountry).HasMaxLength(20);

                entity.Property(e => e.PriPersonName).HasMaxLength(100);

                entity.Property(e => e.PriRelationShip).HasMaxLength(20);

                entity.Property(e => e.PriState).HasMaxLength(20);

                entity.Property(e => e.ReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("ReligionID");

                entity.Property(e => e.ReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ReligionLOVType");

                entity.Property(e => e.SecAddress).HasMaxLength(100);

                entity.Property(e => e.SecCity).HasMaxLength(20);

                entity.Property(e => e.SecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.SecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.SecCountry).HasMaxLength(20);

                entity.Property(e => e.SecPersonName).HasMaxLength(100);

                entity.Property(e => e.SecRelationShip).HasMaxLength(20);

                entity.Property(e => e.SecState).HasMaxLength(20);

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.UnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Wablock)
                    .HasMaxLength(50)
                    .HasColumnName("WABlock");

                entity.Property(e => e.Wacity)
                    .HasMaxLength(100)
                    .HasColumnName("WACity");

                entity.Property(e => e.Waother)
                    .HasMaxLength(500)
                    .HasColumnName("WAOther");

                entity.Property(e => e.Wastate)
                    .HasMaxLength(100)
                    .HasColumnName("WAState");

                entity.Property(e => e.Wastreet)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreet");

                entity.Property(e => e.WastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreetNo");

                entity.Property(e => e.WazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("WAZipCode");
            });

            modelBuilder.Entity<MstEmployeeAsset>(entity =>
            {
                entity.ToTable("MstEmployeeAsset");

                entity.Property(e => e.Accessories)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AssetCode).HasMaxLength(20);

                entity.Property(e => e.AssetName).HasMaxLength(50);

                entity.Property(e => e.AssetTyp).HasMaxLength(50);

                entity.Property(e => e.AuthoritytoDrive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CC");

                entity.Property(e => e.ChasisNo).HasMaxLength(150);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnginNo).HasMaxLength(150);

                entity.Property(e => e.FlgAssigned)
                    .HasColumnName("flg_assigned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hdd).HasMaxLength(50);

                entity.Property(e => e.Imei).HasMaxLength(50);

                entity.Property(e => e.Info1).HasMaxLength(150);

                entity.Property(e => e.Info2).HasMaxLength(150);

                entity.Property(e => e.Info3).HasMaxLength(150);

                entity.Property(e => e.Info4).HasMaxLength(150);

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Otherspecifications)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Processor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.Ram).HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Screen).HasMaxLength(50);

                entity.Property(e => e.SerialNo).HasMaxLength(150);

                entity.Property(e => e.TaxPaidUpto).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Updateddate).HasColumnType("datetime");

                entity.Property(e => e.Vehicletype)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WarrantyTill).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstEmployeeAttachment>(entity =>
            {
                entity.ToTable("MstEmployeeAttachment");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(150);

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeAttachments)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstEmployeeAttachment_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeCertification>(entity =>
            {
                entity.Property(e => e.AwardStatus).HasMaxLength(300);

                entity.Property(e => e.AwardedBy).HasMaxLength(300);

                entity.Property(e => e.CertificationId).HasColumnName("CertificationID");

                entity.Property(e => e.CertificationName).HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Validated).HasMaxLength(300);

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.MstEmployeeCertifications)
                    .HasForeignKey(d => d.CertificationId)
                    .HasConstraintName("FK_MstEmployeeCertifications_MstCertification");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeCertifications)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeCertifications_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeCertificationsApproval>(entity =>
            {
                entity.ToTable("MstEmployeeCertificationsApproval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.AwardStatus).HasMaxLength(300);

                entity.Property(e => e.AwardedBy).HasMaxLength(300);

                entity.Property(e => e.CertificationId).HasColumnName("CertificationID");

                entity.Property(e => e.CertificationName).HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Validated).HasMaxLength(300);

                entity.HasOne(d => d.Approval)
                    .WithMany(p => p.MstEmployeeCertificationsApprovals)
                    .HasForeignKey(d => d.ApprovalId)
                    .HasConstraintName("FK_MstEmployeeCertificationsApproval_MstEmployeeApproval");
            });

            modelBuilder.Entity<MstEmployeeCodeSeries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ENum)
                    .HasMaxLength(30)
                    .HasColumnName("eNum");

                entity.Property(e => e.EndNumber).HasMaxLength(50);

                entity.Property(e => e.EndPrefixSeries).HasMaxLength(30);

                entity.Property(e => e.NextAvailableCode).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(20);

                entity.Property(e => e.SNum)
                    .HasMaxLength(30)
                    .HasColumnName("sNum");

                entity.Property(e => e.StartNumber).HasMaxLength(50);

                entity.Property(e => e.StartPrefixSeries).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstEmployeeCommittee>(entity =>
            {
                entity.ToTable("MstEmployee_Committee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Committee)
                    .WithMany(p => p.MstEmployeeCommittees)
                    .HasForeignKey(d => d.CommitteeId)
                    .HasConstraintName("FK_MstEmployee_Committee_MstCommitteeSetup");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeCommittees)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployee_Committee_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeDocument>(entity =>
            {
                entity.ToTable("MstEmployee_Documents");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DocumentExt)
                    .HasMaxLength(5)
                    .HasColumnName("Document_Ext");

                entity.Property(e => e.DocumentId).HasColumnName("Document_ID");

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(500)
                    .HasColumnName("Document_Path");

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.MstEmployeeDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstEmployee_Documents_MstDocumentCheckList");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeDocuments)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstEmployee_Documents_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeEducation>(entity =>
            {
                entity.ToTable("MstEmployeeEducation");

                entity.Property(e => e.AwardedQualification).HasMaxLength(300);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.InstituteName).HasMaxLength(250);

                entity.Property(e => e.MarkGrade).HasMaxLength(300);

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.QualificationName).HasMaxLength(300);

                entity.Property(e => e.Subject).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeEducations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeEducation_MstEmployee");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.MstEmployeeEducations)
                    .HasForeignKey(d => d.InstituteId)
                    .HasConstraintName("FK_MstEmployeeEducation_MstInstitue");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.MstEmployeeEducations)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK_MstEmployeeEducation_MstQualification");
            });

            modelBuilder.Entity<MstEmployeeEducationApproval>(entity =>
            {
                entity.ToTable("MstEmployeeEducationApproval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.AwardedQualification).HasMaxLength(300);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.InstituteName).HasMaxLength(250);

                entity.Property(e => e.MarkGrade).HasMaxLength(300);

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.QualificationName).HasMaxLength(300);

                entity.Property(e => e.Subject).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Approval)
                    .WithMany(p => p.MstEmployeeEducationApprovals)
                    .HasForeignKey(d => d.ApprovalId)
                    .HasConstraintName("FK_MstEmployeeEducationApproval_MstEmployeeApproval");
            });

            modelBuilder.Entity<MstEmployeeEndOfService>(entity =>
            {
                entity.ToTable("MstEmployee_EndOfService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Service_End_Date");

                entity.Property(e => e.ServiceEndTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Service_End_Type_Desc");

                entity.Property(e => e.ServiceEndTypeId).HasColumnName("Service_End_Type_Id");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeEndOfServices)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstEmployee_EndOfService_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeExitClearnce>(entity =>
            {
                entity.ToTable("MstEmployeeExitClearnce");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssetCode).HasMaxLength(50);

                entity.Property(e => e.AssetName).HasMaxLength(50);

                entity.Property(e => e.AssignDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateReturned).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstEmployeeExperience>(entity =>
            {
                entity.ToTable("MstEmployeeExperience");

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.CompanyName).HasMaxLength(300);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(80);

                entity.Property(e => e.Duties).HasMaxLength(300);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LastSalary).HasMaxLength(300);

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.Position).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeExperiences)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeExperience_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeExperienceApproval>(entity =>
            {
                entity.ToTable("MstEmployeeExperienceApproval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.CompanyName).HasMaxLength(300);

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(80);

                entity.Property(e => e.Duties).HasMaxLength(300);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LastSalary).HasMaxLength(300);

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.Position).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Approval)
                    .WithMany(p => p.MstEmployeeExperienceApprovals)
                    .HasForeignKey(d => d.ApprovalId)
                    .HasConstraintName("FK_MstEmployeeExperienceApproval_MstEmployeeApproval");
            });

            modelBuilder.Entity<MstEmployeeLanguagesProficiency>(entity =>
            {
                entity.ToTable("MstEmployee_LanguagesProficiency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Reading)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Speaking)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Writing)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeLanguagesProficiencies)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployee_LanguagesProficiency_MstEmployee");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.MstEmployeeLanguagesProficiencies)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_MstEmployee_LanguagesProficiency_MstLanguages");
            });

            modelBuilder.Entity<MstEmployeeLeaf>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CarryForwardDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgLeaveCollapse).HasColumnName("flgLeaveCollapse");

                entity.Property(e => e.FromDt).HasColumnType("datetime");

                entity.Property(e => e.LeaveBalance)
                    .HasColumnType("numeric(12, 2)")
                    .HasComputedColumnSql("(([LeavesCarryForward]+[LeavesEntitled])-[LeavesUsed])", false);

                entity.Property(e => e.LeaveCalCode)
                    .HasMaxLength(50)
                    .HasColumnName("leaveCalCode");

                entity.Property(e => e.LeaveCollapseDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveTypeCode).HasMaxLength(20);

                entity.Property(e => e.LeaveTypeDescription).HasMaxLength(250);

                entity.Property(e => e.LeavesAllowed).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.LeavesCarryForward).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.LeavesEntitled).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.LeavesUsed).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.Property(e => e.ToDt).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeLeaves)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeLeaves_MstEmployee");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.MstEmployeeLeaves)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_MstEmployeeLeaves_MstLeaveType");
            });

            modelBuilder.Entity<MstEmployeeLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MstEmployeeLog");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CutDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesigId).HasColumnName("DesigID");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Empid).HasMaxLength(30);

                entity.Property(e => e.Flgactive).HasColumnName("flgactive");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<MstEmployeeLog1>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.ToTable("MstEmployeeLogs");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.AccountNo).HasMaxLength(200);

                entity.Property(e => e.AccountTitle).HasMaxLength(100);

                entity.Property(e => e.AccountType).HasMaxLength(10);

                entity.Property(e => e.AllowedAdvance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AppVersion).HasMaxLength(100);

                entity.Property(e => e.ArabicName).HasMaxLength(150);

                entity.Property(e => e.BankBranch).HasMaxLength(150);

                entity.Property(e => e.BankBranchCode).HasMaxLength(10);

                entity.Property(e => e.BankCardExpiryDt).HasMaxLength(100);

                entity.Property(e => e.BankCode).HasMaxLength(100);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BasicGrossRatio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.BloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BloodGroupLOVType");

                entity.Property(e => e.BonusCode).HasMaxLength(50);

                entity.Property(e => e.BonusPoints).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.CandidateCast)
                    .HasMaxLength(50)
                    .HasColumnName("candidate_cast");

                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ContrEnddate).HasColumnType("datetime");

                entity.Property(e => e.ContrStartDate).HasColumnType("datetime");

                entity.Property(e => e.ContractExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CvPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cv_path");

                entity.Property(e => e.DefaultOffDay).HasMaxLength(50);

                entity.Property(e => e.DefaultShift1).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.DrivingLic)
                    .HasMaxLength(50)
                    .HasColumnName("Driving_lic");

                entity.Property(e => e.DrvLicCompletionDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicLastDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicReleaseDt).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EID");

                entity.Property(e => e.Eidexpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("EIDExpiry");

                entity.Property(e => e.ElementHeadId).HasColumnName("ElementHeadID");

                entity.Property(e => e.EmpCalender).HasMaxLength(50);

                entity.Property(e => e.EmpCardExp)
                    .HasColumnType("datetime")
                    .HasColumnName("empCardExp");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpUnion).HasMaxLength(10);

                entity.Property(e => e.EmployeeContractType).HasMaxLength(20);

                entity.Property(e => e.EnglishName).HasMaxLength(300);

                entity.Property(e => e.Eobino)
                    .HasMaxLength(50)
                    .HasColumnName("EOBINo");

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgBlackListed).HasColumnName("flgBlackListed");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgCmhouseEmp1).HasColumnName("FlgCMHouseEmp1");

                entity.Property(e => e.FlgCompanyResidence).HasColumnName("flgCompanyResidence");

                entity.Property(e => e.FlgDailyWager).HasColumnName("flgDailyWager");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgEobi).HasColumnName("flgEOBI");

                entity.Property(e => e.FlgFlexibleShift).HasColumnName("flgFlexibleShift");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgHold).HasColumnName("flgHold");

                entity.Property(e => e.FlgHruser).HasColumnName("flgHRUser");

                entity.Property(e => e.FlgNotInPayroll).HasColumnName("flgNotInPayroll");

                entity.Property(e => e.FlgOcrdtransfered1).HasColumnName("flgOCRDTransfered1");

                entity.Property(e => e.FlgOffDayApplicable).HasColumnName("flgOffDayApplicable");

                entity.Property(e => e.FlgOnLeave).HasColumnName("flgOnLeave");

                entity.Property(e => e.FlgOtapplicable).HasColumnName("flgOTApplicable");

                entity.Property(e => e.FlgPerPiece).HasColumnName("flgPerPiece");

                entity.Property(e => e.FlgProbation).HasColumnName("flgProbation");

                entity.Property(e => e.FlgSandwich).HasColumnName("flgSandwich");

                entity.Property(e => e.FlgShopManager).HasColumnName("flgShopManager");

                entity.Property(e => e.FlgSocialSecurity).HasColumnName("flgSocialSecurity");

                entity.Property(e => e.FlgSuperVisor).HasColumnName("flgSuperVisor");

                entity.Property(e => e.FlgTax).HasColumnName("flgTax");

                entity.Property(e => e.FlgUser).HasColumnName("flgUser");

                entity.Property(e => e.GenderId)
                    .HasMaxLength(10)
                    .HasColumnName("GenderID");

                entity.Property(e => e.GenderLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("GenderLOVType");

                entity.Property(e => e.GosiSalary).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.GradeLevelId).HasColumnName("GradeLevelID");

                entity.Property(e => e.GratuityName).HasMaxLength(50);

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.GrossSalaryHired).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Hablock)
                    .HasMaxLength(50)
                    .HasColumnName("HABlock");

                entity.Property(e => e.Hacity)
                    .HasMaxLength(100)
                    .HasColumnName("HACity");

                entity.Property(e => e.Hacountry)
                    .HasMaxLength(100)
                    .HasColumnName("HACountry");

                entity.Property(e => e.Haother)
                    .HasMaxLength(500)
                    .HasColumnName("HAOther");

                entity.Property(e => e.Hastate)
                    .HasMaxLength(100)
                    .HasColumnName("HAState");

                entity.Property(e => e.Hastreet)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreet");

                entity.Property(e => e.HastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreetNo");

                entity.Property(e => e.HazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("HAZipCode");

                entity.Property(e => e.HoldDate).HasColumnType("datetime");

                entity.Property(e => e.HoldReasons).HasMaxLength(500);

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.HrBaseCalendar).HasMaxLength(20);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("IDDateofIssue");

                entity.Property(e => e.IdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDExpiryDate");

                entity.Property(e => e.IdexpiryDt)
                    .HasMaxLength(100)
                    .HasColumnName("IDExpiryDt");

                entity.Property(e => e.IdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("IDIssuedBy");

                entity.Property(e => e.Idno)
                    .HasMaxLength(20)
                    .HasColumnName("IDNo");

                entity.Property(e => e.IdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("IDPlaceofIssue");

                entity.Property(e => e.Imagedata)
                    .HasMaxLength(3000)
                    .IsFixedLength();

                entity.Property(e => e.ImgPath).HasMaxLength(600);

                entity.Property(e => e.IncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.Initials).HasMaxLength(30);

                entity.Property(e => e.InsuranceCategory).HasMaxLength(50);

                entity.Property(e => e.InventoryEmail).HasMaxLength(500);

                entity.Property(e => e.IqamaProfessional).HasMaxLength(200);

                entity.Property(e => e.Jd1).HasColumnName("JD1");

                entity.Property(e => e.JobTitle).HasMaxLength(30);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.LastAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LiexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LIExpiryDate");

                entity.Property(e => e.Linsurance)
                    .HasMaxLength(100)
                    .HasColumnName("LInsurance");

                entity.Property(e => e.LocationName).HasMaxLength(500);

                entity.Property(e => e.MartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("MartialStatusID");

                entity.Property(e => e.MartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("MartialStatusLOVType");

                entity.Property(e => e.MedicalCardExpDt).HasMaxLength(100);

                entity.Property(e => e.MedicalCardExpiryDateEmployee).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardExpiryDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardIssueDateEmployee).HasMaxLength(100);

                entity.Property(e => e.MedicalCardIssueDateSpouse).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardNoEmployee)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MedicalCardNoSpouse).HasMaxLength(100);

                entity.Property(e => e.MedicalCategory).HasMaxLength(100);

                entity.Property(e => e.MedicalExpiry).HasColumnType("datetime");

                entity.Property(e => e.MedicalInsurance).HasMaxLength(100);

                entity.Property(e => e.MedicalNetwork).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MoajibEmail).HasMaxLength(500);

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.MultiLogin).HasColumnName("Multi_Login");

                entity.Property(e => e.NamePrefix).HasMaxLength(30);

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.NextAirTicketDate).HasColumnType("datetime");

                entity.Property(e => e.OfficeEmail).HasMaxLength(100);

                entity.Property(e => e.OfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OfficePhone).HasMaxLength(30);

                entity.Property(e => e.OrganizationalUnit).HasMaxLength(50);

                entity.Property(e => e.Otslabs).HasColumnName("OTSlabs");

                entity.Property(e => e.Pager).HasMaxLength(30);

                entity.Property(e => e.PassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDt).HasMaxLength(100);

                entity.Property(e => e.PassportNo).HasMaxLength(100);

                entity.Property(e => e.PayBandId).HasColumnName("PayBandID");

                entity.Property(e => e.PaymentMode).HasMaxLength(10);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PercentagePaid).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerformanceAllowance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PersonalContactNo).HasMaxLength(100);

                entity.Property(e => e.PersonalEmail).HasMaxLength(100);

                entity.Property(e => e.PersonalIm)
                    .HasMaxLength(100)
                    .HasColumnName("PersonalIM");

                entity.Property(e => e.PfloanLimit1)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PFLoanLimit1");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName).HasMaxLength(500);

                entity.Property(e => e.PostProbationIncrementAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("postProbationIncrementAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PreEmpMonth).HasMaxLength(20);

                entity.Property(e => e.PriAddress).HasMaxLength(100);

                entity.Property(e => e.PriCity).HasMaxLength(20);

                entity.Property(e => e.PriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.PriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.PriCountry).HasMaxLength(20);

                entity.Property(e => e.PriPersonName).HasMaxLength(100);

                entity.Property(e => e.PriRelationShip).HasMaxLength(20);

                entity.Property(e => e.PriState).HasMaxLength(20);

                entity.Property(e => e.ProbationEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProfitCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.RecruitmentMode).HasMaxLength(50);

                entity.Property(e => e.ReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("ReligionID");

                entity.Property(e => e.ReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ReligionLOVType");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.ReportToId).HasColumnName("ReportToID");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.RetirementDate).HasColumnType("date");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(150)
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("RoleLOVType");

                entity.Property(e => e.RoleName).HasMaxLength(300);

                entity.Property(e => e.SalaryCurrency).HasMaxLength(5);

                entity.Property(e => e.SboUserCode).HasMaxLength(50);

                entity.Property(e => e.SboempCode)
                    .HasMaxLength(30)
                    .HasColumnName("SBOEmpCode");

                entity.Property(e => e.SecAddress).HasMaxLength(100);

                entity.Property(e => e.SecCity).HasMaxLength(20);

                entity.Property(e => e.SecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.SecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.SecCountry).HasMaxLength(20);

                entity.Property(e => e.SecPersonName).HasMaxLength(100);

                entity.Property(e => e.SecRelationShip).HasMaxLength(20);

                entity.Property(e => e.SecState).HasMaxLength(20);

                entity.Property(e => e.Sect)
                    .HasMaxLength(50)
                    .HasColumnName("sect");

                entity.Property(e => e.Sector).HasMaxLength(100);

                entity.Property(e => e.ShiftDaysCode).HasMaxLength(50);

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.SpouseName).HasMaxLength(250);

                entity.Property(e => e.SuccessionId).HasColumnName("SuccessionID");

                entity.Property(e => e.TeamsId).HasColumnName("TeamsID");

                entity.Property(e => e.TeamsName).HasMaxLength(50);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TransportMode).HasMaxLength(50);

                entity.Property(e => e.UnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.VisaExpiry).HasColumnType("datetime");

                entity.Property(e => e.VisaNo).HasMaxLength(30);

                entity.Property(e => e.Wablock)
                    .HasMaxLength(50)
                    .HasColumnName("WABlock");

                entity.Property(e => e.Wacity)
                    .HasMaxLength(100)
                    .HasColumnName("WACity");

                entity.Property(e => e.Wacountry)
                    .HasMaxLength(100)
                    .HasColumnName("WACountry");

                entity.Property(e => e.Waother)
                    .HasMaxLength(500)
                    .HasColumnName("WAOther");

                entity.Property(e => e.Wastate)
                    .HasMaxLength(100)
                    .HasColumnName("WAState");

                entity.Property(e => e.Wastreet)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreet");

                entity.Property(e => e.WastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreetNo");

                entity.Property(e => e.WazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("WAZipCode");

                entity.Property(e => e.WindowsLogin).HasMaxLength(20);

                entity.Property(e => e.WorkIm)
                    .HasMaxLength(100)
                    .HasColumnName("WorkIM");

                entity.Property(e => e.WorkPermitExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.WorkPermitRef).HasMaxLength(20);

                entity.Property(e => e.WpfCatg)
                    .HasMaxLength(30)
                    .HasColumnName("Wpf_Catg");
            });

            modelBuilder.Entity<MstEmployeeReference>(entity =>
            {
                entity.ToTable("MstEmployee_References");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactNumber).HasMaxLength(11);

                entity.Property(e => e.Designation).HasMaxLength(80);

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Organization).HasMaxLength(150);

                entity.Property(e => e.RelationshipWithCandidate)
                    .HasMaxLength(50)
                    .HasColumnName("Relationship_with_candidate");

                entity.Property(e => e.RemarksFromReference)
                    .HasMaxLength(250)
                    .HasColumnName("Remarks_from_Reference");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MstEmployeeReferences)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstEmployee_References_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeReferral>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeReferrals)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeReferrals_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeReferralsDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.ReferralEmpId).HasColumnName("ReferralEmpID");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.MstEmployeeReferralsDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstEmployeeReferralsDetails_MstEmployeeReferrals");

                entity.HasOne(d => d.ReferralEmp)
                    .WithMany(p => p.MstEmployeeReferralsDetails)
                    .HasForeignKey(d => d.ReferralEmpId)
                    .HasConstraintName("FK_MstEmployeeReferralsDetails_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeRelative>(entity =>
            {
                entity.Property(e => e.Bod)
                    .HasColumnType("datetime")
                    .HasColumnName("BOD");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.FlgDependent).HasColumnName("flgDependent");

                entity.Property(e => e.IdnoRelative)
                    .HasMaxLength(20)
                    .HasColumnName("IDNoRelative");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.MedicalCardExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardNo).HasMaxLength(20);

                entity.Property(e => e.MedicalCardStartDate).HasColumnType("datetime");

                entity.Property(e => e.OccupationId).HasColumnName("Occupation_Id");

                entity.Property(e => e.RelativeId)
                    .HasMaxLength(10)
                    .HasColumnName("RelativeID");

                entity.Property(e => e.RelativeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("RelativeLOVType");

                entity.Property(e => e.TelephoneNo).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeRelatives)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeRelatives_MstEmployee");
            });

            modelBuilder.Entity<MstEmployeeRelativesApproval>(entity =>
            {
                entity.ToTable("MstEmployeeRelativesApproval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.Bod)
                    .HasColumnType("datetime")
                    .HasColumnName("BOD");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.FlgDependent).HasColumnName("flgDependent");

                entity.Property(e => e.IdnoRelative)
                    .HasMaxLength(20)
                    .HasColumnName("IDNoRelative");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.MedicalCardExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.MedicalCardNo).HasMaxLength(20);

                entity.Property(e => e.MedicalCardStartDate).HasColumnType("datetime");

                entity.Property(e => e.OccupationId).HasColumnName("Occupation_Id");

                entity.Property(e => e.RelativeId)
                    .HasMaxLength(10)
                    .HasColumnName("RelativeID");

                entity.Property(e => e.RelativeLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("RelativeLOVType");

                entity.Property(e => e.TelephoneNo).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Approval)
                    .WithMany(p => p.MstEmployeeRelativesApprovals)
                    .HasForeignKey(d => d.ApprovalId)
                    .HasConstraintName("FK_MstEmployeeRelativesApproval_MstEmployeeApproval");
            });

            modelBuilder.Entity<MstEmployeeSuccessor>(entity =>
            {
                entity.ToTable("MstEmployeeSuccessor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.SuccessorId).HasColumnName("successorId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstEmployeeSuccessorEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstEmployeeSuccessor_MstEmployee");

                entity.HasOne(d => d.Successor)
                    .WithMany(p => p.MstEmployeeSuccessorSuccessors)
                    .HasForeignKey(d => d.SuccessorId)
                    .HasConstraintName("FK_MstEmployeeSuccessor_MstEmployee1");
            });

            modelBuilder.Entity<MstEmployeeTest>(entity =>
            {
                entity.ToTable("MstEmployeeTest");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasMaxLength(50)
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MstExpense>(entity =>
            {
                entity.ToTable("MstExpense");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ExpenseId).HasMaxLength(10);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgVoss).HasColumnName("flgVoss");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstForm>(entity =>
            {
                entity.HasKey(e => e.FormCode);

                entity.ToTable("MstForm");

                entity.Property(e => e.FormCode).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstFormula>(entity =>
            {
                entity.ToTable("MstFormula");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstFt>(entity =>
            {
                entity.ToTable("MstFTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.No).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstGenericRequest>(entity =>
            {
                entity.ToTable("MstGenericRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstGldadvanceDetail>(entity =>
            {
                entity.ToTable("MstGLDAdvanceDetail");

                entity.Property(e => e.A1indicator)
                    .HasMaxLength(50)
                    .HasColumnName("A1Indicator");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldadvanceDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDAdvanceDetail_MstGLDetermination");
            });

            modelBuilder.Entity<MstGldbonusDetail>(entity =>
            {
                entity.ToTable("MstGLDBonusDetail");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldbonusDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDBonusDetail_MstGLDetermination");
            });

            modelBuilder.Entity<MstGldcontribution>(entity =>
            {
                entity.ToTable("MstGLDContribution");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmprBalancingAccount).HasMaxLength(20);

                entity.Property(e => e.EmprBalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.EmprCostAccount).HasMaxLength(20);

                entity.Property(e => e.EmprCostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldcontributions)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDContribution_MstGLDetermination");
            });

            modelBuilder.Entity<MstGlddeductionDetail>(entity =>
            {
                entity.ToTable("MstGLDDeductionDetail");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGlddeductionDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDDeductionDetail_MstGLDetermination");
            });

            modelBuilder.Entity<MstGldearningDetail>(entity =>
            {
                entity.ToTable("MstGLDEarningDetail");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccout).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldearningDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDEarningDetail_MstGLDetermination");
            });

            modelBuilder.Entity<MstGldepartmentWise>(entity =>
            {
                entity.ToTable("MstGLDepartmentWise");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstGldetermination>(entity =>
            {
                entity.ToTable("MstGLDetermination");

                entity.Property(e => e.ArrearsExpense).HasMaxLength(16);

                entity.Property(e => e.ArrearsExpenseDesc).HasMaxLength(100);

                entity.Property(e => e.ArrearsPayable).HasMaxLength(16);

                entity.Property(e => e.ArrearsPayableDesc).HasMaxLength(100);

                entity.Property(e => e.BasicSalary).HasMaxLength(16);

                entity.Property(e => e.BasicSalaryDesc).HasMaxLength(100);

                entity.Property(e => e.Bspayable)
                    .HasMaxLength(16)
                    .HasColumnName("BSPayable");

                entity.Property(e => e.BspayableDesc)
                    .HasMaxLength(100)
                    .HasColumnName("BSPayableDesc");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiffDrcr)
                    .HasMaxLength(16)
                    .HasColumnName("DiffDRCR");

                entity.Property(e => e.DiffDrcrdesc)
                    .HasMaxLength(100)
                    .HasColumnName("DiffDRCRDesc");

                entity.Property(e => e.EosexpenseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("EOSExpenseDesc");

                entity.Property(e => e.Eosexpese)
                    .HasMaxLength(16)
                    .HasColumnName("EOSExpese");

                entity.Property(e => e.Eospayable)
                    .HasMaxLength(16)
                    .HasColumnName("EOSPayable");

                entity.Property(e => e.EospayableDesc)
                    .HasMaxLength(100)
                    .HasColumnName("EOSPayableDesc");

                entity.Property(e => e.Gltype)
                    .HasMaxLength(20)
                    .HasColumnName("GLType");

                entity.Property(e => e.Glvalue).HasColumnName("GLValue");

                entity.Property(e => e.GratuityExpense).HasMaxLength(16);

                entity.Property(e => e.GratuityExpenseDesc).HasMaxLength(100);

                entity.Property(e => e.GratuityPayable).HasMaxLength(16);

                entity.Property(e => e.GratuityPayableDesc).HasMaxLength(100);

                entity.Property(e => e.IncomeTaxExpense).HasMaxLength(16);

                entity.Property(e => e.IncomeTaxExpenseDesc).HasMaxLength(100);

                entity.Property(e => e.IncomeTaxPayable).HasMaxLength(16);

                entity.Property(e => e.IncomeTaxPayableDesc).HasMaxLength(100);

                entity.Property(e => e.LeaveEncashmentExpense).HasMaxLength(16);

                entity.Property(e => e.LeaveEncashmentExpenseDesc).HasMaxLength(100);

                entity.Property(e => e.LeaveEncashmentPayable).HasMaxLength(16);

                entity.Property(e => e.LeaveEncashmentPayableDesc).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstGldexpDetail>(entity =>
            {
                entity.ToTable("mstGLDExpDetails");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldexpDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mstGLDExpDetails_mstGLDExpDetails");
            });

            modelBuilder.Entity<MstGldleaveDedDetail>(entity =>
            {
                entity.ToTable("mstGLDLeaveDedDetails");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldleaveDedDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mstGLDLeaveDedDetails_mstGLDLeaveDedDetails");
            });

            modelBuilder.Entity<MstGldloansDetail>(entity =>
            {
                entity.ToTable("MstGLDLoansDetails");

                entity.Property(e => e.A1indicator)
                    .HasMaxLength(50)
                    .HasColumnName("A1Indicator");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldloansDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDLoansDetails_MstGLDetermination");
            });

            modelBuilder.Entity<MstGldoverTimeDetail>(entity =>
            {
                entity.ToTable("MstGLDOverTimeDetail");

                entity.Property(e => e.BalancingAccount).HasMaxLength(20);

                entity.Property(e => e.BalancingAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CostAccount).HasMaxLength(20);

                entity.Property(e => e.CostAcctDisplay).HasMaxLength(120);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Gldid).HasColumnName("GLDId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Gld)
                    .WithMany(p => p.MstGldoverTimeDetails)
                    .HasForeignKey(d => d.Gldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MstGLDOverTimeDetail_MstGLDetermination");
            });

            modelBuilder.Entity<MstGoalsRuless>(entity =>
            {
                entity.ToTable("MstGoalsRuless");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MstGoalsRulesses)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MstGoalsRuless_MstCalendar");
            });

            modelBuilder.Entity<MstGrading>(entity =>
            {
                entity.ToTable("MstGrading");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllowanceCode).HasMaxLength(4000);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Glcode)
                    .HasMaxLength(50)
                    .HasColumnName("GLCode");

                entity.Property(e => e.Gldescription)
                    .HasMaxLength(200)
                    .HasColumnName("GLDescription");

                entity.Property(e => e.MaxSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pbid).HasColumnName("PBID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<MstGratuity>(entity =>
            {
                entity.ToTable("MstGratuity");

                entity.Property(e => e.BasedOn).HasMaxLength(10);

                entity.Property(e => e.BasedOnLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BasedOnLOVType");

                entity.Property(e => e.BasedOnValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Factor).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgAbsoluteYears).HasColumnName("flgAbsoluteYears");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgEffectiveDate).HasColumnName("flgEffectiveDate");

                entity.Property(e => e.FlgWopleaves).HasColumnName("flgWOPLeaves");

                entity.Property(e => e.GratuityLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("GratuityLOVType");

                entity.Property(e => e.GratuityName).HasMaxLength(50);

                entity.Property(e => e.GratuityType).HasMaxLength(10);

                entity.Property(e => e.GrtCode).HasMaxLength(50);

                entity.Property(e => e.SalaryLovType).HasMaxLength(20);

                entity.Property(e => e.SalaryType).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.YearFrom).HasMaxLength(10);

                entity.Property(e => e.YearTo).HasMaxLength(10);
            });

            modelBuilder.Entity<MstGratuityDetail>(entity =>
            {
                entity.ToTable("MstGratuityDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DaysCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Factor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FactorContractEnd).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FactorRes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FactorTerm).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FromPoints).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToPoints).HasColumnType("numeric(19, 6)");

                entity.HasOne(d => d.Grat)
                    .WithMany(p => p.MstGratuityDetails)
                    .HasForeignKey(d => d.GratId)
                    .HasConstraintName("FK_MstGratuityDetail_MstGratuity");
            });

            modelBuilder.Entity<MstGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MstGroup");

                entity.Property(e => e.GroupDescription).HasMaxLength(250);

                entity.Property(e => e.GroupName).HasMaxLength(250);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<MstHierarchySetup>(entity =>
            {
                entity.ToTable("MstHierarchySetup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstHoliday>(entity =>
            {
                entity.HasIndex(e => e.Holiday, "IX_MstHolidays")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Holiday).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.Property(e => e.WeekNumbering)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.WeekendFrom).HasMaxLength(20);

                entity.Property(e => e.WeekendTo).HasMaxLength(20);
            });

            modelBuilder.Entity<MstHolidayDetail>(entity =>
            {
                entity.ToTable("MstHolidayDetail");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Hid).HasColumnName("HId");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.HidNavigation)
                    .WithMany(p => p.MstHolidayDetails)
                    .HasForeignKey(d => d.Hid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstHolidayDetail_MstHolidays");
            });

            modelBuilder.Entity<MstIncrementBracket>(entity =>
            {
                entity.ToTable("MstIncrementBracket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.IncrementPercentage)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("incrementPercentage");

                entity.Property(e => e.ScoreEnd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("scoreEnd");

                entity.Property(e => e.ScoreStart)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("scoreStart");
            });

            modelBuilder.Entity<MstInstitute>(entity =>
            {
                entity.ToTable("MstInstitute");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.County).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.MstInstitutes)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_MstInstitute_MstCity");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstInstitutes)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_MstInstitute_MstCountry");
            });

            modelBuilder.Entity<MstInterviewAssessmentCategory>(entity =>
            {
                entity.ToTable("MstInterviewAssessmentCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FlgDetailPart).HasColumnName("flgDetailPart");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<MstInterviewAssessmentQuestion>(entity =>
            {
                entity.ToTable("MstInterviewAssessmentQuestion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DesignationId).HasColumnName("Designation_ID");

                entity.Property(e => e.InterviewAssessmentCategoryId).HasColumnName("InterviewAssessmentCategory_ID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.Statement).HasMaxLength(200);

                entity.Property(e => e.VacancyId).HasColumnName("Vacancy_ID");

                entity.HasOne(d => d.InterviewAssessmentCategory)
                    .WithMany(p => p.MstInterviewAssessmentQuestions)
                    .HasForeignKey(d => d.InterviewAssessmentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstInterviewAssessmentQuestion_MstInterviewAssessmentCategory");
            });

            modelBuilder.Entity<MstJobDesignation>(entity =>
            {
                entity.ToTable("MstJobDesignation");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.JobPosition).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParentDesignation).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstJobTitle>(entity =>
            {
                entity.ToTable("MstJobTitle");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstKpirule>(entity =>
            {
                entity.ToTable("MstKPIRules");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasicKpipercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("basicKPIPercent");

                entity.Property(e => e.DeptKpipercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("deptKPIPercent");

                entity.Property(e => e.MaxBasicKpicount).HasColumnName("maxBasicKPICount");

                entity.Property(e => e.MaxdeptKpicount).HasColumnName("maxdeptKPICount");

                entity.Property(e => e.MinBasicKpicount).HasColumnName("minBasicKPICount");

                entity.Property(e => e.MindeptKpicount).HasColumnName("mindeptKPICount");
            });

            modelBuilder.Entity<MstLanguage>(entity =>
            {
                entity.ToTable("MstLanguage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstLanguage1>(entity =>
            {
                entity.ToTable("MstLanguages");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstLeaveCalendar>(entity =>
            {
                entity.ToTable("MstLeaveCalendar");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstLeaveConditionalDeduction>(entity =>
            {
                entity.ToTable("MstLeaveConditionalDeduction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeductableLeave).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.NonDeductableLeave).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLeaveDeduction>(entity =>
            {
                entity.ToTable("MstLeaveDeduction");

                entity.HasIndex(e => e.Code, "IX_MstLeaveDeduction")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionValue)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.TypeofDeduction).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstLeaveType>(entity =>
            {
                entity.ToTable("MstLeaveType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionId).HasColumnName("DeductionID");

                entity.Property(e => e.DeductionType).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ElementCode).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgAllowInProbation).HasColumnName("flgAllowInProbation");

                entity.Property(e => e.FlgCarryForward).HasColumnName("flgCarryForward");

                entity.Property(e => e.FlgEncash).HasColumnName("flgEncash");

                entity.Property(e => e.FlgEndOfService).HasColumnName("flgEndOfService");

                entity.Property(e => e.FlgNoticePeriod).HasColumnName("flgNoticePeriod");

                entity.Property(e => e.FlgPartiallyEncash).HasColumnName("flgPartiallyEncash");

                entity.Property(e => e.FlgProRate).HasColumnName("flgProRate");

                entity.Property(e => e.LeaveCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MonthCollapse).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLoan>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ElementCode).HasMaxLength(100);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgMultiple).HasColumnName("flgMultiple");

                entity.Property(e => e.FlgPf).HasColumnName("flgPF");

                entity.Property(e => e.FlgPfloan).HasColumnName("flgPFLoan");

                entity.Property(e => e.GratuityCode).HasMaxLength(100);

                entity.Property(e => e.LoanValue).HasColumnType("numeric(8, 6)");

                entity.Property(e => e.MarkUpRate).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Pfcap)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PFCap");

                entity.Property(e => e.TotalLoanCap).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstLocation>(entity =>
            {
                entity.ToTable("MstLocation");

                entity.Property(e => e.AttandanceId)
                    .HasMaxLength(100)
                    .HasColumnName("AttandanceID");

                entity.Property(e => e.BankCode).HasMaxLength(100);

                entity.Property(e => e.CostCenter).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.SbodocEntry).HasColumnName("SBODocEntry");

                entity.Property(e => e.TradeLicenseNo).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<MstLove>(entity =>
            {
                entity.ToTable("MstLOVE");

                entity.HasIndex(e => new { e.Code, e.Type }, "IX_MstLOVEUnique")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Language).HasMaxLength(30);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<MstMemberShip>(entity =>
            {
                entity.ToTable("MstMemberShip");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<MstMenuList>(entity =>
            {
                entity.ToTable("MstMenuList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormLogicalName).HasMaxLength(150);

                entity.Property(e => e.FormLogicalNameAr)
                    .HasMaxLength(250)
                    .HasColumnName("FormLogicalNameAR");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Menu)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("menu");
            });

            modelBuilder.Entity<MstMpp>(entity =>
            {
                entity.ToTable("MstMPP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationLevelId).HasColumnName("DesignationLevelID");

                entity.Property(e => e.Fiscalyear).HasColumnName("fiscalyear");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgPublish).HasColumnName("flgPublish");

                entity.Property(e => e.HeadCount).HasColumnName("headCount");

                entity.Property(e => e.Level).HasColumnName("level_");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.OccupiedPositionsCurrent).HasDefaultValueSql("((0))");

                entity.Property(e => e.OccupiedPositionsInitial).HasDefaultValueSql("((0))");

                entity.Property(e => e.OpenVacancyCount)
                    .HasColumnName("openVacancyCount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Parentcode).HasColumnName("parentcode");

                entity.Property(e => e.Project).HasMaxLength(200);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.RemainingVacancy).HasColumnName("remainingVacancy");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VacancyExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstBranches1");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstDepartment1");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstDesignation1");

                entity.HasOne(d => d.FiscalyearNavigation)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.Fiscalyear)
                    .HasConstraintName("FK_MstMPP_MstCalendar1");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_MstMPP_MstLocation1");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.MstMpps)
                    .HasForeignKey(d => d.VacancyId)
                    .HasConstraintName("FK_MstMPP_TrnsVacancyRequest");
            });

            modelBuilder.Entity<MstNoficationCategory>(entity =>
            {
                entity.ToTable("MstNoficationCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstObjective>(entity =>
            {
                entity.ToTable("MstObjective");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoEwaight).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxWaight).HasMaxLength(50);

                entity.Property(e => e.MinWaight).HasMaxLength(50);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.MstObjectives)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_MstObjective_MstCalendar");
            });

            modelBuilder.Entity<MstOccupationType>(entity =>
            {
                entity.ToTable("MstOccupationType");

                entity.HasIndex(e => e.Code, "IX_MstOccupationType")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstOverTime>(entity =>
            {
                entity.ToTable("MstOverTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Days).HasMaxLength(10);

                entity.Property(e => e.DaysinYear).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Expression).HasMaxLength(1000);

                entity.Property(e => e.FixValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDefault).HasColumnName("flgDefault");

                entity.Property(e => e.FlgFormula).HasColumnName("flgFormula");

                entity.Property(e => e.FlgPerHour).HasColumnName("flgPerHour");

                entity.Property(e => e.Hour).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Hours).HasMaxLength(10);

                entity.Property(e => e.MaxHour).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MonthDays).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerDayCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PerMonthCap).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ValueLOVType");

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.Property(e => e.Weeks).HasMaxLength(10);
            });

            modelBuilder.Entity<MstPart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MstParts)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_MstParts_MstDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstParts)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstParts_MstDesignation");
            });

            modelBuilder.Entity<MstPartnerFeedback>(entity =>
            {
                entity.ToTable("MstPartnerFeedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Weightage).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MstPartnerFeedbackAssign>(entity =>
            {
                entity.ToTable("MstPartnerFeedbackAssign");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FunctionName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstPartnerFeedbackAssigns)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstPartnerFeedbackAssign_MstEmployee");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.MstPartnerFeedbackAssigns)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_MstPartnerFeedbackAssign_MstPartnerFeedback");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MstPartnerFeedbackAssigns)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MstPartnerFeedbackAssign_MstCalendar");
            });

            modelBuilder.Entity<MstPartnerFeedbackDetail>(entity =>
            {
                entity.ToTable("MstPartnerFeedbackDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetencyName).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.HfeedbackId).HasColumnName("HFeedbackId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Hfeedback)
                    .WithMany(p => p.MstPartnerFeedbackDetails)
                    .HasForeignKey(d => d.HfeedbackId)
                    .HasConstraintName("FK_MstPartnerFeedbackDetail_MstPartnerFeedback");
            });

            modelBuilder.Entity<MstPartnerFeedbackStmnt>(entity =>
            {
                entity.ToTable("MstPartnerFeedbackStmnt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Feeback)
                    .WithMany(p => p.MstPartnerFeedbackStmnts)
                    .HasForeignKey(d => d.FeebackId)
                    .HasConstraintName("FK_MstPartnerFeedbackStmnt_MstPartnerFeedback");
            });

            modelBuilder.Entity<MstPartnerFeedbackStmntDetail>(entity =>
            {
                entity.ToTable("MstPartnerFeedbackStmntDetail");

                entity.Property(e => e.CompetencyStmnt).HasMaxLength(250);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competency)
                    .WithMany(p => p.MstPartnerFeedbackStmntDetails)
                    .HasForeignKey(d => d.CompetencyId)
                    .HasConstraintName("FK_MstPartnerFeedbackStmntDetail_MstPartnerFeedbackDetail");

                entity.HasOne(d => d.FeedbackStmnt)
                    .WithMany(p => p.MstPartnerFeedbackStmntDetails)
                    .HasForeignKey(d => d.FeedbackStmntId)
                    .HasConstraintName("FK_MstPartnerFeedbackStmntDetail_MstPartnerFeedbackStmnt");
            });

            modelBuilder.Entity<MstPartnerPerformanceCategory>(entity =>
            {
                entity.ToTable("MstPartnerPerformanceCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryDescription).HasMaxLength(100);

                entity.Property(e => e.CategoryType).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Points).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstPartnerPerformanceSubCat>(entity =>
            {
                entity.ToTable("MstPartnerPerformanceSubCat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.TotalPoints).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.MstPartnerPerformanceSubCats)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_MstPartnerPerformanceSubCat_MstPartnerPerformanceCategory");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MstPartnerPerformanceSubCats)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MstPartnerPerformanceSubCat_MstCalendar");
            });

            modelBuilder.Entity<MstPartnerPerformanceSubCatDetail>(entity =>
            {
                entity.ToTable("MstPartnerPerformanceSubCatDetail");

                entity.Property(e => e.AssessmentFramework).HasMaxLength(1000);

                entity.Property(e => e.BasisOfEvaluation).HasMaxLength(1000);

                entity.Property(e => e.EvaluationLink).HasMaxLength(50);

                entity.Property(e => e.Points).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCatCode).HasMaxLength(250);

                entity.Property(e => e.SubCatDescription).HasMaxLength(1000);

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.MstPartnerPerformanceSubCatDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_MstPartnerPerformanceSubCatDetail_MstPartnerPerformanceSubCat");
            });

            modelBuilder.Entity<MstPartnerPerformanceTerm>(entity =>
            {
                entity.Property(e => e.AvailableForAvailuation).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TermDescription).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MstPartnerPerformanceTerms)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MstPartnerPerformanceTerms_MstCalendar");
            });

            modelBuilder.Entity<MstPasswordSetup>(entity =>
            {
                entity.ToTable("MstPasswordSetup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstPayBand>(entity =>
            {
                entity.ToTable("MstPayBand");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Gl)
                    .HasMaxLength(250)
                    .HasColumnName("GL");

                entity.Property(e => e.PayBandName).HasMaxLength(150);

                entity.Property(e => e.SalaryRangeFrom).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalaryRangeTo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WeekDayRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeekendRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WrkHrsinWeek).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MstPenaltyRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<MstPerformanceAssessmentCriterion>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstPerformanceBasedPolicy>(entity =>
            {
                entity.ToTable("MStPerformanceBasedPolicy");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("createdBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.Pbid).HasColumnName("PBID");

                entity.Property(e => e.ServiceYear).HasColumnName("serviceYear");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Pb)
                    .WithMany(p => p.MstPerformanceBasedPolicies)
                    .HasForeignKey(d => d.Pbid)
                    .HasConstraintName("FK_MStPerformanceBasedPolicy_MstBonus");
            });

            modelBuilder.Entity<MstPerformanceRating>(entity =>
            {
                entity.ToTable("MstPerformanceRating");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstPerformanceTerm>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailableForEvaluation).HasColumnType("datetime");

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgCommitmentAllowance).HasColumnName("FlgCommitmentALlowance");

                entity.Property(e => e.FlgPerformanceBonus).HasColumnName("FLgPerformanceBonus");

                entity.Property(e => e.NotificationDaysForAppraise).HasColumnName("NotificationDaysForAPpraise");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TermDescription).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MstPerformanceTerms)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MstPerformanceTerms_MstCalendar");
            });

            modelBuilder.Entity<MstPosition>(entity =>
            {
                entity.ToTable("MstPosition");

                entity.Property(e => e.Attachment).HasMaxLength(500);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MaxGradeId).HasColumnName("MaxGradeID");

                entity.Property(e => e.MinGradeId).HasColumnName("MinGradeID");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SbodocEntry).HasColumnName("SBODocEntry");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstProbationCategory>(entity =>
            {
                entity.ToTable("MstProbationCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attribute).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.DesignationId).HasColumnName("designationID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstProbationCategories)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstProbationCategory_MstDesignation");

                entity.HasOne(d => d.YearNavigation)
                    .WithMany(p => p.MstProbationCategories)
                    .HasForeignKey(d => d.Year)
                    .HasConstraintName("FK_MstProbationCategory_MstCalendar");
            });

            modelBuilder.Entity<MstProbationCategoryChildDesignation>(entity =>
            {
                entity.ToTable("MstProbationCategoryChild_Designation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.ProbationId).HasColumnName("ProbationID");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstProbationCategoryChildDesignations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstProbationCategoryChild_Designation_MstDesignation");

                entity.HasOne(d => d.Probation)
                    .WithMany(p => p.MstProbationCategoryChildDesignations)
                    .HasForeignKey(d => d.ProbationId)
                    .HasConstraintName("FK_MstProbationCategoryChild_Designation_MstProbationCategory");
            });

            modelBuilder.Entity<MstProbationEvalCriterion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attribute).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.YearNavigation)
                    .WithMany(p => p.MstProbationEvalCriteria)
                    .HasForeignKey(d => d.Year)
                    .HasConstraintName("FK_MstProbationEvalCriteria_MstCalendar");
            });

            modelBuilder.Entity<MstProbationEvalCycle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.YearNavigation)
                    .WithMany(p => p.MstProbationEvalCycles)
                    .HasForeignKey(d => d.Year)
                    .HasConstraintName("FK_MstProbationEvalCycles_MstCalendar");
            });

            modelBuilder.Entity<MstProbationStatement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DesignationId).HasColumnName("designationID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.ProbationCategoryId).HasColumnName("ProbationCategory_ID");

                entity.Property(e => e.Statement).HasMaxLength(150);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstProbationStatements)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstProbationStatements_MstDesignation");

                entity.HasOne(d => d.ProbationCategory)
                    .WithMany(p => p.MstProbationStatements)
                    .HasForeignKey(d => d.ProbationCategoryId)
                    .HasConstraintName("FK_MstProbationStatements_MstProbationCategory");
            });

            modelBuilder.Entity<MstProbationStatementsChildDesignation>(entity =>
            {
                entity.ToTable("MstProbationStatements_ChildDesignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(30);

                entity.Property(e => e.ProbationStatementId).HasColumnName("ProbationStatementID");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstProbationStatementsChildDesignations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstProbationStatements_ChildDesignation_MstDesignation");

                entity.HasOne(d => d.ProbationStatement)
                    .WithMany(p => p.MstProbationStatementsChildDesignations)
                    .HasForeignKey(d => d.ProbationStatementId)
                    .HasConstraintName("FK_MstProbationStatements_ChildDesignation_MstProbationStatements");
            });

            modelBuilder.Entity<MstProfitCenter>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstProfitCenter");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDelete).HasColumnName("flgDelete");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstProject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstQualification>(entity =>
            {
                entity.ToTable("MstQualification");

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Ftsprof)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FTSProf")
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstRecognition>(entity =>
            {
                entity.ToTable("MstRecognition");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstRecruiter>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_MstRecruiters")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.Recruiter).HasMaxLength(50);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstReferralScheme>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Ptype)
                    .HasMaxLength(50)
                    .HasColumnName("PType");

                entity.Property(e => e.Pvalue)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PValue");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstReferralSchemes)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_MstReferralSchemes_MstElements");
            });

            modelBuilder.Entity<MstRelation>(entity =>
            {
                entity.ToTable("MstRelation");

                entity.HasIndex(e => e.Code, "IX_MstRelation")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstReport>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.ReportCode).HasMaxLength(150);

                entity.Property(e => e.ReportName).HasMaxLength(150);

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstRetroElementDetail>(entity =>
            {
                entity.ToTable("MstRetroElementDetail");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MstRetroElementDetails)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_MstRetroElementDetail_MstElements");

                entity.HasOne(d => d.Retro)
                    .WithMany(p => p.MstRetroElementDetails)
                    .HasForeignKey(d => d.RetroId)
                    .HasConstraintName("FK_MstRetroElementDetail_MstRetroElementSet1");
            });

            modelBuilder.Entity<MstRetroElementSet>(entity =>
            {
                entity.ToTable("MstRetroElementSet");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.RetroSetCode).HasMaxLength(10);

                entity.Property(e => e.RetroSetName).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstSecondment>(entity =>
            {
                entity.ToTable("MstSecondment");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CurrentPaymentMode).HasMaxLength(10);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.DimensionName).HasMaxLength(50);

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Extension)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.HostOfficeName).HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasMaxLength(50);

                entity.Property(e => e.ProjectName).HasMaxLength(50);

                entity.Property(e => e.ReleaseAttachment).HasMaxLength(500);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.ReleaseRef).HasColumnName("releaseRef");

                entity.Property(e => e.Remarks).HasMaxLength(251);

                entity.Property(e => e.ReturnAttachment).HasMaxLength(500);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.TypeDocument).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstSecondments)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_MstSecondment_MstEmployee");
            });

            modelBuilder.Entity<MstSector>(entity =>
            {
                entity.ToTable("MstSector");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstSetting>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlgRptCeo).HasColumnName("flgRptCEO");

                entity.Property(e => e.Term).HasColumnName("term");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<MstShift>(entity =>
            {
                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeductionRuleId).HasColumnName("DeductionRuleID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Duration).HasMaxLength(20);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgHoliDayOverTime).HasColumnName("flgHoliDayOverTime");

                entity.Property(e => e.FlgInTimeOverlap).HasColumnName("flgInTimeOverlap");

                entity.Property(e => e.FlgLeaveDeductionOnWorkingHours).HasColumnName("flgLeaveDeductionOnWorkingHours");

                entity.Property(e => e.FlgOffDayOverTime).HasColumnName("flgOffDayOverTime");

                entity.Property(e => e.FlgOtwrkHrs).HasColumnName("flgOTWrkHrs");

                entity.Property(e => e.FlgOutTimeOverlap).HasColumnName("flgOutTimeOverlap");

                entity.Property(e => e.FlgOverTime).HasColumnName("flgOverTime");

                entity.Property(e => e.FlgWorkingHoursOnMultipTimeInTimeOut).HasColumnName("flgWorkingHoursOnMultipTimeInTimeOut");

                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");

                entity.Property(e => e.Send)
                    .HasMaxLength(10)
                    .HasColumnName("SEnd");

                entity.Property(e => e.ShiftLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ShiftLOVType");

                entity.Property(e => e.ShiftType).HasMaxLength(10);

                entity.Property(e => e.Sstart)
                    .HasMaxLength(10)
                    .HasColumnName("SStart");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<MstShiftBreak>(entity =>
            {
                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duration");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endTime");

                entity.Property(e => e.SeqNum).HasColumnName("seqNum");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("startTime");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.MstShiftBreaks)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_MstShiftBreaks_MstShifts");
            });

            modelBuilder.Entity<MstShiftDay>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstShiftDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicableTime).HasMaxLength(20);

                entity.Property(e => e.BreakTime).HasMaxLength(20);

                entity.Property(e => e.BufferEndTime).HasMaxLength(20);

                entity.Property(e => e.BufferStartTime).HasMaxLength(20);

                entity.Property(e => e.Day).HasMaxLength(20);

                entity.Property(e => e.Duration).HasMaxLength(20);

                entity.Property(e => e.EndGraceTime).HasMaxLength(20);

                entity.Property(e => e.EndTime).HasMaxLength(10);

                entity.Property(e => e.FlgExpectedIn).HasColumnName("flgExpectedIn");

                entity.Property(e => e.FlgExpectedOut).HasColumnName("flgExpectedOut");

                entity.Property(e => e.FlgInOverlap).HasColumnName("flgInOverlap");

                entity.Property(e => e.FlgOutOverlap).HasColumnName("flgOutOverlap");

                entity.Property(e => e.LunchHours).HasMaxLength(10);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartGraceTime).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasMaxLength(10);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.MstShiftDetails)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_MstShiftDetails_MstShifts");
            });

            modelBuilder.Entity<MstSkill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<MstSpecialDay>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<MstStage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.StageDescription).HasMaxLength(150);

                entity.Property(e => e.StageName).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MstStages)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_MstStages_MstLocation");
            });

            modelBuilder.Entity<MstStageDetail>(entity =>
            {
                entity.ToTable("MstStageDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MstStageDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_MstStageDetail_MstEmployee");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.MstStageDetails)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_MstStageDetail_MstStages");
            });

            modelBuilder.Entity<MstState>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.StateName).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.MstStates)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_MstStates_MstCountry");
            });

            modelBuilder.Entity<MstStation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstSubCategory>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("MstSubCategory");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<MstSubPartsStatement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Budget).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ChkFirstEval).HasColumnName("chkFirstEval");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(20)
                    .HasColumnName("docStatus");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.HowToAchieve)
                    .HasMaxLength(1000)
                    .HasColumnName("howToAchieve");

                entity.Property(e => e.Statement).HasMaxLength(500);

                entity.Property(e => e.SubPartId).HasColumnName("subPartID");

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Weightage).HasColumnName("weightage");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MstSubPartsStatements)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_MstSubPartsStatements_MstDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstSubPartsStatements)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstSubPartsStatements_MstDesignation");

                entity.HasOne(d => d.SubPart)
                    .WithMany(p => p.MstSubPartsStatements)
                    .HasForeignKey(d => d.SubPartId)
                    .HasConstraintName("FK_MstSubPartsStatements_MstSubPartss");
            });

            modelBuilder.Entity<MstSubPartss>(entity =>
            {
                entity.ToTable("MstSubPartss");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MstSubPartsses)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_MstSubPartss_MstDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstSubPartsses)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstSubPartss_MstDesignation");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.MstSubPartsses)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK_MstSubPartss_MstParts");
            });

            modelBuilder.Entity<MstTeam>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstTrainingAttachment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Deteled).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocContent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Content");

                entity.Property(e => e.DocName).HasMaxLength(150);

                entity.Property(e => e.Extention)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.MstTrainingAttachments)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_MstTrainingAttachments_TrnsTrainingPlan");
            });

            modelBuilder.Entity<MstTrainingBudget>(entity =>
            {
                entity.ToTable("MstTrainingBudget");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminBudget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FiscalYearId).HasColumnName("FiscalYearID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LogisticBudget).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RemainingBudget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TotalBudget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrainingBudget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrainingCategoryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VenueBudget).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MstTrainingCategory>(entity =>
            {
                entity.ToTable("MstTrainingCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TrainingPlace).HasMaxLength(50);

                entity.Property(e => e.TypeOfTraining).HasMaxLength(50);
            });

            modelBuilder.Entity<MstTrainingCourse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.TrainingCategoryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstTrainingEvaluationCategory>(entity =>
            {
                entity.ToTable("MstTrainingEvaluationCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstTrainingFeedback>(entity =>
            {
                entity.ToTable("MstTrainingFeedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Statement).HasMaxLength(1000);

                entity.Property(e => e.TrainPlanId).HasColumnName("TrainPlanID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.TrainPlan)
                    .WithMany(p => p.MstTrainingFeedbacks)
                    .HasForeignKey(d => d.TrainPlanId)
                    .HasConstraintName("FK_MstTrainingFeedback_TrnsTrainingPlan");
            });

            modelBuilder.Entity<MstTrainingNeedAssesment>(entity =>
            {
                entity.ToTable("MstTrainingNeedAssesment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MstTrainingNeedAssesments)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_MstTrainingNeedAssesment_MstTrainingCategory");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.MstTrainingNeedAssesments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_MstTrainingNeedAssesment_MstTrainingCourses");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MstTrainingNeedAssesments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_MstTrainingNeedAssesment_MstEmployee");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.MstTrainingNeedAssesments)
                    .HasForeignKey(d => d.EvaluationId)
                    .HasConstraintName("FK_MstTrainingNeedAssesment_TrnsPerformanceEvaluationHead");
            });

            modelBuilder.Entity<MstTrainingProvider>(entity =>
            {
                entity.ToTable("MstTrainingProvider");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstTrainingStatement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Statement).HasMaxLength(150);

                entity.Property(e => e.TrainingEvalCategoryId).HasColumnName("TrainingEvalCategoryID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.TrainingEvalCategory)
                    .WithMany(p => p.MstTrainingStatements)
                    .HasForeignKey(d => d.TrainingEvalCategoryId)
                    .HasConstraintName("FK_MstTrainingStatements_MstTrainingEvaluationCategory");
            });

            modelBuilder.Entity<MstTrainingStatementAttach>(entity =>
            {
                entity.ToTable("MstTrainingStatementAttach");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Statement).HasMaxLength(200);
            });

            modelBuilder.Entity<MstTrainingVenue>(entity =>
            {
                entity.ToTable("MstTrainingVenue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstTravelExpense>(entity =>
            {
                entity.ToTable("MstTravelExpense");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarAllwnc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyAllowanceWd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DailyAllowanceWD");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EntertainmentAllwnc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FareKm)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("FareKM");

                entity.Property(e => e.MedicalAllowance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MobileAllwnc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MotorBikeAllwnc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NightStay).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutBack).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MstTravelExpenses)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MstTravelExpense_MstDesignation");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_MstUsers")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.FlgActiveUser)
                    .HasColumnName("flgActiveUser")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FlgPasswordRequest).HasColumnName("flgPasswordRequest");

                entity.Property(e => e.FlgWebUser)
                    .HasColumnName("flgWebUser")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MultiLogin)
                    .HasColumnName("Multi_Login")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassCode).HasMaxLength(40);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(30);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.MstUsers)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_MstUsers_Employee");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.MstUsers)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_MstUsers_MstLanguages");
            });

            modelBuilder.Entity<MstUserBranchMapping>(entity =>
            {
                entity.ToTable("MstUserBranchMapping");

                entity.Property(e => e.AssignDate).HasColumnType("datetime");

                entity.Property(e => e.DeAssignDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MstUserFunction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.FunctionName).HasMaxLength(150);

                entity.Property(e => e.MenuId)
                    .HasMaxLength(150)
                    .HasColumnName("MenuID");
            });

            modelBuilder.Entity<MstUserRoleRight>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Anthorization)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MstUsersAuth>(entity =>
            {
                entity.ToTable("MstUsersAuth");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FunctionId).HasColumnName("FunctionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRights).HasMaxLength(50);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.MstUsersAuths)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_MstUsersAuth_MstUsersAuth");
            });

            modelBuilder.Entity<MstVacancyType>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_MstVacancyTypes")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<MstWarningLetter>(entity =>
            {
                entity.ToTable("MstWarningLetter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Mulg>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.ToTable("MULG");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.EventDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Event_Date");

                entity.Property(e => e.FlgActiveUser).HasColumnName("flgActiveUser");

                entity.Property(e => e.FlgWebUser).HasColumnName("flgWebUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MultiLogin).HasColumnName("Multi_Login");

                entity.Property(e => e.PassCode).HasMaxLength(50);

                entity.Property(e => e.Uip)
                    .HasMaxLength(255)
                    .HasColumnName("UIP");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserCode).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Wun)
                    .HasMaxLength(50)
                    .HasColumnName("WUN");
            });

            modelBuilder.Entity<NeskCfgApprovalDecisionRegister>(entity =>
            {
                entity.ToTable("Nesk_CfgApprovalDecisionRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproverEmailId)
                    .HasMaxLength(450)
                    .HasColumnName("ApproverEmailID");

                entity.Property(e => e.ApproverId).HasColumnName("ApproverID");

                entity.Property(e => e.ApproverName).HasMaxLength(150);

                entity.Property(e => e.DocHirerchyId).HasColumnName("DocHirerchyID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LevelDesc).HasMaxLength(150);

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.LineStatusId)
                    .HasMaxLength(150)
                    .HasColumnName("LineStatusID");

                entity.Property(e => e.LineStatusLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("LineStatusLOVType");

                entity.Property(e => e.PendingAtLevelId).HasColumnName("PendingAtLevelID");

                entity.Property(e => e.Remarks).HasMaxLength(350);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.NeskCfgApprovalDecisionRegisterApprovers)
                    .HasForeignKey(d => d.ApproverId)
                    .HasConstraintName("FK_Nesk_CfgApprovalDecisionRegister_MstEmployee1");

                entity.HasOne(d => d.DocHirerchy)
                    .WithMany(p => p.NeskCfgApprovalDecisionRegisters)
                    .HasForeignKey(d => d.DocHirerchyId)
                    .HasConstraintName("FK_Nesk_CfgApprovalDecisionRegister_Nesk_CfgDocHierarchy");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.NeskCfgApprovalDecisionRegisterEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_Nesk_CfgApprovalDecisionRegister_MstEmployee");
            });

            modelBuilder.Entity<NeskCfgDocHierarchy>(entity =>
            {
                entity.ToTable("Nesk_CfgDocHierarchy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.DocDesc).HasMaxLength(150);

                entity.Property(e => e.FlgFollowHierarchy).HasColumnName("flg_followHierarchy");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.NeskCfgDocHierarchies)
                    .HasForeignKey(d => d.DepartId)
                    .HasConstraintName("FK_Nesk_CfgDocHierarchy_MstDepartment");
            });

            modelBuilder.Entity<NeskCfgDocHierarchyDetail>(entity =>
            {
                entity.ToTable("Nesk_CfgDocHierarchyDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocHirerchyId).HasColumnName("DocHirerchyID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.HirerchyLevelDesc).HasMaxLength(150);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DocHirerchy)
                    .WithMany(p => p.NeskCfgDocHierarchyDetails)
                    .HasForeignKey(d => d.DocHirerchyId)
                    .HasConstraintName("FK_Nesk_CfgDocHierarchyDetail_Nesk_CfgDocHierarchy");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.NeskCfgDocHierarchyDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_Nesk_CfgDocHierarchyDetail_MstEmployee");
            });

            modelBuilder.Entity<NeskTrnsAttendanceRegister>(entity =>
            {
                entity.ToTable("Nesk_TrnsAttendanceRegister");

                entity.Property(e => e.AdjDays)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("adjDays");

                entity.Property(e => e.AdjHrs)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("adjHrs");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EarlyInMin).HasMaxLength(10);

                entity.Property(e => e.EarlyOutMin).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.HrsRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LateInMin).HasMaxLength(10);

                entity.Property(e => e.LateOutMin).HasMaxLength(10);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.TimeInFst).HasMaxLength(10);

                entity.Property(e => e.TimeInSecond).HasMaxLength(10);

                entity.Property(e => e.TimeOutFst).HasMaxLength(10);

                entity.Property(e => e.TimeOutSecond).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.WorkHour).HasMaxLength(10);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.NeskTrnsAttendanceRegisters)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_Nesk_TrnsAttendanceRegister_MstShifts");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.ToTable("PasswordReset");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.EncryptKey)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PerformanceStatementTermAttachment>(entity =>
            {
                entity.ToTable("PerformanceStatementTermAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actual).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.HowToAchieve).HasMaxLength(1000);

                entity.Property(e => e.Percentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StatementId).HasColumnName("StatementID");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Weightage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Statement)
                    .WithMany(p => p.PerformanceStatementTermAttachments)
                    .HasForeignKey(d => d.StatementId)
                    .HasConstraintName("FK_PerformanceStatementTermAttachment_MstSubPartsStatements");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.PerformanceStatementTermAttachments)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_PerformanceStatementTermAttachment_MstPerformanceTerms");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.PerformanceStatementTermAttachments)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_PerformanceStatementTermAttachment_MstCalendar");
            });

            modelBuilder.Entity<PfLoanAmtView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PF_Loan_Amt_View");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.PfLoanAmt)
                    .HasColumnType("numeric(38, 6)")
                    .HasColumnName("PF_Loan_Amt");
            });

            modelBuilder.Entity<RoosterInput>(entity =>
            {
                entity.ToTable("RoosterInput");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.Shift)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shift");

                entity.Property(e => e.Year)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<RoosterInput61>(entity =>
            {
                entity.ToTable("RoosterInput61");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.Shift)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shift");

                entity.Property(e => e.Year)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<RoosterTable>(entity =>
            {
                entity.ToTable("RoosterTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.GroupA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupA");

                entity.Property(e => e.GroupB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupB");

                entity.Property(e => e.GroupC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupC");

                entity.Property(e => e.GroupD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupD");

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<RoosterTable61>(entity =>
            {
                entity.ToTable("RoosterTable61");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.GroupA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupA");

                entity.Property(e => e.GroupB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupB");

                entity.Property(e => e.GroupC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupC");

                entity.Property(e => e.GroupD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupD");

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<SalaryDeduction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SalaryDeductions");

                entity.Property(e => e.Deduction1).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Deduction2).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Deduction3).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Deduction4).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Deduction5).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<SalaryEarning>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SalaryEarnings");

                entity.Property(e => e.Earning1).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Earning2).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Earning3).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Earning4).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Earning5).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<SalaryEmployerContrbution>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SalaryEmployerContrbutions");

                entity.Property(e => e.Contribution1).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Contribution2).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Contribution3).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Contribution4).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Contribution5).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<SalaryLetter>(entity =>
            {
                entity.HasKey(e => e.SelLetId)
                    .HasName("PK__SalaryLe__24E37034E9C0AC19");

                entity.ToTable("SalaryLetter");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("docDate");

                entity.Property(e => e.DocNum).HasColumnName("docNum");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.SalaryLetters)
                    .HasForeignKey(d => d.EmployeeCode)
                    .HasConstraintName("FK_SalaryLetter_MstEmployee");
            });

            modelBuilder.Entity<SendEmail>(entity =>
            {
                entity.ToTable("SendEmail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Msg).HasColumnName("msg");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<StdElement>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StdElements");

                entity.Property(e => e.ElementName).HasMaxLength(100);

                entity.Property(e => e.FlgStandardElement).HasColumnName("flgStandardElement");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StdElements2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StdElements2");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EnglishName).HasMaxLength(300);
            });

            modelBuilder.Entity<TblRpt>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("tblRpts");

                entity.Property(e => e.FlgCritaria).HasColumnName("flgCritaria");

                entity.Property(e => e.FlgDateFrom).HasColumnName("flgDateFrom");

                entity.Property(e => e.FlgDateTo).HasColumnName("flgDateTo");

                entity.Property(e => e.FlgDept).HasColumnName("flgDept");

                entity.Property(e => e.FlgEmployee).HasColumnName("flgEmployee");

                entity.Property(e => e.FlgLocation).HasColumnName("flgLocation");

                entity.Property(e => e.FlgPeriod).HasColumnName("flgPeriod");

                entity.Property(e => e.FlgPreviousPeriod).HasColumnName("flgPreviousPeriod");

                entity.Property(e => e.FlgSystem).HasColumnName("flgSystem");

                entity.Property(e => e.ReportIn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("reportIn");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RptCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rptCode");

                entity.Property(e => e.RptFileStr).HasColumnName("rptFileStr");
            });

            modelBuilder.Entity<TmpEmp>(entity =>
            {
                entity.ToTable("tmpEmps");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empId");
            });

            modelBuilder.Entity<TmpMsXxMstEmployee>(entity =>
            {
                entity.ToTable("tmp_ms_xx_MstEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNo).HasMaxLength(200);

                entity.Property(e => e.AccountTitle).HasMaxLength(100);

                entity.Property(e => e.AccountType).HasMaxLength(10);

                entity.Property(e => e.AllowedAdvance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ArabicName).HasMaxLength(150);

                entity.Property(e => e.BankBranch).HasMaxLength(150);

                entity.Property(e => e.BankBranchCode).HasMaxLength(10);

                entity.Property(e => e.BankCardExpiryDt).HasMaxLength(100);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BasicGrossRatio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BloodGroupId)
                    .HasMaxLength(10)
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("BloodGroupLOVType");

                entity.Property(e => e.BonusCode).HasMaxLength(50);

                entity.Property(e => e.BonusPoints).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.CandidateCast)
                    .HasMaxLength(50)
                    .HasColumnName("candidate_cast");

                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ContrEnddate).HasColumnType("datetime");

                entity.Property(e => e.ContrStartDate).HasColumnType("datetime");

                entity.Property(e => e.ContractExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CvPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cv_path");

                entity.Property(e => e.DefaultOffDay).HasMaxLength(50);

                entity.Property(e => e.DefaultShift).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.DrivingLic)
                    .HasMaxLength(50)
                    .HasColumnName("Driving_lic");

                entity.Property(e => e.DrvLicCompletionDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicLastDt).HasMaxLength(100);

                entity.Property(e => e.DrvLicReleaseDt).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.ElementHeadId).HasColumnName("ElementHeadID");

                entity.Property(e => e.EmpCalender).HasMaxLength(50);

                entity.Property(e => e.EmpCardExp)
                    .HasColumnType("datetime")
                    .HasColumnName("empCardExp");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpUnion).HasMaxLength(10);

                entity.Property(e => e.EmployeeContractType).HasMaxLength(20);

                entity.Property(e => e.EnglishName).HasMaxLength(300);

                entity.Property(e => e.Eobino)
                    .HasMaxLength(50)
                    .HasColumnName("EOBINo");

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgBlackListed).HasColumnName("flgBlackListed");

                entity.Property(e => e.FlgBonus).HasColumnName("flgBonus");

                entity.Property(e => e.FlgCompanyResidence).HasColumnName("flgCompanyResidence");

                entity.Property(e => e.FlgEmail).HasColumnName("flgEmail");

                entity.Property(e => e.FlgEobi).HasColumnName("flgEOBI");

                entity.Property(e => e.FlgFlexibleShift).HasColumnName("flgFlexibleShift");

                entity.Property(e => e.FlgGratuity).HasColumnName("flgGratuity");

                entity.Property(e => e.FlgHold).HasColumnName("flgHold");

                entity.Property(e => e.FlgHruser).HasColumnName("flgHRUser");

                entity.Property(e => e.FlgOffDayApplicable).HasColumnName("flgOffDayApplicable");

                entity.Property(e => e.FlgOnLeave).HasColumnName("flgOnLeave");

                entity.Property(e => e.FlgOtapplicable).HasColumnName("flgOTApplicable");

                entity.Property(e => e.FlgPerPiece).HasColumnName("flgPerPiece");

                entity.Property(e => e.FlgProbation).HasColumnName("flgProbation");

                entity.Property(e => e.FlgSandwich).HasColumnName("flgSandwich");

                entity.Property(e => e.FlgShopManager).HasColumnName("flgShopManager");

                entity.Property(e => e.FlgSocialSecurity).HasColumnName("flgSocialSecurity");

                entity.Property(e => e.FlgSuperVisor).HasColumnName("flgSuperVisor");

                entity.Property(e => e.FlgTax).HasColumnName("flgTax");

                entity.Property(e => e.FlgUser).HasColumnName("flgUser");

                entity.Property(e => e.GenderId)
                    .HasMaxLength(10)
                    .HasColumnName("GenderID");

                entity.Property(e => e.GenderLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("GenderLOVType");

                entity.Property(e => e.GosiSalary).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.GradeLevelId).HasColumnName("GradeLevelID");

                entity.Property(e => e.GratuityName).HasMaxLength(50);

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.GrossSalaryHired).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Hablock)
                    .HasMaxLength(50)
                    .HasColumnName("HABlock");

                entity.Property(e => e.Hacity)
                    .HasMaxLength(100)
                    .HasColumnName("HACity");

                entity.Property(e => e.Hacountry)
                    .HasMaxLength(100)
                    .HasColumnName("HACountry");

                entity.Property(e => e.Haother)
                    .HasMaxLength(500)
                    .HasColumnName("HAOther");

                entity.Property(e => e.Hastate)
                    .HasMaxLength(100)
                    .HasColumnName("HAState");

                entity.Property(e => e.Hastreet)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreet");

                entity.Property(e => e.HastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("HAStreetNo");

                entity.Property(e => e.HazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("HAZipCode");

                entity.Property(e => e.HoldDate).HasColumnType("datetime");

                entity.Property(e => e.HoldReasons).HasMaxLength(500);

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.HrBaseCalendar).HasMaxLength(20);

                entity.Property(e => e.IddateofIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("IDDateofIssue");

                entity.Property(e => e.IdexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDExpiryDate");

                entity.Property(e => e.IdexpiryDt)
                    .HasMaxLength(100)
                    .HasColumnName("IDExpiryDt");

                entity.Property(e => e.IdissuedBy)
                    .HasMaxLength(50)
                    .HasColumnName("IDIssuedBy");

                entity.Property(e => e.Idno)
                    .HasMaxLength(20)
                    .HasColumnName("IDNo");

                entity.Property(e => e.IdplaceofIssue)
                    .HasMaxLength(20)
                    .HasColumnName("IDPlaceofIssue");

                entity.Property(e => e.Imagedata)
                    .HasMaxLength(3000)
                    .IsFixedLength();

                entity.Property(e => e.ImgPath).HasMaxLength(600);

                entity.Property(e => e.IncomeTaxNo).HasMaxLength(20);

                entity.Property(e => e.Initials).HasMaxLength(30);

                entity.Property(e => e.InsuranceCategory).HasMaxLength(50);

                entity.Property(e => e.InventoryEmail).HasMaxLength(500);

                entity.Property(e => e.IqamaProfessional).HasMaxLength(200);

                entity.Property(e => e.JobTitle).HasMaxLength(30);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LocationName).HasMaxLength(500);

                entity.Property(e => e.MartialStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("MartialStatusID");

                entity.Property(e => e.MartialStatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("MartialStatusLOVType");

                entity.Property(e => e.MedicalCardExpDt).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MoajibEmail).HasMaxLength(500);

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.MultiLogin).HasColumnName("Multi_Login");

                entity.Property(e => e.NamePrefix).HasMaxLength(30);

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.OfficeEmail).HasMaxLength(100);

                entity.Property(e => e.OfficeExtension).HasMaxLength(30);

                entity.Property(e => e.OfficeMobile).HasMaxLength(30);

                entity.Property(e => e.OfficePhone).HasMaxLength(30);

                entity.Property(e => e.OrganizationalUnit).HasMaxLength(50);

                entity.Property(e => e.Otslabs).HasColumnName("OTSlabs");

                entity.Property(e => e.Pager).HasMaxLength(30);

                entity.Property(e => e.PassportDateofIssue).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PassportExpiryDt).HasMaxLength(100);

                entity.Property(e => e.PassportNo).HasMaxLength(100);

                entity.Property(e => e.PayBandId).HasColumnName("PayBandID");

                entity.Property(e => e.PaymentMode).HasMaxLength(10);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PercentagePaid).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerformanceAllowance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PersonalContactNo).HasMaxLength(100);

                entity.Property(e => e.PersonalEmail).HasMaxLength(100);

                entity.Property(e => e.PersonalIm)
                    .HasMaxLength(100)
                    .HasColumnName("PersonalIM");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName).HasMaxLength(500);

                entity.Property(e => e.PostProbationIncrementAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("postProbationIncrementAmount");

                entity.Property(e => e.PreEmpMonth).HasMaxLength(20);

                entity.Property(e => e.PriAddress).HasMaxLength(100);

                entity.Property(e => e.PriCity).HasMaxLength(20);

                entity.Property(e => e.PriContactNoLandLine).HasMaxLength(20);

                entity.Property(e => e.PriContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.PriCountry).HasMaxLength(20);

                entity.Property(e => e.PriPersonName).HasMaxLength(100);

                entity.Property(e => e.PriRelationShip).HasMaxLength(20);

                entity.Property(e => e.PriState).HasMaxLength(20);

                entity.Property(e => e.ProfitCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.RecruitmentMode).HasMaxLength(50);

                entity.Property(e => e.ReligionId)
                    .HasMaxLength(10)
                    .HasColumnName("ReligionID");

                entity.Property(e => e.ReligionLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("ReligionLOVType");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.ReportToId).HasColumnName("ReportToID");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.RetirementDate).HasColumnType("date");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(150)
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleLovtype)
                    .HasMaxLength(150)
                    .HasColumnName("RoleLOVType");

                entity.Property(e => e.RoleName).HasMaxLength(300);

                entity.Property(e => e.SalaryCurrency).HasMaxLength(5);

                entity.Property(e => e.SboUserCode).HasMaxLength(50);

                entity.Property(e => e.SboempCode)
                    .HasMaxLength(30)
                    .HasColumnName("SBOEmpCode");

                entity.Property(e => e.SecAddress).HasMaxLength(100);

                entity.Property(e => e.SecCity).HasMaxLength(20);

                entity.Property(e => e.SecContactNoLandline).HasMaxLength(20);

                entity.Property(e => e.SecContactNoMobile).HasMaxLength(20);

                entity.Property(e => e.SecCountry).HasMaxLength(20);

                entity.Property(e => e.SecPersonName).HasMaxLength(100);

                entity.Property(e => e.SecRelationShip).HasMaxLength(20);

                entity.Property(e => e.SecState).HasMaxLength(20);

                entity.Property(e => e.Sect)
                    .HasMaxLength(50)
                    .HasColumnName("sect");

                entity.Property(e => e.Sector).HasMaxLength(50);

                entity.Property(e => e.ShiftDaysCode).HasMaxLength(50);

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(20);

                entity.Property(e => e.SuccessionId).HasColumnName("SuccessionID");

                entity.Property(e => e.TeamsId).HasColumnName("TeamsID");

                entity.Property(e => e.TeamsName).HasMaxLength(50);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TransportMode).HasMaxLength(50);

                entity.Property(e => e.UnionMembershipNo).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.VisaNo).HasMaxLength(30);

                entity.Property(e => e.Wablock)
                    .HasMaxLength(50)
                    .HasColumnName("WABlock");

                entity.Property(e => e.Wacity)
                    .HasMaxLength(100)
                    .HasColumnName("WACity");

                entity.Property(e => e.Wacountry)
                    .HasMaxLength(100)
                    .HasColumnName("WACountry");

                entity.Property(e => e.Waother)
                    .HasMaxLength(500)
                    .HasColumnName("WAOther");

                entity.Property(e => e.Wastate)
                    .HasMaxLength(100)
                    .HasColumnName("WAState");

                entity.Property(e => e.Wastreet)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreet");

                entity.Property(e => e.WastreetNo)
                    .HasMaxLength(100)
                    .HasColumnName("WAStreetNo");

                entity.Property(e => e.WazipCode)
                    .HasMaxLength(20)
                    .HasColumnName("WAZipCode");

                entity.Property(e => e.WindowsLogin).HasMaxLength(20);

                entity.Property(e => e.WorkIm)
                    .HasMaxLength(100)
                    .HasColumnName("WorkIM");

                entity.Property(e => e.WorkPermitExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.WorkPermitRef).HasMaxLength(20);

                entity.Property(e => e.WpfCatg)
                    .HasMaxLength(30)
                    .HasColumnName("Wpf_Catg");
            });

            modelBuilder.Entity<TmpVlBal>(entity =>
            {
                entity.ToTable("tmpVlBal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Doj)
                    .HasColumnType("datetime")
                    .HasColumnName("doj");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empCode");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.VlBalance).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<TrainingRequestForm>(entity =>
            {
                entity.ToTable("TrainingRequestForm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccommodationFees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocName).HasMaxLength(200);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.ExpectedOutcome).HasMaxLength(1000);

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FIleExtension");

                entity.Property(e => e.OtherExpenses)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("otherExpenses");

                entity.Property(e => e.PettyExpenses).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Scope).HasMaxLength(1000);

                entity.Property(e => e.SpecificCategory).HasMaxLength(100);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Trainer).HasMaxLength(20);

                entity.Property(e => e.TrainingFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrainingRequired).HasMaxLength(100);

                entity.Property(e => e.TravellingFees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrainingRequestForms)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrainingRequestForm_MstEmployee");
            });

            modelBuilder.Entity<TrnDisciplinaryAppeal>(entity =>
            {
                entity.ToTable("TrnDisciplinaryAppeal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisciplinaryActionId).HasColumnName("DisciplinaryActionID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsActivityLog>(entity =>
            {
                entity.ToTable("TrnsActivityLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivityDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("Activity_Datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ActivityDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Activity_Description");

                entity.Property(e => e.ActivityType).HasColumnName("Activity_Type");

                entity.Property(e => e.LoggedInDb)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LoggedInDB");

                entity.Property(e => e.Query).IsUnicode(false);

                entity.Property(e => e.UserIp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_IP");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrnsAdvance>(entity =>
            {
                entity.ToTable("TrnsAdvance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedAmount)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.CalCode).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Designation).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType).HasDefaultValueSql("((20))");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgPaid).HasColumnName("flgPaid");

                entity.Property(e => e.FlgStop).HasColumnName("flgStop");

                entity.Property(e => e.Gratuity)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("gratuity");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName).HasMaxLength(100);

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.OriginatorId).HasColumnName("OriginatorID");

                entity.Property(e => e.OriginatorName).HasMaxLength(100);

                entity.Property(e => e.ReceivedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RemainingAmount)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.RequestedAmount)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.Salary)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.TransId).HasColumnName("TransID");

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.AdvanceTypeNavigation)
                    .WithMany(p => p.TrnsAdvances)
                    .HasForeignKey(d => d.AdvanceType)
                    .HasConstraintName("FK_TrnsAdvance_MstAdvance");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsAdvanceEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsAdvance_MstEmployee");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TrnsAdvanceManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_TrnsAdvance_MstEmployee1");

                entity.HasOne(d => d.Originator)
                    .WithMany(p => p.TrnsAdvanceOriginators)
                    .HasForeignKey(d => d.OriginatorId)
                    .HasConstraintName("FK_TrnsAdvance_MstEmployee2");
            });

            modelBuilder.Entity<TrnsAdvancePaymentBatch>(entity =>
            {
                entity.ToTable("TrnsAdvancePaymentBatch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvanceName).HasMaxLength(150);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DurationTo).HasColumnType("datetime");

                entity.Property(e => e.PaidAccount).HasMaxLength(250);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(150);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(150);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsAdvancePaymentBatchDetail>(entity =>
            {
                entity.ToTable("TrnsAdvancePaymentBatchDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AbsentDeduction).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AdvanceApproved).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AdvanceDeduction).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AdvancePercentage).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Allowance).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BasicSalaryEarned).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(250);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.LoanInstallment).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MaxAdvanceAllowed).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Otdeduction)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("OTDeduction");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsAdvancePaymentBatchDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsAdvancePaymentBatchDetail_TrnsAdvancePaymentBatch");
            });

            modelBuilder.Entity<TrnsAdvancePettyCashClaimsDetail>(entity =>
            {
                entity.ToTable("TrnsAdvancePettyCashClaimsDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountCode).HasMaxLength(150);

                entity.Property(e => e.AccountName).HasMaxLength(250);

                entity.Property(e => e.CalCode).HasMaxLength(100);

                entity.Property(e => e.ClaimAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ClaimDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Reconsiled).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Refernce).HasMaxLength(250);

                entity.Property(e => e.Remarks).HasMaxLength(350);

                entity.Property(e => e.Sboid).HasColumnName("SBOID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsAdvancePettyCashReconcile>(entity =>
            {
                entity.ToTable("TrnsAdvancePettyCashReconcile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CalCode).HasMaxLength(100);

                entity.Property(e => e.ClaimDocId).HasColumnName("ClaimDocID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentType).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgProcessInPayroll).HasColumnName("flgProcessInPayroll");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.RequestDocId).HasColumnName("RequestDocID");

                entity.Property(e => e.Sboid).HasColumnName("SBOID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsAdvancePettyCashRequest>(entity =>
            {
                entity.ToTable("TrnsAdvancePettyCashRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(100);

                entity.Property(e => e.ClaimAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(200);

                entity.Property(e => e.FlgPaid).HasColumnName("flgPaid");

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequestedDate).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Sboid).HasColumnName("SBOID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsAdvanceReceived>(entity =>
            {
                entity.ToTable("TrnsAdvanceReceived");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvanceId).HasColumnName("AdvanceID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(250);

                entity.Property(e => e.ReceivedAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            });

            modelBuilder.Entity<TrnsAdvanceRegister>(entity =>
            {
                entity.ToTable("TrnsAdvanceRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AdvanceId).HasColumnName("AdvanceID");

                entity.Property(e => e.BaseDocNum).HasMaxLength(20);

                entity.Property(e => e.BaseType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.DueAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(20)
                    .HasColumnName("EmpID");

                entity.Property(e => e.RecoveredAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsAdvanceRequest>(entity =>
            {
                entity.ToTable("TrnsAdvanceRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvanceCode).HasMaxLength(250);

                entity.Property(e => e.AdvanceDescription).HasMaxLength(250);

                entity.Property(e => e.AdvanceProvidedOn).HasColumnType("datetime");

                entity.Property(e => e.ApprovedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.EmpDept).HasMaxLength(50);

                entity.Property(e => e.EmpDesg).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FkadvanceId).HasColumnName("FKAdvanceID");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<TrnsAppealEvidence>(entity =>
            {
                entity.ToTable("TrnsAppealEvidence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppealId).HasColumnName("AppealID");

                entity.Property(e => e.EvidenceDescription).HasMaxLength(2000);

                entity.Property(e => e.EvidenceExtension).HasMaxLength(100);

                entity.Property(e => e.EvidencePath).HasMaxLength(1000);

                entity.HasOne(d => d.Appeal)
                    .WithMany(p => p.TrnsAppealEvidences)
                    .HasForeignKey(d => d.AppealId)
                    .HasConstraintName("FK_TrnsAppealEvidence_TrnDisciplinaryAppeal");
            });

            modelBuilder.Entity<TrnsAppraisalResult>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CurrentSalary)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("currentSalary");

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empCode");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empName");

                entity.Property(e => e.IncrementPercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("incrementPercent");

                entity.Property(e => e.PerformanceId).HasColumnName("PerformanceID");

                entity.Property(e => e.ProposedSalary)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("proposedSalary");

                entity.Property(e => e.Salaryfinalized)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("salaryfinalized");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("score");
            });

            modelBuilder.Entity<TrnsAssistanceRequest>(entity =>
            {
                entity.ToTable("TrnsAssistanceRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attachment).HasMaxLength(400);

                entity.Property(e => e.AttachmentType).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.MaritalStatus).HasMaxLength(30);

                entity.Property(e => e.OtherMartialStatus).HasMaxLength(500);

                entity.Property(e => e.OtherReason).HasMaxLength(500);

                entity.Property(e => e.ProblemType).HasMaxLength(30);

                entity.Property(e => e.Reason).HasMaxLength(2000);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsAssistanceRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsAssistanceRequest_MstEmployee");
            });

            modelBuilder.Entity<TrnsAttendancePosted>(entity =>
            {
                entity.ToTable("TrnsAttendancePosted");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Day).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.FlgApplicableDays).HasColumnName("flgApplicableDays");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsAttendanceRegister>(entity =>
            {
                entity.ToTable("TrnsAttendanceRegister");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Date2).HasColumnType("datetime");

                entity.Property(e => e.DateDay).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EarlyInMin).HasMaxLength(10);

                entity.Property(e => e.EarlyOutMin).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Field1).HasMaxLength(500);

                entity.Property(e => e.Field2).HasMaxLength(500);

                entity.Property(e => e.FkpayrollId).HasColumnName("FKPayrollID");

                entity.Property(e => e.FlgIsNewLeave).HasColumnName("flgIsNewLeave");

                entity.Property(e => e.FlgModified).HasColumnName("flgModified");

                entity.Property(e => e.FlgMtpenalty).HasColumnName("flgMTPenalty");

                entity.Property(e => e.FlgOffDay).HasColumnName("flgOffDay");

                entity.Property(e => e.FlgPost).HasColumnName("flgPost");

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.FlgProcessed).HasColumnName("flgProcessed");

                entity.Property(e => e.FlgSave).HasColumnName("flgSave");

                entity.Property(e => e.LateInMin).HasMaxLength(10);

                entity.Property(e => e.LateOutMin).HasMaxLength(10);

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeaveDedRule).HasMaxLength(50);

                entity.Property(e => e.LeaveHour).HasMaxLength(10);

                entity.Property(e => e.Othour)
                    .HasMaxLength(10)
                    .HasColumnName("OTHour");

                entity.Property(e => e.Ottype).HasColumnName("OTType");

                entity.Property(e => e.Otunits).HasColumnName("OTUnits");

                entity.Property(e => e.OvertimeAdjustment).HasMaxLength(10);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PreTimeIn).HasMaxLength(10);

                entity.Property(e => e.PreTimeOut).HasMaxLength(10);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.ReportingTime).HasMaxLength(10);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.ShiftIdnew).HasColumnName("ShiftIDNew");

                entity.Property(e => e.ShortHours).HasMaxLength(10);

                entity.Property(e => e.StandardPaidHours).HasMaxLength(10);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.TimeIn).HasMaxLength(10);

                entity.Property(e => e.TimeOut).HasMaxLength(10);

                entity.Property(e => e.TotalWorkingHours).HasMaxLength(10);

                entity.Property(e => e.TourHours).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.WorkHour).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsAttendanceRegisterDetail_MstEmployee");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_TrnsAttendanceRegisterDetail_MstLeaveType");

                entity.HasOne(d => d.OttypeNavigation)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.Ottype)
                    .HasConstraintName("FK_TrnsAttendanceRegisterDetail_MstOverTime");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsAttendanceRegister_CfgPeriodDates");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.TrnsAttendanceRegisters)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_TrnsAttendanceRegisterDetail_MstShifts");
            });

            modelBuilder.Entity<TrnsAttendanceRegisterDetail>(entity =>
            {
                entity.ToTable("TrnsAttendanceRegisterDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.TimeInCc)
                    .HasMaxLength(20)
                    .HasColumnName("TimeInCC");

                entity.Property(e => e.TimeOutCc)
                    .HasMaxLength(20)
                    .HasColumnName("TimeOutCC");

                entity.Property(e => e.TotalHours).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsAttendanceRegisterDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsAttendanceRegisterDetail_TrnsAttendanceRegister");
            });

            modelBuilder.Entity<TrnsAttendanceRegisterT>(entity =>
            {
                entity.ToTable("TrnsAttendanceRegisterTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DayName).HasMaxLength(50);

                entity.Property(e => e.EarlyOutMin).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgOffDay).HasColumnName("flgOffDay");

                entity.Property(e => e.FlgOnSpecialDayLeave).HasColumnName("flgOnSpecialDayLeave");

                entity.Property(e => e.LateInMin).HasMaxLength(50);

                entity.Property(e => e.Otcount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OTCount");

                entity.Property(e => e.Othours)
                    .HasMaxLength(50)
                    .HasColumnName("OTHours");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PostedBy).HasMaxLength(50);

                entity.Property(e => e.ProcessedBy).HasMaxLength(50);

                entity.Property(e => e.ShiftHours).HasMaxLength(50);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.TimeIn).HasMaxLength(50);

                entity.Property(e => e.TimeOut).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkHours).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsAttendanceRegisterTs)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsNaheedAttRegister_MstEmployee");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.TrnsAttendanceRegisterTs)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_TrnsNaheedAttRegister_MstShifts");
            });

            modelBuilder.Entity<TrnsBatch>(entity =>
            {
                entity.Property(e => e.BatchName).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.ElmtCode).HasMaxLength(30);

                entity.Property(e => e.ElmtName).HasMaxLength(50);

                entity.Property(e => e.ElmtType).HasMaxLength(30);

                entity.Property(e => e.EmplrCont).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(50);

                entity.Property(e => e.PayrollPeriod).HasMaxLength(50);

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.Remarks).HasMaxLength(300);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.ValType).HasMaxLength(30);

                entity.Property(e => e.Value).HasColumnType("numeric(19, 6)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.TrnsBatches)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_TrnsBatches_MstElements");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsBatches)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsBatches_CfgPayrollDefination");

                entity.HasOne(d => d.PayrollPeriodNavigation)
                    .WithMany(p => p.TrnsBatches)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_TrnsBatches_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsBatchesDetail>(entity =>
            {
                entity.Property(e => e.BatchesId).HasColumnName("BatchesID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmplrCont).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(30);

                entity.HasOne(d => d.Batches)
                    .WithMany(p => p.TrnsBatchesDetails)
                    .HasForeignKey(d => d.BatchesId)
                    .HasConstraintName("FK_TrnsBatchesDetails_TrnsBatches");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsBatchesDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsBatchesDetails_MstEmployee");
            });

            modelBuilder.Entity<TrnsBenchMovement>(entity =>
            {
                entity.ToTable("TrnsBenchMovement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.FlgOnBench).HasColumnName("flgOnBench");

                entity.Property(e => e.FlgOnBoard).HasColumnName("flgOnBoard");

                entity.Property(e => e.LeaveType).HasMaxLength(20);

                entity.Property(e => e.OnBenchEmpId).HasColumnName("OnBenchEmpID");

                entity.Property(e => e.OnBoardEmpId).HasColumnName("OnBoardEmpID");

                entity.Property(e => e.SenderEmpId).HasColumnName("SenderEmpID");

                entity.Property(e => e.StartsFrom).HasColumnType("datetime");

                entity.Property(e => e.ToUntil).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.SenderEmp)
                    .WithMany(p => p.TrnsBenchMovements)
                    .HasForeignKey(d => d.SenderEmpId)
                    .HasConstraintName("FK_TrnsBenchMovement_MstEmployee");
            });

            modelBuilder.Entity<TrnsBenchMovementDetail>(entity =>
            {
                entity.ToTable("TrnsBenchMovementDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenchId).HasColumnName("BenchID");

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.OnBenchEmpId).HasColumnName("OnBenchEmpID");

                entity.Property(e => e.OnBenchEmpName).HasMaxLength(150);

                entity.Property(e => e.OnBoardEmpId).HasColumnName("OnBoardEmpID");

                entity.Property(e => e.ProjectName).HasMaxLength(500);

                entity.Property(e => e.RegionalHeadId).HasColumnName("RegionalHeadID");

                entity.Property(e => e.RegionalHeadName).HasMaxLength(150);

                entity.HasOne(d => d.Bench)
                    .WithMany(p => p.TrnsBenchMovementDetails)
                    .HasForeignKey(d => d.BenchId)
                    .HasConstraintName("FK_TrnsBenchMovementDetail_TrnsBenchMovement");
            });

            modelBuilder.Entity<TrnsBonu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TrnsCdpdetail>(entity =>
            {
                entity.ToTable("TrnsCDPDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assessed)
                    .HasMaxLength(50)
                    .HasColumnName("assessed");

                entity.Property(e => e.FlgTrainingCoaching).HasColumnName("flg_TrainingCoaching");

                entity.Property(e => e.FlgTrainingExternal).HasColumnName("flg_trainingExternal");

                entity.Property(e => e.FlgTrainingInternal).HasColumnName("flg_trainingInternal");

                entity.Property(e => e.FlgTrainingProject).HasColumnName("flg_TrainingProject");

                entity.Property(e => e.HeadId).HasColumnName("headID");

                entity.Property(e => e.Justication).HasColumnName("justication");

                entity.Property(e => e.Progress)
                    .HasMaxLength(50)
                    .HasColumnName("progress");

                entity.Property(e => e.Required)
                    .HasMaxLength(50)
                    .HasColumnName("required");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsCdpdetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsCDPDetail_TrnsCDPHead");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TrnsCdpdetails)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_TrnsCDPDetail_MstCompetancy");
            });

            modelBuilder.Entity<TrnsCdphead>(entity =>
            {
                entity.ToTable("TrnsCDPHead");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentsCareerPath).HasColumnName("comments_careerPath");

                entity.Property(e => e.CommentsCareersPref).HasColumnName("comments_careersPref");

                entity.Property(e => e.CommentsComplinace).HasColumnName("comments_complinace");

                entity.Property(e => e.CommentsDevelopmentPlan).HasColumnName("comments_developmentPlan");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsCdpheads)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_TrnsCDPHead_MstEmployee");
            });

            modelBuilder.Entity<TrnsCeoremark>(entity =>
            {
                entity.ToTable("TrnsCEORemarks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDt");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("departmentName");

                entity.Property(e => e.DeptId).HasColumnName("deptID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status")
                    .HasDefaultValueSql("(N'Pending')");

                entity.Property(e => e.Term).HasColumnName("term");

                entity.Property(e => e.UpdateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDt");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<TrnsCompetencyProfile>(entity =>
            {
                entity.ToTable("TrnsCompetencyProfile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("DocStatusID");

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<TrnsCompetencyProfileDetail>(entity =>
            {
                entity.ToTable("TrnsCompetencyProfileDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cgid).HasColumnName("CGID");

                entity.Property(e => e.Code).HasMaxLength(6);

                entity.Property(e => e.Cpid).HasColumnName("CPID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Cg)
                    .WithMany(p => p.TrnsCompetencyProfileDetails)
                    .HasForeignKey(d => d.Cgid)
                    .HasConstraintName("FK_TrnsCompetencyProfileDetail_MstCompetencyGroup");

                entity.HasOne(d => d.Cp)
                    .WithMany(p => p.TrnsCompetencyProfileDetails)
                    .HasForeignKey(d => d.Cpid)
                    .HasConstraintName("FK_TrnsCompetencyProfileDetail_TrnsCompetencyProfile");
            });

            modelBuilder.Entity<TrnsCph>(entity =>
            {
                entity.ToTable("TrnsCPH");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Create_By");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_Date");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.TrnsCphs)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsCPH_MstCPHElement");
            });

            modelBuilder.Entity<TrnsDeductionRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsDeductionRulesDetail>(entity =>
            {
                entity.ToTable("TrnsDeductionRulesDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.LeaveCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RangeFrom).HasMaxLength(10);

                entity.Property(e => e.RangeTo).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsDeductionRulesDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsDeductionRulesDetail_TrnsDeductionRules");
            });

            modelBuilder.Entity<TrnsDeptShift>(entity =>
            {
                entity.ToTable("trnsDeptShift");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createBy");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("createDt");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.EffectiveTo).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Ref).HasMaxLength(50);

                entity.Property(e => e.ShiftFor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shiftFor");

                entity.Property(e => e.ShiftForId).HasColumnName("shiftForId");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("updateBy");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDt");
            });

            modelBuilder.Entity<TrnsDeptShiftDetail>(entity =>
            {
                entity.ToTable("trnsDeptShiftDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeptShiftId).HasColumnName("deptShiftId");

                entity.Property(e => e.ShiftForId).HasColumnName("shiftForId");

                entity.HasOne(d => d.DeptShift)
                    .WithMany(p => p.TrnsDeptShiftDetails)
                    .HasForeignKey(d => d.DeptShiftId)
                    .HasConstraintName("FK_trnsDeptShiftDetail_trnsDeptShift");
            });

            modelBuilder.Entity<TrnsDisciplinaryActionCommittee>(entity =>
            {
                entity.ToTable("TrnsDisciplinaryActionCommittee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionHeadId).HasColumnName("ActionHeadID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.ActionHead)
                    .WithMany(p => p.TrnsDisciplinaryActionCommittees)
                    .HasForeignKey(d => d.ActionHeadId)
                    .HasConstraintName("FK_TrnsDisciplinaryActionCommittee_TrnsDisciplinaryActionRequest");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsDisciplinaryActionCommittees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsDisciplinaryActionCommittee_MstEmployee");
            });

            modelBuilder.Entity<TrnsDisciplinaryActionDetail>(entity =>
            {
                entity.ToTable("TrnsDisciplinaryActionDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisciplinaryActionId).HasColumnName("DisciplinaryActionID");

                entity.HasOne(d => d.ActionAgainstNavigation)
                    .WithMany(p => p.TrnsDisciplinaryActionDetails)
                    .HasForeignKey(d => d.ActionAgainst)
                    .HasConstraintName("FK_TrnsDisciplinaryActionDetail_MstEmployee");

                entity.HasOne(d => d.DisciplinaryAction)
                    .WithMany(p => p.TrnsDisciplinaryActionDetails)
                    .HasForeignKey(d => d.DisciplinaryActionId)
                    .HasConstraintName("FK_TrnsDisciplinaryActionDetail_TrnsDisciplinaryActionRequest");
            });

            modelBuilder.Entity<TrnsDisciplinaryActionEvidence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisciplinaryActionId).HasColumnName("DisciplinaryActionID");

                entity.Property(e => e.EvidenceDescription).HasMaxLength(100);

                entity.Property(e => e.FileExtension).HasMaxLength(20);

                entity.Property(e => e.FilePath).HasMaxLength(150);

                entity.HasOne(d => d.DisciplinaryAction)
                    .WithMany(p => p.TrnsDisciplinaryActionEvidences)
                    .HasForeignKey(d => d.DisciplinaryActionId)
                    .HasConstraintName("FK_TrnsDisciplinaryActionEvidences_TrnsDisciplinaryActionRequest");
            });

            modelBuilder.Entity<TrnsDisciplinaryActionRequest>(entity =>
            {
                entity.ToTable("TrnsDisciplinaryActionRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(500)
                    .HasColumnName("attachment");

                entity.Property(e => e.AttachmentExt).HasMaxLength(50);

                entity.Property(e => e.Ceoremarks)
                    .HasMaxLength(1000)
                    .HasColumnName("CEORemarks");

                entity.Property(e => e.ComitteeSubmitReport).HasColumnType("datetime");

                entity.Property(e => e.CommitteeFormationDate).HasColumnType("datetime");

                entity.Property(e => e.CommitteeRemarks).HasMaxLength(1000);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfReport).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EnquiryOfficerAssignedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryOfficerSubmitDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryOfficersSummary).HasMaxLength(1000);

                entity.Property(e => e.Fine)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("fine");

                entity.Property(e => e.FlgAdvice).HasColumnName("flgAdvice");

                entity.Property(e => e.FlgCounslingOrDevelopmentPlan).HasColumnName("flgCounslingOrDevelopmentPlan");

                entity.Property(e => e.FlgFinalWarning).HasColumnName("flgFinalWarning");

                entity.Property(e => e.FlgInquiryOfficerAssigned).HasColumnName("FLgInquiryOfficerAssigned");

                entity.Property(e => e.FlgInquiryOfficerSubmitted).HasColumnName("FLgInquiryOfficerSubmitted");

                entity.Property(e => e.FlgTermination).HasColumnName("flgTermination");

                entity.Property(e => e.FlgWarning).HasColumnName("flgWarning");

                entity.Property(e => e.HrActionDate).HasColumnType("datetime");

                entity.Property(e => e.SuspensionFrom).HasColumnType("datetime");

                entity.Property(e => e.SuspensionRemarks).HasMaxLength(1000);

                entity.Property(e => e.SuspensionTo).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsDisciplinaryActionWitnessess>(entity =>
            {
                entity.ToTable("TrnsDisciplinaryActionWitnessess");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisciplianryActionId).HasColumnName("DisciplianryActionID");

                entity.HasOne(d => d.DisciplianryAction)
                    .WithMany(p => p.TrnsDisciplinaryActionWitnessesses)
                    .HasForeignKey(d => d.DisciplianryActionId)
                    .HasConstraintName("FK_TrnsDisciplinaryActionWitnessess_TrnsDisciplinaryActionRequest");

                entity.HasOne(d => d.WitnessNavigation)
                    .WithMany(p => p.TrnsDisciplinaryActionWitnessesses)
                    .HasForeignKey(d => d.Witness)
                    .HasConstraintName("FK_TrnsDisciplinaryActionWitnessess_MstEmployee");
            });

            modelBuilder.Entity<TrnsDisciplinaryAppealEvidence>(entity =>
            {
                entity.ToTable("TrnsDisciplinaryAppealEvidence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppealId).HasColumnName("AppealID");

                entity.Property(e => e.EvidenceDescription).HasMaxLength(2000);

                entity.Property(e => e.EvidenceExtension).HasMaxLength(100);

                entity.Property(e => e.EvidencePath).HasMaxLength(1000);

                entity.HasOne(d => d.Appeal)
                    .WithMany(p => p.TrnsDisciplinaryAppealEvidences)
                    .HasForeignKey(d => d.AppealId)
                    .HasConstraintName("FK_TrnsDisciplinaryAppealEvidence_TrnDisciplinaryAppeal");
            });

            modelBuilder.Entity<TrnsDisclaimerRequest>(entity =>
            {
                entity.HasKey(e => e.DiscId);

                entity.ToTable("trnsDisclaimerRequest");

                entity.Property(e => e.DiscId).HasColumnName("discId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("docDate");

                entity.Property(e => e.DocNum).HasColumnName("docNum");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmployeeCode).HasColumnName("employeeCode");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.FinanceCustody)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("financeCustody");

                entity.Property(e => e.GeneralCustody)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("generalCustody");

                entity.Property(e => e.HrCustody)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hrCustody");

                entity.Property(e => e.ItCustody)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("itCustody");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.PublicCustody)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("publicCustody");

                entity.Property(e => e.Sector)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.TrnsDisclaimerRequests)
                    .HasForeignKey(d => d.EmployeeCode)
                    .HasConstraintName("FK_trnsDisclaimerRequest_MstEmployee");
            });

            modelBuilder.Entity<TrnsDutyResumption>(entity =>
            {
                entity.ToTable("TrnsDutyResumption");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.LeaveEndDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.ResumptionDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsElementPerRate>(entity =>
            {
                entity.ToTable("TrnsElementPerRate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.ProcessOn).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsElementPerRateDetail>(entity =>
            {
                entity.ToTable("TrnsElementPerRateDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Count).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsElementPerRateDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsElementPerRateDetail_TrnsElementPerRate");
            });

            modelBuilder.Entity<TrnsEmpElementHead>(entity =>
            {
                entity.HasKey(e => e.HeadId);

                entity.ToTable("trnsEmpElementHead");

                entity.Property(e => e.HeadId).HasColumnName("headID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.EmpId).HasColumnName("empID");
            });

            modelBuilder.Entity<TrnsEmpPercent>(entity =>
            {
                entity.ToTable("TrnsEmpPercent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TrnsEmpTransferSummary>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmpTransferSummary");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FactorDistribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            });

            modelBuilder.Entity<TrnsEmpVl>(entity =>
            {
                entity.HasKey(e => e.EmpVlId)
                    .HasName("PK_trnsEmpVL");

                entity.ToTable("TrnsEmpVL");

                entity.Property(e => e.EmpVlId).HasColumnName("empVlID");

                entity.Property(e => e.Bfbalance)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("BFBalance");

                entity.Property(e => e.Bfdate)
                    .HasColumnType("datetime")
                    .HasColumnName("BFDate");

                entity.Property(e => e.EmpJoinDate)
                    .HasColumnType("datetime")
                    .HasColumnName("empJoinDate");

                entity.Property(e => e.EmpVlStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("empVlStartDate");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmpVls)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_trnsEmpVL_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmpVldetail>(entity =>
            {
                entity.ToTable("trnsEmpVLDetail");

                entity.Property(e => e.TrnsEmpVldetailId).HasColumnName("trnsEmpVLDetailId");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createBy");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.DaysAvailable)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("daysAvailable");

                entity.Property(e => e.DaysCount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("daysCount");

                entity.Property(e => e.EncashValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FlgCanceled).HasColumnName("flgCanceled");

                entity.Property(e => e.FlgClosed).HasColumnName("flgClosed");

                entity.Property(e => e.FlgPaidOnLeave).HasColumnName("flgPaidOnLeave");

                entity.Property(e => e.FlgTicketRequired).HasColumnName("flgTicketRequired");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveRequestId).HasColumnName("leaveRequestId");

                entity.Property(e => e.PerDayGross).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TrnsEmpVlid).HasColumnName("trnsEmpVLId");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("updateBy");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.HasOne(d => d.TrnsEmpVl)
                    .WithMany(p => p.TrnsEmpVldetails)
                    .HasForeignKey(d => d.TrnsEmpVlid)
                    .HasConstraintName("FK_trnsEmpVLDetail_trnsEmpVL");
            });

            modelBuilder.Entity<TrnsEmployeeArrear>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TrnsEmployeeArrears)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_TrnsEmployeeArrears_MstLocation");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsEmployeeArrears)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsEmployeeArrears_CfgPayrollDefination");

                entity.HasOne(d => d.PayrollPeriod)
                    .WithMany(p => p.TrnsEmployeeArrears)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_TrnsEmployeeArrears_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeeArrearsDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeArrearsDetail");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpArrearId).HasColumnName("EmpArrearID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.EmpArrear)
                    .WithMany(p => p.TrnsEmployeeArrearsDetails)
                    .HasForeignKey(d => d.EmpArrearId)
                    .HasConstraintName("FK_TrnsEmployeeArrearsDetail_TrnsEmployeeArrears");
            });

            modelBuilder.Entity<TrnsEmployeeAttendanceAllowance>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeeAttendanceAllowance");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.CalculatedOnNavigation)
                    .WithMany(p => p.TrnsEmployeeAttendanceAllowances)
                    .HasForeignKey(d => d.CalculatedOn)
                    .HasConstraintName("FK_TrnsEmployeeAttendanceAllowance_MstElements");
            });

            modelBuilder.Entity<TrnsEmployeeAttendanceAllowanceDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeeAttendanceAllowanceDetail");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeAttendanceAllowanceDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeAttendanceAllowanceDetail_MstEmployee");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeeAttendanceAllowanceDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsEmployeeAttendanceAllowanceDetail_TrnsEmployeeAttendanceAllowance");
            });

            modelBuilder.Entity<TrnsEmployeeBonu>(entity =>
            {
                entity.Property(e => e.CalendarCode).HasMaxLength(50);

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PayrollCode).HasMaxLength(50);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PaysInPeriodCode).HasMaxLength(50);

                entity.Property(e => e.PaysInPeriodId).HasColumnName("PaysInPeriodID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsEmployeeBonus)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsEmployeeBonus_CfgPayrollDefination");

                entity.HasOne(d => d.PaysInPeriod)
                    .WithMany(p => p.TrnsEmployeeBonus)
                    .HasForeignKey(d => d.PaysInPeriodId)
                    .HasConstraintName("FK_TrnsEmployeeBonus_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeeBonusDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeBonusDetail");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalculatedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(500);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NetSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Percentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryRange).HasMaxLength(100);

                entity.Property(e => e.SlabCode).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeeBonusDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsEmployeeBonusDetail_TrnsEmployeeBonus");
            });

            modelBuilder.Entity<TrnsEmployeeClearence>(entity =>
            {
                entity.ToTable("TrnsEmployeeClearence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClearenceEmpId).HasColumnName("ClearenceEmpID");

                entity.Property(e => e.ClearenceFormType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.NoticeFrom).HasColumnType("datetime");

                entity.Property(e => e.NoticeTo).HasColumnType("datetime");

                entity.Property(e => e.Receivable).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeClearences)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeClearence_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeeClearenceDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeClearenceDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetName).HasMaxLength(50);

                entity.Property(e => e.ParentTableId).HasColumnName("ParentTableID");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.ParentTable)
                    .WithMany(p => p.TrnsEmployeeClearenceDetails)
                    .HasForeignKey(d => d.ParentTableId)
                    .HasConstraintName("FK_TrnsEmployeeClearenceDetail_TrnsEmployeeClearence");
            });

            modelBuilder.Entity<TrnsEmployeeClearenceHierarchy>(entity =>
            {
                entity.ToTable("TrnsEmployeeClearenceHierarchy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproverId).HasColumnName("ApproverID");

                entity.Property(e => e.ApproverName).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsEmployeeContributionWithdraw>(entity =>
            {
                entity.ToTable("TrnsEmployeeContributionWithdraw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.ClosingBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.EmpContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpWithdraw).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeName).HasMaxLength(250);

                entity.Property(e => e.EmprContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmprWithdraw).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.OpeningPf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OpeningPF");

                entity.Property(e => e.OpeningPfemp)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OpeningPFEmp");

                entity.Property(e => e.OpeningPfempr)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OpeningPFEmpr");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.Sbono).HasColumnName("SBONo");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.YearToDatePf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("YearToDatePF");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeContributionWithdraws)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeContributionWithdraw_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeeElement>(entity =>
            {
                entity.ToTable("TrnsEmployeeElement");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpGrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsEmployeeElements)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsEmployeeElement_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeeElementAdvance>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementAdvance");

                entity.Property(e => e.AdvanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Advance)
                    .WithMany(p => p.TrnsEmployeeElementAdvances)
                    .HasForeignKey(d => d.AdvanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CfgEmployeeAdvanceDetail_MstAdvance");

                entity.HasOne(d => d.EmpElmt)
                    .WithMany(p => p.TrnsEmployeeElementAdvances)
                    .HasForeignKey(d => d.EmpElmtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CfgEmployeeAdvanceDetail_CfgEmployeeElement");
            });

            modelBuilder.Entity<TrnsEmployeeElementDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementDetail");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ElementCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ElementDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ElementType).HasMaxLength(30);

                entity.Property(e => e.ElementValueType).HasMaxLength(30);

                entity.Property(e => e.EmpContr).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmplrContr).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgModified).HasColumnName("flgModified");

                entity.Property(e => e.FlgOneTimeConsumed).HasColumnName("flgOneTimeConsumed");

                entity.Property(e => e.FlgPaid).HasColumnName("flgPaid");

                entity.Property(e => e.FlgPayroll).HasColumnName("flgPayroll");

                entity.Property(e => e.FlgRetro).HasColumnName("flgRetro");

                entity.Property(e => e.FlgStandard).HasColumnName("flgStandard");

                entity.Property(e => e.FlgTaxable).HasColumnName("flgTaxable");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.RetroAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ValueType).HasMaxLength(30);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.TrnsEmployeeElementDetails)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CfgEmployeeElementDetail_MstElementEarning");

                entity.HasOne(d => d.EmpElmt)
                    .WithMany(p => p.TrnsEmployeeElementDetails)
                    .HasForeignKey(d => d.EmpElmtId)
                    .HasConstraintName("FK_CfgEmployeeElementDetail_CfgEmployeeElementDetail");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsEmployeeElementDetails)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsEmployeeElementDetail_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeeElementDetail1>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElementId).HasColumnName("elementId");

                entity.Property(e => e.HeadId).HasColumnName("headID");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.TrnsEmployeeElementDetail1s)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_TrnsEmployeeElementDetails_MstElements");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsEmployeeElementDetail1s)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsEmployeeElementDetails_trnsEmpElementHead");
            });

            modelBuilder.Entity<TrnsEmployeeElementLoan>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementLoan");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MarkUpRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalLoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.EmpElmt)
                    .WithMany(p => p.TrnsEmployeeElementLoans)
                    .HasForeignKey(d => d.EmpElmtId)
                    .HasConstraintName("FK_CfgEmployeeLoanDetail_CfgEmployeeElement");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.TrnsEmployeeElementLoans)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_CfgEmployeeLoanDetail_MstLoans");
            });

            modelBuilder.Entity<TrnsEmployeeElementRegister>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementRegister");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PperiodId).HasColumnName("PPeriodID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsEmployeeElementRegisters)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsEmployeeElementRegister_MstEmployee");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsEmployeeElementRegisters)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsEmployeeElementRegister_CfgPayrollDefination");

                entity.HasOne(d => d.Pperiod)
                    .WithMany(p => p.TrnsEmployeeElementRegisters)
                    .HasForeignKey(d => d.PperiodId)
                    .HasConstraintName("FK_TrnsEmployeeElementRegister_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeeElementRegisterDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeElementRegisterDetail");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EeregisterId).HasColumnName("EERegisterID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgRetroActive).HasColumnName("flgRetroActive");

                entity.Property(e => e.RetroPayAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Eeregister)
                    .WithMany(p => p.TrnsEmployeeElementRegisterDetails)
                    .HasForeignKey(d => d.EeregisterId)
                    .HasConstraintName("FK_TrnsEmployeeElementRegisterDetail_TrnsEmployeeElementRegister");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.TrnsEmployeeElementRegisterDetails)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_TrnsEmployeeElementRegisterDetail_MstElements");
            });

            modelBuilder.Entity<TrnsEmployeeExitInterview>(entity =>
            {
                entity.ToTable("TrnsEmployeeExitInterview");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EeavailabilityJobDescription)
                    .HasMaxLength(50)
                    .HasColumnName("EEAvailabilityJobDescription");

                entity.Property(e => e.EecolleaguesAttitude)
                    .HasMaxLength(50)
                    .HasColumnName("EEColleaguesAttitude");

                entity.Property(e => e.EecoopTopManagement)
                    .HasMaxLength(50)
                    .HasColumnName("EECoopTopManagement");

                entity.Property(e => e.Eediscrimination)
                    .HasMaxLength(50)
                    .HasColumnName("EEDiscrimination");

                entity.Property(e => e.EefeedbackSystem)
                    .HasMaxLength(50)
                    .HasColumnName("EEFeedbackSystem");

                entity.Property(e => e.EeformalTraining)
                    .HasMaxLength(50)
                    .HasColumnName("EEFormalTraining");

                entity.Property(e => e.Eeharrasment)
                    .HasMaxLength(50)
                    .HasColumnName("EEHarrasment");

                entity.Property(e => e.Eesupervision)
                    .HasMaxLength(50)
                    .HasColumnName("EESupervision");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndDateAtSamson).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.Hrcomments)
                    .HasMaxLength(50)
                    .HasColumnName("HRComments");

                entity.Property(e => e.Jrbenefits)
                    .HasMaxLength(50)
                    .HasColumnName("JRBenefits");

                entity.Property(e => e.Jrchallenge)
                    .HasMaxLength(50)
                    .HasColumnName("JRChallenge");

                entity.Property(e => e.JrdirectionSense)
                    .HasMaxLength(50)
                    .HasColumnName("JRDirectionSense");

                entity.Property(e => e.JrjobTraining)
                    .HasMaxLength(50)
                    .HasColumnName("JRJobTraining");

                entity.Property(e => e.JropprGrowth)
                    .HasMaxLength(50)
                    .HasColumnName("JROpprGrowth");

                entity.Property(e => e.JrphysicalWorkCondition)
                    .HasMaxLength(50)
                    .HasColumnName("JRPhysicalWorkCondition");

                entity.Property(e => e.Jrsalary)
                    .HasMaxLength(50)
                    .HasColumnName("JRSalary");

                entity.Property(e => e.JrsignificanceWork)
                    .HasMaxLength(50)
                    .HasColumnName("JRSignificanceWork");

                entity.Property(e => e.Jrworkload)
                    .HasMaxLength(50)
                    .HasColumnName("JRWorkload");

                entity.Property(e => e.LeastLikeJob)
                    .HasMaxLength(1000)
                    .HasColumnName("leastLikeJob");

                entity.Property(e => e.MostLikeJob)
                    .HasMaxLength(1000)
                    .HasColumnName("mostLikeJob");

                entity.Property(e => e.NewEmployer).HasMaxLength(50);

                entity.Property(e => e.ReasonOfLeaving).HasMaxLength(1000);

                entity.Property(e => e.RlcouldDoToStayWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("RLCouldDoToStayWithUs");

                entity.Property(e => e.RlforcedReason)
                    .HasMaxLength(1000)
                    .HasColumnName("RLforcedReason");

                entity.Property(e => e.RllocationJob)
                    .HasMaxLength(1000)
                    .HasColumnName("RLlocationJob");

                entity.Property(e => e.RlprocedureContributedToLeave)
                    .HasMaxLength(1000)
                    .HasColumnName("RLprocedureContributedToLeave");

                entity.Property(e => e.RlreasonOfLeaving)
                    .HasMaxLength(1000)
                    .HasColumnName("RLreasonOfLeaving");

                entity.Property(e => e.SgbadTimeWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("SGbadTimeWithUs");

                entity.Property(e => e.Sgbenefits)
                    .HasMaxLength(1000)
                    .HasColumnName("SGbenefits");

                entity.Property(e => e.Sgchallenge)
                    .HasMaxLength(1000)
                    .HasColumnName("SGChallenge");

                entity.Property(e => e.SgdoyouGetSupport)
                    .HasMaxLength(1000)
                    .HasColumnName("SGDoyouGetSupport");

                entity.Property(e => e.SggoalsClearInEmployment)
                    .HasMaxLength(1000)
                    .HasColumnName("SGgoalsClearInEmployment");

                entity.Property(e => e.SggoodTimeWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("SGgoodTimeWithUs");

                entity.Property(e => e.SghowWeMakeFullerUseOfYourSkills)
                    .HasMaxLength(1000)
                    .HasColumnName("SGhowWeMakeFullerUseOfYourSkills");

                entity.Property(e => e.SgjobDescAccuratnt)
                    .HasMaxLength(1000)
                    .HasColumnName("SGJobDescAccuratnt");

                entity.Property(e => e.SgjobTraining)
                    .HasMaxLength(1000)
                    .HasColumnName("SGjobTraining");

                entity.Property(e => e.SgoppForGrowth)
                    .HasMaxLength(1000)
                    .HasColumnName("SGoppForGrowth");

                entity.Property(e => e.SgphysicalWorkingCondition)
                    .HasMaxLength(1000)
                    .HasColumnName("SGPhysicalWorkingCondition");

                entity.Property(e => e.Sgsalary)
                    .HasMaxLength(500)
                    .HasColumnName("SGsalary");

                entity.Property(e => e.SgsayAboutCommunication)
                    .HasMaxLength(1000)
                    .HasColumnName("SGsayAboutCommunication");

                entity.Property(e => e.SgsenseOfDirection)
                    .HasMaxLength(1000)
                    .HasColumnName("SGsenseOfDirection");

                entity.Property(e => e.SgsignificaneOfWork)
                    .HasMaxLength(1000)
                    .HasColumnName("SGsignificaneOfWork");

                entity.Property(e => e.SgskillsUsedToAdvantage)
                    .HasMaxLength(1000)
                    .HasColumnName("SGskillsUsedToAdvantage");

                entity.Property(e => e.SgwhatImprovCanBe)
                    .HasMaxLength(1000)
                    .HasColumnName("SGwhatImprovCanBe");

                entity.Property(e => e.Sgworkload)
                    .HasMaxLength(1000)
                    .HasColumnName("SGWorkload");

                entity.Property(e => e.SslQ151)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q151");

                entity.Property(e => e.SslQ1512)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q1512");

                entity.Property(e => e.SslQ1513)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q1513");

                entity.Property(e => e.SslQ1514)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q1514");

                entity.Property(e => e.SslQ1515)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q1515");

                entity.Property(e => e.SslQ1516)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SSL_Q1516");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartDateAtSamson).HasColumnType("datetime");

                entity.Property(e => e.TypeOfContract).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WhichFactorsAttracted).HasMaxLength(1000);

                entity.Property(e => e.WnnewEmployer)
                    .HasMaxLength(500)
                    .HasColumnName("WNnewEmployer");

                entity.Property(e => e.WnnewJobBenefits)
                    .HasMaxLength(1000)
                    .HasColumnName("WNNewJobBenefits");

                entity.Property(e => e.WnnewJobDifferFromCurrent)
                    .HasMaxLength(1000)
                    .HasColumnName("WNnewJobDifferFromCurrent");

                entity.Property(e => e.WnwhatAttractNewJob)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatAttractNewJob");

                entity.Property(e => e.WnwhatGoingToDo)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatGoingToDo");

                entity.Property(e => e.WnwhatSortOfJob)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatSortOfJob");

                entity.Property(e => e.WouldYouRecommendFriend).HasMaxLength(50);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.TrnsEmployeeExitInterviews)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_TrnsEmployeeExitInterview_MstDepartment");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeExitInterviews)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeExitInterview_MstEmployee");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.TrnsEmployeeExitInterviews)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_TrnsEmployeeExitInterview_MstGrading");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TrnsEmployeeExitInterviews)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_TrnsEmployeeExitInterview_MstPosition");
            });

            modelBuilder.Entity<TrnsEmployeeExitInterviewAttach>(entity =>
            {
                entity.ToTable("TrnsEmployeeExitInterviewAttach");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocContent).HasMaxLength(150);

                entity.Property(e => e.DocName).HasMaxLength(250);

                entity.Property(e => e.ExitInterviewId).HasColumnName("exitInterviewId");

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExitInterview)
                    .WithMany(p => p.TrnsEmployeeExitInterviewAttaches)
                    .HasForeignKey(d => d.ExitInterviewId)
                    .HasConstraintName("FK_TrnsEmployeeExitInterviewAttach_TrnsEmployeeExitInterview");
            });

            modelBuilder.Entity<TrnsEmployeeHiring>(entity =>
            {
                entity.ToTable("TrnsEmployeeHiring");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CandidateId).HasColumnName("candidateID");

                entity.Property(e => e.ContractType)
                    .HasMaxLength(50)
                    .HasColumnName("contractType");

                entity.Property(e => e.ElementDetailId).HasColumnName("elementDetailId");

                entity.Property(e => e.EmpContractAccepted).HasColumnName("empContractAccepted");

                entity.Property(e => e.Empcode)
                    .HasMaxLength(10)
                    .HasColumnName("empcode");

                entity.Property(e => e.OfferStatus)
                    .HasMaxLength(50)
                    .HasColumnName("offerStatus");

                entity.Property(e => e.ProbabtionPeriod)
                    .HasMaxLength(50)
                    .HasColumnName("probabtionPeriod");

                entity.HasOne(d => d.ElementDetail)
                    .WithMany(p => p.TrnsEmployeeHirings)
                    .HasForeignKey(d => d.ElementDetailId)
                    .HasConstraintName("FK_TrnsEmployeeHiring_trnsEmpElementHead");
            });

            modelBuilder.Entity<TrnsEmployeeLoan>(entity =>
            {
                entity.ToTable("TrnsEmployeeLoan");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpCostCenter).HasMaxLength(50);

                entity.Property(e => e.EmpDepartment).HasMaxLength(50);

                entity.Property(e => e.EmpDesignation).HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<TrnsEmployeeNoLateAllowance>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeeNoLateAllowance");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsEmployeeNoLateAllowanceDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeeNoLateAllowanceDetail");

                entity.Property(e => e.InternalId).HasColumnName("InternalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeNoLateAllowanceDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeNoLateAllowanceDetail_MstEmployee");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeeNoLateAllowanceDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsEmployeeNoLateAllowanceDetail_TrnsEmployeeNoLateAllowance");
            });

            modelBuilder.Entity<TrnsEmployeeOvertime>(entity =>
            {
                entity.ToTable("TrnsEmployeeOvertime");

                entity.Property(e => e.AttendanceId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AttendanceID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(100);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsEmployeeOvertimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsEmployeeOvertime_MstEmployee");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsEmployeeOvertimes)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsEmployeeOvertime_CfgPerformancePeriod");
            });

            modelBuilder.Entity<TrnsEmployeeOvertimeDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeOvertimeDetail");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FromTime).HasMaxLength(10);

                entity.Property(e => e.Otdate)
                    .HasColumnType("datetime")
                    .HasColumnName("OTDate");

                entity.Property(e => e.Othours)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OTHours");

                entity.Property(e => e.Otvalue)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OTValue");

                entity.Property(e => e.OvertimeId).HasColumnName("OvertimeID");

                entity.Property(e => e.ToTime).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.ValueType).HasMaxLength(10);

                entity.HasOne(d => d.EmpOvertime)
                    .WithMany(p => p.TrnsEmployeeOvertimeDetails)
                    .HasForeignKey(d => d.EmpOvertimeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsEmployeeOvertimeDetail_TrnsEmployeeOvertimeDetail");

                entity.HasOne(d => d.Overtime)
                    .WithMany(p => p.TrnsEmployeeOvertimeDetails)
                    .HasForeignKey(d => d.OvertimeId)
                    .HasConstraintName("FK_TrnsEmployeeOvertimeDetail_MstOverTime");
            });

            modelBuilder.Entity<TrnsEmployeePenalty>(entity =>
            {
                entity.ToTable("TrnsEmployeePenalty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeePenalties)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeePenalty_MstEmployee");

                entity.HasOne(d => d.Penalty)
                    .WithMany(p => p.TrnsEmployeePenalties)
                    .HasForeignKey(d => d.PenaltyId)
                    .HasConstraintName("FK_TrnsEmployeePenalty_MstPenaltyRules");
            });

            modelBuilder.Entity<TrnsEmployeePerPieceProcessing>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeePerPieceProcessing");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreditAccount).HasMaxLength(16);

                entity.Property(e => e.CreditName).HasMaxLength(100);

                entity.Property(e => e.DebitAccount).HasMaxLength(16);

                entity.Property(e => e.DebitName).HasMaxLength(100);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(200);

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.FlgProcessed).HasColumnName("flgProcessed");

                entity.Property(e => e.Jenum).HasColumnName("JENum");

                entity.Property(e => e.NetPayable).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.UdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeePerPieceProcessings)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeePerPieceProcessing_MstEmployee");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsEmployeePerPieceProcessings)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsEmployeePerPieceProcessing_CfgPayrollDefination");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsEmployeePerPieceProcessings)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsEmployeePerPieceProcessing_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeePerPieceProcessingDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeePerPieceProcessingDetail");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.LineTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Qty).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeePerPieceProcessingDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsEmployeePerPieceProcessingDetail_TrnsEmployeePerPieceProcessing");
            });

            modelBuilder.Entity<TrnsEmployeePerPieceRate>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeePerPieceRate");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeePerPieceRates)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeePerPieceRate_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeePerPieceRateDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeePerPieceRateDetail");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgDelete).HasColumnName("flgDelete");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsEmployeePerPieceRateDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsEmployeePerPieceRateDetail_TrnsEmployeePerPieceRate");
            });

            modelBuilder.Entity<TrnsEmployeePerformance>(entity =>
            {
                entity.ToTable("TrnsEmployeePerformance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllowancePercentage).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsEmployeePerformanceDetail>(entity =>
            {
                entity.ToTable("TrnsEmployeePerformanceDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllowanceId).HasColumnName("AllowanceID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EelementId).HasColumnName("EelementID");

                entity.Property(e => e.EmpName).HasMaxLength(500);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Allowance)
                    .WithMany(p => p.TrnsEmployeePerformanceDetails)
                    .HasForeignKey(d => d.AllowanceId)
                    .HasConstraintName("FK_TrnsEmployeeAllowanceDetail_TrnsEmployeeAllowance");
            });

            modelBuilder.Entity<TrnsEmployeeProfitLossAllocation>(entity =>
            {
                entity.ToTable("TrnsEmployeeProfitLossAllocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocatedProfitLoss).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(150);

                entity.Property(e => e.ClosingBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ClosingBalanceAfterAllocation).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.EmpContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmployeeName).HasMaxLength(250);

                entity.Property(e => e.EmprContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.OpeningEmpPf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OpeningEmpPF");

                entity.Property(e => e.OpeningEmprPf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OpeningEmprPF");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PostingDate).HasColumnType("datetime");

                entity.Property(e => e.ProfitLossPerYear).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalContribution).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WithdrawnValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.YearToDatePf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("YearToDatePF");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeProfitLossAllocations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeProfitLossAllocation_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeeReHire>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsEmployeeReHire");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.BranchIdnew).HasColumnName("BranchIDNew");

                entity.Property(e => e.BranchNameNew).HasMaxLength(500);

                entity.Property(e => e.BranchNameOld).HasMaxLength(500);

                entity.Property(e => e.Bsnew)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("BSNew");

                entity.Property(e => e.Bsold)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("BSOld");

                entity.Property(e => e.ContractTypeNew).HasMaxLength(10);

                entity.Property(e => e.ContractTypeOld).HasMaxLength(10);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DepartNameOld).HasMaxLength(500);

                entity.Property(e => e.DepartmentIdnew).HasColumnName("DepartmentIDNew");

                entity.Property(e => e.DepartmentNameNew).HasMaxLength(500);

                entity.Property(e => e.DesigNameOld).HasMaxLength(500);

                entity.Property(e => e.DesignationIdnew).HasColumnName("DesignationIDNew");

                entity.Property(e => e.DesignationNameNew).HasMaxLength(500);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmployeeContractType).HasMaxLength(100);

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.FlgReHire).HasColumnName("flgReHire");

                entity.Property(e => e.Gsnew)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("GSNew");

                entity.Property(e => e.Gsold)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("GSOld");

                entity.Property(e => e.JoiningDtNew).HasColumnType("datetime");

                entity.Property(e => e.JoiningDtOld).HasColumnType("datetime");

                entity.Property(e => e.LocNameOld).HasMaxLength(500);

                entity.Property(e => e.LocationIdnew).HasColumnName("LocationIDNew");

                entity.Property(e => e.LocationNameNew).HasMaxLength(500);

                entity.Property(e => e.ManagerIdnew).HasColumnName("ManagerIDNew");

                entity.Property(e => e.ManagerIdold).HasColumnName("ManagerIDOld");

                entity.Property(e => e.ManagerNameNew).HasMaxLength(200);

                entity.Property(e => e.ManagerNameOld).HasMaxLength(200);

                entity.Property(e => e.PaymentModeNew).HasMaxLength(10);

                entity.Property(e => e.PaymentModeOld).HasMaxLength(10);

                entity.Property(e => e.PayrollModeNew).HasMaxLength(10);

                entity.Property(e => e.PayrollModeOld).HasMaxLength(10);

                entity.Property(e => e.PayrollNameNew).HasMaxLength(50);

                entity.Property(e => e.PayrollNameOld).HasMaxLength(50);

                entity.Property(e => e.ResignationDtOld).HasColumnType("datetime");

                entity.Property(e => e.TerminationDtOld).HasColumnType("datetime");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeeReHires)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeeReHire_MstEmployee");
            });

            modelBuilder.Entity<TrnsEmployeeTransfer>(entity =>
            {
                entity.ToTable("TrnsEmployeeTransfer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsEmployeeTransferDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCentre).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.EmpCalendar).HasMaxLength(100);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(150);

                entity.Property(e => e.ExistingLocation).HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ToLocation).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.TrnsEmployeeTransferDetails)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_TrnsEmployeeTransferDetails_TrnsEmployeeTransfer");
            });

            modelBuilder.Entity<TrnsEmployeeTravellExpence>(entity =>
            {
                entity.ToTable("TrnsEmployeeTravellExpence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Charges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDay).HasMaxLength(150);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromCity).HasMaxLength(150);

                entity.Property(e => e.Km)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("KM");

                entity.Property(e => e.NightStay).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Other).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutBack).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PayrollMonthId).HasColumnName("PayrollMonthID");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.ToCity).HasMaxLength(150);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsEmployeeWddetail>(entity =>
            {
                entity.ToTable("TrnsEmployeeWDDetails");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EmpWdid).HasColumnName("EmpWDId");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NetIncome).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerDayIncome).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryBase).HasMaxLength(50);

                entity.Property(e => e.ShiftHours).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalHours).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.WorkDays).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.EmpWd)
                    .WithMany(p => p.TrnsEmployeeWddetails)
                    .HasForeignKey(d => d.EmpWdid)
                    .HasConstraintName("FK_TrnsEmployeeWDDetails_TrnsEmployeeWorkDays");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.TrnsEmployeeWddetails)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_TrnsEmployeeWDDetails_MstShifts");
            });

            modelBuilder.Entity<TrnsEmployeeWorkDay>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeIdfrom).HasColumnName("EmployeeIDFrom");

                entity.Property(e => e.EmployeeIdto).HasColumnName("EmployeeIDTo");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TrnsEmployeeWorkDays)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_TrnsEmployeeWorkDays_MstLocation");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsEmployeeWorkDays)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsEmployeeWorkDays_CfgPayrollDefination");

                entity.HasOne(d => d.PayrollPeriod)
                    .WithMany(p => p.TrnsEmployeeWorkDays)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_TrnsEmployeeWorkDays_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsEmployeesAlert>(entity =>
            {
                entity.ToTable("TrnsEmployeesAlert");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.TrnsEmployeesAlerts)
                    .HasForeignKey(d => d.AlertId)
                    .HasConstraintName("FK_TrnsEmployeesAlert_CfgAlertManagement");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsEmployeesAlerts)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsEmployeesAlert_MstEmployee");
            });

            modelBuilder.Entity<TrnsExperienceLetter>(entity =>
            {
                entity.HasKey(e => e.LetterId);

                entity.ToTable("TrnsExperienceLetter");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("docDate");

                entity.Property(e => e.DocNum).HasColumnName("docNum");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.TrnsExperienceLetters)
                    .HasForeignKey(d => d.EmployeeCode)
                    .HasConstraintName("FK_TrnsExperienceLetter_MstEmployee");
            });

            modelBuilder.Entity<TrnsFinalSettelmentRegister>(entity =>
            {
                entity.ToTable("TrnsFinalSettelmentRegister");

                entity.Property(e => e.A1jenum).HasColumnName("A1JENum");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DaysPaid).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpAdvance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpArrears).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBasic).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBonus).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBranch).HasMaxLength(500);

                entity.Property(e => e.EmpDepartment).HasMaxLength(500);

                entity.Property(e => e.EmpDesignation).HasMaxLength(500);

                entity.Property(e => e.EmpElementTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpExpense).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpGross).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpJobTitle).HasMaxLength(500);

                entity.Property(e => e.EmpLoan).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpLocation).HasMaxLength(500);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.EmpOt)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("EmpOT");

                entity.Property(e => e.EmpPosition).HasMaxLength(500);

                entity.Property(e => e.EmpRetroElement).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpTaxblTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FsheadId).HasColumnName("FSHeadID");

                entity.Property(e => e.Jenum).HasColumnName("JENum");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.UpdateBy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsFinalSettelmentRegisters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsFinalSettelmentRegister_MstEmployee");

                entity.HasOne(d => d.Fshead)
                    .WithMany(p => p.TrnsFinalSettelmentRegisters)
                    .HasForeignKey(d => d.FsheadId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsFinalSettelmentRegister_TrnsFSHead");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsFinalSettelmentRegisters)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsFinalSettelmentRegister_CfgPayrollDefination");

                entity.HasOne(d => d.PayrollPeriod)
                    .WithMany(p => p.TrnsFinalSettelmentRegisters)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_TrnsFinalSettelmentRegister_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsFinalSettelmentRegisterDetail>(entity =>
            {
                entity.ToTable("TrnsFinalSettelmentRegisterDetail");

                entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");

                entity.Property(e => e.BaseValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueCalculatedOn).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueType).HasMaxLength(20);

                entity.Property(e => e.CostType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreditAccount).HasMaxLength(16);

                entity.Property(e => e.CreditAccountName).HasMaxLength(100);

                entity.Property(e => e.CreditValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DealerCode).HasMaxLength(250);

                entity.Property(e => e.DebitAccount).HasMaxLength(16);

                entity.Property(e => e.DebitAccountName).HasMaxLength(100);

                entity.Property(e => e.DebitValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgGross).HasColumnName("flgGross");

                entity.Property(e => e.FlgStandard).HasColumnName("flgStandard");

                entity.Property(e => e.Fsid).HasColumnName("FSID");

                entity.Property(e => e.LineMemo).HasMaxLength(100);

                entity.Property(e => e.LineSubType).HasMaxLength(30);

                entity.Property(e => e.LineType).HasMaxLength(30);

                entity.Property(e => e.LineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfDay).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Othours)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OTHours");

                entity.Property(e => e.TaxableAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Fs)
                    .WithMany(p => p.TrnsFinalSettelmentRegisterDetails)
                    .HasForeignKey(d => d.Fsid)
                    .HasConstraintName("FK_TrnsFinalSettelmentRegisterDetail_TrnsFinalSettelmentRegister");
            });

            modelBuilder.Entity<TrnsFshead>(entity =>
            {
                entity.ToTable("TrnsFSHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.InternalEmpId).HasColumnName("internalEmpID");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.ResignDt).HasColumnType("datetime");

                entity.Property(e => e.TerminationDt).HasColumnType("datetime");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.InternalEmp)
                    .WithMany(p => p.TrnsFsheads)
                    .HasForeignKey(d => d.InternalEmpId)
                    .HasConstraintName("FK_TrnsFSHead_MstEmployee");
            });

            modelBuilder.Entity<TrnsGenericRequest>(entity =>
            {
                entity.ToTable("TrnsGenericRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfRequest).HasColumnType("datetime");

                entity.Property(e => e.DocAprovalStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(250);

                entity.Property(e => e.GenericId).HasColumnName("GenericID");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.RequestType).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsGenericRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__TrnsGener__EmpID__055132DE");

                entity.HasOne(d => d.Generic)
                    .WithMany(p => p.TrnsGenericRequests)
                    .HasForeignKey(d => d.GenericId)
                    .HasConstraintName("FK__TrnsGener__Gener__06455717");
            });

            modelBuilder.Entity<TrnsGradeBenifit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenifitId).HasColumnName("BenifitID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Benifit)
                    .WithMany(p => p.TrnsGradeBenifits)
                    .HasForeignKey(d => d.BenifitId)
                    .HasConstraintName("FK_TrnsGradeBenifits_MstBenefits");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.TrnsGradeBenifits)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_TrnsGradeBenifits_MstGrading");
            });

            modelBuilder.Entity<TrnsGratuitySlab>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .HasName("PK_Table_2");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.BasedOn).HasMaxLength(50);

                entity.Property(e => e.BasedOnValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalculatedDays).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FlgAbsoluteYears).HasColumnName("flgAbsoluteYears");

                entity.Property(e => e.FlgEffectiveDate).HasColumnName("flgEffectiveDate");

                entity.Property(e => e.FlgPerYear).HasColumnName("flgPerYear");

                entity.Property(e => e.FlgWopleaves).HasColumnName("flgWOPLeaves");

                entity.Property(e => e.SlabCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsGratuitySlabsDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsGratuitySlabsDetail");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DaysCount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FromPoints).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToPoints).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsGratuitySlabsDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsGratuitySlabsDetail_TrnsGratuitySlabs");
            });

            modelBuilder.Entity<TrnsGrevianceRequest>(entity =>
            {
                entity.ToTable("TrnsGrevianceRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(500)
                    .HasColumnName("attachment");

                entity.Property(e => e.AttachmentExt).HasMaxLength(50);

                entity.Property(e => e.ComitteeSubmitReport).HasColumnType("datetime");

                entity.Property(e => e.CommitteeFormationDate).HasColumnType("datetime");

                entity.Property(e => e.CommitteeRemarks).HasMaxLength(1000);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfReport).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EnquiryOfficerAssignedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryOfficerSubmitDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryOfficersSummary).HasMaxLength(1000);

                entity.Property(e => e.FlgDisciplinaryAction).HasColumnName("flgDisciplinaryAction");

                entity.Property(e => e.FlgInquiryOfficerAssigned).HasColumnName("FLgInquiryOfficerAssigned");

                entity.Property(e => e.FlgInquiryOfficerSubmitted).HasColumnName("FLgInquiryOfficerSubmitted");

                entity.Property(e => e.FlgMediation).HasColumnName("flgMediation");

                entity.Property(e => e.FlgNoFurthurAction).HasColumnName("flgNoFurthurAction");

                entity.Property(e => e.HrActionDate).HasColumnType("datetime");

                entity.Property(e => e.RemarksofCeo)
                    .HasMaxLength(1000)
                    .HasColumnName("RemarksofCEO");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsHeadBudget>(entity =>
            {
                entity.ToTable("TrnsHeadBudget");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DocType).HasDefaultValueSql("((14))");

                entity.Property(e => e.FromDt).HasColumnType("datetime");

                entity.Property(e => e.LocationName).HasMaxLength(50);

                entity.Property(e => e.ToDt).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.TrnsHeadBudgets)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_TrnsHeadBudget_MstLocation");
            });

            modelBuilder.Entity<TrnsHeadBudgetDetail>(entity =>
            {
                entity.ToTable("TrnsHeadBudgetDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BudgetId).HasColumnName("BudgetID");

                entity.Property(e => e.BudgetedHearcount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.OccupiedPositions).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.TrnsHeadBudgetDetails)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstBraches");

                entity.HasOne(d => d.Budget)
                    .WithMany(p => p.TrnsHeadBudgetDetails)
                    .HasForeignKey(d => d.BudgetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_TrnsHeadBudget");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.TrnsHeadBudgetDetails)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstDepartment");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.TrnsHeadBudgetDetails)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_TrnsHeadBudgetDetail_MstDesignation");
            });

            modelBuilder.Entity<TrnsIncDetail>(entity =>
            {
                entity.ToTable("TrnsIncDetail");

                entity.Property(e => e.ApplOn)
                    .HasMaxLength(10)
                    .HasColumnName("applOn");

                entity.Property(e => e.Arear)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("arear");

                entity.Property(e => e.CBasic)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("cBasic");

                entity.Property(e => e.CDesignation)
                    .HasMaxLength(250)
                    .HasColumnName("cDesignation");

                entity.Property(e => e.CGross)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("cGross");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(50)
                    .HasColumnName("empCode");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .HasColumnName("empName");

                entity.Property(e => e.FlgCurrentPeriod).HasColumnName("flgCurrentPeriod");

                entity.Property(e => e.IncType)
                    .HasMaxLength(10)
                    .HasColumnName("incType");

                entity.Property(e => e.IncValue)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("incValue");

                entity.Property(e => e.NDesignation)
                    .HasMaxLength(250)
                    .HasColumnName("nDesignation");

                entity.Property(e => e.NewBasic)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("newBasic");

                entity.Property(e => e.NewGross)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("newGross");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsIncDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_trnsIncDetail_MstEmployee");

                entity.HasOne(d => d.Incr)
                    .WithMany(p => p.TrnsIncDetails)
                    .HasForeignKey(d => d.IncrId)
                    .HasConstraintName("FK_trnsIncDetail_TrnsIncrementPromotion");
            });

            modelBuilder.Entity<TrnsIncrementPromotion>(entity =>
            {
                entity.ToTable("TrnsIncrementPromotion");

                entity.Property(e => e.ApplicableDate).HasColumnType("datetime");

                entity.Property(e => e.ArearElementId).HasColumnName("arearElementId");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IncreamentType).HasMaxLength(50);

                entity.Property(e => e.IncreamentValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PayIn).HasColumnName("payIn");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.TransId).HasColumnName("transId");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsIncrementPromotions)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsIncrementPromotion_CfgPayrollDefination");
            });

            modelBuilder.Entity<TrnsInternalTransfer>(entity =>
            {
                entity.ToTable("TrnsInternalTransfer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.NewDepartmentId).HasColumnName("NewDepartmentID");

                entity.Property(e => e.NewLocationId).HasColumnName("NewLocationID");

                entity.Property(e => e.OldDepartmentId).HasColumnName("OldDepartmentID");

                entity.Property(e => e.OldLocationId).HasColumnName("OldLocationID");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsInternalTransferEmps)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsInternalTransfer_MstEmployee");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TrnsInternalTransferManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_TrnsInternalTransfer_MstEmployee1");

                entity.HasOne(d => d.NewBranch)
                    .WithMany(p => p.TrnsInternalTransfers)
                    .HasForeignKey(d => d.NewBranchId)
                    .HasConstraintName("FK_TrnsInternalTransfer_MstBranches");

                entity.HasOne(d => d.NewDepartment)
                    .WithMany(p => p.TrnsInternalTransfers)
                    .HasForeignKey(d => d.NewDepartmentId)
                    .HasConstraintName("FK_TrnsInternalTransfer_MstDepartment");

                entity.HasOne(d => d.NewLocation)
                    .WithMany(p => p.TrnsInternalTransfers)
                    .HasForeignKey(d => d.NewLocationId)
                    .HasConstraintName("FK_TrnsInternalTransfer_MstLocation");
            });

            modelBuilder.Entity<TrnsInterviewAssessment>(entity =>
            {
                entity.ToTable("TrnsInterviewAssessment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adaptiblity).HasColumnName("adaptiblity");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.CommentsEdu).HasColumnName("comments_edu");

                entity.Property(e => e.CommentsGeneral).HasColumnName("comments_general");

                entity.Property(e => e.CommentsSkills).HasColumnName("comments_skills");

                entity.Property(e => e.Communication).HasColumnName("communication");

                entity.Property(e => e.Confidence).HasColumnName("confidence");

                entity.Property(e => e.Creativity).HasColumnName("creativity");

                entity.Property(e => e.CurrentSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("current_salary");

                entity.Property(e => e.DecisionMaking).HasColumnName("decisionMaking");

                entity.Property(e => e.Designation).HasColumnName("designation");

                entity.Property(e => e.DocStatus)
                    .HasColumnName("docStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Education)
                    .HasMaxLength(50)
                    .HasColumnName("education");

                entity.Property(e => e.ExpectedSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("expected_salary");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.FinalAssessment)
                    .HasMaxLength(50)
                    .HasColumnName("finalAssessment")
                    .HasComment("Recommended for Employment, Not Recommended, Holder for this position, Holder for other posiiton");

                entity.Property(e => e.Growth).HasColumnName("growth");

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.InterviewCallId).HasColumnName("InterviewCall_ID");

                entity.Property(e => e.InterviewerName)
                    .HasMaxLength(50)
                    .HasColumnName("interviewerName");

                entity.Property(e => e.JobKnowledge).HasColumnName("jobKnowledge");

                entity.Property(e => e.LastPositon)
                    .HasMaxLength(50)
                    .HasColumnName("last_positon");

                entity.Property(e => e.Leadorship).HasColumnName("leadorship");

                entity.Property(e => e.ObtainedScore).HasColumnName("obtainedScore");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(50)
                    .HasColumnName("organization_name");

                entity.Property(e => e.Planning).HasColumnName("planning");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.Presentation).HasColumnName("presentation");

                entity.Property(e => e.RecommendedSalary)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("recommended_salary")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ResourceManagement).HasColumnName("resourceManagement");

                entity.Property(e => e.Stablity).HasColumnName("stablity");

                entity.Property(e => e.Teamwork).HasColumnName("teamwork");

                entity.Property(e => e.TechnicalSkills).HasColumnName("technicalSkills");

                entity.Property(e => e.Thoroughness).HasColumnName("thoroughness");

                entity.Property(e => e.TotalScore).HasColumnName("totalScore");

                entity.Property(e => e.VacancyCode).HasColumnName("vacancy_code");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.TrnsInterviewAssessments)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_TrnsInterviewAssessment_MstCandidate");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.TrnsInterviewAssessments)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK_TrnsInterviewAssessment_MstDesignation");

                entity.HasOne(d => d.InterviewCall)
                    .WithMany(p => p.TrnsInterviewAssessments)
                    .HasForeignKey(d => d.InterviewCallId)
                    .HasConstraintName("FK_TrnsInterviewAssessment_TrnsInterviewCall");
            });

            modelBuilder.Entity<TrnsInterviewAssessmentDetail>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(3000);

                entity.Property(e => e.Score).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.TrnsInterviewAssessmentDetails)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsInterviewAssessmentDetails_TrnsInterviewAssessment");
            });

            modelBuilder.Entity<TrnsInterviewCall>(entity =>
            {
                entity.ToTable("TrnsInterviewCall");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallStatus)
                    .HasMaxLength(50)
                    .HasColumnName("callStatus");

                entity.Property(e => e.CandidateId).HasColumnName("candidateID");

                entity.Property(e => e.ClosedOn)
                    .HasColumnType("date")
                    .HasColumnName("closedOn");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.FlgActive).HasColumnName("flg_Active");

                entity.Property(e => e.InterviewDate)
                    .HasColumnType("date")
                    .HasColumnName("interviewDate");

                entity.Property(e => e.InterviewNo).HasColumnName("interview_no");

                entity.Property(e => e.InterviewTime)
                    .HasMaxLength(50)
                    .HasColumnName("interviewTime");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Reminder)
                    .HasMaxLength(50)
                    .HasColumnName("reminder");

                entity.Property(e => e.ReminderUnit)
                    .HasMaxLength(50)
                    .HasColumnName("reminder_unit");

                entity.Property(e => e.SchDate)
                    .HasColumnType("date")
                    .HasColumnName("schDate");

                entity.Property(e => e.Scheduling)
                    .HasMaxLength(50)
                    .HasColumnName("scheduling");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subject).HasColumnName("subject");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("type");

                entity.Property(e => e.VacancyNo).HasColumnName("vacancyNo");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.TrnsInterviewCalls)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_TrnsInterviewCall_MstCandidate");
            });

            modelBuilder.Entity<TrnsInterviewCallActivity>(entity =>
            {
                entity.ToTable("TrnsInterviewCallActivity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivityContent).HasMaxLength(100);

                entity.Property(e => e.ActivityDt).HasColumnType("datetime");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.HandledbyEmpId).HasColumnName("handledbyEmpID");

                entity.Property(e => e.Icid).HasColumnName("ICID");

                entity.Property(e => e.Recurrence)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.HandledbyEmp)
                    .WithMany(p => p.TrnsInterviewCallActivities)
                    .HasForeignKey(d => d.HandledbyEmpId)
                    .HasConstraintName("FK_TrnsInterviewCallActivity_MstEmployee");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.TrnsInterviewCallActivities)
                    .HasForeignKey(d => d.Icid)
                    .HasConstraintName("FK_TrnsInterviewCallActivity_TrnsInterviewCall");
            });

            modelBuilder.Entity<TrnsInterviewCallPanelList>(entity =>
            {
                entity.ToTable("TrnsInterviewCallPanelList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Icid).HasColumnName("ICID");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsInterviewCallPanelLists)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsInterviewCallPanelList_MstEmployee");

                entity.HasOne(d => d.Ic)
                    .WithMany(p => p.TrnsInterviewCallPanelLists)
                    .HasForeignKey(d => d.Icid)
                    .HasConstraintName("FK_TrnsInterviewCallPanelList_TrnsInterviewCall1");
            });

            modelBuilder.Entity<TrnsInterviewEa>(entity =>
            {
                entity.ToTable("TrnsInterviewEAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AssetmentScore).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BudgetSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ContractType).HasMaxLength(10);

                entity.Property(e => e.ContractTypeLov)
                    .HasMaxLength(20)
                    .HasColumnName("ContractTypeLOV");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.DocType).HasDefaultValueSql("((21))");

                entity.Property(e => e.FlgAccepted).HasColumnName("flgAccepted");

                entity.Property(e => e.FlgContract).HasColumnName("flgContract");

                entity.Property(e => e.FlgSelected).HasColumnName("flgSelected");

                entity.Property(e => e.InterviewId).HasColumnName("InterviewID");

                entity.Property(e => e.KnowledgeSkillScore).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ProbationUnit).HasMaxLength(10);

                entity.Property(e => e.RecommendedSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Result).HasMaxLength(10);

                entity.Property(e => e.Series).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.TrnsInterviewEas)
                    .HasForeignKey(d => d.InterviewId)
                    .HasConstraintName("FK_TrnsInterviewEAS_TrnsInterviewCall");
            });

            modelBuilder.Entity<TrnsInterviewEasassetment>(entity =>
            {
                entity.ToTable("TrnsInterviewEASAssetment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Ieasid).HasColumnName("IEASId");

                entity.Property(e => e.Marks).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Obtain).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Required).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.TrnsInterviewEasassetments)
                    .HasForeignKey(d => d.CriteriaId)
                    .HasConstraintName("FK_TrnsInterviewEASAssetment_MstAssestmentCriteria");

                entity.HasOne(d => d.Ieas)
                    .WithMany(p => p.TrnsInterviewEasassetments)
                    .HasForeignKey(d => d.Ieasid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsInterviewEASAssetment_TrnsInterviewEAS");

                entity.HasOne(d => d.Panelist)
                    .WithMany(p => p.TrnsInterviewEasassetments)
                    .HasForeignKey(d => d.PanelistId)
                    .HasConstraintName("FK_TrnsInterviewEASAssetment_MstEmployee");
            });

            modelBuilder.Entity<TrnsInterviewEaspanelist>(entity =>
            {
                entity.ToTable("TrnsInterviewEASPanelist");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ieasid).HasColumnName("IEASId");

                entity.Property(e => e.Marks).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Obtained).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Required).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.TrnsInterviewEaspanelists)
                    .HasForeignKey(d => d.CriteriaId)
                    .HasConstraintName("FK_TrnsInterviewEASPanelist_MstAssestmentCriteria");

                entity.HasOne(d => d.Ieas)
                    .WithMany(p => p.TrnsInterviewEaspanelists)
                    .HasForeignKey(d => d.Ieasid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsInterviewEASPanelist_TrnsInterviewEAS");

                entity.HasOne(d => d.Panelist)
                    .WithMany(p => p.TrnsInterviewEaspanelists)
                    .HasForeignKey(d => d.PanelistId)
                    .HasConstraintName("FK_TrnsIEASPanelist_MstEmployee");
            });

            modelBuilder.Entity<TrnsInterviewEasscoreBoard>(entity =>
            {
                entity.ToTable("TrnsInterviewEASScoreBoard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageMarks).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Ieasid).HasColumnName("IEASId");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.HasOne(d => d.Assestment)
                    .WithMany(p => p.TrnsInterviewEasscoreBoards)
                    .HasForeignKey(d => d.AssestmentId)
                    .HasConstraintName("FK_TrnsInterviewEASScoreBoard_MstAssestment");

                entity.HasOne(d => d.Ieas)
                    .WithMany(p => p.TrnsInterviewEasscoreBoards)
                    .HasForeignKey(d => d.Ieasid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsInterviewEASScoreBoard_TrnsInterviewEAS");
            });

            modelBuilder.Entity<TrnsInterviewRecommendation>(entity =>
            {
                entity.ToTable("TrnsInterviewRecommendation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(30);

                entity.Property(e => e.CandidateId).HasColumnName("candidateId");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(10)
                    .HasColumnName("ContractID");

                entity.Property(e => e.ContractName).HasMaxLength(20);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(20);

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FinalVerdict)
                    .HasMaxLength(10)
                    .HasColumnName("finalVerdict")
                    .IsFixedLength();

                entity.Property(e => e.FlgDocSentForApproval).HasColumnName("flgDocSentForApproval");

                entity.Property(e => e.InterviewCallId).HasColumnName("InterviewCall_ID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(20);

                entity.Property(e => e.OfferedSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RecommendedSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("score");

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.TrnsInterviewRecommendations)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_TrnsInterviewRecommendation_MstCandidate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsInterviewRecommendations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsInterviewRecommendation_MstEmployee");

                entity.HasOne(d => d.InterviewCall)
                    .WithMany(p => p.TrnsInterviewRecommendations)
                    .HasForeignKey(d => d.InterviewCallId)
                    .HasConstraintName("FK_TrnsInterviewRecommendation_TrnsInterviewCall");
            });

            modelBuilder.Entity<TrnsJe>(entity =>
            {
                entity.ToTable("trnsJE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.DisbursedId).HasColumnName("DisbursedID");

                entity.Property(e => e.FlgCanceled).HasColumnName("flgCanceled");

                entity.Property(e => e.FlgDisburseStatus).HasColumnName("flgDisburseStatus");

                entity.Property(e => e.FlgPosted).HasColumnName("flgPosted");

                entity.Property(e => e.IntSboPublished).HasColumnName("intSboPublished");

                entity.Property(e => e.IntSboTransfered).HasColumnName("intSboTransfered");

                entity.Property(e => e.JepostingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("JEPostingDate");

                entity.Property(e => e.Memo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.SbojeNum).HasColumnName("SBOJeNum");

                entity.Property(e => e.Source).HasMaxLength(100);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsJes)
                    .HasForeignKey(d => d.PayrollId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_trnsJE_CfgPayrollDefination");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsJes)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_trnsJE_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsJea1>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsJEA1");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.AcctDesc).HasMaxLength(100);

                entity.Property(e => e.AcctType).HasMaxLength(50);

                entity.Property(e => e.AcctTypeDc)
                    .HasMaxLength(50)
                    .HasColumnName("AcctTypeDC");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Cccode)
                    .HasMaxLength(50)
                    .HasColumnName("CCCode");

                entity.Property(e => e.Ccdesc)
                    .HasMaxLength(100)
                    .HasColumnName("CCDesc");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocType).HasMaxLength(50);

                entity.Property(e => e.Glcode)
                    .HasMaxLength(50)
                    .HasColumnName("GLCode");

                entity.Property(e => e.Glindication)
                    .HasMaxLength(50)
                    .HasColumnName("GLIndication");

                entity.Property(e => e.PeriodName).HasMaxLength(100);

                entity.Property(e => e.PostingDate).HasColumnType("datetime");

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.Reference).HasMaxLength(100);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsJeccregister>(entity =>
            {
                entity.ToTable("TrnsJECCRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.CreditAccountCode).HasMaxLength(100);

                entity.Property(e => e.CreditAccountName).HasMaxLength(100);

                entity.Property(e => e.DebitAccountCode).HasMaxLength(100);

                entity.Property(e => e.DebitAccountName).HasMaxLength(100);

                entity.Property(e => e.Jeid).HasColumnName("JEID");

                entity.Property(e => e.LineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NewLineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.TrnsJeccregisters)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsJECCRegister_TrnsSalaryProcessRegister");
            });

            modelBuilder.Entity<TrnsJedetail>(entity =>
            {
                entity.ToTable("trnsJEDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctCode).HasMaxLength(100);

                entity.Property(e => e.AcctName).HasMaxLength(200);

                entity.Property(e => e.BranchName).HasMaxLength(100);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Credit).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Debit).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Dimension1).HasMaxLength(100);

                entity.Property(e => e.Dimension2).HasMaxLength(100);

                entity.Property(e => e.Dimension3).HasMaxLength(100);

                entity.Property(e => e.Dimension4).HasMaxLength(100);

                entity.Property(e => e.Dimension5).HasMaxLength(100);

                entity.Property(e => e.Fcurrency)
                    .HasMaxLength(100)
                    .HasColumnName("FCurrency");

                entity.Property(e => e.Jeid).HasColumnName("JEID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Project).HasMaxLength(100);

                entity.HasOne(d => d.Je)
                    .WithMany(p => p.TrnsJedetails)
                    .HasForeignKey(d => d.Jeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_trnsJEDetail_trnsJE");
            });

            modelBuilder.Entity<TrnsJobAdvertising>(entity =>
            {
                entity.ToTable("TrnsJobAdvertising");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvertiseMedium).HasMaxLength(30);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.FlgExternal).HasColumnName("flgExternal");

                entity.Property(e => e.FlgInternal).HasColumnName("flgInternal");

                entity.Property(e => e.FlgRecruiter).HasColumnName("flgRecruiter");

                entity.Property(e => e.JrdocId).HasColumnName("JRDocID");

                entity.Property(e => e.Jrseries).HasColumnName("JRSeries");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Jrdoc)
                    .WithMany(p => p.TrnsJobAdvertisings)
                    .HasForeignKey(d => d.JrdocId)
                    .HasConstraintName("FK_TrnsJobAdvertising_TrnsJobRequisition");

                entity.HasOne(d => d.PreferredRecruitersNavigation)
                    .WithMany(p => p.TrnsJobAdvertisings)
                    .HasForeignKey(d => d.PreferredRecruiters)
                    .HasConstraintName("FK_TrnsJobAdvertising_MstRecruiters");
            });

            modelBuilder.Entity<TrnsJobRequisition>(entity =>
            {
                entity.ToTable("TrnsJobRequisition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocatedBudget).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AppOccupancy).HasMaxLength(10);

                entity.Property(e => e.ApprovedBy).HasMaxLength(15);

                entity.Property(e => e.Branch).HasMaxLength(30);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BudgetSalaryFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BudgetSalaryTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CompensationRemarks).HasMaxLength(50);

                entity.Property(e => e.ContractType).HasMaxLength(10);

                entity.Property(e => e.ContractTypeLov)
                    .HasMaxLength(20)
                    .HasColumnName("ContractTypeLOV");

                entity.Property(e => e.CostCenter).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.Designation).HasMaxLength(30);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType)
                    .HasDefaultValueSql("((15))")
                    .HasComment("15");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExperianceUnit).HasMaxLength(20);

                entity.Property(e => e.FlgAdvertised).HasColumnName("flgAdvertised");

                entity.Property(e => e.FlgTempBasis).HasColumnName("flgTempBasis");

                entity.Property(e => e.Location).HasMaxLength(30);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PostingDate).HasColumnType("datetime");

                entity.Property(e => e.RecommendedSalary).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RejOccupancy).HasMaxLength(10);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.RequestedBy).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.Property(e => e.VacantPosition).HasMaxLength(10);

                entity.Property(e => e.ValidUpto).HasColumnType("datetime");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.TrnsJobRequisitions)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_TrnsJobRequisition_MstBraches");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.TrnsJobRequisitions)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_TrnsJobRequisition_MstDepartment");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.TrnsJobRequisitions)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_TrnsJobRequisition_MstDesignation");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.TrnsJobRequisitions)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_TrnsJobRequisition_MstLocation");
            });

            modelBuilder.Entity<TrnsJrdetailCertification>(entity =>
            {
                entity.ToTable("TrnsJRDetailCertification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Jrid).HasColumnName("JRID");

                entity.Property(e => e.Module).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.CertificationTypeNavigation)
                    .WithMany(p => p.TrnsJrdetailCertifications)
                    .HasForeignKey(d => d.CertificationType)
                    .HasConstraintName("FK_TrnsJobRequisitionQualificationCertification_MstCertification");

                entity.HasOne(d => d.Jr)
                    .WithMany(p => p.TrnsJrdetailCertifications)
                    .HasForeignKey(d => d.Jrid)
                    .HasConstraintName("FK_TrnsJobRequisitionQualificationCertification_TrnsJobRequisition");
            });

            modelBuilder.Entity<TrnsJrdetailCompetancy>(entity =>
            {
                entity.ToTable("TrnsJRDetailCompetancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CompetancyId).HasColumnName("CompetancyID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Jrid).HasColumnName("JRID");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Competancy)
                    .WithMany(p => p.TrnsJrdetailCompetancies)
                    .HasForeignKey(d => d.CompetancyId)
                    .HasConstraintName("FK_TrnsJobRequisitionCompetancy_MstCompetancy");

                entity.HasOne(d => d.Jr)
                    .WithMany(p => p.TrnsJrdetailCompetancies)
                    .HasForeignKey(d => d.Jrid)
                    .HasConstraintName("FK_TrnsJobRequisitionCompetancy_TrnsJobRequisition");
            });

            modelBuilder.Entity<TrnsJrdetailEducation>(entity =>
            {
                entity.ToTable("TrnsJRDetailEducation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Diploma).HasMaxLength(15);

                entity.Property(e => e.Jrid).HasColumnName("JRID");

                entity.Property(e => e.Major).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.EducationTypeNavigation)
                    .WithMany(p => p.TrnsJrdetailEducations)
                    .HasForeignKey(d => d.EducationType)
                    .HasConstraintName("FK_TrnsJobRequisitionQualification_MstQualification");

                entity.HasOne(d => d.Jr)
                    .WithMany(p => p.TrnsJrdetailEducations)
                    .HasForeignKey(d => d.Jrid)
                    .HasConstraintName("FK_TrnsJobRequisitionQualification_TrnsJobRequisition");
            });

            modelBuilder.Entity<TrnsJrdetailSkill>(entity =>
            {
                entity.ToTable("TrnsJRDetailSkills");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Jrid).HasColumnName("JRID");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Jr)
                    .WithMany(p => p.TrnsJrdetailSkills)
                    .HasForeignKey(d => d.Jrid)
                    .HasConstraintName("FK_TrnsJobRequisitionSkills_TrnsJobRequisition");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TrnsJrdetailSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_TrnsJobRequisitionSkills_MstSkills");
            });

            modelBuilder.Entity<TrnsKpi>(entity =>
            {
                entity.ToTable("TrnsKPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.KeyObjectives).HasMaxLength(30);

                entity.Property(e => e.LaggingKpi)
                    .HasMaxLength(30)
                    .HasColumnName("LaggingKPI");

                entity.Property(e => e.LeadingKpi)
                    .HasMaxLength(30)
                    .HasColumnName("LeadingKPI");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<TrnsLeaveRequestHistory>(entity =>
            {
                entity.ToTable("TrnsLeaveRequestHistory");

                entity.Property(e => e.ApproverName).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FlgAction).HasColumnName("flgAction");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.StatusId)
                    .HasMaxLength(10)
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("StatusLOVType");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TrnsLeaveRequestHistories)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_TrnsLeaveRequestHistory_TrnsLeavesRequest");
            });

            modelBuilder.Entity<TrnsLeavesRequest>(entity =>
            {
                entity.ToTable("TrnsLeavesRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adldate)
                    .HasColumnType("datetime")
                    .HasColumnName("ADLDate");

                entity.Property(e => e.AttendanceId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AttendanceID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.Compensation).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DeductAmnt).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DeductId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeductedAmnt).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DestAddress).HasMaxLength(200);

                entity.Property(e => e.DestPh)
                    .HasMaxLength(30)
                    .HasColumnName("DestPH");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType).HasDefaultValueSql("((13))");

                entity.Property(e => e.EmpDept).HasMaxLength(50);

                entity.Property(e => e.EmpDesg).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpLoc).HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FlgMedical).HasColumnName("flgMedical");

                entity.Property(e => e.FlgOfficial).HasColumnName("flgOfficial");

                entity.Property(e => e.FlgPaid).HasColumnName("flgPaid");

                entity.Property(e => e.FlgVisa).HasColumnName("flgVisa");

                entity.Property(e => e.FromTime).HasMaxLength(50);

                entity.Property(e => e.LeaveDescription).HasMaxLength(250);

                entity.Property(e => e.LeaveFrom).HasColumnType("datetime");

                entity.Property(e => e.LeaveTo).HasColumnType("datetime");

                entity.Property(e => e.LeavesType).HasMaxLength(50);

                entity.Property(e => e.MedicalMode).HasMaxLength(20);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PendingDedAmnt).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PendingDedId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.RembAmnt).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SubId).HasColumnName("SubID");

                entity.Property(e => e.SubName).HasMaxLength(200);

                entity.Property(e => e.TicketType).HasMaxLength(20);

                entity.Property(e => e.ToTime).HasMaxLength(50);

                entity.Property(e => e.TotalCount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Units).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(10)
                    .HasColumnName("UnitsID");

                entity.Property(e => e.UnitsLovtype)
                    .HasMaxLength(20)
                    .HasColumnName("UnitsLOVType");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsLeavesRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsLeavesRequest_MstEmployee");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.TrnsLeavesRequests)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_TrnsLeavesRequest_MstLeaveType");
            });

            modelBuilder.Entity<TrnsLoan>(entity =>
            {
                entity.ToTable("TrnsLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType).HasDefaultValueSql("((11))");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName).HasMaxLength(100);

                entity.Property(e => e.MarkUpRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfInstallments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.OriginatorId).HasColumnName("OriginatorID");

                entity.Property(e => e.OriginatorName).HasMaxLength(100);

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransId).HasColumnName("TransID");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsLoanEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsLoan_MstEmployee");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TrnsLoanManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_TrnsLoan_MstEmployee1");

                entity.HasOne(d => d.Originator)
                    .WithMany(p => p.TrnsLoanOriginators)
                    .HasForeignKey(d => d.OriginatorId)
                    .HasConstraintName("FK_TrnsLoan_MstEmployee2");
            });

            modelBuilder.Entity<TrnsLoanAndAdvancePayment>(entity =>
            {
                entity.ToTable("TrnsLoanAndAdvancePayment");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocType).HasDefaultValueSql("((11))");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgAccount).HasColumnName("flgAccount");

                entity.Property(e => e.FlgBank).HasColumnName("flgBank");

                entity.Property(e => e.Latype)
                    .HasMaxLength(30)
                    .HasColumnName("LAType");

                entity.Property(e => e.LoadAdvanceId).HasColumnName("LoadAdvanceID");

                entity.Property(e => e.Manager).HasMaxLength(30);

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsLoanAndAdvancePayments)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsLoanAndAdvancePayment_MstEmployee");
            });

            modelBuilder.Entity<TrnsLoanAndAdvancePaymentDetail>(entity =>
            {
                entity.ToTable("TrnsLoanAndAdvancePaymentDetail");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentRemarks).HasMaxLength(100);

                entity.Property(e => e.Glaccount)
                    .HasMaxLength(16)
                    .HasColumnName("GLAccount");

                entity.Property(e => e.Glname)
                    .HasMaxLength(50)
                    .HasColumnName("GLName");

                entity.Property(e => e.LapaymentId).HasColumnName("LAPaymentID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Lapayment)
                    .WithMany(p => p.TrnsLoanAndAdvancePaymentDetails)
                    .HasForeignKey(d => d.LapaymentId)
                    .HasConstraintName("FK_TrnsLoanAndAdvancePaymentDetail_TrnsLoanAndAdvancePayment");
            });

            modelBuilder.Entity<TrnsLoanDetail>(entity =>
            {
                entity.ToTable("TrnsLoanDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ApprovedInstallment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgStopRecovery).HasColumnName("flgStopRecovery");

                entity.Property(e => e.FlgVoid).HasColumnName("flgVoid");

                entity.Property(e => e.Gratuity).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Installments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LnAid).HasColumnName("LnAID");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.ReceivedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RecoveredAmount)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.LnA)
                    .WithMany(p => p.TrnsLoanDetails)
                    .HasForeignKey(d => d.LnAid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsLoanDetail_TrnsLoan");

                entity.HasOne(d => d.LoanTypeNavigation)
                    .WithMany(p => p.TrnsLoanDetails)
                    .HasForeignKey(d => d.LoanType)
                    .HasConstraintName("FK_TrnsLoanDetail_MstLoans");
            });

            modelBuilder.Entity<TrnsLoanInstallmentPlan>(entity =>
            {
                entity.ToTable("TrnsLoanInstallmentPlan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.FlgRevised).HasColumnName("flgRevised");

                entity.Property(e => e.FlgUsed).HasColumnName("flgUsed");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.Reference).HasMaxLength(200);

                entity.Property(e => e.Sboid).HasColumnName("SBOID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.TrnsLoanInstallmentPlans)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_TrnsLoanInstallmentPlan_TrnsLoan");
            });

            modelBuilder.Entity<TrnsLoanMarkupRateDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MarkupRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfInstallments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PrincipalAmount).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<TrnsLoanReceived>(entity =>
            {
                entity.ToTable("TrnsLoanReceived");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(250);

                entity.Property(e => e.LnAid).HasColumnName("LnAID");

                entity.Property(e => e.ReceivedAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            });

            modelBuilder.Entity<TrnsLoanRegister>(entity =>
            {
                entity.ToTable("TrnsLoanRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseDocNum).HasMaxLength(20);

                entity.Property(e => e.BaseType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.DueAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(20)
                    .HasColumnName("EmpID");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.RecoveredAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.TrnsLoanRegisters)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_TrnsLoanRegister_TrnsLoan");
            });

            modelBuilder.Entity<TrnsLoanRequest>(entity =>
            {
                entity.ToTable("TrnsLoanRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.EmpDept).HasMaxLength(50);

                entity.Property(e => e.EmpDesg).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.FkloanId).HasColumnName("FKLoanID");

                entity.Property(e => e.FlgStopInstallment).HasColumnName("flgStopInstallment");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.InstallmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanCode).HasMaxLength(250);

                entity.Property(e => e.LoanDescription).HasMaxLength(250);

                entity.Property(e => e.LoanProvidedOn).HasColumnType("datetime");

                entity.Property(e => e.NoOfInstallments).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.RequestedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<TrnsLstslab>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsLSTSlabs");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.FkfiscalYear).HasColumnName("FKFiscalYear");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsLstslabDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsLSTSlabDetails");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinValue).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsLstslabDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsLSTSlabDetails_TrnsLSTSlabs");
            });

            modelBuilder.Entity<TrnsLstslabPeriod>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsLSTSlabPeriods");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.PaidMonths).HasMaxLength(50);

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsLstslabPeriods)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsLSTSlabPeriods_TrnsLSTSlabs");
            });

            modelBuilder.Entity<TrnsMarriageAssistanceRequest>(entity =>
            {
                entity.ToTable("TrnsMarriageAssistanceRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalOfDoc).HasMaxLength(200);

                entity.Property(e => e.ApprovalReceivingApp).HasMaxLength(200);

                entity.Property(e => e.AssistanceType).HasMaxLength(100);

                entity.Property(e => e.Attachment).HasMaxLength(400);

                entity.Property(e => e.AttachmentType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.MeetRequirement).HasMaxLength(20);

                entity.Property(e => e.Remarks).HasMaxLength(2000);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ZakaatEmpDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsMarriageAssistanceRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsMarriageAssistanceRequest_MstEmployee");
            });

            modelBuilder.Entity<TrnsMedical>(entity =>
            {
                entity.ToTable("TrnsMedical");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Consultation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("consultation");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empName");

                entity.Property(e => e.MDate)
                    .HasColumnType("datetime")
                    .HasColumnName("mDate");

                entity.Property(e => e.Medicine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("medicine");

                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("relation");
            });

            modelBuilder.Entity<TrnsNotificaiotnApprovalSystem>(entity =>
            {
                entity.ToTable("TrnsNotificaiotnApprovalSystem");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateForm).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsNotificaiotnApprovalSystems)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsNotificaiotnApprovalSystem_MstEmployee");

                entity.HasOne(d => d.NotificationCategory)
                    .WithMany(p => p.TrnsNotificaiotnApprovalSystems)
                    .HasForeignKey(d => d.NotificationCategoryId)
                    .HasConstraintName("FK_TrnsNotificaiotnApprovalSystem_MstNoficationCategory");
            });

            modelBuilder.Entity<TrnsObSalaryAdj>(entity =>
            {
                entity.ToTable("TrnsObSalaryAdj");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsObarrear>(entity =>
            {
                entity.ToTable("TrnsOBArrears");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrearId).HasColumnName("ArrearID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Updatedby).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Arrear)
                    .WithMany(p => p.TrnsObarrears)
                    .HasForeignKey(d => d.ArrearId)
                    .HasConstraintName("FK_TrnsOBArrears_MstArrears");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObarrears)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBArrears_MstEmployee");
            });

            modelBuilder.Entity<TrnsObcontribution>(entity =>
            {
                entity.ToTable("TrnsOBContribution");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.ContributionId).HasColumnName("ContributionID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Contribution)
                    .WithMany(p => p.TrnsObcontributions)
                    .HasForeignKey(d => d.ContributionId)
                    .HasConstraintName("FK_TrnsOBContribution_MstElementContribution");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObcontributions)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBContribution_MstEmployee");
            });

            modelBuilder.Entity<TrnsObdisbursement>(entity =>
            {
                entity.ToTable("TrnsOBDisbursement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.SalaryAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsObgratuity>(entity =>
            {
                entity.ToTable("TrnsOBGratuity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObgratuities)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBGratuity_MstEmployee");
            });

            modelBuilder.Entity<TrnsObjFnyDetail>(entity =>
            {
                entity.ToTable("TrnsObjFNY_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .HasColumnName("approvalStatus");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.HeadId).HasColumnName("headId");

                entity.Property(e => e.KpIndicator)
                    .HasMaxLength(50)
                    .HasColumnName("kpIndicator");

                entity.Property(e => e.Subheading)
                    .HasMaxLength(50)
                    .HasColumnName("subheading");

                entity.Property(e => e.Timeline)
                    .HasMaxLength(50)
                    .HasColumnName("timeline");

                entity.Property(e => e.Weightage)
                    .HasMaxLength(10)
                    .HasColumnName("weightage");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsObjFnyDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsObjFNY_detail_TrnsObjFNY_head");
            });

            modelBuilder.Entity<TrnsObjFnyHead>(entity =>
            {
                entity.ToTable("TrnsObjFNY_head");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .HasColumnName("approvalStatus");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FieldForCalc)
                    .HasMaxLength(50)
                    .HasColumnName("field_forCalc");

                entity.Property(e => e.FlgHrapproval)
                    .HasColumnName("flgHRApproval")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KpIndicator).HasColumnName("kpIndicator");

                entity.Property(e => e.ObjectiveId).HasColumnName("objectiveId");

                entity.Property(e => e.SelfProgress)
                    .HasMaxLength(50)
                    .HasColumnName("selfProgress");

                entity.Property(e => e.Subheading).HasColumnName("subheading");

                entity.Property(e => e.SuperVisorComments)
                    .HasMaxLength(500)
                    .HasColumnName("superVisorComments");

                entity.Property(e => e.SupervisorCalculation)
                    .HasMaxLength(50)
                    .HasColumnName("supervisorCalculation");

                entity.Property(e => e.SupervisorProgress)
                    .HasMaxLength(50)
                    .HasColumnName("supervisorProgress");

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.Property(e => e.Timeline).HasColumnName("timeline");

                entity.Property(e => e.Weightage)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("weightage");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObjFnyHeads)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsObjFNY_head_MstEmployee");

                entity.HasOne(d => d.Objective)
                    .WithMany(p => p.TrnsObjFnyHeads)
                    .HasForeignKey(d => d.ObjectiveId)
                    .HasConstraintName("FK_TrnsObjFNY_head_MstObjective");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.TrnsObjFnyHeads)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_TrnsObjFNY_head_MstCalendar");
            });

            modelBuilder.Entity<TrnsObjFnyHeadTemp>(entity =>
            {
                entity.ToTable("TrnsObjFNY_headTemp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .HasColumnName("approvalStatus");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FieldForCalc)
                    .HasMaxLength(50)
                    .HasColumnName("field_forCalc");

                entity.Property(e => e.FlgHrapproval).HasColumnName("flgHRApproval");

                entity.Property(e => e.KpIndicator).HasColumnName("kpIndicator");

                entity.Property(e => e.ObjectiveId).HasColumnName("objectiveId");

                entity.Property(e => e.SelfProgress)
                    .HasMaxLength(50)
                    .HasColumnName("selfProgress");

                entity.Property(e => e.Subheading).HasColumnName("subheading");

                entity.Property(e => e.SupervisorCalculation)
                    .HasMaxLength(50)
                    .HasColumnName("supervisorCalculation");

                entity.Property(e => e.SupervisorProgress)
                    .HasMaxLength(50)
                    .HasColumnName("supervisorProgress");

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.Property(e => e.Timeline).HasColumnName("timeline");

                entity.Property(e => e.Weightage).HasColumnName("weightage");

                entity.Property(e => e.YearId).HasColumnName("yearId");
            });

            modelBuilder.Entity<TrnsObjFnyProgress>(entity =>
            {
                entity.ToTable("TrnsObjFNY_Progress");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkObjDetailId).HasColumnName("fk_objDetailId");

                entity.Property(e => e.SelfProgress)
                    .HasMaxLength(50)
                    .HasColumnName("selfProgress");

                entity.Property(e => e.SupervisorProgress)
                    .HasMaxLength(50)
                    .HasColumnName("supervisorProgress");

                entity.HasOne(d => d.FkObjDetail)
                    .WithMany(p => p.TrnsObjFnyProgresses)
                    .HasForeignKey(d => d.FkObjDetailId)
                    .HasConstraintName("FK_TrnsObjFNY_Progress_TrnsObjFNY_detail");
            });

            modelBuilder.Entity<TrnsObleaf>(entity =>
            {
                entity.ToTable("TrnsOBLeaves");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.LeaveAllowance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeaveBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeaveId).HasColumnName("LeaveID");

                entity.Property(e => e.LeaveUsed).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeavesCarryForward).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LeavesEntitled).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObleaves)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBLeaves_MstEmployee");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.TrnsObleaves)
                    .HasForeignKey(d => d.LeaveId)
                    .HasConstraintName("FK_TrnsOBLeaves_MstLeaveType");
            });

            modelBuilder.Entity<TrnsObloan>(entity =>
            {
                entity.ToTable("TrnsOBLoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BalanceAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Installment).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.RecoverdAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("numeric(19, 6)")
                    .HasComputedColumnSql("([BalanceAmount]+[RecoverdAmount])", false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObloans)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBLoan_MstEmployee");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.TrnsObloans)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_TrnsOBLoan_MstLoans");
            });

            modelBuilder.Entity<TrnsObprovidentFund>(entity =>
            {
                entity.ToTable("TrnsOBProvidentFund");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CummulativeRoi)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("CummulativeROI");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmployeeBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployerBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObprovidentFunds)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBProvidentFund_MstEmployee");
            });

            modelBuilder.Entity<TrnsObsalary>(entity =>
            {
                entity.ToTable("TrnsOBSalary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SalaryBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObsalaries)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBSalary_MstEmployee");
            });

            modelBuilder.Entity<TrnsObtax>(entity =>
            {
                entity.ToTable("TrnsOBTax");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CalId).HasColumnName("CalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Month).HasColumnType("datetime");

                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TaxBalance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsObtaxes)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOBTax_MstEmployee");
            });

            modelBuilder.Entity<TrnsOfferLetter>(entity =>
            {
                entity.ToTable("TrnsOfferLetter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalPoints).HasMaxLength(2100);

                entity.Property(e => e.AdminActionDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovedSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.ContractId)
                    .HasMaxLength(30)
                    .HasColumnName("ContractID");

                entity.Property(e => e.ContractName).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName).HasMaxLength(500);

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EndingDate).HasColumnType("datetime");

                entity.Property(e => e.FlgDocSentForApproval).HasColumnName("flgDocSentForApproval");

                entity.Property(e => e.FlgHrhiringDecisionStatus).HasColumnName("flgHRHiringDecisionStatus");

                entity.Property(e => e.FlgRegionalHeadDecisionStatus).HasColumnName("flgRegionalHeadDecisionStatus");

                entity.Property(e => e.FlgSentToHr).HasColumnName("flgSentToHR");

                entity.Property(e => e.FlgSentToRegionalHead).HasColumnName("flgSentToRegionalHead");

                entity.Property(e => e.InterviewRecommendationId).HasColumnName("InterviewRecommendationID");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(500);

                entity.Property(e => e.OfferedSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PrjCode).HasMaxLength(50);

                entity.Property(e => e.PrjName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.RecommendedSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsOfferLetters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsOfferLetter_TrnsOfferLetter");

                entity.HasOne(d => d.InterviewRecommendation)
                    .WithMany(p => p.TrnsOfferLetters)
                    .HasForeignKey(d => d.InterviewRecommendationId)
                    .HasConstraintName("FK_TrnsOfferLetter_TrnsInterviewRecommendation");
            });

            modelBuilder.Entity<TrnsOtslab>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsOTSlab");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.SlabCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsOtslabDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsOTSlabDetail");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LowerLimit).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Ottype).HasColumnName("OTType");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpperLimit).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.OttypeNavigation)
                    .WithMany(p => p.TrnsOtslabDetails)
                    .HasForeignKey(d => d.Ottype)
                    .HasConstraintName("FK_TrnsOTSlabDetail_MstOverTime");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.TrnsOtslabDetails)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsOTSlabDetail_TrnsOTSlab");
            });

            modelBuilder.Entity<TrnsOvertime>(entity =>
            {
                entity.ToTable("TrnsOvertime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.OverTimeHours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PeriodCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsPartnerAssessmentDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerAssessmentDetail");

                entity.Property(e => e.FlgPartner).HasColumnName("flgPartner");

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Score).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPartnerAssessmentDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPartnerAssessmentDetail_MstEmployee");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsPartnerAssessmentDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsPartnerAssessmentDetail_TrnsPartnerAssessmentHead");

                entity.HasOne(d => d.Stmnt)
                    .WithMany(p => p.TrnsPartnerAssessmentDetails)
                    .HasForeignKey(d => d.StmntId)
                    .HasConstraintName("FK_TrnsPartnerAssessmentDetail_MstPartnerFeedbackStmntDetail");
            });

            modelBuilder.Entity<TrnsPartnerAssessmentHead>(entity =>
            {
                entity.ToTable("TrnsPartnerAssessmentHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.PartnerFunction)
                    .HasMaxLength(50)
                    .HasColumnName("partnerFunction");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.TotalScore).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPartnerAssessmentHeads)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPartnerAssessmentHead_MstEmployee");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.TrnsPartnerAssessmentHeads)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_TrnsPartnerAssessmentHead_MstPartnerFeedback");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerAssessmentHeads)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerAssessmentHead_MstCalendar");
            });

            modelBuilder.Entity<TrnsPartnerBusinessRevenue>(entity =>
            {
                entity.ToTable("TrnsPartnerBusinessRevenue");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerBusinessRevenues)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerBusinessRevenue_MstCalendar");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.TrnsPartnerBusinessRevenues)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK_TrnsPartnerBusinessRevenue_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPartnerBusinessRevenueDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerBusinessRevenueDetail");

                entity.Property(e => e.NewBusinessAmnt).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PartnerName).HasMaxLength(50);

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositiveNumbers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.BusinessRevenue)
                    .WithMany(p => p.TrnsPartnerBusinessRevenueDetails)
                    .HasForeignKey(d => d.BusinessRevenueId)
                    .HasConstraintName("FK_TrnsPartnerBusinessRevenueDetail_TrnsPartnerBusinessRevenueDetail");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerBusinessRevenueDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerBusinessRevenueDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerContributionDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerContributionDetail");

                entity.Property(e => e.BonusPool).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContributionId).HasColumnName("ContributionID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.PartnerName).HasMaxLength(50);

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositiveNumbers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Contribution)
                    .WithMany(p => p.TrnsPartnerContributionDetails)
                    .HasForeignKey(d => d.ContributionId)
                    .HasConstraintName("FK_TrnsPartnerContributionDetail_TrnsPartnerContributionPool");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerContributionDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerContributionDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerContributionPool>(entity =>
            {
                entity.ToTable("TrnsPartnerContributionPool");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerContributionPools)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerContributionPool_MstCalendar");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.TrnsPartnerContributionPools)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK_TrnsPartnerContributionPool_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPartnerFacilitateTrainingDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerFacilitateTrainingDetail");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositiveNumbers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrainerHours).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsPartnerFacilitateTrainingDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsPartnerFacilitateTrainingDetail_TrnsPartnerFacilitateTrainingHead");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerFacilitateTrainingDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerFacilitateTrainingDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerFacilitateTrainingHead>(entity =>
            {
                entity.ToTable("TrnsPartnerFacilitateTrainingHead");

                entity.Property(e => e.AllocatedPoints).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerFacilitateTrainingHeads)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerFacilitateTrainingHead_MstCalendar");

                entity.HasOne(d => d.SubCatDetail)
                    .WithMany(p => p.TrnsPartnerFacilitateTrainingHeads)
                    .HasForeignKey(d => d.SubCatDetailId)
                    .HasConstraintName("FK_TrnsPartnerFacilitateTrainingHead_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPartnerFeedback360>(entity =>
            {
                entity.ToTable("TrnsPartnerFeedback360");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgPartner).HasColumnName("flgPartner");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Weightage).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ComptncyStmnt)
                    .WithMany(p => p.TrnsPartnerFeedback360s)
                    .HasForeignKey(d => d.ComptncyStmntId)
                    .HasConstraintName("FK_TrnsPartnerFeedback360_MstPartnerFeedbackStmntDetail");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerFeedback360s)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerFeedback360_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerNetProfit>(entity =>
            {
                entity.ToTable("TrnsPartnerNetProfit");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerNetProfits)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerNetProfit_MstCalendar");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.TrnsPartnerNetProfits)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK_TrnsPartnerNetProfit_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPartnerNetProfitDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerNetProfitDetail");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.NetProfit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetProfitId).HasColumnName("NetProfitID");

                entity.Property(e => e.PartnerName).HasMaxLength(50);

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositiveNumbers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.NetProfitNavigation)
                    .WithMany(p => p.TrnsPartnerNetProfitDetails)
                    .HasForeignKey(d => d.NetProfitId)
                    .HasConstraintName("FK_TrnsPartnerNetProfitDetail_TrnsPartnerNetProfit");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerNetProfitDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerNetProfitDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerPerformanceFinalPosting>(entity =>
            {
                entity.ToTable("TrnsPartnerPerformanceFinalPosting");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WeightageAllocation).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightageSumAfter).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightageSumBefore).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TrnsPartnerPerformanceFinalPostings)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_TrnsPartnerPerformanceFinalPosting_MstPartnerPerformanceCategory");
            });

            modelBuilder.Entity<TrnsPartnerRevenueAccrual>(entity =>
            {
                entity.ToTable("TrnsPartnerRevenueAccrual");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerRevenueAccruals)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerRevenueAccrual_MstCalendar");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.TrnsPartnerRevenueAccruals)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK_TrnsPartnerRevenueAccrual_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPartnerRevenueAccrualDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerRevenueAccrualDetail");

                entity.Property(e => e.PartnerName).HasMaxLength(50);

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositiveNumbers).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Revenue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerRevenueAccrualDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerRevenueAccrualDetail_MstEmployee");

                entity.HasOne(d => d.RevenueAcc)
                    .WithMany(p => p.TrnsPartnerRevenueAccrualDetails)
                    .HasForeignKey(d => d.RevenueAccId)
                    .HasConstraintName("FK_TrnsPartnerRevenueAccrualDetail_TrnsPartnerRevenueAccrual");
            });

            modelBuilder.Entity<TrnsPartnerUnAllocatedFormsDetail>(entity =>
            {
                entity.ToTable("TrnsPartnerUnAllocatedFormsDetail");

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsPartnerUnAllocatedFormsDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsPartnerUnAllocatedFormsDetail_TrnsPartnerUnAllocatedFormsHead");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerUnAllocatedFormsDetails)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerUnAllocatedFormsDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsPartnerUnAllocatedFormsHead>(entity =>
            {
                entity.ToTable("TrnsPartnerUnAllocatedFormsHead");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PartnerPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.TrnsPartnerUnAllocatedFormsHeads)
                    .HasForeignKey(d => d.FiscalYear)
                    .HasConstraintName("FK_TrnsPartnerUnAllocatedFormsHead_MstCalendar");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrnsPartnerUnAllocatedFormsHeads)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrnsPartnerUnAllocatedFormsHead_MstEmployee");

                entity.HasOne(d => d.SubCatDetail)
                    .WithMany(p => p.TrnsPartnerUnAllocatedFormsHeads)
                    .HasForeignKey(d => d.SubCatDetailId)
                    .HasConstraintName("FK_TrnsPartnerUnAllocatedFormsHead_MstPartnerPerformanceSubCatDetail");
            });

            modelBuilder.Entity<TrnsPayeslab>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsPAYESlabs");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsPayeslabDetail>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsPAYESlabDetails");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.ExceededPercentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FixValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.MaxValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MinValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpperCap).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsPayeslabDetails)
                    .HasForeignKey(d => d.Fkid)
                    .HasConstraintName("FK_TrnsPAYESlabDetails_TrnsPAYESlabs");
            });

            modelBuilder.Entity<TrnsPeerFeedback360>(entity =>
            {
                entity.ToTable("TrnsPeerFeedback360");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Weightage).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Comptncy)
                    .WithMany(p => p.TrnsPeerFeedback360s)
                    .HasForeignKey(d => d.ComptncyId)
                    .HasConstraintName("FK_TrnsPeerFeedback360_MstPartnerFeedbackDetail");

                entity.HasOne(d => d.Peer)
                    .WithMany(p => p.TrnsPeerFeedback360s)
                    .HasForeignKey(d => d.PeerId)
                    .HasConstraintName("FK_TrnsPeerFeedback360_MstEmployee");
            });

            modelBuilder.Entity<TrnsPerformanceAppraisal>(entity =>
            {
                entity.ToTable("TrnsPerformanceAppraisal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppraiserDepartment).HasMaxLength(50);

                entity.Property(e => e.AppraiserId).HasColumnName("AppraiserID");

                entity.Property(e => e.AppraiserName).HasMaxLength(20);

                entity.Property(e => e.AppraiserPosition).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.DocType).HasDefaultValueSql("((17))");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(20);

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.TotalScore).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Appraiser)
                    .WithMany(p => p.TrnsPerformanceAppraisalAppraisers)
                    .HasForeignKey(d => d.AppraiserId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal_MstEmployee1");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerformanceAppraisalEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal_MstEmployee");

                entity.HasOne(d => d.PlanNumberNavigation)
                    .WithMany(p => p.TrnsPerformanceAppraisals)
                    .HasForeignKey(d => d.PlanNumber)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal_TrnsPerformancePlan");
            });

            modelBuilder.Entity<TrnsPerformanceAppraisal360>(entity =>
            {
                entity.ToTable("TrnsPerformanceAppraisal360");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CompetencyGroupId).HasColumnName("CompetencyGroupID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType).HasDefaultValueSql("((18))");

                entity.Property(e => e.EmpFirstName).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpLastName).HasMaxLength(20);

                entity.Property(e => e.OverallRating).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PerfPeriodFrom).HasColumnType("datetime");

                entity.Property(e => e.PerfPeriodTo).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.TotalScore).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.CompetencyGroup)
                    .WithMany(p => p.TrnsPerformanceAppraisal360s)
                    .HasForeignKey(d => d.CompetencyGroupId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360_MstCompetencyGroup");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerformanceAppraisal360s)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360_MstEmployee");

                entity.HasOne(d => d.PlanNoNavigation)
                    .WithMany(p => p.TrnsPerformanceAppraisal360s)
                    .HasForeignKey(d => d.PlanNo)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360_TrnsPerformancePlan");
            });

            modelBuilder.Entity<TrnsPerformanceAppraisal360Detail>(entity =>
            {
                entity.ToTable("TrnsPerformanceAppraisal360Detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ap360id).HasColumnName("AP360ID");

                entity.Property(e => e.CompetencyId).HasColumnName("CompetencyID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Customer).HasMaxLength(50);

                entity.Property(e => e.LineTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ScoreCustomer).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ScoreManager).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ScorePeer).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ScoreSo)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("ScoreSO");

                entity.Property(e => e.ScoreSupplier).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SelfScore).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SubOrdinateId).HasColumnName("SubOrdinateID");

                entity.Property(e => e.Supplier).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Ap360)
                    .WithMany(p => p.TrnsPerformanceAppraisal360Details)
                    .HasForeignKey(d => d.Ap360id)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360Detail_TrnsPerformanceAppraisal360");

                entity.HasOne(d => d.Competency)
                    .WithMany(p => p.TrnsPerformanceAppraisal360Details)
                    .HasForeignKey(d => d.CompetencyId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360Detail_TrnsCompetencyProfile");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TrnsPerformanceAppraisal360DetailManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360Detail_MstEmployee");

                entity.HasOne(d => d.PeerNavigation)
                    .WithMany(p => p.TrnsPerformanceAppraisal360DetailPeerNavigations)
                    .HasForeignKey(d => d.Peer)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360Detail_MstEmployee2");

                entity.HasOne(d => d.SubOrdinate)
                    .WithMany(p => p.TrnsPerformanceAppraisal360DetailSubOrdinates)
                    .HasForeignKey(d => d.SubOrdinateId)
                    .HasConstraintName("FK_TrnsPerformanceAppraisal360Detail_MstEmployee1");
            });

            modelBuilder.Entity<TrnsPerformanceAppraisalDetail>(entity =>
            {
                entity.ToTable("TrnsPerformanceAppraisalDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Kpiid).HasColumnName("KPIID");

                entity.Property(e => e.ManagerRemarks).HasMaxLength(100);

                entity.Property(e => e.Paid).HasColumnName("PAID");

                entity.Property(e => e.ReportingManager).HasMaxLength(10);

                entity.Property(e => e.ReportingManagerLov)
                    .HasMaxLength(20)
                    .HasColumnName("ReportingManagerLOV");

                entity.Property(e => e.Score).HasMaxLength(10);

                entity.Property(e => e.SelfAppraisal).HasMaxLength(10);

                entity.Property(e => e.SelfAppraisalLov)
                    .HasMaxLength(20)
                    .HasColumnName("SelfAppraisalLOV");

                entity.Property(e => e.SelfRemarks).HasMaxLength(100);

                entity.Property(e => e.TargetPer).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.Weightage).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Kpi)
                    .WithMany(p => p.TrnsPerformanceAppraisalDetails)
                    .HasForeignKey(d => d.Kpiid)
                    .HasConstraintName("FK_TrnsPerformanceAppraisalDetail_TrnsPerformancePlan");

                entity.HasOne(d => d.Pa)
                    .WithMany(p => p.TrnsPerformanceAppraisalDetails)
                    .HasForeignKey(d => d.Paid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsPerformanceAppraisalDetail_TrnsPerformanceAppraisal");
            });

            modelBuilder.Entity<TrnsPerformanceEvaluationHead>(entity =>
            {
                entity.ToTable("TrnsPerformanceEvaluationHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnamolyAmount)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AnomalyPercentage)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AppraiserId).HasColumnName("AppraiserID");

                entity.Property(e => e.AppraiserRatingDate).HasColumnType("datetime");

                entity.Property(e => e.AppraiserRemarks).HasMaxLength(500);

                entity.Property(e => e.Ceoremarks)
                    .HasMaxLength(500)
                    .HasColumnName("CEORemarks");

                entity.Property(e => e.Comments)
                    .HasMaxLength(550)
                    .HasColumnName("comments");

                entity.Property(e => e.CommitmentAllowance).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentSalary)
                    .HasColumnType("decimal(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmployeeAssessmentRemarks).HasMaxLength(500);

                entity.Property(e => e.EmployeeSigningComments).HasMaxLength(500);

                entity.Property(e => e.EmployeeSigningDate).HasColumnType("datetime");

                entity.Property(e => e.FinalRating)
                    .HasMaxLength(20)
                    .HasColumnName("finalRating");

                entity.Property(e => e.FiscalYear).HasColumnName("fiscalYear");

                entity.Property(e => e.FlgHodapproved)
                    .HasColumnName("flgHODApproved")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FlgRevert).HasColumnName("flgRevert");

                entity.Property(e => e.Hodcomments)
                    .HasMaxLength(500)
                    .HasColumnName("HODComments");

                entity.Property(e => e.HranamolyAmount)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("HRAnamolyAmount");

                entity.Property(e => e.HranamolyPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("HRAnamolyPercentage");

                entity.Property(e => e.Hrcomments)
                    .HasMaxLength(500)
                    .HasColumnName("HRComments");

                entity.Property(e => e.Improvement)
                    .HasMaxLength(550)
                    .HasColumnName("improvement");

                entity.Property(e => e.IncrementPercentage)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("incrementPercentage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncrementedSalary)
                    .HasColumnType("decimal(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PerformanceBonus).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.TotalScore).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Trainings)
                    .HasMaxLength(550)
                    .HasColumnName("trainings");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Appraiser)
                    .WithMany(p => p.TrnsPerformanceEvaluationHeadAppraisers)
                    .HasForeignKey(d => d.AppraiserId)
                    .HasConstraintName("FK_TrnsPerformanceEvaluationHead_MstEmployee1");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerformanceEvaluationHeadEmps)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPerformanceEvaluationHead_MstEmployee");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.TrnsPerformanceEvaluationHeads)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_TrnsPerformanceEvaluationHead_MstPerformanceTerms");
            });

            modelBuilder.Entity<TrnsPerformanceManagement>(entity =>
            {
                entity.ToTable("TrnsPerformanceManagement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnamolyAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AnomalyPercentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AppraiseeComments).HasColumnName("appraiseeComments");

                entity.Property(e => e.AppraiserComments).HasColumnName("appraiserComments");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.FinalRating)
                    .HasMaxLength(50)
                    .HasColumnName("finalRating");

                entity.Property(e => e.FinalScore).HasColumnName("finalScore");

                entity.Property(e => e.HrComments).HasColumnName("hrComments");

                entity.Property(e => e.IncrementPercentage)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("incrementPercentage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SupervisorComments).HasColumnName("supervisorComments");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerformanceManagements)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_TrnsPerformanceManagement_MstEmployee");
            });

            modelBuilder.Entity<TrnsPerformancePlan>(entity =>
            {
                entity.ToTable("TrnsPerformancePlan");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpBranch).HasMaxLength(50);

                entity.Property(e => e.EmpDepartment).HasMaxLength(50);

                entity.Property(e => e.EmpDesignation).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.PlanDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerformancePlans)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPerformancePlan_MstEmployee");
            });

            modelBuilder.Entity<TrnsPerformancePlanDetail>(entity =>
            {
                entity.ToTable("TrnsPerformancePlanDetail");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Kpiid).HasColumnName("KPIID");

                entity.Property(e => e.Ppid).HasColumnName("PPID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TargetPer).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.Property(e => e.WeightagePer).HasColumnType("numeric(6, 3)");

                entity.HasOne(d => d.Kpi)
                    .WithMany(p => p.TrnsPerformancePlanDetails)
                    .HasForeignKey(d => d.Kpiid)
                    .HasConstraintName("FK_TrnsPerformancePlanDetail_TrnsKPI");

                entity.HasOne(d => d.Pp)
                    .WithMany(p => p.TrnsPerformancePlanDetails)
                    .HasForeignKey(d => d.Ppid)
                    .HasConstraintName("FK_TrnsPerformancePlanDetail_TrnsPerformancePlan");
            });

            modelBuilder.Entity<TrnsPerofrmanceEvaluationDetail>(entity =>
            {
                entity.ToTable("TrnsPerofrmanceEvaluationDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actual).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.HeadId).HasColumnName("HeadID");

                entity.Property(e => e.Percentage).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("remarks");

                entity.Property(e => e.Score).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StatementId).HasColumnName("StatementID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsPerofrmanceEvaluationDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsPerofrmanceEvaluationDetail_MstEmployee");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsPerofrmanceEvaluationDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsPerofrmanceEvaluationDetail_TrnsPerformanceEvaluationHead");
            });

            modelBuilder.Entity<TrnsProbationAssesDetail>(entity =>
            {
                entity.ToTable("TrnsProbationAssesDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HeadId).HasColumnName("HeadID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("remarks");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.StatementId).HasColumnName("statementID");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsProbationAssesDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsProbationAssesDetail_TrnsProbationAssesHead");

                entity.HasOne(d => d.Statement)
                    .WithMany(p => p.TrnsProbationAssesDetails)
                    .HasForeignKey(d => d.StatementId)
                    .HasConstraintName("FK_TrnsProbationAssesDetail_MstProbationStatements");
            });

            modelBuilder.Entity<TrnsProbationAssesHead>(entity =>
            {
                entity.ToTable("TrnsProbationAssesHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocNum).HasColumnName("docNum");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.IncrementedAmount).HasMaxLength(10);

                entity.Property(e => e.ProbCycleId).HasColumnName("ProbCycleID");

                entity.Property(e => e.RecommendedAmount).HasMaxLength(10);

                entity.Property(e => e.StatusConfirmation).HasMaxLength(50);

                entity.Property(e => e.TotalScore)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("totalScore");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsProbationAssesHeads)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsProbationAssesHead_MstEmployee");

                entity.HasOne(d => d.ProbCycle)
                    .WithMany(p => p.TrnsProbationAssesHeads)
                    .HasForeignKey(d => d.ProbCycleId)
                    .HasConstraintName("FK_TrnsProbationAssesHead_MstProbationEvalCycles");
            });

            modelBuilder.Entity<TrnsProbationCategorryCycleAttachment>(entity =>
            {
                entity.ToTable("TrnsProbationCategorryCycleAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProbationCycleId).HasColumnName("ProbationCycle_ID");

                entity.Property(e => e.ProbationStatementId).HasColumnName("ProbationStatement_ID");

                entity.HasOne(d => d.ProbationCycle)
                    .WithMany(p => p.TrnsProbationCategorryCycleAttachments)
                    .HasForeignKey(d => d.ProbationCycleId)
                    .HasConstraintName("FK_TrnsProbationCategorryCycleAttachment_MstProbationEvalCycles");

                entity.HasOne(d => d.ProbationStatement)
                    .WithMany(p => p.TrnsProbationCategorryCycleAttachments)
                    .HasForeignKey(d => d.ProbationStatementId)
                    .HasConstraintName("FK_TrnsProbationCategorryCycleAttachment_MstProbationStatements");
            });

            modelBuilder.Entity<TrnsProbationDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentsHr)
                    .HasMaxLength(500)
                    .HasColumnName("commentsHr");

                entity.Property(e => e.CriteriaId).HasColumnName("criteriaID");

                entity.Property(e => e.HeadId).HasColumnName("headID");

                entity.Property(e => e.Progress)
                    .HasMaxLength(50)
                    .HasColumnName("progress");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.TrnsProbationDetails)
                    .HasForeignKey(d => d.CriteriaId)
                    .HasConstraintName("FK_TrnsProbationDetails_MstProbationEvalCriteria");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsProbationDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsProbationDetails_TrnsProbationHead");
            });

            modelBuilder.Entity<TrnsProbationHead>(entity =>
            {
                entity.ToTable("TrnsProbationHead");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.FlgActive)
                    .HasColumnName("flgActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProbCycleId).HasColumnName("probCycleID");

                entity.Property(e => e.StatusConfirmation)
                    .HasMaxLength(50)
                    .HasColumnName("statusConfirmation");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsProbationHeads)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsProbationHead_MstEmployee");

                entity.HasOne(d => d.ProbCycle)
                    .WithMany(p => p.TrnsProbationHeads)
                    .HasForeignKey(d => d.ProbCycleId)
                    .HasConstraintName("FK_TrnsProbationHead_MstProbationEvalCycles");
            });

            modelBuilder.Entity<TrnsPromotionAdvice>(entity =>
            {
                entity.ToTable("TrnsPromotionAdvice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdviceStatus).HasMaxLength(10);

                entity.Property(e => e.AdviceStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("AdviceStatusLOV");

                entity.Property(e => e.AppraisalDate).HasColumnType("datetime");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocType).HasDefaultValueSql("((19))");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.FltPromotion).HasColumnName("fltPromotion");

                entity.Property(e => e.IncrementPer).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.LastPromotionDate).HasColumnType("datetime");

                entity.Property(e => e.NewStatus).HasMaxLength(10);

                entity.Property(e => e.PerfPeriodFrom).HasColumnType("datetime");

                entity.Property(e => e.PerfPeriodTo).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.TotalScorce).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.PlanNoNavigation)
                    .WithMany(p => p.TrnsPromotionAdvices)
                    .HasForeignKey(d => d.PlanNo)
                    .HasConstraintName("FK_TrnsPromotionAdvice_TrnsPerformancePlan");
            });

            modelBuilder.Entity<TrnsQuarterTaxAdj>(entity =>
            {
                entity.ToTable("TrnsQuarterTaxAdj");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);
            });

            modelBuilder.Entity<TrnsQuarterTaxAdjDetail>(entity =>
            {
                entity.ToTable("TrnsQuarterTaxAdjDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.Qtaid).HasColumnName("QTAID");

                entity.Property(e => e.RemaiCurnt).HasMaxLength(100);

                entity.Property(e => e.TaxableAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Qta)
                    .WithMany(p => p.TrnsQuarterTaxAdjDetails)
                    .HasForeignKey(d => d.Qtaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsQuarterTaxAdjDetail_TrnsQuarterTaxAdjDetail");
            });

            modelBuilder.Entity<TrnsReHireEmployee>(entity =>
            {
                entity.ToTable("TrnsReHireEmployee");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsReHireEmployees)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsReHireEmployee_MstEmployee");
            });

            modelBuilder.Entity<TrnsReHireEmployeeDetail>(entity =>
            {
                entity.ToTable("TrnsReHireEmployeeDetail");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Category).HasMaxLength(10);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.ContractType).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Eobimember)
                    .HasMaxLength(10)
                    .HasColumnName("EOBIMember");

                entity.Property(e => e.Eobinumber)
                    .HasMaxLength(10)
                    .HasColumnName("EOBINumber");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.IncomeTaxRebate).HasMaxLength(50);

                entity.Property(e => e.JoinningDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.NewBasicSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NewConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.NewContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.NewContractType).HasMaxLength(50);

                entity.Property(e => e.NewJoiningDate).HasColumnType("datetime");

                entity.Property(e => e.NewPayRollMode).HasMaxLength(50);

                entity.Property(e => e.NewPayRollName).HasMaxLength(50);

                entity.Property(e => e.OtherIncome).HasMaxLength(10);

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.ProvidentFundBalance).HasMaxLength(10);

                entity.Property(e => e.ReHireId).HasColumnName("ReHireID");

                entity.Property(e => e.ReportingManager).HasMaxLength(10);

                entity.Property(e => e.ResignaitonDate).HasColumnType("datetime");

                entity.Property(e => e.Scale).HasMaxLength(10);

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.Ssm)
                    .HasMaxLength(10)
                    .HasColumnName("SSM");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SSN");

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TypeLov).HasColumnName("TypeLOV");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsReHireEmployeeDetails)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsReHireEmployeeDetail_CfgPayrollDefination");

                entity.HasOne(d => d.ReHire)
                    .WithMany(p => p.TrnsReHireEmployeeDetails)
                    .HasForeignKey(d => d.ReHireId)
                    .HasConstraintName("FK_TrnsReHireEmployeeDetail_TrnsReHireEmployee");
            });

            modelBuilder.Entity<TrnsRegionalHead>(entity =>
            {
                entity.ToTable("TrnsRegionalHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(15);

                entity.Property(e => e.DocStatus).HasMaxLength(15);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgSentToHr).HasColumnName("flgSentToHR");
            });

            modelBuilder.Entity<TrnsRegionalHeadDetail>(entity =>
            {
                entity.ToTable("TrnsRegionalHeadDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.InterviewRecommendationId).HasColumnName("InterviewRecommendationID");

                entity.Property(e => e.OfferLetterId).HasColumnName("OfferLetterID");

                entity.Property(e => e.RegionalHeadId).HasColumnName("RegionalHeadID");

                entity.Property(e => e.StatusId)
                    .HasMaxLength(20)
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusName).HasMaxLength(20);

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.InterviewRecommendation)
                    .WithMany(p => p.TrnsRegionalHeadDetails)
                    .HasForeignKey(d => d.InterviewRecommendationId)
                    .HasConstraintName("FK_TrnsRegionalHeadDetail_TrnsInterviewRecommendation");

                entity.HasOne(d => d.OfferLetter)
                    .WithMany(p => p.TrnsRegionalHeadDetails)
                    .HasForeignKey(d => d.OfferLetterId)
                    .HasConstraintName("FK_TrnsRegionalHeadDetail_TrnsOfferLetter");

                entity.HasOne(d => d.RegionalHead)
                    .WithMany(p => p.TrnsRegionalHeadDetails)
                    .HasForeignKey(d => d.RegionalHeadId)
                    .HasConstraintName("FK_TrnsRegionalHeadDetail_TrnsRegionalHead");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.TrnsRegionalHeadDetails)
                    .HasForeignKey(d => d.VacancyId)
                    .HasConstraintName("FK_TrnsRegionalHeadDetail_TrnsVacancyRequest");
            });

            modelBuilder.Entity<TrnsRejectedObj>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeptId).HasColumnName("deptID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.RejectedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("rejectedDate");

                entity.Property(e => e.Term).HasColumnName("term");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<TrnsResignation>(entity =>
            {
                entity.ToTable("TrnsResignation");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentPaymentMode).HasMaxLength(50);

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DocStatus).HasMaxLength(10);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.DocType).HasDefaultValueSql("((12))");

                entity.Property(e => e.EmpDept).HasMaxLength(50);

                entity.Property(e => e.EmpDesg).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlgOption1).HasColumnName("flgOption1");

                entity.Property(e => e.FlgOption2).HasColumnName("flgOption2");

                entity.Property(e => e.FlgOption3).HasColumnName("flgOption3");

                entity.Property(e => e.FlgOption4).HasColumnName("flgOption4");

                entity.Property(e => e.FlgOption5).HasColumnName("flgOption5");

                entity.Property(e => e.FlgOption6).HasColumnName("flgOption6");

                entity.Property(e => e.FlgOption7).HasColumnName("flgOption7");

                entity.Property(e => e.IsHr).HasColumnName("IsHR");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.OriginatorId).HasColumnName("OriginatorID");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.ResignationReason).HasMaxLength(250);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TypeOfResignation).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TrnsResignations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_TrnsResignation_MstDepartment");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsResignations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsResignation_MstEmployee");
            });

            modelBuilder.Entity<TrnsResonsOfLeaving>(entity =>
            {
                entity.ToTable("TrnsResonsOfLeaving");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.RlcouldDoToStayWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("RLCouldDoToStayWithUs");

                entity.Property(e => e.RlforcedReason)
                    .HasMaxLength(1000)
                    .HasColumnName("RLforcedReason");

                entity.Property(e => e.RllocationJob)
                    .HasMaxLength(1000)
                    .HasColumnName("RLlocationJob");

                entity.Property(e => e.RlprocedureContributedToLeave)
                    .HasMaxLength(1000)
                    .HasColumnName("RLprocedureContributedToLeave");

                entity.Property(e => e.RlreasonOfLeaving)
                    .HasMaxLength(1000)
                    .HasColumnName("RLreasonOfLeaving");

                entity.Property(e => e.SgbadTimeWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("SGbadTimeWithUs");

                entity.Property(e => e.SgdoyouGetSupport)
                    .HasMaxLength(1000)
                    .HasColumnName("SGDoyouGetSupport");

                entity.Property(e => e.SggoalsClearInEmployment)
                    .HasMaxLength(1000)
                    .HasColumnName("SGgoalsClearInEmployment");

                entity.Property(e => e.SggoodTimeWithUs)
                    .HasMaxLength(1000)
                    .HasColumnName("SGgoodTimeWithUs");

                entity.Property(e => e.SghowWeMakeFullerUseOfYourSkills)
                    .HasMaxLength(1000)
                    .HasColumnName("SGhowWeMakeFullerUseOfYourSkills");

                entity.Property(e => e.SgjobDescAccuratnt)
                    .HasMaxLength(1000)
                    .HasColumnName("SGJobDescAccuratnt");

                entity.Property(e => e.SgsayAboutCommunication)
                    .HasMaxLength(1000)
                    .HasColumnName("SGsayAboutCommunication");

                entity.Property(e => e.SgskillsUsedToAdvantage)
                    .HasMaxLength(1000)
                    .HasColumnName("SGskillsUsedToAdvantage");

                entity.Property(e => e.SgwhatImprovCanBe)
                    .HasMaxLength(1000)
                    .HasColumnName("SGwhatImprovCanBe");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WnnewJobBenefits)
                    .HasMaxLength(1000)
                    .HasColumnName("WNNewJobBenefits");

                entity.Property(e => e.WnnewJobDifferFromCurrent)
                    .HasMaxLength(1000)
                    .HasColumnName("WNnewJobDifferFromCurrent");

                entity.Property(e => e.WnwhatAttractNewJob)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatAttractNewJob");

                entity.Property(e => e.WnwhatGoingToDo)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatGoingToDo");

                entity.Property(e => e.WnwhatSortOfJob)
                    .HasMaxLength(1000)
                    .HasColumnName("WNwhatSortOfJob");
            });

            modelBuilder.Entity<TrnsSalaryArear>(entity =>
            {
                entity.ToTable("TrnsSalaryArear");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpTaxblTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PaidDays).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSalaryArears)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsSalaryArear_MstEmployee");
            });

            modelBuilder.Entity<TrnsSalaryArearDetail>(entity =>
            {
                entity.ToTable("TrnsSalaryArearDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueCalculatedOn).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Fkid).HasColumnName("FKID");

                entity.Property(e => e.FlgEffectOnGross).HasColumnName("flgEffectOnGross");

                entity.Property(e => e.FlgSalaryArear).HasColumnName("flgSalaryArear");

                entity.Property(e => e.LineMemo).HasMaxLength(100);

                entity.Property(e => e.LineSubType).HasMaxLength(30);

                entity.Property(e => e.LineType).HasMaxLength(30);

                entity.Property(e => e.LineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfDay).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Othours)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OTHours");

                entity.Property(e => e.TaxableAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.TrnsSalaryArearDetails)
                    .HasForeignKey(d => d.Fkid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsSalaryArearDetail_TrnsSalaryArear");
            });

            modelBuilder.Entity<TrnsSalaryChange>(entity =>
            {
                entity.ToTable("TrnsSalaryChange");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrearElementId).HasColumnName("ArrearElementID");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(10);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.NewBasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NewDesgId).HasColumnName("NewDesgID");

                entity.Property(e => e.NewGrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.OldBasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.OldDesigId).HasColumnName("OldDesigID");

                entity.Property(e => e.OldGrossSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PayBandDescNew).HasMaxLength(200);

                entity.Property(e => e.PayBandDescOld).HasMaxLength(200);

                entity.Property(e => e.PayInPeriodId).HasColumnName("PayInPeriodID");

                entity.Property(e => e.PromotionIncrement).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArrearElement)
                    .WithMany(p => p.TrnsSalaryChanges)
                    .HasForeignKey(d => d.ArrearElementId)
                    .HasConstraintName("FK_TrnsSalaryChange_MstElements");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSalaryChanges)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsSalaryChange_MstEmployee");

                entity.HasOne(d => d.NewDesg)
                    .WithMany(p => p.TrnsSalaryChanges)
                    .HasForeignKey(d => d.NewDesgId)
                    .HasConstraintName("FK_TrnsSalaryChange_MstDesignation");

                entity.HasOne(d => d.PayInPeriod)
                    .WithMany(p => p.TrnsSalaryChanges)
                    .HasForeignKey(d => d.PayInPeriodId)
                    .HasConstraintName("FK_TrnsSalaryChange_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsSalaryClassification>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsSalaryClassification");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CAccountCode)
                    .HasMaxLength(50)
                    .HasColumnName("cAccountCode");

                entity.Property(e => e.CAccountDesc)
                    .HasMaxLength(100)
                    .HasColumnName("cAccountDesc");

                entity.Property(e => e.DAccountCode)
                    .HasMaxLength(50)
                    .HasColumnName("dAccountCode");

                entity.Property(e => e.DAccountDesc)
                    .HasMaxLength(100)
                    .HasColumnName("dAccountDesc");

                entity.Property(e => e.DisburseType).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.LineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            });

            modelBuilder.Entity<TrnsSalaryDisbursement>(entity =>
            {
                entity.ToTable("TrnsSalaryDisbursement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasicSallary).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(100);

                entity.Property(e => e.GorssSallary).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.NetSallary).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.Property(e => e.ValueType).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsSalaryDisbursement1>(entity =>
            {
                entity.ToTable("TrnsSalaryDisbursement1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DisburseAmount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetSalary).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsSalaryProcessRegister>(entity =>
            {
                entity.ToTable("TrnsSalaryProcessRegister");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DaysPaid).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EmpAdvace).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpArrears).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBasic).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBonus).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpBranch).HasMaxLength(500);

                entity.Property(e => e.EmpCostCenter).HasMaxLength(500);

                entity.Property(e => e.EmpD1).HasMaxLength(500);

                entity.Property(e => e.EmpD2).HasMaxLength(500);

                entity.Property(e => e.EmpD3).HasMaxLength(500);

                entity.Property(e => e.EmpD4).HasMaxLength(500);

                entity.Property(e => e.EmpD5).HasMaxLength(500);

                entity.Property(e => e.EmpDepartment).HasMaxLength(500);

                entity.Property(e => e.EmpDesignation).HasMaxLength(500);

                entity.Property(e => e.EmpElementTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpExpense).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpGross).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpJobTitle).HasMaxLength(500);

                entity.Property(e => e.EmpLoan).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpLocation).HasMaxLength(500);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.EmpOt)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("EmpOT");

                entity.Property(e => e.EmpPosition).HasMaxLength(500);

                entity.Property(e => e.EmpProject).HasMaxLength(500);

                entity.Property(e => e.EmpRetroElement).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpTaxblTotal).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EmpTotalTax).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FlgDisburse).HasColumnName("flgDisburse");

                entity.Property(e => e.FlgEmailed).HasColumnName("flgEmailed");

                entity.Property(e => e.FlgHoldPayment).HasColumnName("flgHoldPayment");

                entity.Property(e => e.Jenum).HasColumnName("JENum");

                entity.Property(e => e.JenumA1).HasColumnName("JENumA1");

                entity.Property(e => e.MonthDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.OpdocEntry).HasColumnName("OPDocEntry");

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(30);

                entity.Property(e => e.PayrollPeriodId).HasColumnName("PayrollPeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSalaryProcessRegisters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnSalaryProcessRegister_MstEmployee");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsSalaryProcessRegisters)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnSalaryProcessRegister_CfgPayrollDefination");

                entity.HasOne(d => d.PayrollPeriod)
                    .WithMany(p => p.TrnsSalaryProcessRegisters)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_TrnSalaryProcessRegister_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsSalaryProcessRegisterDetail>(entity =>
            {
                entity.ToTable("TrnsSalaryProcessRegisterDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.A1indicators)
                    .HasMaxLength(50)
                    .HasColumnName("A1Indicators");

                entity.Property(e => e.BaseValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueCalculatedOn).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BaseValueType).HasMaxLength(20);

                entity.Property(e => e.CostType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreditAccount).HasMaxLength(16);

                entity.Property(e => e.CreditAccountName).HasMaxLength(100);

                entity.Property(e => e.CreditValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DebitAccount).HasMaxLength(16);

                entity.Property(e => e.DebitAccountName).HasMaxLength(100);

                entity.Property(e => e.DebitValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DisburseType).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.FlgGross).HasColumnName("flgGross");

                entity.Property(e => e.FlgIncentivePaid).HasColumnName("flgIncentivePaid");

                entity.Property(e => e.FlgStandard).HasColumnName("flgStandard");

                entity.Property(e => e.LineMemo).HasMaxLength(100);

                entity.Property(e => e.LineSubType).HasMaxLength(30);

                entity.Property(e => e.LineType).HasMaxLength(30);

                entity.Property(e => e.LineValue).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NoOfDay).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Othours)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("OTHours");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Srid).HasColumnName("SRID");

                entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.HasOne(d => d.Sr)
                    .WithMany(p => p.TrnsSalaryProcessRegisterDetails)
                    .HasForeignKey(d => d.Srid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrnsSalaryProcessRegisterDetail_TrnsSalaryProcessRegister");
            });

            modelBuilder.Entity<TrnsSchoolPensionRequest>(entity =>
            {
                entity.ToTable("TrnsSchoolPensionRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.Contract).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.MeetRequirement).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSchoolPensionRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsSchoolPensionRequest_MstEmployee");
            });

            modelBuilder.Entity<TrnsSchoolPensionRequestDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChildName).HasMaxLength(100);

                entity.Property(e => e.Grade).HasMaxLength(30);

                entity.Property(e => e.SchoolName).HasMaxLength(100);

                entity.Property(e => e.SchoolPensionRequestId).HasColumnName("SchoolPensionRequestID");

                entity.HasOne(d => d.SchoolPensionRequest)
                    .WithMany(p => p.TrnsSchoolPensionRequestDetails)
                    .HasForeignKey(d => d.SchoolPensionRequestId)
                    .HasConstraintName("FK_TrnsSchoolPensionRequestDetails_TrnsSchoolPensionRequest");
            });

            modelBuilder.Entity<TrnsScore>(entity =>
            {
                entity.ToTable("TrnsScore");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TrnsSduae>(entity =>
            {
                entity.ToTable("TrnsSDUAE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisburseAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Jedescription)
                    .HasMaxLength(200)
                    .HasColumnName("JEDescription");

                entity.Property(e => e.Jeid).HasColumnName("JEID");

                entity.Property(e => e.PaidAccount).HasMaxLength(50);

                entity.Property(e => e.PaymentAccounts).HasMaxLength(50);

                entity.Property(e => e.PaymentMode).HasMaxLength(150);

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

                entity.Property(e => e.PayrollName).HasMaxLength(100);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(100);

                entity.Property(e => e.Sbojeid).HasColumnName("SBOJEID");

                entity.Property(e => e.Sboopid).HasColumnName("SBOOPID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrnsShiftsDaysRegister>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsShiftsDaysRegister");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(150);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.ShiftName).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TrnsSingleEntryOtdetail>(entity =>
            {
                entity.ToTable("TrnsSingleEntryOTDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.CalculatedOt)
                    .HasMaxLength(50)
                    .HasColumnName("CalculatedOT");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpName).HasMaxLength(500);

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.SingleEntryOtid).HasColumnName("SingleEntryOTID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSingleEntryOtdetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsSingleEntryOTDetail_MstEmployee");

                entity.HasOne(d => d.OverTime)
                    .WithMany(p => p.TrnsSingleEntryOtdetails)
                    .HasForeignKey(d => d.OverTimeId)
                    .HasConstraintName("FK_TrnsSingleEntryOTDetail_MstOverTime");

                entity.HasOne(d => d.SingleEntryOt)
                    .WithMany(p => p.TrnsSingleEntryOtdetails)
                    .HasForeignKey(d => d.SingleEntryOtid)
                    .HasConstraintName("FK_TrnsSingleEntryOTDetail_TrnsSingleEntryOTRequest");
            });

            modelBuilder.Entity<TrnsSingleEntryOtrequest>(entity =>
            {
                entity.ToTable("TrnsSingleEntryOTRequest");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DcStatus).HasMaxLength(50);

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(150);

                entity.Property(e => e.Ottype).HasColumnName("OTType");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OttypeNavigation)
                    .WithMany(p => p.TrnsSingleEntryOtrequests)
                    .HasForeignKey(d => d.Ottype)
                    .HasConstraintName("FK_TrnsSingleEntryOTRequest_MstOverTime");

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.TrnsSingleEntryOtrequests)
                    .HasForeignKey(d => d.PayrollId)
                    .HasConstraintName("FK_TrnsSingleEntryOTRequest_CfgPayrollDefination");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsSingleEntryOtrequests)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsSingleEntryOTRequest_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsSpdaysAdj>(entity =>
            {
                entity.ToTable("TrnsSPDaysAdj");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdjDaysCount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AdjHourCount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AdjType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createBy");

                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("createDt");

                entity.Property(e => e.DeductedAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.OverTiimeHrsCount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OverTimeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("updateBy");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsSpdaysAdjs)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_trnsSPDaysAdj_MstEmployee");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsSpdaysAdjs)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_trnsSPDaysAdj_CfgPeriodDates");
            });

            modelBuilder.Entity<TrnsTaxAdjustment>(entity =>
            {
                entity.ToTable("TrnsTaxAdjustment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalendarCode).HasMaxLength(20);

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.EmpCode).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.TrnsTaxAdjustments)
                    .HasForeignKey(d => d.CalendarId)
                    .HasConstraintName("FK_TrnsTaxAdjustment_MstCalendar");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTaxAdjustments)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTaxAdjustment_MstEmployee");
            });

            modelBuilder.Entity<TrnsTaxAdjustmentDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.AmountType).HasMaxLength(20);

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgMonthly).HasColumnName("flgMonthly");

                entity.Property(e => e.Period).HasMaxLength(30);

                entity.Property(e => e.Taid).HasColumnName("TAID");

                entity.Property(e => e.TaxType).HasMaxLength(20);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.HasOne(d => d.Ta)
                    .WithMany(p => p.TrnsTaxAdjustmentDetails)
                    .HasForeignKey(d => d.Taid)
                    .HasConstraintName("FK_TrnsTaxAdjustmentDetails_TrnsTaxAdjustment");
            });

            modelBuilder.Entity<TrnsTempAttendance>(entity =>
            {
                entity.ToTable("TrnsTempAttendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.FkempId).HasColumnName("FKEmpID");

                entity.Property(e => e.FlgProcessed).HasColumnName("flgProcessed");

                entity.Property(e => e.InOut)
                    .HasMaxLength(10)
                    .HasColumnName("In_Out");

                entity.Property(e => e.PolledDate).HasColumnType("datetime");

                entity.Property(e => e.PunchedDate).HasColumnType("datetime");

                entity.Property(e => e.PunchedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PunchedTime).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<TrnsTextileGroupAttendanceReg>(entity =>
            {
                entity.ToTable("TrnsTextileGroupAttendanceReg");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DayName).HasMaxLength(50);

                entity.Property(e => e.EarlyOutMin).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.LateInMin).HasMaxLength(50);

                entity.Property(e => e.LeaveCount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Otcount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OTCount");

                entity.Property(e => e.Othours)
                    .HasMaxLength(50)
                    .HasColumnName("OTHours");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PostedBy).HasMaxLength(50);

                entity.Property(e => e.ProcessedBy).HasMaxLength(50);

                entity.Property(e => e.ShiftHours).HasMaxLength(50);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.TimeIn).HasMaxLength(50);

                entity.Property(e => e.TimeOut).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkHours).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTextileGroupAttendanceRegs)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTextileGroupAttendanceReg_MstEmployee");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.TrnsTextileGroupAttendanceRegs)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_TrnsTextileGroupAttendanceReg_CfgPeriodDates");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.TrnsTextileGroupAttendanceRegs)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_TrnsTextileGroupAttendanceReg_MstShifts");
            });

            modelBuilder.Entity<TrnsTrainingAttendance>(entity =>
            {
                entity.ToTable("TrnsTrainingAttendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgAttended).HasColumnName("flgAttended");

                entity.Property(e => e.IsHr).HasColumnName("isHR");

                entity.Property(e => e.TrainingPlanId).HasColumnName("TrainingPlanID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTrainingAttendances)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTrainingAttendance_MstEmployee");

                entity.HasOne(d => d.TrainingPlan)
                    .WithMany(p => p.TrnsTrainingAttendances)
                    .HasForeignKey(d => d.TrainingPlanId)
                    .HasConstraintName("FK_TrnsTrainingAttendance_TrnsTrainingPlan");
            });

            modelBuilder.Entity<TrnsTrainingAttendanceAttachment>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocContent)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DocName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.IsHr).HasColumnName("isHR");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AttedanceDetail)
                    .WithMany(p => p.TrnsTrainingAttendanceAttachments)
                    .HasForeignKey(d => d.AttedanceDetailId)
                    .HasConstraintName("FK_TrnsTrainingAttendanceAttachments_TrnsTrainingAttendanceDetail");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.TrnsTrainingAttendanceAttachments)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_TrnsTrainingAttendanceAttachments_TrnsTrainingAttendance");

                entity.HasOne(d => d.TrainingPlan)
                    .WithMany(p => p.TrnsTrainingAttendanceAttachments)
                    .HasForeignKey(d => d.TrainingPlanId)
                    .HasConstraintName("FK_TrnsTrainingAttendanceAttachments_TrnsTrainingPlan");
            });

            modelBuilder.Entity<TrnsTrainingAttendanceDetail>(entity =>
            {
                entity.ToTable("TrnsTrainingAttendanceDetail");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlgAttended).HasColumnName("flgAttended");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.TrainingHours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.TrnsTrainingAttendanceDetails)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_TrnsTrainingAttendanceDetail_TrnsTrainingAttendance");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTrainingAttendanceDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTrainingAttendanceDetail_MstEmployee");
            });

            modelBuilder.Entity<TrnsTrainingEvaluation>(entity =>
            {
                entity.ToTable("TrnsTrainingEvaluation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EthicsRemarks).HasMaxLength(150);

                entity.Property(e => e.FlgEthics).HasColumnName("flgEthics");

                entity.Property(e => e.FlgFormalDress).HasColumnName("flgFormalDress");

                entity.Property(e => e.FlgFullAttendance).HasColumnName("flgFullAttendance");

                entity.Property(e => e.FlgQuestions).HasColumnName("flgQuestions");

                entity.Property(e => e.FlgReadToLearn).HasColumnName("flgReadToLearn");

                entity.Property(e => e.FlgSpirit).HasColumnName("flgSpirit");

                entity.Property(e => e.FormalDressRemarks).HasMaxLength(150);

                entity.Property(e => e.FullAttendanceRemarks).HasMaxLength(150);

                entity.Property(e => e.QuestionsRemarks).HasMaxLength(150);

                entity.Property(e => e.ReadToLearnRemarks).HasMaxLength(150);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.SpiritRemarks).HasMaxLength(150);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrainPlanId).HasColumnName("TrainPlanID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(150)
                    .HasColumnName("UpdatedBY");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTrainingEvaluations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTrainingEvaluation_MstEmployee");

                entity.HasOne(d => d.TrainPlan)
                    .WithMany(p => p.TrnsTrainingEvaluations)
                    .HasForeignKey(d => d.TrainPlanId)
                    .HasConstraintName("FK_TrnsTrainingEvaluation_TrnsTrainingPlan");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.TrnsTrainingEvaluations)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK_TrnsTrainingEvaluation_TrnsTrainingVenue");
            });

            modelBuilder.Entity<TrnsTrainingEvaluationDetail>(entity =>
            {
                entity.ToTable("TrnsTrainingEvaluationDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.StatementId).HasColumnName("StatementID");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.TrnsTrainingEvaluationDetails)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_TrnsTrainingEvaluationDetail_TrnsTrainingEvaluation");
            });

            modelBuilder.Entity<TrnsTrainingFeedback>(entity =>
            {
                entity.ToTable("TrnsTrainingFeedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpDep).HasMaxLength(100);

                entity.Property(e => e.EmpDesig).HasMaxLength(100);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FromAttend).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Tid).HasColumnName("TId");

                entity.Property(e => e.ToAttend).HasColumnType("datetime");

                entity.Property(e => e.TrainerName).HasMaxLength(100);

                entity.Property(e => e.TrainingHours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTrainingFeedbacks)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTrainingFeedback_MstEmployee");

                entity.HasOne(d => d.TidNavigation)
                    .WithMany(p => p.TrnsTrainingFeedbacks)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK_TrnsTrainingFeedback_TrnsTrainingPlan");
            });

            modelBuilder.Entity<TrnsTrainingFeedbackDetail>(entity =>
            {
                entity.ToTable("TrnsTrainingFeedbackDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Fbid).HasColumnName("FBID");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.StatementId).HasColumnName("StatementID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Fb)
                    .WithMany(p => p.TrnsTrainingFeedbackDetails)
                    .HasForeignKey(d => d.Fbid)
                    .HasConstraintName("FK_TrnsTrainingFeedbackDetail_TrnsTrainingFeedback");

                entity.HasOne(d => d.Statement)
                    .WithMany(p => p.TrnsTrainingFeedbackDetails)
                    .HasForeignKey(d => d.StatementId)
                    .HasConstraintName("FK_TrnsTrainingFeedbackDetail_MstTrainingFeedback");
            });

            modelBuilder.Entity<TrnsTrainingPlan>(entity =>
            {
                entity.ToTable("TrnsTrainingPlan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminBudget).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.AttendanceBy).HasMaxLength(200);

                entity.Property(e => e.BudgetId).HasColumnName("BudgetID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.Dimension).HasMaxLength(200);

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(20)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.FlgAlertToAdmin).HasColumnName("flgAlertToAdmin");

                entity.Property(e => e.FlgCertificate).HasColumnName("flgCertificate");

                entity.Property(e => e.FlgClose).HasColumnName("flgClose");

                entity.Property(e => e.FlgDetailBudget).HasColumnName("flgDetailBudget");

                entity.Property(e => e.FlgEssPublished).HasColumnName("flgEssPublished");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.HoursPerDay).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Methodolgy).HasMaxLength(150);

                entity.Property(e => e.Mode).HasMaxLength(100);

                entity.Property(e => e.Need).HasMaxLength(500);

                entity.Property(e => e.PlanDescription).HasMaxLength(50);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.Purpose).HasMaxLength(500);

                entity.Property(e => e.ReqTools).HasMaxLength(300);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TotalBudget).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalHours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalTrainerHours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TrainerName).HasMaxLength(150);

                entity.Property(e => e.TrainingBudget).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TrainingCategoryId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TrainingCourseId).HasColumnName("TrainingCourseID");

                entity.Property(e => e.TrainingName).HasMaxLength(150);

                entity.Property(e => e.TrainingProviderId).HasColumnName("TrainingProviderID");

                entity.Property(e => e.TrainingType).HasMaxLength(200);

                entity.Property(e => e.TrainingVenueId).HasColumnName("TrainingVenueID");

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsSparse();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(100);

                entity.Property(e => e.VenueBudget).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Budget)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.BudgetId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstTrainingBudget");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstEmployee");

                entity.HasOne(d => d.TrainingCategory)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.TrainingCategoryId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstTrainingCategory");

                entity.HasOne(d => d.TrainingCourse)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.TrainingCourseId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstTrainingCourses");

                entity.HasOne(d => d.TrainingProvider)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.TrainingProviderId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstTrainingProvider");

                entity.HasOne(d => d.TrainingVenue)
                    .WithMany(p => p.TrnsTrainingPlans)
                    .HasForeignKey(d => d.TrainingVenueId)
                    .HasConstraintName("FK_TrnsTrainingPlan_MstTrainingVenue");
            });

            modelBuilder.Entity<TrnsTrainingPlanDetail>(entity =>
            {
                entity.ToTable("TrnsTrainingPlanDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FlgStatus).HasColumnName("flgStatus");

                entity.Property(e => e.TrainPlanId).HasColumnName("TrainPlanID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrnsTrainingPlanDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TrnsTrainingPlanDetail_MstEmployee");

                entity.HasOne(d => d.TrainPlan)
                    .WithMany(p => p.TrnsTrainingPlanDetails)
                    .HasForeignKey(d => d.TrainPlanId)
                    .HasConstraintName("FK_TrnsTrainingPlanDetail_TrnsTrainingPlan");
            });

            modelBuilder.Entity<TrnsTravelPaymentRequest>(entity =>
            {
                entity.HasKey(e => e.TprId);

                entity.ToTable("TrnsTravelPaymentRequest");

                entity.Property(e => e.TprId).HasColumnName("tprId");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasColumnName("department");

                entity.Property(e => e.DocAprStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docAprStatus");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("docDate");

                entity.Property(e => e.DocNum).HasColumnName("docNum");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .HasColumnName("sector");

                entity.Property(e => e.TravelTo)
                    .HasMaxLength(200)
                    .HasColumnName("travelTo");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.TrnsTravelPaymentRequests)
                    .HasForeignKey(d => d.EmployeeCode)
                    .HasConstraintName("FK_TrnsTravelPaymentRequest_MstEmployee");
            });

            modelBuilder.Entity<TrnsVacancyApplication>(entity =>
            {
                entity.ToTable("trnsVacancyApplication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Achievements).HasMaxLength(1000);

                entity.Property(e => e.AppliedFor)
                    .HasMaxLength(50)
                    .HasColumnName("appliedFor");

                entity.Property(e => e.AppliedOn)
                    .HasColumnType("date")
                    .HasColumnName("appliedOn");

                entity.Property(e => e.AvailDate).HasColumnType("datetime");

                entity.Property(e => e.Branch)
                    .HasMaxLength(50)
                    .HasColumnName("branch");

                entity.Property(e => e.CandidateId).HasColumnName("candidateID");

                entity.Property(e => e.CareeaGoal)
                    .HasMaxLength(1000)
                    .HasColumnName("careeaGoal");

                entity.Property(e => e.Clientlimitation)
                    .HasMaxLength(1)
                    .HasColumnName("clientlimitation")
                    .IsFixedLength();

                entity.Property(e => e.Details).HasMaxLength(1000);

                entity.Property(e => e.ExtraCurr).HasMaxLength(1000);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .HasColumnName("remarks");

                entity.Property(e => e.Traveling).HasMaxLength(1000);

                entity.Property(e => e.VacancyId).HasColumnName("vacancyID");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.TrnsVacancyApplications)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnsVacancyApplication_TrnsVacancyRequest");
            });

            modelBuilder.Entity<TrnsVacancyAssessmentStatement>(entity =>
            {
                entity.HasOne(d => d.Statement)
                    .WithMany(p => p.TrnsVacancyAssessmentStatements)
                    .HasForeignKey(d => d.StatementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsVacancyAssessmentStatements_MstInterviewAssessmentQuestion");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.TrnsVacancyAssessmentStatements)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnsVacancyAssessmentStatements_TrnsVacancyRequest");
            });

            modelBuilder.Entity<TrnsVacancyRequest>(entity =>
            {
                entity.ToTable("TrnsVacancyRequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AgeMax).HasColumnName("age_max");

                entity.Property(e => e.AgeMin).HasColumnName("age_min");

                entity.Property(e => e.AgePref).HasColumnName("age_pref");

                entity.Property(e => e.AlternateArrangement).HasColumnName("alternateArrangement");

                entity.Property(e => e.AnyTargetPerson)
                    .HasMaxLength(50)
                    .HasColumnName("any_targetPerson");

                entity.Property(e => e.ApprovedOrganogram).HasColumnName("approved_organogram");

                entity.Property(e => e.Attachment).HasMaxLength(500);

                entity.Property(e => e.BasicDuties).HasColumnName("basic_duties");

                entity.Property(e => e.Branch).HasColumnName("branch");

                entity.Property(e => e.Budgeted).HasMaxLength(10);

                entity.Property(e => e.CellPhone).HasColumnName("cellPhone");

                entity.Property(e => e.Computer).HasColumnName("computer");

                entity.Property(e => e.Coo)
                    .HasMaxLength(50)
                    .HasColumnName("coo");

                entity.Property(e => e.CreditLimit)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("creditLimit");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Designation).HasColumnName("designation");

                entity.Property(e => e.DesignationLevelId).HasColumnName("DesignationLevelID");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocNumber).HasColumnName("docNumber");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(50)
                    .HasColumnName("docStatus");

                entity.Property(e => e.DocType).HasColumnName("docType");

                entity.Property(e => e.EarliestStartDate)
                    .HasColumnType("date")
                    .HasColumnName("earliest_startDate");

                entity.Property(e => e.EmployeeAssigned).HasColumnName("employeeAssigned");

                entity.Property(e => e.FlgActive).HasColumnName("flgActive");

                entity.Property(e => e.FlgSendToHr).HasColumnName("flgSendToHR");

                entity.Property(e => e.FlgonHold).HasColumnName("flgonHold");

                entity.Property(e => e.Fuel).HasColumnName("fuel");

                entity.Property(e => e.Function)
                    .HasMaxLength(50)
                    .HasColumnName("function_");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.HeadOfHr)
                    .HasMaxLength(50)
                    .HasColumnName("headOfHR");

                entity.Property(e => e.HodDate)
                    .HasColumnType("date")
                    .HasColumnName("hod_date");

                entity.Property(e => e.HodName)
                    .HasMaxLength(50)
                    .HasColumnName("hod_name");

                entity.Property(e => e.HofDate)
                    .HasColumnType("date")
                    .HasColumnName("hof_date");

                entity.Property(e => e.HofName)
                    .HasMaxLength(50)
                    .HasColumnName("hof_name");

                entity.Property(e => e.JdAvailable).HasColumnName("jd_available");

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.JobTitleName).HasMaxLength(50);

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.MinEducation)
                    .HasMaxLength(50)
                    .HasColumnName("min_education")
                    .HasComment("Graduation, Masters,Diploma");

                entity.Property(e => e.MinExperience)
                    .HasMaxLength(50)
                    .HasColumnName("min_experience");

                entity.Property(e => e.MppRef).HasColumnName("mppRef");

                entity.Property(e => e.NoOfPostions).HasColumnName("no_of_postions");

                entity.Property(e => e.OnHoldReason)
                    .HasMaxLength(50)
                    .HasColumnName("onHoldReason");

                entity.Property(e => e.OpenHeadCount).HasColumnName("openHeadCount");

                entity.Property(e => e.OtherFacility)
                    .HasMaxLength(500)
                    .HasColumnName("other_facility");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("position")
                    .HasComment("Replacement, Vacant , New Position");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.PositionType)
                    .HasMaxLength(50)
                    .HasColumnName("position_type")
                    .HasComment("Permanent, Contractual, Intern");

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.RecruitmentType).HasMaxLength(30);

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.ReplaceEmpId)
                    .HasMaxLength(10)
                    .HasColumnName("ReplaceEmpID");

                entity.Property(e => e.RrDate)
                    .HasColumnType("date")
                    .HasColumnName("rr_date");

                entity.Property(e => e.RrName)
                    .HasMaxLength(50)
                    .HasColumnName("rr_name");

                entity.Property(e => e.SalaryMax)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("salary_max");

                entity.Property(e => e.SalaryMin)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("salary_min");

                entity.Property(e => e.Seating).HasColumnName("seating");

                entity.Property(e => e.SpecificDegree)
                    .HasMaxLength(50)
                    .HasColumnName("specific_degree");

                entity.Property(e => e.SpecificIndustry).HasColumnName("specific_industry");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("0 for Open ; 1 for closed");

                entity.Property(e => e.SupervisorTitle)
                    .HasMaxLength(50)
                    .HasColumnName("supervisor_title");

                entity.Property(e => e.TemporaryLocationId).HasColumnName("TemporaryLocationID");

                entity.Property(e => e.TemporaryLocationName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VacancyExpirydate).HasColumnType("datetime");

                entity.Property(e => e.Vehicle).HasColumnName("vehicle");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.TrnsVacancyRequests)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK_TrnsVacancyRequest_MstBranches");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.TrnsVacancyRequests)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_TrnsVacancyRequest_MstDepartment");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.TrnsVacancyRequests)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK_TrnsVacancyRequest_MstDesignation");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.TrnsVacancyRequests)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_TrnsVacancyRequest_MstLocation");

                entity.HasOne(d => d.MppRefNavigation)
                    .WithMany(p => p.TrnsVacancyRequests)
                    .HasForeignKey(d => d.MppRef)
                    .HasConstraintName("FK_TrnsVacancyRequest_MstMPP");
            });

            modelBuilder.Entity<TrnsVacancyStatus>(entity =>
            {
                entity.ToTable("TrnsVacancyStatus");

                entity.HasIndex(e => e.Code, "IX_TrnVacancyStatus")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.InitiatedBy).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusVacancy).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<TrnsViolation>(entity =>
            {
                entity.ToTable("TrnsViolation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.DeductionAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DeductionType).HasMaxLength(50);

                entity.Property(e => e.DeductionUnit).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DocAprStatus).HasMaxLength(30);

                entity.Property(e => e.DocAprStatusLov)
                    .HasMaxLength(150)
                    .HasColumnName("DocAprStatusLOV");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocStatus).HasMaxLength(30);

                entity.Property(e => e.DocStatusLov)
                    .HasMaxLength(150)
                    .HasColumnName("DocStatusLOV");

                entity.Property(e => e.EmpName).HasMaxLength(150);

                entity.Property(e => e.InternalEmpId).HasColumnName("internalEmpID");

                entity.Property(e => e.PenaltyType).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.UpdateDt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.ViolationLevel).HasMaxLength(50);

                entity.HasOne(d => d.InternalEmp)
                    .WithMany(p => p.TrnsViolations)
                    .HasForeignKey(d => d.InternalEmpId)
                    .HasConstraintName("FK_TrnsViolation_MstEmployee");
            });

            modelBuilder.Entity<TrnsVlEntitlement>(entity =>
            {
                entity.HasKey(e => e.TrnsVlEntId)
                    .HasName("PK_trnsVlEntitlement");

                entity.ToTable("TrnsVlEntitlement");

                entity.Property(e => e.TrnsVlEntId).HasColumnName("trnsVlEntId");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("createBy");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Entitlments)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("entitlments");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fromDate");

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("toDate");

                entity.Property(e => e.TrnsEmpVlid).HasColumnName("trnsEmpVLId");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("updateBy");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.HasOne(d => d.TrnsEmpVl)
                    .WithMany(p => p.TrnsVlEntitlements)
                    .HasForeignKey(d => d.TrnsEmpVlid)
                    .HasConstraintName("FK_trnsVlEntitlement_trnsEmpVL");
            });

            modelBuilder.Entity<TrnsWarningLetter>(entity =>
            {
                entity.ToTable("TrnsWarningLetter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attachment).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(20);

                entity.Property(e => e.DocStatus).HasMaxLength(20);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Remarks).HasMaxLength(2000);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WarningType).HasMaxLength(100);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TrnsWarningLetters)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_TrnsWarningLetter_MstEmployee");
            });

            modelBuilder.Entity<TrnsWorkInQuarter>(entity =>
            {
                entity.ToTable("TrnsWorkInQuarter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TrnsleaveEncashment>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("TrnsleaveEncashment");

                entity.Property(e => e.InternalId).HasColumnName("internalID");

                entity.Property(e => e.Approved).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Balance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BalanceBf)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("BalanceBF");

                entity.Property(e => e.BasicSalary).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CalCode).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.DocAprStatus).HasMaxLength(50);

                entity.Property(e => e.DocStatus).HasMaxLength(50);

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpName).HasMaxLength(250);

                entity.Property(e => e.Entitled).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FromDt).HasColumnType("datetime");

                entity.Property(e => e.LeaveId).HasColumnName("LeaveID");

                entity.Property(e => e.LeaveType).HasMaxLength(100);

                entity.Property(e => e.LeaveUsed).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodName).HasMaxLength(100);

                entity.Property(e => e.Requested).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalAvailable).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalLeaves).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<VacancyEmailNotification>(entity =>
            {
                entity.ToTable("VacancyEmailNotification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminEmail).HasMaxLength(200);

                entity.Property(e => e.Itemail)
                    .HasMaxLength(200)
                    .HasColumnName("ITEmail");
            });

            modelBuilder.Entity<ViewApprovalTemplate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewApprovalTemplate");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FlgAdvance).HasColumnName("flgAdvance");

                entity.Property(e => e.FlgAppraisal).HasColumnName("flgAppraisal");

                entity.Property(e => e.FlgCandidate).HasColumnName("flgCandidate");

                entity.Property(e => e.FlgEmpHiring).HasColumnName("flgEmpHiring");

                entity.Property(e => e.FlgEmpLeave).HasColumnName("flgEmpLeave");

                entity.Property(e => e.FlgJobRequisition).HasColumnName("flgJobRequisition");

                entity.Property(e => e.FlgLoan).HasColumnName("flgLoan");

                entity.Property(e => e.FlgResignation).HasColumnName("flgResignation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.StageName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ViewDeptHiearcy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDeptHiearcy");

                entity.Property(e => e.Code).HasMaxLength(300);

                entity.Property(e => e.DeptName).HasMaxLength(500);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.L1code)
                    .HasMaxLength(300)
                    .HasColumnName("L1Code");

                entity.Property(e => e.L1deptName)
                    .HasMaxLength(500)
                    .HasColumnName("L1DeptName");

                entity.Property(e => e.L1id).HasColumnName("L1Id");

                entity.Property(e => e.L2code)
                    .HasMaxLength(300)
                    .HasColumnName("L2Code");

                entity.Property(e => e.L2deptName)
                    .HasMaxLength(500)
                    .HasColumnName("L2DeptName");

                entity.Property(e => e.L2id).HasColumnName("L2Id");

                entity.Property(e => e.L3code)
                    .HasMaxLength(300)
                    .HasColumnName("L3Code");

                entity.Property(e => e.L3deptName)
                    .HasMaxLength(500)
                    .HasColumnName("L3DeptName");

                entity.Property(e => e.L3id).HasColumnName("L3Id");

                entity.Property(e => e.L4code)
                    .HasMaxLength(300)
                    .HasColumnName("L4Code");

                entity.Property(e => e.L4deptName)
                    .HasMaxLength(500)
                    .HasColumnName("L4DeptName");

                entity.Property(e => e.L4id).HasColumnName("L4Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
