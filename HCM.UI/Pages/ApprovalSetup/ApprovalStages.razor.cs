using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.ApprovalSetup
{
    public partial class ApprovalStages
    {
        #region Inject Service

        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public ICfgApprovalStage _stageService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variable

        private bool Loading = false;
        private IEnumerable<MstEmployee> AuthorizerNames { get; set; } = new HashSet<MstEmployee>();

        CfgApprovalStage oModel = new CfgApprovalStage();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        private string LoginUser = "";

        #endregion

        #region Function

        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "MultipleEmployeeSelect");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    AuthorizerNames = (HashSet<MstEmployee>)result.Data;
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
                parameters.Add("DialogFor", "ApprovalStages");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (CfgApprovalStage)result.Data;
                    oModel = res;
                    List<MstEmployee> oListTemp = new List<MstEmployee>();
                    foreach (var item in oModel.CfgApprovalStageDetails)
                    {
                        MstEmployee obj = new MstEmployee();
                        obj.Id = (int)item.FkempId;
                        obj.EmpId = item.AuthorizerId;
                        oListTemp.Add(obj);
                    }
                    AuthorizerNames = oListTemp.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(Convert.ToString(oModel.Id)))
                {
                    try
                    {
                        Loading = true;
                        var res1 = new ApiResponseModel();
                        await Task.Delay(1);
                        
                        if (oModel.StageName == null || oModel.ApprovalsNo == null || oModel.RejectionsNo == null)
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (AuthorizerNames == null && AuthorizerNames.Count() == 0)
                        {
                            Snackbar.Add("Please Select Employee.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (AuthorizerNames != null && AuthorizerNames.Count() > 0)
                        {
                            oModel.CfgApprovalStageDetails.Clear();
                            foreach (var Line in AuthorizerNames)
                            {
                                CfgApprovalStageDetail oLine = new CfgApprovalStageDetail();
                                oLine.FkempId = Convert.ToInt32(Line.Id);
                                oLine.AuthorizerId = Line.EmpId;
                                oLine.CreatedDate = DateTime.Now;
                                oModel.CfgApprovalStageDetails.Add(oLine);
                            }
                        }
                        if (oModel != null && oModel.CfgApprovalStageDetails != null && oModel.CfgApprovalStageDetails.Count > 0)
                        {
                            if (oModel.Id == 0)
                            {
                                oModel.CreatedBy = LoginUser;
                                oModel.StageDescription = oModel.StageName;
                                oModel.CreatedDate = DateTime.Now;
                                oModel.FlgActive = true;
                                res1 = await _stageService.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUser;
                                oModel.StageDescription = oModel.StageName;
                                oModel.UpdatedDate = DateTime.Now;
                                oModel.FlgActive = true;
                                res1 = await _stageService.Update(oModel);
                            }
                        }
                        else
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (res1 != null && res1.Id == 1)
                        {
                            Snackbar.Add(res1.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(1000);
                            Navigation.NavigateTo("/ApprovalStages", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
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
                Navigation.NavigateTo("/ApprovalStages", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion

        #region Initialize

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
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
            }
        }

        #endregion
    }
}
