global using HCM.API.HCMModels;
using HCM.API;
using HCM.API.Interfaces.Account;
using HCM.API.Interfaces.Advance;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.Attendance;
using HCM.API.Interfaces.Authorization;
using HCM.API.Interfaces.Batch;
using HCM.API.Interfaces.Bonus;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Interfaces.Loan;
using HCM.API.Interfaces.MasterData;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Interfaces.SAPData;
using HCM.API.Interfaces.ShiftManagement;
using HCM.API.Repository.Account;
using HCM.API.Repository.Advance;
using HCM.API.Repository.ApprovalSetup;
using HCM.API.Repository.Attendance;
using HCM.API.Repository.Authorization;
using HCM.API.Repository.Batch;
using HCM.API.Repository.Bonus;
using HCM.API.Repository.ClientSpecific;
using HCM.API.Repository.EmployeeMasterSetup;
using HCM.API.Repository.Loan;
using HCM.API.Repository.MasterData;
using HCM.API.Repository.MasterElement;
using HCM.API.Repository.SAPData;
using HCM.API.Repository.ShiftManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string? DBCon = builder.Configuration.GetSection("APIBaseUrl").ToString();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HCMOneContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
}).AddJwtBearer("JwtBearer", JwtOptions =>
{
    JwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MEPLHCMONEkiSecretKeyJWTkliyaBahutSecret")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(30)
    };
});

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<ISAPData, SAPDataRepo>();
builder.Services.AddScoped<IMstForm, MstFormRepo>();
builder.Services.AddScoped<IMstDimension, MstDimensionRepo>();
builder.Services.AddScoped<IMstDocumentNumberSeries, MstDocumentNumberSeriesRepo>();
builder.Services.AddScoped<IMstCountryStateCity, MstCountryStateCityRepo>();
builder.Services.AddScoped<IMstDepartment, MstDepartmentRepo>();
builder.Services.AddScoped<IMstContractor, MstContractorRepo>();
builder.Services.AddScoped<IMstStation, MstStationRepo>();
builder.Services.AddScoped<IMstDesignation, MstDesignationRepo>();
builder.Services.AddScoped<IMstLocation, MstLocationRepo>();
builder.Services.AddScoped<IMstPosition, MstPositionRepo>();
builder.Services.AddScoped<IMstGrading, MstGradingRepo>();
builder.Services.AddScoped<IMstBranch, MstBranchRepo>();
builder.Services.AddScoped<IMstCalendar, MstCalendarRepo>();
builder.Services.AddScoped<IMstLeaveCalendar, MstLeaveCalendarRepo>();
builder.Services.AddScoped<IMstEmailConfig, MstEmailConfigRepo>();
builder.Services.AddScoped<ICfgPayrollDefinationinit, CfgPayrollDefinationinitRepo>();
builder.Services.AddScoped<IMstElement, MstElementRepo>();
builder.Services.AddScoped<IMstLove, MstLoveRepo>();
builder.Services.AddScoped<IMstOverTime, MstOverTimeRepo>();
builder.Services.AddScoped<IMstLoans, MstLoansRepo>();
builder.Services.AddScoped<IMstShifts, MstShiftRepo>();
builder.Services.AddScoped<IMstAdvance, MstAdvanceRepo>();
builder.Services.AddScoped<IMstLeaveType, MstLeaveTypeRepo>();
builder.Services.AddScoped<IMstLeaveDeduction, MstLeaveDeductionRepo>();
builder.Services.AddScoped<IMstDeductionRule, MstDeductionRuleRepo>();
builder.Services.AddScoped<ICfgTaxSetup, CfgTaxSetupRepo>();
builder.Services.AddScoped<IMstAttendanceRules, MstAttendanceRulesRepo>();
builder.Services.AddScoped<IMstBonus, MstBonusRepo>();
builder.Services.AddScoped<ICfgPayrollDefination, CfgPayrollDefinationRepo>();
builder.Services.AddScoped<IMstGratuity, MstGratuityRepo>();
builder.Services.AddScoped<IMstUser, MstUserRepo>();
builder.Services.AddScoped<IMstEmployeeMasterData, MstEmployeeMasterDataRepo>();
builder.Services.AddScoped<ITrnsEmployeeTransfer, TrnsEmployeeTransferRepo>();
builder.Services.AddScoped<ITrnsAttendanceRegister, TrnsAttendanceRegisterRepo>();
builder.Services.AddScoped<ITrnsTempAttendance, TrnsTempAttendanceRepo>();
builder.Services.AddScoped<IMstEmployeeLeaves, MstEmployeeLeavesRepo>();
builder.Services.AddScoped<ITrnsLeaveRequest, TrnsLeaveRequestRepo>();
builder.Services.AddScoped<ITrnsElementTransaction, TrnsElementTransactionRepo>();
builder.Services.AddScoped<ITrnsLoanRequest, TrnsLoanRequestRepo>();
builder.Services.AddScoped<ITrnsAdvanceRequest, TrnsAdvanceRequestRepo>();
builder.Services.AddScoped<ITrnsEmployeeOverTime, TrnsEmployeeOverTimeRepo>();
builder.Services.AddScoped<ITrnsEmployeeResign, TrnsEmployeeResignRepo>();
builder.Services.AddScoped<ICfgApprovalStage, CfgApprovalStageDetailRepo>();
builder.Services.AddScoped<ITrnsTaxAdjustment, TrnsTaxAdjustmentRepo>();
builder.Services.AddScoped<ITrnsEmployeeBonus, TrnsEmployeeBonusRepo>();
builder.Services.AddScoped<ITrnsReHireEmployee, TrnsReHireEmployeeRepo>();
builder.Services.AddScoped<ICfgApprovalTemplate, CfgApprovalTemplateRepo>();
builder.Services.AddScoped<IDocApprovalDecesion, DocApprovalDecesionRepo>();
builder.Services.AddScoped<ITrnsSingleEntryOtrequest, TrnsSingleEntryOtrequestRepo>();
builder.Services.AddScoped<IUserAuthorization, UserAuthorizationRepo>();
builder.Services.AddScoped<ITrnsBatchProcess, TrnsBatchProcessRepo>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccessRepo>();
builder.Services.AddScoped<IMstchartofAccount, MstchartofAccountRepo>();
builder.Services.AddScoped<IMstHoliDay, MstHolidayRepo>();
builder.Services.AddScoped<IMstGldetermination, MstGldeterminationRepo>();
builder.Services.AddScoped<ITrnsProductStage, TrnsProductStageRepo>();
builder.Services.AddScoped<IMstTarget, MstTargetRepo>();
builder.Services.AddScoped<ITrnsPerPiece, TrnsPerPieceRepo>();

Settings.TitleConfig = builder.Configuration.GetValue<string>("TitleConfig");
Settings.EmailConfig = builder.Configuration.GetValue<string>("EmailConfig");
Settings.PasswordConfig = builder.Configuration.GetValue<string>("PasswordConfig");
Settings.HostConfig = builder.Configuration.GetValue<string>("HostConfig");
Settings.PortConfig = builder.Configuration.GetValue<int>("PortConfig");
Settings.IsSSlConfig = builder.Configuration.GetValue<bool>("IsSSlConfig");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Scaffold-DbContext "Server=PK-LHR-MME-133;Database=HCMOne;User ID=sa;Password=super;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir HCMModels -Force