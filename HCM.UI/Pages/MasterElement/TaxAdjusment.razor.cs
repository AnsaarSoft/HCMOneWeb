﻿using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
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
    public partial class TaxAdjusment
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
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public ITrnsEmployeeOverTime _TrnsEmployeeOverTime { get; set; }

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

        MstOverTime oModelmstOvertime = new MstOverTime();
        private IEnumerable<MstOverTime> oListmstOverTime = new List<MstOverTime>();

        TrnsEmployeeOvertime oModel = new TrnsEmployeeOvertime();
        private IEnumerable<TrnsEmployeeOvertime> oList = new List<TrnsEmployeeOvertime>();

        TrnsEmployeeOvertimeDetail oModelTrnsEmployeeOvertimeDetail = new TrnsEmployeeOvertimeDetail();
        private IEnumerable<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOvertimeDetail = new List<TrnsEmployeeOvertimeDetail>();
        private List<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOtDetail = new List<TrnsEmployeeOvertimeDetail>();

        CfgPayrollDefination oPayroll = new CfgPayrollDefination();
        private List<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

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
                    oModel.EmployeeId = oModelMstEmployee.Id;
                    
                    EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;
                    var EmpDetail = oListEmployee.Where(x => x.EmpId == oModelMstEmployee.EmpId).FirstOrDefault();
                    oPayroll = oListPayroll.Where(x => x.Id == EmpDetail.PayrollId).FirstOrDefault();
                    CfgPeriodDate mstPayrollPeriod = new CfgPeriodDate();
                    oListPayrollPeriod = oPayroll.CfgPeriodDates.Where(x => x.PayrollId == oPayroll.Id).ToList();
                   
                   // FullName = EmpDetail.FirstName + " " + EmpDetail.MiddleName + " " + EmpDetail.LastName;
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
                parameters.Add("DialogFor", "TrnsEmployeeOverTime");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsEmployeeOvertime)result.Data;
                    oModel = res;
                    oModelMstEmployee = oListEmployee.Where(x => x.Id == oModel.EmployeeId).FirstOrDefault();
                    FullName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName+ " " + oModelMstEmployee.LastName;

                    oListTrnsEmployeeOvertimeDetail = oModel.TrnsEmployeeOvertimeDetails.ToList();
                    oModelTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOvertimeDetail.Where(x => x.EmpOvertimeId == oModel.Id).FirstOrDefault();


                   // oModelmstOvertime = oListmstOverTime.Where(x=>x.Id== oModelTrnsEmployeeOvertimeDetail.OvertimeId).FirstOrDefault();                   
                   //// oModelmstOvertime.Id = (int)oModelTrnsEmployeeOvertimeDetail.OvertimeId;
                   // docdate = oModelTrnsEmployeeOvertimeDetail.Otdate;
                   // timefrom = TimeSpan.Parse(oModelTrnsEmployeeOvertimeDetail.FromTime);
                   // timeto = TimeSpan.Parse(oModelTrnsEmployeeOvertimeDetail.ToTime);
                   // Hours = Convert.ToDecimal(oModelTrnsEmployeeOvertimeDetail.Othours);
                   // Amount = Convert.ToDecimal(oModelTrnsEmployeeOvertimeDetail.Amount);
                }
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
        private async Task GetAllOvertime()
        {
            try
            {
                oListmstOverTime = await _mstOverTime.GetAllData();
                oListmstOverTime = oListmstOverTime.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmployeeOvertime()
        {
            try
            {
                oList = await _TrnsEmployeeOverTime.GetAllData();
                oList = oList.ToList();
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
                //oListPayrollPeriod = oListPayroll.Select(x=>x.CfgPeriodDates).ToList();
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
                        Description = o.Description,
                    }).ToList();
                var res = oListmstOverTime.Where(x => x.Code.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstOverTime
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
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
        private async Task CalHour()
        {
            try
            {
                await Task.Delay(1);
                if ((timefrom != null && timeto != null))
                {

                    string totalhour = (timeto - timefrom).ToString();
                    Hours = Convert.ToDecimal(TimeSpan.Parse(totalhour).TotalHours);
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
                // var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
               // IEnumerable<TrnsEmployeeOvertimeDetail> listot = oListTrnsEmployeeOvertimeDetail.ToList();
                var res = oListTrnsEmployeeOvertimeDetail.Where(x => x.Id == LineNum).FirstOrDefault();
                oListTrnsEmployeeOtDetail = oListTrnsEmployeeOvertimeDetail.ToList();
                if (res != null)
                {
                    oModel.Id = (int)res.EmpOvertimeId;
                    oModelmstOvertime = oListmstOverTime.Where(x => x.Id == res.OvertimeId).FirstOrDefault();
                   
                    docdate = res.Otdate;
                    timefrom= TimeSpan.Parse(res.FromTime);
                    timeto= TimeSpan.Parse(res.ToTime);
                    Hours = (decimal)res.Othours;
                    IsFlg = (bool)res.FlgActive;
                    
                    var filterRecord =oListTrnsEmployeeOvertimeDetail.Where(x => x.Id == res.Id).FirstOrDefault();
                    oListTrnsEmployeeOtDetail.Remove(filterRecord);
                    oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOtDetail;
                    //var FilterRecord = oListTrnsEmployeeOvertimeDetail.Where(x => x.Id == res.Id).FirstOrDefault();
                    //oListTrnsEmployeeOTDtl.Remove(FilterRecord);
                    //oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOTDtl;
                    oList = oList.Where(x => x.Id != LineNum);
                }
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
                List<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOTDtl = new List<TrnsEmployeeOvertimeDetail>();
                oListTrnsEmployeeOTDtl = oListTrnsEmployeeOvertimeDetail.ToList();
                if (oListTrnsEmployeeOvertimeDetail.Count() > 0)
                {
                    var FilterRecord = oListTrnsEmployeeOvertimeDetail.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsEmployeeOTDtl.Remove(FilterRecord);
                    oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOTDtl;
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

               
                if (oListTrnsEmployeeOvertimeDetail.Count() > 0)
                {
                    oModel.EmployeeId = oModelMstEmployee.Id;

                    oListTrnsEmployeeOtDetail.Clear();
                    foreach (var item in oListTrnsEmployeeOvertimeDetail)
                    {
                        
                        //oModel.TrnsEmployeeOvertimeDetails = oListTrnsEmployeeOvertimeDetail.ToList();
                        //oDetailList.ToList();                        
                        if (oModel.Id == 0)
                        {
                            item.UserId = LoginUser;
                            item.CreateDate = DateTime.Now.Date;
                            oListTrnsEmployeeOtDetail.Add(item);
                            oModel.TrnsEmployeeOvertimeDetails =  oListTrnsEmployeeOtDetail.ToList();

                        }
                        else
                        {
                            item.UpdatedBy = LoginUser;
                            item.UpdateDate = DateTime.Now.Date;
                            oListTrnsEmployeeOtDetail.Add(item);
                            oModel.TrnsEmployeeOvertimeDetails = oListTrnsEmployeeOtDetail.ToList();
                        }


                    }


                    //if (oModel.Id == 0)
                    //{
                    //    oModelTrnsEmployeeOvertimeDetail.CreateDate = DateTime.Now;
                    //    oModelTrnsEmployeeOvertimeDetail.UserId = LoginUser;
                    //}
                    //else
                    //{
                    //    oModelTrnsEmployeeOvertimeDetail.UpdateDate = DateTime.Now;
                    //    oModelTrnsEmployeeOvertimeDetail.UpdatedBy = LoginUser;
                    //}
                    //oModel.TrnsEmployeeOvertimeDetails.Add(oModelTrnsEmployeeOvertimeDetail);

                    //if (oModel.TrnsEmployeeOvertimeDetails.Count() > 0)
                    //{
                        if (oModel.Id == 0)
                        {
                            oModel.UserId = LoginUser;
                            res = await _TrnsEmployeeOverTime.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _TrnsEmployeeOverTime.Update(oModel);
                        }

                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(3000);
                            Navigation.NavigateTo("/EmployeeOverTime", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                    //}
                    //else
                    //{
                    //    Snackbar.Add("No Record Found .", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //}

                }

                else
                {
                    Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> AddList()
        {
            try
            {

                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);


              //  oModel.EmployeeId = oModelMstEmployee.Id;
              TrnsEmployeeOvertimeDetail trnsEmployeeOvertimeDetail = new TrnsEmployeeOvertimeDetail();
                trnsEmployeeOvertimeDetail.OvertimeId = oModelmstOvertime.Id;
                trnsEmployeeOvertimeDetail.EmpOvertimeId = oModel.Id;
                trnsEmployeeOvertimeDetail.Otdate = docdate;
                trnsEmployeeOvertimeDetail.FromTime = timefrom.ToString();
                trnsEmployeeOvertimeDetail.ToTime = timeto.ToString();
                trnsEmployeeOvertimeDetail.Othours = Hours;
                trnsEmployeeOvertimeDetail.FlgActive=IsFlg;
                oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModelmstOvertime.Id).FirstOrDefault();
                oModelTrnsEmployeeOvertimeDetail.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Hours);

                if (!string.IsNullOrWhiteSpace(oModel.PeriodName)
                    && (trnsEmployeeOvertimeDetail.OvertimeId != null && trnsEmployeeOvertimeDetail.OvertimeId > 0)
                    && (trnsEmployeeOvertimeDetail.Otdate != null)
                    && (trnsEmployeeOvertimeDetail.Othours != null && trnsEmployeeOvertimeDetail.Othours > 0)
                    && (trnsEmployeeOvertimeDetail.Amount != null && trnsEmployeeOvertimeDetail.Amount > 0)
                    && (trnsEmployeeOvertimeDetail.FlgActive != null && trnsEmployeeOvertimeDetail.FlgActive != false))
                {
                    
                    oListTrnsEmployeeOtDetail.Add(trnsEmployeeOvertimeDetail);
                    oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOtDetail.ToList();
                    docdate =DateTime.Now;
                    timefrom= new TimeSpan(0, 0, 0); 
                    timeto = new TimeSpan(0,0,0);
                    Hours = 0;
                    Amount = 0;
                    IsFlg = false;
                    //oModelTrnsEmployeeOvertimeDetail = null;
                }

                else
                {
                    Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    await GetAllEmployeesPayroll();
                    await GetAllOvertime();
                    await GetAllEmployeeOvertime();
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

