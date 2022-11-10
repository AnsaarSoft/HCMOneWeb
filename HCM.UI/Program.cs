global using HCM.API.HCMModels;
using Blazored.LocalStorage;
using CA.UI.Authentication;
using HCM.API.Repository.SAPData;
using HCM.UI;
using HCM.UI.Data.Account;
using HCM.UI.Data.Advance;
using HCM.UI.Data.ApprovalSetup;
using HCM.UI.Data.Attendance;
using HCM.UI.Data.Authorization;
using HCM.UI.Data.Batch;
using HCM.UI.Data.Bonus;
using HCM.UI.Data.ClientSpecific;
using HCM.UI.Data.EmployeeMasterSetup;
using HCM.UI.Data.Loan;
using HCM.UI.Data.MasterData;
using HCM.UI.Data.MasterElement;
using HCM.UI.Data.SAPData;
using HCM.UI.Data.ShiftManagement;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.Advance;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.Interfaces.Attendance;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.Batch;
using HCM.UI.Interfaces.Bonus;
using HCM.UI.Interfaces.ClientSpecific;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.Loan;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using HCM.UI.Interfaces.SAPData;
using HCM.UI.Interfaces.ShiftManagement;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<ISAPData, SAPDataService>();
builder.Services.AddScoped<IMstForm, MstFormService>();
builder.Services.AddScoped<IMstDocumentNumberSeries, MstDocumentNumberSeriesService>();
builder.Services.AddScoped<IMstCountryStateCity, MstCountryStateCityService>();
builder.Services.AddScoped<IMstDimension, MstDimensionService>();
builder.Services.AddScoped<IMstDepartment, MstDepartmentService>();
builder.Services.AddScoped<IMstContractor, MstContractorService>();
builder.Services.AddScoped<IMstStation, MstStationService>();
builder.Services.AddScoped<IMstDesignation, MstDesignationService>();
builder.Services.AddScoped<IMstLocation, MstLocationService>();
builder.Services.AddScoped<IMstPosition, MstPositionService>();
builder.Services.AddScoped<IMstGrading, MstGradingService>();
builder.Services.AddScoped<IMstBranch, MstBranchService>();
builder.Services.AddScoped<IMstCalendar, MstCalendarService>();
builder.Services.AddScoped<IMstLeaveCalendar, MstLeaveCalendarService>();
builder.Services.AddScoped<IMstEmailConfig, MstEmailConfigService>();
builder.Services.AddScoped<ICfgPayrollDefinationinit, CfgPayrollDefinationinitService>();
builder.Services.AddScoped<IMstLoans, MstLoansService>();
builder.Services.AddScoped<IMstElement, MstElementService>();
builder.Services.AddScoped<IMstLove, MstLoveService>();
builder.Services.AddScoped<IMstOverTime, MstOverTimeService>();
builder.Services.AddScoped<IMstShifts, MstShiftService>();
builder.Services.AddScoped<IMstAdvance, MstAdvanceService>();
builder.Services.AddScoped<IMstLeaveType, MstLeaveTypeService>();
builder.Services.AddScoped<IMstLeaveDeduction, MstLeaveDeductionService>();
builder.Services.AddScoped<IMstDeductionRule, MstDeductionRuleService>();
builder.Services.AddScoped<ICfgTaxSetup, CfgTaxSetupService>();
builder.Services.AddScoped<IMstAttendanceRules, MstAttendanceRulesService>();
builder.Services.AddScoped<IMstBonus, MstBonusService>();
builder.Services.AddScoped<ICfgPayrollDefination, CfgPayrollDefinationService>();
builder.Services.AddScoped<IMstGratuity, MstGratuityService>();
builder.Services.AddScoped<IMstUser, MstUserService>();
builder.Services.AddScoped<IMstEmployeeMasterData, MstEmployeeMasterDataService>();
builder.Services.AddScoped<ITrnsEmployeeTransfer, TrnsEmployeeTransferService>();
builder.Services.AddScoped<ITrnsAttendanceRegister, TrnsAttendanceRegisterService>();
builder.Services.AddScoped<ITrnsTempAttendance, TrnsTempAttendanceService>();
builder.Services.AddScoped<IMstEmployeeLeaves, MstEmployeeLeavesService>();
builder.Services.AddScoped<ITrnsLeaveRequest, TrnsLeaveRequestService>();
builder.Services.AddScoped<ITrnsElementTransaction, TrnsElementTransactionService>();
builder.Services.AddScoped<ITrnsLoanRequest, TrnsLoanRequestService>();
builder.Services.AddScoped<ITrnsAdvanceRequest, TrnsAdvanceRequestService>();
builder.Services.AddScoped<ITrnsEmployeeOverTime, TrnsEmployeeOverTimeService>();
builder.Services.AddScoped<ITrnsEmployeeResign, TrnsEmployeeResignService>();
builder.Services.AddScoped<ICfgApprovalStage, oCfgApprovalStageService>();
builder.Services.AddScoped<ITrnsTaxAdjustment, TrnsTaxAdjustmentService>();
builder.Services.AddScoped<ITrnsEmployeeBonus, TrnsEmployeeBonusService>();
builder.Services.AddScoped<ITrnsReHireEmployee, TrnsReHireEmployeeService>();
builder.Services.AddScoped<ICfgApprovalTemplate, CfgApprovalTemplateService>();
builder.Services.AddScoped<IDocApprovalDecesion, DocApprovalDecesionService>();
builder.Services.AddScoped<ITrnsSingleEntryOtrequest, TrnsSingleEntryOtrequestService>();
builder.Services.AddScoped<IUserAuthorization, UserAuthorizationService>();
builder.Services.AddScoped<ITrnsBatchProcess, TrnsBatchProcessService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccessService>();
builder.Services.AddScoped<IMstchartofAccount, MstchartofAccountService>();
builder.Services.AddScoped<IMstHoliday, MstHolidayService>();
builder.Services.AddScoped<IMstGldetermination, MstGldeterminationService>();
builder.Services.AddScoped<ITrnsProductStage, TrnsProductStageService>();
builder.Services.AddScoped<IMstTarget, MstTargetService>();
builder.Services.AddScoped<ITrnsPerPiece, TrnsPerPieceService>();
//Configuration Start

Settings.APIBaseURL = builder.Configuration.GetValue<string>("APIBaseUrl");
Settings.DialogFor = "";
//Configuration End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();