﻿using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class LeaveCalendar
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLeaveCalendar _mstLeaveCalendar { get; set; }
        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }


        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledDate = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string searchString1 = "";
        private bool FilterFunc(MstLeaveCalendar element) => FilterFunc(element, searchString1);

        MstLeaveCalendar oModel = new MstLeaveCalendar();
        private IEnumerable<MstLeaveCalendar> oList = new List<MstLeaveCalendar>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description))
                {
                    if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.StartDate = _dateRange.Start;
                        oModel.EndDate = _dateRange.End;
                        if (oModel.Code.Length > 20)
                        {
                            Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                        else
                        {
                            var MonthDifference = DateTimeSpan.GetMonthDifference((DateTime)oModel.StartDate, (DateTime)oModel.EndDate);
                            if (MonthDifference < 12)
                            {
                                Snackbar.Add("Invalid Date Selection, must be within 12 months range", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                            else
                            {

                                if (oModel.Id == 0)
                                {
                                    oModel.UserId = LoginUser;
                                    res = await _mstLeaveCalendar.Insert(oModel);
                                }
                                else
                                {
                                    oModel.UpdatedBy = LoginUser;
                                    res = await _mstLeaveCalendar.Update(oModel);
                                }
                            }
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/LeaveCalendar", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel.FlgActive = true;
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

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/LeaveCalendar", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllLeaveCalendars()
        {
            try
            {
                oList = await _mstLeaveCalendar.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstLeaveCalendar element, string searchString1)
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

        public void RemoveRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id != LineNum);
                oList = res;
                if (oList.Count() == 0)
                {
                    oModel = new MstLeaveCalendar();
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
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    DisabledDate = true;
                    oModel.Id = res.Id;
                    oModel.Code = res.Code;
                    DisabledCode = true;
                    oModel.Description = res.Description;
                    oModel.StartDate = _dateRange.Start = res.StartDate;
                    oModel.EndDate = _dateRange.End = res.EndDate;
                    _dateRange = new DateRange(oModel.StartDate, oModel.EndDate);
                    oModel.FlgActive = res.FlgActive;
                    oList = oList.Where(x => x.Id != LineNum);
                    //_ = InvokeAsync(StateHasChanged);
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
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;

                    var res1 = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res1.Where(x => x.CMenuID == 30 && x.UserRights == true).ToList().Count > 0)
                    {
                        oModel.FlgActive = true;
                        await GetAllLeaveCalendars();
                        if (oList.Where(x => x.FlgActive == true).Count() > 0)
                        {
                            DisabledDate = true;
                            var res = oList.Where(x => x.FlgActive == true).Max(x => x.EndDate);
                            Convert.ToDateTime(res).AddDays(1);
                            _dateRange = new DateRange(Convert.ToDateTime(res.Value).AddDays(1), Convert.ToDateTime(res).AddMonths(12));
                            _dateRange.Start = MinDate = Convert.ToDateTime(res).AddDays(1);
                        }
                        else
                        {
                            //MinDate = DateTime.Now.Date;
                            _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date.AddMonths(12));
                        }
                    }
                    else
                    {
                        Navigation.NavigateTo("/Dashboard", forceLoad: true);
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

        #endregion
    }
}
