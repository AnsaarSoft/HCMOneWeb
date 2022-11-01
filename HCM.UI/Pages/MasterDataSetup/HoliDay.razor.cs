﻿using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class HoliDay
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
        private bool FilterFunc(MstHoliDay element) => FilterFunc(element, searchString1);

        MstHoliDay oModel = new MstHoliDay();
        private IEnumerable<MstHoliDay> oList = new List<MstHoliDay>();

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
                        Snackbar.Add(oModel.Code + " : is Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oModel.Id == 0)
                        {
                            oModel.CreatedBy = LoginUser;
                            res = await _mstHoliday.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstHoliday.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/HoliDay", forceLoad: true);
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
                Navigation.NavigateTo("/HoliDay", forceLoad: true);
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

        private bool FilterFunc(MstHoliDay element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
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
                    oModel = new MstHoliDay();
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
                    oModel.Code = res.Code;
                    oModel.Description = res.Description;
                    oModel.HolidayDate = res.HolidayDate;
                    oModel.FlgActive = res.FlgActive;
                    if (oModel.Id !=0)
                    {
                        oModel.CreatedDate = res.CreatedDate;
                        oModel.CreatedBy = res.CreatedBy;
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
