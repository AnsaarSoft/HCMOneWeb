﻿using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Blazored.LocalStorage;
using HCM.UI.Interfaces.Authorization;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Bonus
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstBonus _mstBonus { get; set; }

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        public IMask AlphaNumericMask2 = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstBonu element) => FilterFunc(element, searchString1);

        MstBonu oModel = new MstBonu();
        List<MstLove> oLoveList = new List<MstLove>();
        List<MstElement> oElementList = new List<MstElement>();
        private IEnumerable<MstBonu> oList = new List<MstBonu>();
        #endregion

        #region Functions        

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Code) && (oModel.DocNo > 0))
                {
                    if (oModel.Id == 0)
                    {
                        if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                        {
                            Snackbar.Add(oModel.Code + " is already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                        else
                        {
                            oModel.UserId = LoginUser;
                            res = await _mstBonus.Insert(oModel);
                        }
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _mstBonus.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Bonus", forceLoad: true);
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

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/Bonus", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(MstBonu element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DocCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllBonus()
        {
            try
            {
                oList = await _mstBonus.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLove()
        {
            try
            {
                oLoveList = await _mstLove.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllElement()
        {
            try
            {
                oElementList = await _mstElement.GetAllData();
                oElementList = oElementList.Where(x => x.FlgActive == true && x.FlgEmployeeBonus == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private Task SetDocNo()
        {
            try
            {
                oModel.DocNo = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }

        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    AlphaNumericMask2 = new RegexMask(@"^[a-zA-Z0-9_]*$");

                    oModel.Id = res.Id;
                    oModel.DocNo = res.DocNo;
                    oModel.Code = res.Code;
                    DisabledCode = true;
                    oModel.DocCode = res.DocCode;
                    oModel.ValueType = res.ValueType;
                    oModel.SalaryFrom = res.SalaryFrom;
                    oModel.SalaryTo = res.SalaryTo;
                    oModel.ScaleFrom = res.ScaleFrom;
                    oModel.ScaleTo = res.ScaleTo;
                    oModel.BonusPercentage = res.BonusPercentage;
                    oModel.MinimumMonthsDuration = res.MinimumMonthsDuration;
                    oModel.ElementType = res.ElementType;
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

                    var res = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res.Where(x => x.CMenuID == 22 && x.UserRights == true).ToList().Count > 0)
                    {
                        await GetAllBonus();
                        await SetDocNo();
                        await GetAllLove();
                        //await GetAllElement();
                        oModel.FlgActive = true;
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
