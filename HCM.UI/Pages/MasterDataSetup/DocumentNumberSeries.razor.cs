﻿using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class DocumentNumberSeries
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstForm _mstForm { get; set; }

        [Inject]
        public IMstDocumentNumberSeries _mstDocumentNumberSeries { get; set; }

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }


        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledCode = false;
        private string searchString1 = "";
        private string LoginUser = "";
        private bool FilterFunc(MstDocumentNumberSeries element) => FilterFunc(element, searchString1);

        MstDocumentNumberSeries oModel = new MstDocumentNumberSeries();
        private IEnumerable<MstDocumentNumberSeries> oList = new List<MstDocumentNumberSeries>();

        MstForm oModelForm = new MstForm();
        private IEnumerable<MstForm> oListForm = new List<MstForm>();

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModelForm.FormName) && !string.IsNullOrWhiteSpace(oModel.Prefix) && oModel.StartNo > 0)
                {
                    if (oList.Where(x => x.Prefix.Trim().ToLowerInvariant() == oModel.Prefix.Trim().ToLowerInvariant()).Count() > 0)
                    {
                        Snackbar.Add(oModel.Prefix + " : prefix already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.FkformCode = oModelForm.FormCode;
                        oModel.FormName = oModelForm.FormName;
                        if (oModel.Id == 0)
                        {
                            oModel.CreatedBy = LoginUser;
                            res = await _mstDocumentNumberSeries.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstDocumentNumberSeries.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/DocumentNumberSeries", forceLoad: true);
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
                Navigation.NavigateTo("/DocumentNumberSeries", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllDocumentNumberSeriess()
        {
            try
            {
                oList = await _mstDocumentNumberSeries.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllForms()
        {
            try
            {
                oListForm = await _mstForm.GetAllData();
                oListForm = oListForm.Where(x => x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<IEnumerable<MstForm>> SearchForm(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListForm.Select(o => new MstForm
                    {
                        FormCode = o.FormCode,
                        FormName = o.FormName,
                    }).ToList();
                var res = oListForm.Where(x => x.FormName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstForm
                {
                    FormCode = x.FormCode,
                    FormName = x.FormName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private bool FilterFunc(MstDocumentNumberSeries element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.FormName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Prefix.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.StartNo.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
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
                    oModel = new MstDocumentNumberSeries();
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
                    //oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    //DisbaledCode = true;
                    //oModel.Description = res.Description;
                    //oModel.FlgActive = res.FlgActive;
                    oModel = res;
                    oModelForm.FormCode = (int)oModel.FkformCode;
                    oModelForm.FormName = oModel.FormName;
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

                    var res = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res.Where(x => x.CMenuID == 4 && x.UserRights == true).ToList().Count > 0)
                    {
                        //var res = await _administrationService.FetchUserAuth(Session.UserCode);
                        Loading = true;
                        oModel.FlgActive = true;
                        await GetAllForms();
                        await GetAllDocumentNumberSeriess();
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
