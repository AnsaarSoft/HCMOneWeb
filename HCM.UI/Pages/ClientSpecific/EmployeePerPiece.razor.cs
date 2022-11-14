using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ClientSpecific;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;

namespace HCM.UI.Pages.ClientSpecific
{
    public partial class EmployeePerPiece
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
        public ITrnsPerPiece _trnsPerPiece { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledCode = false;
        private string searchString1 = "";
        private string LoginUser = "";
        private bool FilterFunc(TrnsPerPieceTransactionDetail element) => FilterFunc(element, searchString1);

        MstHoliday1 oModel1 = new MstHoliday1();
        private IEnumerable<MstHoliday1> oList1 = new List<MstHoliday1>();

        private IEnumerable<MstHolidayDetail> oList1MstHolidayDetail = new List<MstHolidayDetail>();
        List<MstHolidayDetail> oList1MstHolidayDtl = new List<MstHolidayDetail>();

        TrnsPerPieceTransaction oModel = new TrnsPerPieceTransaction();
        private IEnumerable<TrnsPerPieceTransaction> oList = new List<TrnsPerPieceTransaction>();

        private IEnumerable<TrnsPerPieceTransactionDetail> oListTrnsPerPieceDetail = new List<TrnsPerPieceTransactionDetail>();
        List<TrnsPerPieceTransactionDetail> oListTrnsPerPieceDtl = new List<TrnsPerPieceTransactionDetail>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion

        #region Functions
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsPerPiece");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsPerPieceTransaction)result.Data;
                    oModel = res;
                    oListTrnsPerPieceDetail = res.TrnsPerPieceTransactionDetails;
                    foreach (var item in oListTrnsPerPieceDetail)
                    {
                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = LoginUser;
                    }
                    oListTrnsPerPieceDtl = oListTrnsPerPieceDetail.ToList();
                    //DisbaledCode = true;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogProductStage(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsProductStage");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStage)result.Data;
                    oModel.Psid = res.Id;
                    oModel.Pscode = res.Code;
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
                parameters.Add("DialogFor", "PerPieceTransaction");
                parameters.Add("ProductStageId", oModel.Psid);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsPerPieceTransactionDetail)result.Data;

                    //if (oModel.Id == 0)
                    //{
                        res.UserId = LoginUser;
                        res.CreateDate = DateTime.Now;
                    //}
                    //else
                    //{
                    //    res.UpdatedBy = LoginUser;
                    //    res.UpdateDate = DateTime.Now;
                    //}

                    oListTrnsPerPieceDtl.Add(res);
                    oListTrnsPerPieceDetail = oListTrnsPerPieceDtl;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialog(DialogOptions options, TrnsPerPieceTransactionDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaTrnsPerPieceDetail", oDetailPara);
                parameters.Add("DialogFor", "PerPieceTransaction");
                parameters.Add("ProductStageId", oModel.Psid);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (TrnsPerPieceTransactionDetail)result.Data;
                    var update = oListTrnsPerPieceDetail.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oListTrnsPerPieceDtl.Remove(update);
                    }
                    if (oModel.Id != 0)
                    {
                        res.UpdateDate = DateTime.Now;
                        res.UpdatedBy = LoginUser;
                    }
                    //else
                    //{
                    //    res.CreateDate = DateTime.Now;
                    //    res.UserId = LoginUser;

                    //}

                    oListTrnsPerPieceDtl.Add(res);
                    oListTrnsPerPieceDetail = oListTrnsPerPieceDtl;
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

                oListTrnsPerPieceDtl = oListTrnsPerPieceDetail.ToList();
                if (oListTrnsPerPieceDetail.Count() > 0)
                {
                    var FilterRecord = oListTrnsPerPieceDetail.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsPerPieceDtl.Remove(FilterRecord);
                    oListTrnsPerPieceDetail = oListTrnsPerPieceDtl;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task<ApiResponseModel> Post()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                if (oModel.Id != 0)
                {
                    oModel.DocStatus = "Posted";
                    oModel.ProductionDate = DateTime.Now;
                    oModel.UpdatedBy = LoginUser;
                    res = await _trnsPerPiece.Update(oModel);
                }
                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/EmployeePerPiece", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Pscode) && oListTrnsPerPieceDetail.Count() > 0)
                {
                    oModel.TrnsPerPieceTransactionDetails = oListTrnsPerPieceDetail.ToList();
                    //if (oList1.Where(x => x.Holiday.Trim().ToLowerInvariant() == oModel1.Holiday.Trim().ToLowerInvariant()).Count() > 0)
                    //{
                    //    Snackbar.Add(oModel1.Holiday + " : is Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //}
                    //else
                    //{
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsPerPiece.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsPerPiece.Update(oModel);
                    }
                    // }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/EmployeePerPiece", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel1.FlgActive = true;
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
                Navigation.NavigateTo("/EmployeePerPiece", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task GetAllTransPerPiece()
        {
            try
            {
                oList = await _trnsPerPiece.GetAllData();
                oList = oList.ToList();
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
                oModel.DocNum = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private bool FilterFunc(TrnsPerPieceTransactionDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DepartmentName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.SubItemName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.StattionName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
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
                    Loading = true;
                    oModel.DocStatus = "Draft";
                    oModel.DocDate = DateTime.Now;
                    await GetAllTransPerPiece();
                    await SetDocNo();
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
