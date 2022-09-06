using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class TaxSetup
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstTaxSetup _mstTaxSetup { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;        

        private string searchString1 = "";
        private bool FilterFunc(MstTaxSetupDetail element) => FilterFunc(element, searchString1);

        MstTaxSetup oModel = new MstTaxSetup();
        List<MstCalendar> oCalendarList = new List<MstCalendar>();

        private IEnumerable<MstTaxSetupDetail> oDetailList = new List<MstTaxSetupDetail>();
        List<MstTaxSetupDetail> oDetail = new List<MstTaxSetupDetail>();
        private IEnumerable<MstTaxSetup> oList = new List<MstTaxSetup>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };
        
        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TaxSetup");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstTaxSetup)result.Data;
                    oModel = res;
                    oDetailList = oModel.MstTaxSetupDetails;
                    oDetail = oDetailList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenEditDialog(DialogOptions options, MstTaxSetupDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaTax", oDetailPara);
                parameters.Add("DialogFor", "TaxSetup");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (MstTaxSetupDetail)result.Data;                    
                    var update = oDetailList.Where(x => x.TaxCode == res.TaxCode).FirstOrDefault();
                    if (update != null)
                    {
                        oDetail.Remove(update);
                    }
                    MstTaxSetupDetail oTaxDetail = new MstTaxSetupDetail();
                    oTaxDetail.Id = res.Id;
                    oTaxDetail.Fkid = res.Fkid;
                    oTaxDetail.TaxCode = res.TaxCode;
                    oTaxDetail.MinAmount = res.MinAmount;
                    oTaxDetail.MaxAmount = res.MaxAmount;
                    oTaxDetail.TaxValue = res.TaxValue;
                    oTaxDetail.FixTerm = res.FixTerm;
                    oTaxDetail.Description = res.Description;
                    oTaxDetail.FlgActive = res.FlgActive;
                    oTaxDetail.AdditionalDisc = res.AdditionalDisc;
                    oDetail.Add(oTaxDetail);
                    oDetailList = oDetail.ToList();
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
                parameters.Add("DialogFor", "TaxSetup");
                var dialog = Dialog.Show<ProcessDialog>("", parameters,options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstTaxSetupDetail)result.Data;
                    if (oDetailList.Where(x => x.TaxCode == res.TaxCode).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {                        
                        oDetail.Add(res);
                        oDetailList = oDetail;
                    }
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
                if ((oModel.SalaryYear != null) && (oModel.MinTaxSalaryF != null) && (oModel.SeniorCitizonAge != null) && (oModel.MaxSalaryDisc != null) && (oModel.DiscountOnTotalTax != null))
                {

                    oModel.MstTaxSetupDetails = oDetailList.ToList();
                    if (oModel.Id == 0)
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _mstTaxSetup.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _mstTaxSetup.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/TaxSetup", forceLoad: true);
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
                Navigation.NavigateTo("/TaxSetup", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(MstTaxSetupDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.TaxCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllCalendar()
        {
            try
            {
                oCalendarList = await _mstCalendar.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        public void RemoveRecord(string TaxCode)
        {
            try
            {
                oDetailList = oDetailList.Where(x => x.TaxCode != TaxCode).ToList();
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    oModel.MinTaxSalaryF = 0;

                    oModel.DiscountOnTotalTax = 0;
                    oModel.MaxSalaryDisc = 0;
                    oModel.SeniorCitizonAge = 0;
                    await GetAllCalendar();
                    //await GetAllTaxSetup();
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
