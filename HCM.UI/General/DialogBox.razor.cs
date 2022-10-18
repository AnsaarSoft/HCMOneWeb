using HCM.API.Models;
using HCM.UI.Interfaces.Advance;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.Interfaces.Bonus;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.Loan;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;

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

        #endregion

        #region Variables

        private bool _processingTable = false;
        bool Loading = false;
        private string searchString1 = "";
        private int selectedRowNumber = -1;
        private List<string> clickedEvents = new();

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
                oListMstEmployee = await _mstEmployee.GetAllData();
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

        #endregion

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
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
