using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Holiday
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstHoliday _mstHoliday { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledCode = false;
        private string searchString1 = "";
        private string LoginUser = "";
        private bool FilterFunc(MstHolidayDetail element) => FilterFunc(element, searchString1);

        MstHoliday1 oModel = new MstHoliday1();
        private IEnumerable<MstHoliday1> oList = new List<MstHoliday1>();

        private IEnumerable<MstHolidayDetail> oListMstHolidayDetail = new List<MstHolidayDetail>();
        List<MstHolidayDetail> oListMstHolidayDtl = new List<MstHolidayDetail>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion

        #region Functions
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "Holiday");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstHoliday1)result.Data;
                    oModel = res;
                    oListMstHolidayDetail = res.MstHolidayDetails;
                    foreach (var item in oListMstHolidayDetail)
                    {
                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = LoginUser;
                    }
                    DisbaledCode = true;
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
                parameters.Add("DialogFor", "HolidayDetail");
                // parameters.Add("EmpId", oModel.EmployeeId);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstHolidayDetail)result.Data;
                    res.FlgActive = true;
                    oListMstHolidayDtl.Add(res);
                    oListMstHolidayDetail = oListMstHolidayDtl;
                    if (oModel.Id ==0)
                    {
                        foreach (var item in oListMstHolidayDetail)
                        {
                            item.CreateDate = DateTime.Now;
                            item.UserId= LoginUser;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialog(DialogOptions options, MstHolidayDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaMstHolidayDetail", oDetailPara);
                parameters.Add("DialogFor", "HolidayDetail");
                // parameters.Add("EmpId", oModel.EmployeeId);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (MstHolidayDetail)result.Data;
                    var update = oListMstHolidayDetail.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oListMstHolidayDtl.Remove(update);
                    }
                    if (oModel.Id != 0)
                    {
                        res.UpdateDate = DateTime.Now;
                        res.UpdatedBy = LoginUser;
                    }
                    else
                    {
                        res.CreateDate = DateTime.Now;
                        res.UserId = LoginUser;

                    }

                    oListMstHolidayDtl.Add(res);
                    oListMstHolidayDetail = oListMstHolidayDtl;
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
                // List<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOTDtl = new List<TrnsEmployeeOvertimeDetail>();
                //  oListTrnsEmployeeOTDtl = oListTrnsEmployeeOvertimeDetail.ToList();
                oListMstHolidayDtl = oListMstHolidayDetail.ToList();
                if (oListMstHolidayDetail.Count() > 0)
                {
                    var FilterRecord = oListMstHolidayDetail.Where(x => x.Id == ID).FirstOrDefault();
                    oListMstHolidayDtl.Remove(FilterRecord);
                    oListMstHolidayDetail = oListMstHolidayDtl;
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
                oModel.MstHolidayDetails = oListMstHolidayDetail.ToList();
                if (!string.IsNullOrWhiteSpace(oModel.Holiday) && !string.IsNullOrWhiteSpace(oModel.HolidayName) && oListMstHolidayDetail.Count() > 0)
                {
                    //if (oList.Where(x => x.Holiday.Trim().ToLowerInvariant() == oModel.Holiday.Trim().ToLowerInvariant()).Count() > 0)
                    //{
                    //    Snackbar.Add(oModel.Holiday + " : is Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //}
                    //else
                    //{
                        if (oModel.Id == 0)
                        {
                            oModel.UserId = LoginUser;
                            res = await _mstHoliday.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstHoliday.Update(oModel);
                        }
                   // }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Holiday", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel.FlgActive = true;
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s) Or add Detail", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/Holiday", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task GetAllHoliday()
        {
            try
            {
                oList = await _mstHoliday.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFunc(MstHolidayDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Remarks.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element..Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }
        public void RemoveRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id != LineNum);
                oList = res;
                if (oList.Count() == 0)
                {
                    oModel = new MstHoliday1();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    oModel.Id = res.Id;
                    oModel.Holiday = res.Holiday;
                    oModel.HolidayName = res.HolidayName;
                    oModel.FlgActive = res.FlgActive;
                    if (oModel.Id != 0)
                    {
                        oModel.CreateDate = res.CreateDate;
                        oModel.UserId = res.UserId;
                    }
                    DisbaledCode = true;
                    oList = oList.Where(x => x.Id != LineNum);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    //var res = await _administrationService.FetchUserAuth(Session.UserCode);
                    Loading = true;
                    oModel.FlgActive = true;
                    await GetAllHoliday();
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion
    }
}
