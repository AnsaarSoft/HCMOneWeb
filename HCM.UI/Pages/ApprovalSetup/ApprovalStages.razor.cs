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
        public IMstStages _stageService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variable

        private bool Loading = false;
        private IEnumerable<MstEmployee> AuthorizerNames { get; set; } = new HashSet<MstEmployee>();

        MstStage oModel = new MstStage();

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
                    AuthorizerNames = (ICollection<MstEmployee>)result.Data;
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
                parameters.Add("DialogFor", "LeaveRequest");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    //var res = (TrnsLeavesRequest)result.Data;
                    //oModel = res;
                    //_dateRange.Start = oModel.LeaveFrom;
                    //_dateRange.End = oModel.LeaveTo;
                    //SetEmployeeLeaves();
                    //if (!string.IsNullOrWhiteSpace(oModel.FromTime) && !string.IsNullOrWhiteSpace(oModel.ToTime))
                    //{
                    //    string[] spFromTime = oModel.FromTime.Split(':');
                    //    TimeSpan FromTime = new TimeSpan(Convert.ToInt32(spFromTime[0]), Convert.ToInt32(spFromTime[1]), 0);
                    //    TSFromTime = FromTime;

                    //    string[] spToTime = oModel.ToTime.Split(':');
                    //    TimeSpan ToTime = new TimeSpan(Convert.ToInt32(spToTime[0]), Convert.ToInt32(spToTime[1]), 0);
                    //    TSToTime = ToTime;
                    //}
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

                        if (oModel.StageName == null || oModel.NumberOfApprovals == null || oModel.NumberOfRejectins == null)
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
                            oModel.MstStageDetails.Clear();
                            foreach (var Line in AuthorizerNames)
                            {
                                MstStageDetail oLine = new MstStageDetail();
                                oLine.EmployeeId = Convert.ToInt32(Line.Id);
                                oLine.EmpId = Line.EmpId;
                                oLine.CreatedDate = DateTime.Now;
                                oModel.MstStageDetails.Add(oLine);
                            }
                        }
                        if (oModel != null && oModel.MstStageDetails != null && oModel.MstStageDetails.Count > 0)
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
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
