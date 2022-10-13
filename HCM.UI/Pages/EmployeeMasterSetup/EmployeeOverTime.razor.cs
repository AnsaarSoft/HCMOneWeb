using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Immutable;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeOverTime
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string Amount = "";
        private string Hours = "";
        private string PayrollPeriodstr = "";
        private string FullName = "";
        private string searchString1 = "";

        private bool FilterFunc(MstEmployee element) => FilterFunc(element, searchString1);


        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();


        MstOverTime oModel = new MstOverTime();
        private IEnumerable<MstOverTime> oListmstOverTime = new List<MstOverTime>();

    
        CfgPayrollDefination oPayroll = new CfgPayrollDefination();
        private List<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();

        CfgPeriodDate oPayrollPeriod = new CfgPeriodDate();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        DateTime? docdate;
        TimeSpan? timefrom = new TimeSpan();
        TimeSpan? timeto = new TimeSpan();
        #endregion


        #region Functions

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
        private async Task GetAllOvertime()
        {
            try
            {
                oListmstOverTime = await _mstOverTime.GetAllData();
                oListmstOverTime  = oListmstOverTime.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmployeesPayroll()
        {
            try
            {
                oListPayroll = await _CfgPayrollDefination.GetAllData();
                oListPayroll = oListPayroll.Where(x => x.FlgActive == true).ToList();
             //   MstPayroll oMstPayroll = oListPayroll.Where(x => x.PayrollType == oModel.PayrollType).FirstOrDefault();
             //   oMstPayrollPeriodList = oMstPayroll.MstPayrollPeriods.Where(x => x.CalCode == PayrollCalendar && x.Fkid == oMstPayroll.Id).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<IEnumerable<MstOverTime>> SearchOvertime(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListmstOverTime.Select(o => new MstOverTime
                    {
                        Id = o.Id,
                        Code = o.Code,
                    }).ToList();
                var res = oListmstOverTime.Where(x => x.Code.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstOverTime
                {
                    Id = x.Id,
                    Code = x.Code,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private bool FilterFunc(MstEmployee element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
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
                    oPayroll =  oListPayroll.Where(x =>x.Id  == EmpDetail.PayrollId).FirstOrDefault();
                    CfgPeriodDate mstPayrollPeriod = new CfgPeriodDate(); 
                    oListPayrollPeriod = oPayroll.CfgPeriodDates.Where(x=>x.FkcalId == oPayroll.Id).ToList();

                    DateTime dt = (DateTime)oPayroll.FirstPeriodEndDt;
                    PayrollPeriodstr = dt.ToString("MM/dd/yyyy");
                    //Payroll.
                    //oPayrollPeriod = (MstPayrollPeriod)oPayroll.MstPayrollPeriods;
                    FullName = EmpDetail.FirstName + " " + EmpDetail.MiddleName;
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

        private async Task TimeFrom()
        {
            try
            {
                if (timefrom != null && timeto != null)
                {
                    Hours = (timeto - timefrom).ToString();
                }

                //    await Task.Delay(1);
          
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        private async Task TimeTo()
        {
            try
            {
                if (timefrom != null && timeto != null)
                {
                    Hours = (timeto - timefrom).ToString();
                }

                //    await Task.Delay(1);

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
                Navigation.NavigateTo("/EmployeeOverTime", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }


        public void EditRecord(int LineNum)
        {
            try
            {
                //var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();

                //if (res != null)
                //{
                //    oModel.Id = res.Id;
                //    oModel.DoNum = res.DoNum;
                //    oModel.DocDate= res.DocDate;
                //    oModel.TrnsEmployeeTransferDetails = res.TrnsEmployeeTransferDetails;
                //    oListFilteredEmployeeTransferDetail = res.TrnsEmployeeTransferDetails;

                //    oList = oList.Where(x => x.Id != LineNum);
                //}
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private async Task DeleteFromFilter(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<MstEmployee> oListEmployeeTemp = new List<MstEmployee>();
                oListEmployeeTemp = oListFilteredEmployee.ToList();
                if (oListFilteredEmployee.Count() > 0)
                {
                    var FilterRecord = oListFilteredEmployee.Where(x => x.Id == ID).FirstOrDefault();
                    oListEmployeeTemp.Remove(FilterRecord);
                    oListFilteredEmployee = oListEmployeeTemp;
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
                //if (oListFilteredEmployeeTransferDetail.Count() > 0)
                //{
                //    oDetailListadd.Clear();
                //    oModel.DocDate = docdate;
                //    foreach (var item in oListFilteredEmployeeTransferDetail)
                //    {
                //        oModel.TrnsEmployeeTransferDetails = oListFilteredEmployeeTransferDetail.ToList();
                //            //oDetailList.ToList();                        
                //        if (oModel.Id == 0)
                //        {
                //            item.CreatedBy = LoginUser;
                //            item.CreateDate = DateTime.Now.Date;
                //            oDetailListadd.Add(item);
                //            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();

                //        }
                //        else
                //        {
                //            item.UpdatedBy = LoginUser;
                //            item.UpdateDate = DateTime.Now.Date;
                //            oDetailListadd.Add(item);
                //            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();
                //        }


                //    }
                //    if (oModel.Id == 0)
                //    {
                //        oModel.CreatedBy = LoginUser;
                //        res = await _trnsEmployeeTransfer.Insert(oModel);
                //    }
                //    else
                //    {
                //        oModel.UpdatedBy = LoginUser;
                //        res = await _trnsEmployeeTransfer.Update(oModel);
                //    }

                //    if (res != null && res.Id == 1)
                //    {
                //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //        await Task.Delay(3000);
                //        Navigation.NavigateTo("/EmployeeIncreament", forceLoad: true);
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //}
                //else
                //{
                //    Snackbar.Add("No Employee selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
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
                   // _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);

                    await GetAllEmployees();
                    await GetAllEmployeesPayroll();
                    await GetAllOvertime();
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

