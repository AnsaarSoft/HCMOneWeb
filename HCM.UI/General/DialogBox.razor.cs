﻿using DocumentFormat.OpenXml.ExtendedProperties;
using HCM.UI.Interfaces.Authorization;
using HCM.API.Models;
using HCM.UI.Interfaces.Advance;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.Interfaces.Batch;
using HCM.UI.Interfaces.Bonus;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.Loan;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Blazored.LocalStorage;
using HCM.UI.Interfaces.SAPData;
using HCM.UI.Interfaces.ClientSpecific;
using HCM.UI.Interfaces.Reports;

namespace HCM.UI.General
{
    public partial class DialogBox
    {
        #region InjectService        

        [Inject]
        public IDialogService Dialog { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public ICfgTaxSetup _CfgTaxSetup { get; set; }

        [Inject]
        public IMstGratuity _mstGratuity { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefinationSetup { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployee { get; set; }

        [Inject]
        public ITrnsEmployeeTransfer _trnsEmployeeTransfer { get; set; }

        [Inject]
        public ITrnsLeaveRequest _trnsLeavesRequest { get; set; }

        [Inject]
        public ITrnsLoanRequest _trnsLoanRequest { get; set; }

        [Inject]
        public ITrnsAdvanceRequest _trnsAdvanceRequest { get; set; }

        [Parameter]
        public string DialogFor { get; set; }

        [Parameter]
        public IEnumerable<MstElementLink> PayrollElements { get; set; }

        [Parameter]
        public int productStageID { get; set; } =0;
        [Parameter]
        public string productStageItemCode { get; set; }

        [Inject]
        public ITrnsEmployeeResign _trnsEmployeeResign { get; set; }

        [Inject]
        public ITrnsEmployeeOverTime _trnsEmployeeOverTime { get; set; }

        [Inject]
        public ITrnsTaxAdjustment _trnsTaxAdjustment { get; set; }

        [Inject]
        public ICfgApprovalStage _mstStages { get; set; }

        [Inject]
        public ICfgApprovalTemplate _cfgApprovalTemplate { get; set; }

        [Inject]
        public ITrnsReHireEmployee _trnsReHireEmployee { get; set; }

        [Inject]
        public ITrnsEmployeeBonus _trnsEmployeeBonus { get; set; }

        [Inject]
        public ITrnsSingleEntryOtrequest _trnsSingleEntryOtrequest { get; set; }

        [Inject]
        public ITrnsBatchProcess _trnsBatch { get; set; }

        [Inject]
        public IUserDataAccess _userDataAccess { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstchartofAccount _mstchartofAccount { get; set; }

        [Inject]
        public IMstGldetermination _mstGldetermination { get; set; }

        [Inject]
        public IMstHoliday _mstHoliday { get; set; }

        [Inject]
        public IMstStation _mstStation { get; set; }

        [Inject]
        public ISAPData _SAPData { get; set; }
        [Inject]
        public ITrnsProductStage _trnsProductStage { get; set; }
        [Inject]
        public ITrnsPerPiece _trnsPerPiece { get; set; }
        #endregion

        #region Variables

        private bool _processingTable = false;
        bool Loading = false;
        private string searchString1 = "";
        private int selectedRowNumber = -1;
        private List<string> clickedEvents = new();
        private string LoginUser = "";

        public string Remarks { get; set; }

        private bool FilterFuncElement(MstElement element) => FilterFuncElement(element, searchString1);
        private bool FilterFuncShift(MstShift element) => FilterFuncShift(element, searchString1);
        private bool FilterFuncTaxSetup(CfgTaxSetup element) => FilterFuncTaxSetup(element, searchString1);
        private bool FilterFuncPayrollSetup(CfgPayrollDefination element) => FilterFuncPayrollSetup(element, searchString1);
        private bool FilterFuncGratuitySetup(MstGratuity element) => FilterFuncGratuitySetup(element, searchString1);
        private bool FilterFuncMstEmployee(MstEmployee element) => FilterFuncMstEmployee(element, searchString1);
        private bool FilterFuncTrnsEmployeeTransfer(TrnsEmployeeTransfer element) => FilterFuncTrnsEmployeeTransfer(element, searchString1);
        private bool FilterFuncTrnsLeavesRequest(TrnsLeavesRequest element) => FilterFuncTrnsLeavesRequest(element, searchString1);
        private bool FilterFuncTrnsLoanRequest(TrnsLoanRequest element) => FilterFuncTrnsLoanRequest(element, searchString1);
        private bool FilterFuncTrnsAdvanceRequest(TrnsAdvanceRequest element) => FilterFuncTrnsAdvanceRequest(element, searchString1);
        private bool FilterFuncTrnsEmployeeOvertime(TrnsEmployeeOvertime element) => FilterFuncTrnsEmployeeOvertime(element, searchString1);
        private bool FilterFuncTrnsEmployeeResign(TrnsResignation element) => FilterFuncTrnsEmployeeResign(element, searchString1);
        private bool FilterFuncTrnsTaxAdjustment(TrnsTaxAdjustment element) => FilterFuncTrnsTaxAdjustment(element, searchString1);
        private bool FilterFuncCfgApprovalStage(CfgApprovalStage element) => FilterFuncCfgApprovalStage(element, searchString1);
        private bool FilterFuncCfgApprovalTemplate(CfgApprovalTemplate element) => FilterFuncCfgApprovalTemplate(element, searchString1);
        private bool FilterFuncTrnsEmployeeReHire(TrnsEmployeeReHire element) => FilterFuncTrnsEmployeeReHire(element, searchString1);
        private bool FilterFuncEmployeeBonus(TrnsEmployeeBonu element) => FilterFuncEmployeeBonus(element, searchString1);
        private bool FilterFuncBatch(TrnsBatch element) => FilterFuncBatch(element, searchString1);
        private bool FilterFuncMonthlyOT(TrnsSingleEntryOtrequest element) => FilterFuncMonthlyOT(element, searchString1);
        private bool FilterFuncUserDataAccess(UserDataAccess element) => FilterFuncUserDataAccess(element, searchString1);
        private bool FilterFuncMstLocation(MstLocation element) => FilterFuncMstLocation(element, searchString1);
        private bool FilterFuncMstDepartment(MstDepartment element) => FilterFuncMstDepartment(element, searchString1);
        private bool FilterFuncVMlocGlDertmination(VMLoc_Gldetermination element) => FilterFuncVMlocGlDertmination(element, searchString1);
        private bool FilterFuncVMDeptGldetermination(VMDept_Gldetermination element) => FilterFuncVMDeptGldetermination(element, searchString1);
        private bool FilterFuncMstchartofAccount(MstchartofAccount element) => FilterFuncMstchartofAccount(element, searchString1);
        private bool FilterFuncMstHoliday(MstHoliday1 element) => FilterFuncMstHoliday(element, searchString1);
        private bool FilterFuncMstStation(MstStation element) => FilterFuncMstStation(element, searchString1);
        private bool FilterFuncSAPModels(SAPModels element) => FilterFuncSAPModels(element, searchString1);
        private bool FilterFuncTrnsProductStage(TrnsProductStage element) => FilterFuncTrnsProductStage(element, searchString1);
        private bool FilterFuncTrnsProductStageItem(TrnsProductStageItem element) => FilterFuncTrnsProductStageItem(element, searchString1);
        private bool FilterFuncTrnsProductStageStation(TrnsProductStageStation element) => FilterFuncTrnsProductStageStation(element, searchString1);
        private bool FilterFuncTrnsPerPiece(TrnsPerPieceTransaction element) => FilterFuncTrnsPerPiece(element, searchString1);
        void Cancel() => MudDialog.Cancel();

        private MudTable<MstElement> _tableElement;
        MstElement oModelElement = new MstElement();
        List<MstElement> oListElement = new List<MstElement>();
        private HashSet<MstElement> HashElement = new HashSet<MstElement>();

        private MudTable<MstShift> _tableShift;
        MstShift oModelShift = new MstShift();
        List<MstShift> oListShift = new List<MstShift>();

        private MudTable<CfgTaxSetup> _tableTaxSetup;
        CfgTaxSetup oModelTaxSetup = new CfgTaxSetup();
        List<CfgTaxSetup> oListTaxSetup = new List<CfgTaxSetup>();

        private MudTable<CfgPayrollDefination> _tablePayroll;
        CfgPayrollDefination oModelPayrollSetup = new CfgPayrollDefination();
        List<CfgPayrollDefination> oListPayrollSetup = new List<CfgPayrollDefination>();

        private MudTable<MstGratuity> _tableGratuity;
        MstGratuity oModelGratuitySetup = new MstGratuity();
        List<MstGratuity> oListGratuitySetup = new List<MstGratuity>();

        private MudTable<MstEmployee> _tableMstEmployee;
        MstEmployee oModelMstEmployee = new MstEmployee();
        List<MstEmployee> oListMstEmployee = new List<MstEmployee>();

        private MudTable<TrnsEmployeeTransfer> _tableTrnsEmployeeTransfer;
        TrnsEmployeeTransfer oModelTrnsEmployeeTransfer = new TrnsEmployeeTransfer();
        List<TrnsEmployeeTransfer> oListTrnsEmployeeTransfer = new List<TrnsEmployeeTransfer>();

        private MudTable<TrnsLeavesRequest> _tableTrnsLeavesRequest;
        TrnsLeavesRequest oModelTrnsLeavesRequest = new TrnsLeavesRequest();
        List<TrnsLeavesRequest> oListTrnsLeavesRequest = new List<TrnsLeavesRequest>();

        private MudTable<TrnsLoanRequest> _tableTrnsLoanRequest;
        TrnsLoanRequest oModelTrnsLoanRequest = new TrnsLoanRequest();
        List<TrnsLoanRequest> oListTrnsLoanRequest = new List<TrnsLoanRequest>();

        private MudTable<TrnsAdvanceRequest> _tableTrnsAdvanceRequest;
        TrnsAdvanceRequest oModelTrnsAdvanceRequest = new TrnsAdvanceRequest();
        List<TrnsAdvanceRequest> oListTrnsAdvanceRequest = new List<TrnsAdvanceRequest>();

        private MudTable<TrnsResignation> _tableTrnsEmployeeResign;
        TrnsResignation oModelTrnsEmployeeResign = new TrnsResignation();
        List<TrnsResignation> oListTrnsEmployeeResign = new List<TrnsResignation>();

        private MudTable<TrnsEmployeeOvertime> _tableTrnsEmployeeOvertime;
        TrnsEmployeeOvertime oModelTrnsEmployeeOvertime = new TrnsEmployeeOvertime();
        List<TrnsEmployeeOvertime> oListTrnsEmployeeOvertime = new List<TrnsEmployeeOvertime>();

        private MudTable<TrnsTaxAdjustment> _tableTaxAdjustment;
        TrnsTaxAdjustment oModelTrnsTaxAdjustment = new TrnsTaxAdjustment();
        List<TrnsTaxAdjustment> oListTrnsTaxAdjustment = new List<TrnsTaxAdjustment>();

        private HashSet<MstEmployee> selectedEmployee = new HashSet<MstEmployee>();

        private MudTable<CfgApprovalStage> _tableCfgApprovalStage;
        CfgApprovalStage oModelCfgApprovalStage = new CfgApprovalStage();
        List<CfgApprovalStage> oListCfgApprovalStage = new List<CfgApprovalStage>();

        private MudTable<CfgApprovalTemplate> _tableCfgApprovalTemplate;
        CfgApprovalTemplate oModelCfgApprovalTemplate = new CfgApprovalTemplate();
        List<CfgApprovalTemplate> oListCfgApprovalTemplate = new List<CfgApprovalTemplate>();

        private MudTable<TrnsEmployeeReHire> _tableTrnsEmployeeReHire;
        TrnsEmployeeReHire oModelTrnsEmployeeReHire = new TrnsEmployeeReHire();
        List<TrnsEmployeeReHire> oListTrnsEmployeeReHire = new List<TrnsEmployeeReHire>();

        private MudTable<TrnsEmployeeBonu> _tableEmployeeBonus;
        TrnsEmployeeBonu oModelEmployeeBonus = new TrnsEmployeeBonu();
        List<TrnsEmployeeBonu> oListEmployeeBonus = new List<TrnsEmployeeBonu>();

        private MudTable<TrnsBatch> _tableBatch;
        TrnsBatch oModelBatch = new TrnsBatch();
        List<TrnsBatch> oListBatch = new List<TrnsBatch>();

        private MudTable<TrnsSingleEntryOtrequest> _tableTrnsSingleEntryOtrequest;
        TrnsSingleEntryOtrequest oModelTrnsSingleEntryOtrequest = new TrnsSingleEntryOtrequest();
        List<TrnsSingleEntryOtrequest> oListTrnsSingleEntryOtrequest = new List<TrnsSingleEntryOtrequest>();

        private MudTable<UserDataAccess> _tableUserDataAccess;
        UserDataAccess oModelUserDataAccess = new UserDataAccess();
        IEnumerable<UserDataAccess> oListUserDataAccessDistinct = new List<UserDataAccess>();
        List<UserDataAccess> oListUserDataAccess = new List<UserDataAccess>();

        private MudTable<MstLocation> _tableMstLocation;
        MstLocation oModelMstLocation = new MstLocation();
        List<MstLocation> oListMstLocation = new List<MstLocation>();

        private MudTable<VMLoc_Gldetermination> _tableVMLoc_Gldetermination;
        VMLoc_Gldetermination VMLoc_Gldetermination = new VMLoc_Gldetermination();
        List<VMLoc_Gldetermination> olistVMLoc_Gldetermination = new List<VMLoc_Gldetermination>();

        MstGldetermination oModelMstGldetermination = new MstGldetermination();
        List<MstGldetermination> olistMstGldetermination = new List<MstGldetermination>();


        private MudTable<MstDepartment> _tableMstDepartment;
        MstDepartment oModelMstDepartment = new MstDepartment();
        List<MstDepartment> oListMstDepartment = new List<MstDepartment>();

        private MudTable<VMDept_Gldetermination> _tableVMDept_Gldetermination;
        VMDept_Gldetermination VMDept_Gldetermination = new VMDept_Gldetermination();
        List<VMDept_Gldetermination> olistVMDept_Gldetermination = new List<VMDept_Gldetermination>();


        private MudTable<MstchartofAccount> _tableMstchartofAccount;
        MstchartofAccount oModelMstchartofAccount = new MstchartofAccount();
        List<MstchartofAccount> oListMstchartofAccount = new List<MstchartofAccount>();

        private MudTable<MstHoliday1> _tableMstHoliday;
        MstHoliday1 oModelMstHoliday = new MstHoliday1();
        List<MstHoliday1> oListMstHoliday = new List<MstHoliday1>();

        private MudTable<MstStation> _tableMstStation;
        MstStation oModelMstStation = new MstStation();
        List<MstStation> oListMstStation = new List<MstStation>();
        private HashSet<MstStation> HashStation = new HashSet<MstStation>();

        private MudTable<SAPModels> _tableSAPModels;
        SAPModels oModelSAPModels = new SAPModels();
        List<SAPModels> oListSAPModels = new List<SAPModels>();
        private HashSet<SAPModels> HashSAPModels = new HashSet<SAPModels>();

        private MudTable<TrnsProductStage> _tableTrnsProductStage;
        TrnsProductStage oModelTrnsProductStage = new TrnsProductStage();
        List<TrnsProductStage> oListTrnsProductStage = new List<TrnsProductStage>();

        private MudTable<TrnsProductStageItem> _tableTrnsProductStageItem;
        TrnsProductStageItem oModelTrnsProductStageItem = new TrnsProductStageItem();
        List<TrnsProductStageItem> oListTrnsProductStageItem = new List<TrnsProductStageItem>();

        private MudTable<TrnsProductStageStation> _tableTrnsProductStageStation;
        TrnsProductStageStation oModelTrnsProductStageStation = new TrnsProductStageStation();
        List<TrnsProductStageStation> oListTrnsProductStageStation = new List<TrnsProductStageStation>();

        private MudTable<TrnsPerPieceTransaction> _tableTrnsPerPiece;
        TrnsPerPieceTransaction oModelTrnsPerPiece = new TrnsPerPieceTransaction();
        List<TrnsPerPieceTransaction> oListTrnsPerPiece = new List<TrnsPerPieceTransaction>();

        #endregion

        #region Functions

        private async Task GetAllElements()
        {
            try
            {
                oListElement = await _mstElement.GetAllData();
                if (DialogFor == "ElementTransaction")
                {
                    List<MstElement> oListTemp = new List<MstElement>();
                    foreach (var PayrollElement in PayrollElements)
                    {
                        var SelectedElement = oListElement.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                        oListTemp.Add(SelectedElement);
                    }
                    oListElement = oListTemp.ToList();
                }
                if (oListElement?.Count == 0 || oListElement == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncElement(MstElement element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ElmtType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Type.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllShift()
        {
            try
            {
                oListShift = await _mstShift.GetAllData();
                if (oListShift?.Count == 0 || oListShift == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncShift(MstShift element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllTaxSetup()
        {
            try
            {
                oListTaxSetup = await _CfgTaxSetup.GetAllData();
                if (oListTaxSetup?.Count == 0 || oListTaxSetup == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTaxSetup(CfgTaxSetup element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.SalaryYear.ToString().Contains(searchString1))
                return true;
            if (element.MinTaxSalaryF.ToString().Contains(searchString1))
                return true;
            if (element.SeniorCitizonAge.ToString().Contains(searchString1))
                return true;
            if (element.MaxSalaryDisc.ToString().Contains(searchString1))
                return true;
            if (element.DiscountOnTotalTax.ToString().Contains(searchString1))
                return true;
            return false;
        }

        private async Task GetAllPayrollSetup()
        {
            try
            {
                oListPayrollSetup = await _CfgPayrollDefinationSetup.GetAllData();
                if (oListPayrollSetup?.Count == 0 || oListPayrollSetup == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncPayrollSetup(CfgPayrollDefination element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.PayrollName.Equals(searchString1))
                return true;
            if (element.PayrollType.Equals(searchString1))
                return true;
            if (element.Gltype.Equals(searchString1))
                return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }

        private async Task GetAllGratuitySetup()
        {
            try
            {
                oListGratuitySetup = await _mstGratuity.GetAllData();
                if (oListGratuitySetup?.Count == 0 || oListGratuitySetup == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncGratuitySetup(MstGratuity element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Equals(searchString1))
                return true;
            if (element.BasedOn.Equals(searchString1))
                return true;
            if (element.BasedOnValue.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllMstEmployee()
        {
            try
            {
                oListMstEmployee = await _mstEmployee.GetAllData(LoginUser);
                if (oListMstEmployee?.Count == 0 || oListMstEmployee == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstEmployee(MstEmployee element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FirstName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsEmployeeTransfer()
        {
            try
            {
                oListTrnsEmployeeTransfer = await _trnsEmployeeTransfer.GetAllData();
                if (oListTrnsEmployeeTransfer?.Count == 0 || oListTrnsEmployeeTransfer == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsEmployeeTransfer(TrnsEmployeeTransfer element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DoNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsLeavesRequest()
        {
            try
            {
                oListTrnsLeavesRequest = await _trnsLeavesRequest.GetAllData();
                if (oListTrnsLeavesRequest?.Count == 0 || oListTrnsLeavesRequest == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsLeavesRequest(TrnsLeavesRequest element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocAprStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LeaveType.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsLoanRequest()
        {
            try
            {
                oListTrnsLoanRequest = await _trnsLoanRequest.GetAllData();
                if (oListTrnsLoanRequest?.Count == 0 || oListTrnsLoanRequest == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsLoanRequest(TrnsLoanRequest element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocAprStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LoanDescription.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsAdvanceRequest()
        {
            try
            {
                oListTrnsAdvanceRequest = await _trnsAdvanceRequest.GetAllData();
                if (oListTrnsAdvanceRequest?.Count == 0 || oListTrnsAdvanceRequest == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsAdvanceRequest(TrnsAdvanceRequest element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocAprStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.AdvanceDescription.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsEmployeeOverTime()
        {
            try
            {
                oListTrnsEmployeeOvertime = await _trnsEmployeeOverTime.GetAllData();
                if (oListTrnsEmployeeOvertime?.Count == 0 || oListTrnsEmployeeOvertime == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsEmployeeOvertime(TrnsEmployeeOvertime element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.PeriodName.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.EmployeeId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllTrnsEmployeeResign()
        {
            try
            {
                oListTrnsEmployeeResign = await _trnsEmployeeResign.GetAllData();
                if (oListTrnsEmployeeResign?.Count == 0 || oListTrnsEmployeeResign == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsEmployeeResign(TrnsResignation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocAprStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ResignDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsTaxAdjustment()
        {
            try
            {
                oListTrnsTaxAdjustment = await _trnsTaxAdjustment.GetAllData();
                if (oListTrnsTaxAdjustment?.Count == 0 || oListTrnsTaxAdjustment == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsTaxAdjustment(TrnsTaxAdjustment element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DocAprStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DocDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.ResignDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllMstEmployeeReHire()
        {
            try
            {
                oListMstEmployee = await _mstEmployee.GetAllData();
                oListMstEmployee = oListMstEmployee.Where(x => x.FlgActive == false && (x.ResignDate != null || x.TerminationDate != null)).ToList();
                if (oListMstEmployee?.Count == 0 || oListMstEmployee == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstEmployeeReHire(MstEmployee element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FirstName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllMstStages()
        {
            try
            {
                oListCfgApprovalStage = await _mstStages.GetAllData();
                if (oListCfgApprovalStage?.Count == 0 || oListCfgApprovalStage == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncCfgApprovalStage(CfgApprovalStage element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.StageName.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllCfgApprovalTemplate()
        {
            try
            {
                oListCfgApprovalTemplate = await _cfgApprovalTemplate.GetAllData();
                if (oListCfgApprovalTemplate?.Count == 0 || oListCfgApprovalTemplate == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncCfgApprovalTemplate(CfgApprovalTemplate element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Name.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllTrnsEmployeeReHire()
        {
            try
            {
                oListTrnsEmployeeReHire = await _trnsReHireEmployee.GetAllData();
                if (oListTrnsEmployeeReHire?.Count == 0 || oListTrnsEmployeeReHire == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsEmployeeReHire(TrnsEmployeeReHire element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmployeeName.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllEmployeeBonus()
        {
            try
            {
                oListEmployeeBonus = await _trnsEmployeeBonus.GetAllData();
                if (oListEmployeeBonus?.Count == 0 || oListEmployeeBonus == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncEmployeeBonus(TrnsEmployeeBonu element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocumentNo.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.CalendarCode.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PayrollCode.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PaysInPeriodCode.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Status.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllBatch()
        {
            try
            {
                oListBatch = await _trnsBatch.GetAllData();
                if (oListBatch?.Count == 0 || oListBatch == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncBatch(TrnsBatch element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocNum.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.BatchName.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PayrollName.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ElmtCode.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PayrollPeriod.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllFilterFuncMonthlyOT()
        {
            try
            {
                oListTrnsSingleEntryOtrequest = await _trnsSingleEntryOtrequest.GetAllData();
                if (oListTrnsSingleEntryOtrequest?.Count == 0 || oListTrnsSingleEntryOtrequest == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMonthlyOT(TrnsSingleEntryOtrequest element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocStatus.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Ottype.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllUserDataAccess()
        {
            try
            {
                oListUserDataAccess = await _userDataAccess.GetAllData();
                oListUserDataAccessDistinct = oListUserDataAccess.DistinctBy(x => x.EmpId);
                if (oListUserDataAccess?.Count() == 0 || oListUserDataAccess == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncUserDataAccess(UserDataAccess element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllGLdetermination()
        {
            try
            {
                olistMstGldetermination = await _mstGldetermination.GetAllData();
                if (olistMstGldetermination?.Count == 0 || olistMstGldetermination == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                if (DialogFor == "Location")
                {
                    await SetVMlocGlDertmination();
                }
                else if (DialogFor == "department")
                {
                    await SetVMDeptGlDertmination();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllMstLocation()
        {
            try
            {
                oListMstLocation = await _mstLocation.GetAllData();
                if (oListMstLocation?.Count == 0 || oListMstLocation == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                await GetAllGLdetermination();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstLocation(MstLocation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Name.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }
        private Task SetVMlocGlDertmination()
        {
            try
            {
                foreach (var item in oListMstLocation)
                {
                    VMLoc_Gldetermination vMLoc_Gldetermination = new VMLoc_Gldetermination();
                    vMLoc_Gldetermination.LocID = item.Id;
                    vMLoc_Gldetermination.LocCode = item.Name;
                    vMLoc_Gldetermination.LocDescription = item.Description;
                    olistVMLoc_Gldetermination.Add(vMLoc_Gldetermination);
                }
                foreach (var item in olistVMLoc_Gldetermination)
                {
                    item.GlID = olistMstGldetermination.Where(x => x.Glvalue == item.LocID && x.Gltype == "Loc").Select(x => x.Id).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private bool FilterFuncVMlocGlDertmination(VMLoc_Gldetermination element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.LocCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LocDescription.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllMstDepartment()
        {
            try
            {
                oListMstDepartment = await _mstDepartment.GetAllData();
                if (oListMstDepartment?.Count == 0 || oListMstDepartment == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                await GetAllGLdetermination();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstDepartment(MstDepartment element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeptName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private Task SetVMDeptGlDertmination()
        {
            try
            {
                foreach (var item in oListMstDepartment)
                {
                    VMDept_Gldetermination vMDept_Gldetermination = new VMDept_Gldetermination();
                    vMDept_Gldetermination.DeptID = item.Id;
                    vMDept_Gldetermination.DeptCode = item.Code;
                    vMDept_Gldetermination.DeptDescription = item.DeptName;
                    olistVMDept_Gldetermination.Add(vMDept_Gldetermination);
                }
                foreach (var item in olistVMDept_Gldetermination)
                {
                    item.GlID = olistMstGldetermination.Where(x => x.Glvalue == item.DeptID && x.Gltype == "Dept").Select(x => x.Id).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private bool FilterFuncVMDeptGldetermination(VMDept_Gldetermination element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DeptCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeptDescription.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllMstchartofAccount()
        {
            try
            {
                oListMstchartofAccount = await _mstchartofAccount.GetAllData();
                if (oListMstchartofAccount?.Count == 0 || oListMstchartofAccount == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstchartofAccount(MstchartofAccount element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllMstHoliday()
        {
            try
            {
                oListMstHoliday = await _mstHoliday.GetAllData();
                if (oListMstHoliday?.Count == 0 || oListMstHoliday == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstHoliday(MstHoliday1 element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Holiday.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.HolidayName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.JoiningDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllMstStation()
        {
            try
            {
                oListMstStation = await _mstStation.GetAllData();
                if (oListMstStation?.Count == 0 || oListMstStation == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstStation(MstStation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetAllSAPModels()
        {
            try
            {
                oListSAPModels = await _SAPData.GetAllItemsFromSAP();
                if (oListSAPModels?.Count == 0 || oListSAPModels == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncSAPModels(SAPModels element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ItemCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.ItemGroupCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllTrnsProductStage()
        {
            try
            {
                oListTrnsProductStage = await _trnsProductStage.GetAllData();
                if (DialogFor == "TrnsProductStageItem" && productStageID != 0)
                {
                    TrnsProductStage trnsProductStage = new TrnsProductStage();
                    trnsProductStage = oListTrnsProductStage.Where(x=>x.Id == productStageID).FirstOrDefault();
                    oListTrnsProductStageItem = trnsProductStage.TrnsProductStageItems.Where(x=>x.Psid == trnsProductStage.Id).ToList();
                }
               else if (DialogFor == "TrnsProductStageStation" && productStageID != 0)
                {
                    TrnsProductStage trnsProductStage = new TrnsProductStage();
                    trnsProductStage = oListTrnsProductStage.Where(x => x.Id == productStageID).FirstOrDefault();
                    oListTrnsProductStageStation = trnsProductStage.TrnsProductStageStations.Where(x => x.Psid == trnsProductStage.Id).ToList();
                }

                if (oListTrnsProductStage?.Count == 0 || oListTrnsProductStage == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsProductStage(TrnsProductStage element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.ItemGroupCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }
        private bool FilterFuncTrnsProductStageItem(TrnsProductStageItem element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ItemCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemDescription.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.SubItemDescription.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemGrpCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemGrpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.ItemGroupCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }
        private bool FilterFuncTrnsProductStageStation(TrnsProductStageStation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.StationCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.StationDescription.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.ItemGroupCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        private async Task GetAllTrnsPerPiece()
        {
            try
            {
                oListTrnsPerPiece = await _trnsPerPiece.GetAllData();
                if (oListTrnsPerPiece?.Count == 0 || oListTrnsPerPiece == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncTrnsPerPiece(TrnsPerPieceTransaction element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Pscode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element..Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.ItemGroupCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    if (DialogFor == "Element" || DialogFor == "PayrollElement")
                    {
                        await GetAllElements();
                    }
                    else if (DialogFor == "ElementTransaction")
                    {
                        await GetAllElements();
                    }
                    else if (DialogFor == "Shifts")
                    {
                        await GetAllShift();
                    }
                    else if (DialogFor == "TaxSetup")
                    {
                        await GetAllTaxSetup();
                    }
                    else if (DialogFor == "GratuitySetup")
                    {
                        await GetAllGratuitySetup();
                    }
                    else if (DialogFor == "PayrollSetup")
                    {
                        await GetAllPayrollSetup();
                    }
                    else if (DialogFor == "EmployeeMaster")
                    {
                        await GetAllMstEmployee();
                    }
                    else if (DialogFor == "MultipleEmployeeSelect")
                    {
                        await GetAllMstEmployee();
                    }
                    else if (DialogFor == "TrnsEmployeeTransfer")
                    {
                        await GetAllTrnsEmployeeTransfer();
                    }
                    else if (DialogFor == "LeaveRequest")
                    {
                        await GetAllTrnsLeavesRequest();
                    }
                    else if (DialogFor == "LoanRequest")
                    {
                        await GetAllTrnsLoanRequest();
                    }
                    else if (DialogFor == "AdvanceRequest")
                    {
                        await GetAllTrnsAdvanceRequest();
                    }
                    else if (DialogFor == "TrnsEmployeeOverTime")
                    {
                        await GetAllTrnsEmployeeOverTime();
                    }
                    else if (DialogFor == "EmployeeResign")
                    {
                        await GetAllTrnsEmployeeResign();
                    }
                    else if (DialogFor == "TaxAdjustment")
                    {
                        await GetAllTrnsTaxAdjustment();
                    }
                    else if (DialogFor == "EmployeeReHire")
                    {
                        await GetAllMstEmployeeReHire();
                    }
                    else if (DialogFor == "ApprovalStages")
                    {
                        await GetAllMstStages();
                    }
                    else if (DialogFor == "ApprovalTemplate")
                    {
                        await GetAllCfgApprovalTemplate();
                    }
                    else if (DialogFor == "EmployeeReHireEdit")
                    {
                        await GetAllTrnsEmployeeReHire();
                    }
                    else if (DialogFor == "EmployeeBonus")
                    {
                        await GetAllEmployeeBonus();
                    }
                    else if (DialogFor == "Batch")
                    {
                        await GetAllBatch();
                    }
                    else if (DialogFor == "MonthlyOT")
                    {
                        await GetAllFilterFuncMonthlyOT();
                    }
                    else if (DialogFor == "UserDataAccess")
                    {
                        await GetAllUserDataAccess();
                    }
                    else if (DialogFor == "Location")
                    {
                        await GetAllMstLocation();
                    }
                    else if (DialogFor == "department")
                    {
                        await GetAllMstDepartment();
                    }
                    else if (DialogFor == "COA")
                    {
                        await GetAllMstchartofAccount();
                    }
                    else if (DialogFor == "Holiday")
                    {
                        await GetAllMstHoliday();
                    }
                    else if (DialogFor == "Station")
                    {
                        await GetAllMstStation();
                    }
                    else if (DialogFor == "StageItem")
                    {
                        await GetAllSAPModels();
                    }
                    else if (DialogFor == "TrnsProductStage")
                    {
                        await GetAllTrnsProductStage();
                    }
                    else if (DialogFor == "TrnsProductStageItem")
                    {
                        await GetAllTrnsProductStage();
                    }
                    else if (DialogFor == "TrnsProductStageStation")
                    {
                        await GetAllTrnsProductStage();
                    }
                    else if (DialogFor == "TrnsPerPiece")
                    {
                        await GetAllTrnsPerPiece();
                    }
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
                }



                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        public void RowClickEventElement(TableRowClickEventArgs<MstElement> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncElement(MstElement element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableElement.SelectedItem != null && _tableElement.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventShift(TableRowClickEventArgs<MstShift> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncShift(MstShift element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableShift.SelectedItem != null && _tableShift.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTaxSetup(TableRowClickEventArgs<CfgTaxSetup> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTaxSetup(CfgTaxSetup element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTaxSetup.SelectedItem != null && _tableTaxSetup.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventPayrollSetup(TableRowClickEventArgs<CfgPayrollDefination> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncPayrollSetup(CfgPayrollDefination element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tablePayroll.SelectedItem != null && _tablePayroll.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventGratuitySetup(TableRowClickEventArgs<MstGratuity> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncGratuitySetup(MstGratuity element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableGratuity.SelectedItem != null && _tableGratuity.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstEmployee(TableRowClickEventArgs<MstEmployee> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncMstEmployee(MstEmployee element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstEmployee.SelectedItem != null && _tableMstEmployee.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsEmployeeTransfer(TableRowClickEventArgs<TrnsEmployeeTransfer> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsEmployeeTransfer(TrnsEmployeeTransfer element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsEmployeeTransfer.SelectedItem != null && _tableTrnsEmployeeTransfer.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsLeavesRequest(TableRowClickEventArgs<TrnsLeavesRequest> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsLeavesRequest(TrnsLeavesRequest element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsLeavesRequest.SelectedItem != null && _tableTrnsLeavesRequest.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsLoanRequest(TableRowClickEventArgs<TrnsLoanRequest> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsLoanRequest(TrnsLoanRequest element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsLoanRequest.SelectedItem != null && _tableTrnsLoanRequest.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsAdvanceRequest(TableRowClickEventArgs<TrnsAdvanceRequest> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsAdvanceRequest(TrnsAdvanceRequest element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsAdvanceRequest.SelectedItem != null && _tableTrnsAdvanceRequest.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsEmployeeOverTime(TableRowClickEventArgs<TrnsEmployeeOvertime> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsEmployeeOverTime(TrnsEmployeeOvertime element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsEmployeeOvertime.SelectedItem != null && _tableTrnsEmployeeOvertime.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsEmployeeResign(TableRowClickEventArgs<TrnsResignation> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTrnsEmployeeResign(TrnsResignation element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsEmployeeResign.SelectedItem != null && _tableTrnsEmployeeResign.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
        public void RowClickEventTaxAdjustment(TableRowClickEventArgs<TrnsTaxAdjustment> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncTaxAdjustment(TrnsTaxAdjustment element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTaxAdjustment.SelectedItem != null && _tableTaxAdjustment.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstEmployeeReHire(TableRowClickEventArgs<MstEmployee> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncMstEmployeeReHire(MstEmployee element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstEmployee.SelectedItem != null && _tableMstEmployee.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstStages(TableRowClickEventArgs<CfgApprovalStage> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncCfgApprovalStage(CfgApprovalStage element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableCfgApprovalStage.SelectedItem != null && _tableCfgApprovalStage.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventCfgApprovalTemplate(TableRowClickEventArgs<CfgApprovalTemplate> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncCfgApprovalTemplate(CfgApprovalTemplate element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableCfgApprovalTemplate.SelectedItem != null && _tableCfgApprovalTemplate.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsEmployeeReHire(TableRowClickEventArgs<TrnsEmployeeReHire> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncTrnsEmployeeReHire(TrnsEmployeeReHire element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsEmployeeReHire.SelectedItem != null && _tableTrnsEmployeeReHire.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventEmployeeBonus(TableRowClickEventArgs<TrnsEmployeeBonu> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncEmployeeBonus(TrnsEmployeeBonu element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableEmployeeBonus.SelectedItem != null && _tableEmployeeBonus.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventBatch(TableRowClickEventArgs<TrnsBatch> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncBatch(TrnsBatch element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableBatch.SelectedItem != null && _tableBatch.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMonthlyOT(TableRowClickEventArgs<TrnsSingleEntryOtrequest> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        public void RowClickEventMonthlyOT(TableRowClickEventArgs<UserDataAccess> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMonthlyOT(TrnsSingleEntryOtrequest element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsSingleEntryOtrequest.SelectedItem != null && _tableTrnsSingleEntryOtrequest.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
        private string SelectedRowClassFuncFilterFuncUserDataAccess(UserDataAccess element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableUserDataAccess.SelectedItem != null && _tableUserDataAccess.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstLocation(TableRowClickEventArgs<MstLocation> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMstLocation(MstLocation element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstLocation.SelectedItem != null && _tableMstLocation.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstDepartment(TableRowClickEventArgs<MstDepartment> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMstDepartment(MstDepartment element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstDepartment.SelectedItem != null && _tableMstDepartment.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstchartofAccount(TableRowClickEventArgs<MstchartofAccount> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMstchartofAccount(MstchartofAccount element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstchartofAccount.SelectedItem != null && _tableMstchartofAccount.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventVMlocGlDertmination(TableRowClickEventArgs<VMLoc_Gldetermination> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncVMlocGlDertmination(VMLoc_Gldetermination element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableVMLoc_Gldetermination.SelectedItem != null && _tableVMLoc_Gldetermination.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventVMDeptGldetermination(TableRowClickEventArgs<VMDept_Gldetermination> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncVMDeptGldetermination(VMDept_Gldetermination element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableVMDept_Gldetermination.SelectedItem != null && _tableVMDept_Gldetermination.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstHoliday(TableRowClickEventArgs<MstHoliday1> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMstHoliday(MstHoliday1 element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstHoliday.SelectedItem != null && _tableMstHoliday.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventMstStation(TableRowClickEventArgs<MstStation> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncMstStation(MstStation element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableMstStation.SelectedItem != null && _tableMstStation.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventSAPModels(TableRowClickEventArgs<SAPModels> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncSAPModels(SAPModels element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableSAPModels.SelectedItem != null && _tableSAPModels.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsProductStage(TableRowClickEventArgs<TrnsProductStage> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncTrnsProductStage(TrnsProductStage element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsProductStage.SelectedItem != null && _tableTrnsProductStage.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsProductStageItem(TableRowClickEventArgs<TrnsProductStageItem> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncTrnsProductStageItem(TrnsProductStageItem element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsProductStageItem.SelectedItem != null && _tableTrnsProductStageItem.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void RowClickEventTrnsProductStageStation(TableRowClickEventArgs<TrnsProductStageStation> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncTrnsProductStageStation(TrnsProductStageStation element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsProductStageStation.SelectedItem != null && _tableTrnsProductStageStation.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
         
        public void RowClickEventPerPiece(TableRowClickEventArgs<TrnsPerPieceTransaction> tableRowClickEventArgs)
        {
            try
            {
                clickedEvents.Add("Row has been clicked");
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private string SelectedRowClassFuncFilterFuncPerPiece(TrnsPerPieceTransaction element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (_tableTrnsPerPiece.SelectedItem != null && _tableTrnsPerPiece.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
        
        private void Submit()
        {
            try
            {
                if (DialogFor == "Element" && oModelElement.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<MstElement>(oModelElement));
                }
                else if (DialogFor == "ElementTransaction" && oListElement.Count() > 0)
                {
                    MudDialog.Close(DialogResult.Ok<HashSet<MstElement>>(HashElement));
                }
                else if (DialogFor == "Shifts" && oModelShift.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<MstShift>(oModelShift));
                }
                else if (DialogFor == "TaxSetup" && oModelTaxSetup.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<CfgTaxSetup>(oModelTaxSetup));
                }
                else if (DialogFor == "GratuitySetup" && oModelGratuitySetup.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<MstGratuity>(oModelGratuitySetup));
                }
                else if (DialogFor == "PayrollSetup" && oModelPayrollSetup.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<CfgPayrollDefination>(oModelPayrollSetup));
                }
                else if (DialogFor == "PayrollElement" && HashElement.Count() > 0)
                {
                    MudDialog.Close(DialogResult.Ok<HashSet<MstElement>>(HashElement));
                }
                else if (DialogFor == "EmployeeMaster" && oModelMstEmployee.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<MstEmployee>(oModelMstEmployee));
                }
                else if (DialogFor == "MultipleEmployeeSelect" && selectedEmployee.Count > 0)
                {
                    MudDialog.Close(DialogResult.Ok<HashSet<MstEmployee>>(selectedEmployee));
                }
                else if (DialogFor == "TrnsEmployeeTransfer" && oModelTrnsEmployeeTransfer.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsEmployeeTransfer>(oModelTrnsEmployeeTransfer));
                }
                else if (DialogFor == "LeaveRequest" && oModelTrnsLeavesRequest.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsLeavesRequest>(oModelTrnsLeavesRequest));
                }
                else if (DialogFor == "LoanRequest" && oModelTrnsLoanRequest.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsLoanRequest>(oModelTrnsLoanRequest));
                }
                else if (DialogFor == "AdvanceRequest" && oModelTrnsAdvanceRequest.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsAdvanceRequest>(oModelTrnsAdvanceRequest));
                }
                else if (DialogFor == "TrnsEmployeeOverTime" && oModelTrnsEmployeeOvertime.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsEmployeeOvertime>(oModelTrnsEmployeeOvertime));
                }
                else if (DialogFor == "EmployeeResign" && oModelTrnsEmployeeResign.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsResignation>(oModelTrnsEmployeeResign));
                }
                else if (DialogFor == "TaxAdjustment" && oModelTrnsTaxAdjustment.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsTaxAdjustment>(oModelTrnsTaxAdjustment));
                }
                else if (DialogFor == "EmployeeReHire" && oModelMstEmployee.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<MstEmployee>(oModelMstEmployee));
                }
                else if (DialogFor == "ApprovalStages" && oModelCfgApprovalStage.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<CfgApprovalStage>(oModelCfgApprovalStage));
                }
                else if (DialogFor == "ApprovalTemplate" && oModelCfgApprovalTemplate.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<CfgApprovalTemplate>(oModelCfgApprovalTemplate));
                }
                else if (DialogFor == "EmployeeReHireEdit" && oModelTrnsEmployeeReHire.InternalId > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsEmployeeReHire>(oModelTrnsEmployeeReHire));
                }
                else if (DialogFor == "EmployeeBonus" && oModelEmployeeBonus.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsEmployeeBonu>(oModelEmployeeBonus));
                }
                else if (DialogFor == "Batch" && oModelBatch.Id > 0)
                {
                    MudDialog.Close(DialogResult.Ok<TrnsBatch>(oModelBatch));
                }
                else if (DialogFor == "ApprovalDecesion")
                {
                    MudDialog.Close(DialogResult.Ok(Remarks));
                }
                else if (DialogFor == "MonthlyOT")
                {
                    MudDialog.Close(DialogResult.Ok(oModelTrnsSingleEntryOtrequest));
                }
                else if (DialogFor == "UserDataAccess")
                {
                    var a = oListUserDataAccessDistinct;
                    oListUserDataAccess = oListUserDataAccess.Where(x => x.EmpId == oModelUserDataAccess.EmpId).ToList();
                    MudDialog.Close(DialogResult.Ok<List<UserDataAccess>>(oListUserDataAccess));
                }
                else if (DialogFor == "Location")
                {
                    MudDialog.Close(DialogResult.Ok(VMLoc_Gldetermination));
                }
                else if (DialogFor == "department")
                {
                    MudDialog.Close(DialogResult.Ok(VMDept_Gldetermination));
                }
                else if (DialogFor == "COA")
                {
                    MudDialog.Close(DialogResult.Ok(oModelMstchartofAccount));
                }
                else if (DialogFor == "Holiday")
                {
                    MudDialog.Close(DialogResult.Ok(oModelMstHoliday));
                }
                else if (DialogFor == "Station" && oListMstStation.Count() > 0)
                {
                    MudDialog.Close(DialogResult.Ok<HashSet<MstStation>>(HashStation));
                    // MudDialog.Close(DialogResult.Ok(oModelMstStation));
                }
                else if (DialogFor == "StageItem" && oListSAPModels.Count() > 0)
                {
                    MudDialog.Close(DialogResult.Ok<HashSet<SAPModels>>(HashSAPModels));
                    //MudDialog.Close(DialogResult.Ok(oModelSAPModels));
                }
                else if (DialogFor == "TrnsProductStage")
                {
                    MudDialog.Close(DialogResult.Ok(oModelTrnsProductStage));
                }
                else if (DialogFor == "TrnsProductStageItem")
                {
                    MudDialog.Close(DialogResult.Ok(oModelTrnsProductStageItem));
                }
                else if (DialogFor == "TrnsProductStageStation")
                {
                    MudDialog.Close(DialogResult.Ok(oModelTrnsProductStageStation));
                }
                else if (DialogFor == "TrnsPerPiece")
                {
                    MudDialog.Close(DialogResult.Ok(oModelTrnsPerPiece));
                }
                else
                {
                    Snackbar.Add("Select row first", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        #endregion
    }
}
