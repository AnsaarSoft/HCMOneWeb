using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
//using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using MudBlazor;
using System.Collections.Immutable;
using static MudBlazor.CategoryTypes;


namespace HCM.UI.Pages.MasterElement
{
    public partial class TaxAdjustment
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public ITrnsTaxAdjustment _TrnsTaxAdjustment { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsFlg = false;

        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        string EmpName = "";
        private decimal Amount;
        private decimal Hours;
        private string PayrollPeriodstr = "Select Period";
        private string FullName = "";
        private string searchString1 = "";

        private bool FilterFunc(TrnsEmployeeOvertimeDetail element) => FilterFunc(element, searchString1);


        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        TrnsTaxAdjustment oModel = new TrnsTaxAdjustment();
        private IEnumerable<TrnsTaxAdjustment> oList = new List<TrnsTaxAdjustment>();

        private IEnumerable<TrnsTaxAdjustmentDetail> oDetailList = new List<TrnsTaxAdjustmentDetail>();
        List<TrnsTaxAdjustmentDetail> oDetail = new List<TrnsTaxAdjustmentDetail>();
        private IEnumerable<TrnsTaxAdjustmentDetail> oListdtl = new List<TrnsTaxAdjustmentDetail>();

        CfgPayrollDefination oPayroll = new CfgPayrollDefination();
        private List<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();


        List<MstCalendar> oCalendarList = new List<MstCalendar>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        DateTime? docdate;
        TimeSpan? timefrom = new TimeSpan();
        TimeSpan? timeto = new TimeSpan();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion


        #region Functions
        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelMstEmployee = res;
                    //oModel.EmployeeId = oModelMstEmployee.Id;
                    
                    EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;
                    var EmpDetail = oListEmployee.Where(x => x.EmpId == oModelMstEmployee.EmpId).FirstOrDefault();
                      oModelMstEmployee.PayrollName = EmpDetail.PayrollName;
                    oModelMstEmployee = EmpDetail;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TaxAdjustment");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsTaxAdjustment)result.Data;
                    oModel = res;
                    oModelMstEmployee = oListEmployee.Where(x => x.Id == oModel.EmpId).FirstOrDefault();
                    FullName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName+ " " + oModelMstEmployee.LastName;
                    EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName+ " " + oModelMstEmployee.LastName;
                    oDetailList = oModel.TrnsTaxAdjustmentDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenAddDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TaxAdjustment");
                parameters.Add("EmpPayrollId", oModelMstEmployee.PayrollId);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsTaxAdjustmentDetail)result.Data;
                    if (oDetailList.Where(x => x.Id == res.Taid).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oDetail.Add(res);
                        oDetailList = oDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialog(DialogOptions options, TrnsTaxAdjustmentDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaTaxAdjust", oDetailPara);
                parameters.Add("DialogFor", "TaxAdjustment");
                parameters.Add("EmpPayrollId", oModelMstEmployee.PayrollId);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (TrnsTaxAdjustmentDetail)result.Data;
                    var update = oDetailList.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oDetail.Remove(update);
                    }
                    TrnsTaxAdjustmentDetail oTaxDetail = new TrnsTaxAdjustmentDetail();
                    oTaxDetail.Id = res.Id;
                    oTaxDetail.Amount = res.Amount;
                    oTaxDetail.FlgActive = res.FlgActive;
                    oTaxDetail.CreateDt = DateTime.Now;
                    oTaxDetail.CreatedBy = LoginUser;
                    if (oModel.Id != 0)
                    {
                        oTaxDetail.UpdateDt= DateTime.Now;
                        oTaxDetail.UpdatedBy= LoginUser;
                    }
                    else
                    {
                        oTaxDetail.CreateDt = DateTime.Now;
                        oTaxDetail.CreatedBy = LoginUser;

                    }

                    oTaxDetail = res;
                    oDetail.Add(oTaxDetail);
                    oDetailList = oDetail.ToList();
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllCalendar()
        {
            try
            {
                oCalendarList = await _mstCalendar.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmployees()
        {
            try
            {
                oListEmployee = await _mstEmployeeMaster.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllTaxAdjustment()
        {
            try
            {
                oList = await _TrnsTaxAdjustment.GetAllData();
                oList = oList.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFunc(TrnsEmployeeOvertimeDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.OvertimeId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private async Task<IEnumerable<MstEmployee>> SearchEmployee(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();

                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task FillEmployeeCode(MstEmployee oModelMstEmpCode)
        {
            try
            {
                if (oModelMstEmpCode != null)
                {
                    var EmpDetail = oListEmployee.Where(x => x.EmpId == oModelMstEmpCode.EmpId).FirstOrDefault();
                    oPayroll = oListPayroll.Where(x => x.Id == EmpDetail.PayrollId).FirstOrDefault();
                    CfgPeriodDate mstPayrollPeriod = new CfgPeriodDate();
                    oListPayrollPeriod = oPayroll.CfgPeriodDates.Where(x => x.PayrollId == oPayroll.Id).ToList();
                    //DateTime dt = (DateTime)oPayroll.FirstPeriodEndDt;
                    FullName = EmpDetail.FirstName + " " + EmpDetail.MiddleName + " " + EmpDetail.LastName;
                    oModelMstEmployee.PayrollName = EmpDetail.PayrollName;
                    oModelMstEmployee = EmpDetail;

                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/TaxAdjustment", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task DeleteFromFilter(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<TrnsTaxAdjustmentDetail> oListTrnsEmployeeTaxAdjustDtl = new List<TrnsTaxAdjustmentDetail>();
                oListTrnsEmployeeTaxAdjustDtl = oDetailList.ToList();
                if (oDetailList.Count() > 0)
                {
                    var FilterRecord = oDetailList.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsEmployeeTaxAdjustDtl.Remove(FilterRecord);
                    oDetailList = oListTrnsEmployeeTaxAdjustDtl;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                oModel.EmpId = oModelMstEmployee.Id;
                oModel.EmpCode = oModelMstEmployee.EmpId;
                oModel.CalendarCode = oCalendarList.Where(x=>x.Id == oModel.CalendarId).Select(x=>x.Code).FirstOrDefault();
                oModel.FlgActive = true;
                if ((oModel.EmpId != null) && (oModel.CalendarId != null) && oDetailList.Count() > 0)
                {
                    foreach (var item in oDetailList)
                    {
                        if (oModel.Id == 0)
                        {
                            item.CreateDt = DateTime.Now;
                            item.CreatedBy = LoginUser;
                        }
                        else
                        {
                            item.UpdateDt = DateTime.Now;
                            item.UpdatedBy = LoginUser;
                        }
                    }

                    oModel.TrnsTaxAdjustmentDetails = oDetailList.ToList();
                    if (oModel.Id == 0)
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _TrnsTaxAdjustment.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _TrnsTaxAdjustment.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/TaxAdjustment", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
                return res;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                return null;
            }
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    await GetAllEmployees();
                    await GetAllTaxAdjustment();
                    await GetAllCalendar();
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

        #endregion
    }
}

