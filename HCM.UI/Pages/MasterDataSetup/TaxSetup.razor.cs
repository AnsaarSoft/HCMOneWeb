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


        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstTaxSetupDetail element) => FilterFunc(element, searchString1);

        MstTaxSetup oModel = new MstTaxSetup();
        MstTaxSetupDetail oDetail = new MstTaxSetupDetail();
        List<MstCalendar> oCalendarList = new List<MstCalendar>();
        List<MstTaxSetupDetail> oDetailList = new List<MstTaxSetupDetail>();
        private IEnumerable<MstTaxSetup> oList = new List<MstTaxSetup>();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };
        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                Settings.DialogFor = "TaxSetup";
                var dialog = Dialog.Show<DialogBox>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    oDetailList.Clear();
                    DisabledCode = true;
                    var res = (MstTaxSetup)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oModel = res;
                    foreach (var item in oModel.MstTaxSetupDetails)
                    {
                        MstTaxSetupDetail vm = new MstTaxSetupDetail();
                        vm.Id = item.Id;
                        vm.Fkid = item.Fkid;
                        vm.TaxCode = item.TaxCode;
                        vm.MinAmount = item.MinAmount;
                        vm.MaxAmount = item.MaxAmount;
                        vm.TaxValue = item.TaxValue;
                        vm.FixTerm = item.FixTerm;
                        vm.Description = item.Description;
                        vm.FlgActive = item.FlgActive;
                        vm.AdditionalDisc = item.AdditionalDisc;
                        
                        oDetailList.Add(vm);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenEditDialog(DialogOptions options, MstTaxSetupDetail oDetail)
        {
            try
            {
                Settings.DialogFor = "TaxSetup";
               
                    var parameters = new DialogParameters { ["oDetailParaTax"] = oDetail };
                    var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                    var result = await dialog.Result;

                    if (!result.Cancelled)
                    {
                        var res = (MstTaxSetupDetail)result.Data;
                        AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oDetailList.ElementAt(oDetail.Id).TaxCode = res.TaxCode;
                    oDetailList.ElementAt(oDetail.Id).MinAmount = res.MinAmount;
                    oDetailList.ElementAt(oDetail.Id).MaxAmount = res.MaxAmount;
                    oDetailList.ElementAt(oDetail.Id).TaxValue = res.TaxValue;
                    oDetailList.ElementAt(oDetail.Id).FixTerm = res.FixTerm;
                    oDetailList.ElementAt(oDetail.Id).Description = res.Description;
                    oDetailList.ElementAt(oDetail.Id).FlgActive = res.FlgActive;
                    oDetailList.ElementAt(oDetail.Id).AdditionalDisc = res.AdditionalDisc;
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
                Settings.DialogFor = "TaxSetup";
                var dialog = Dialog.Show<ProcessDialog>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    //DisabledCode = true;
                    var res = (MstTaxSetupDetail)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oDetailList.Add(res);
                }
                //var parameters = new DialogParameters { ["oDetailListPara"] = oDetailListDG };
                //var dialog = Dialog.Show<ProcessDialog>("", parameters, options);

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
                    
                        oModel.MstTaxSetupDetails = new List<MstTaxSetupDetail>();
                        foreach (var item in oDetailList)
                        {
                            oDetail = new MstTaxSetupDetail();
                            oDetail.Id = item.Id;
                            oDetail.Fkid = item.Fkid;
                            oDetail.TaxCode = item.TaxCode;
                            oDetail.MinAmount = item.MinAmount;
                            oDetail.MaxAmount = item.MaxAmount;
                            oDetail.TaxValue = item.TaxValue;
                            oDetail.FixTerm = item.FixTerm;
                            oDetail.Description = item.Description;
                            oDetail.FlgActive = item.FlgActive;
                            oDetail.AdditionalDisc = item.AdditionalDisc;
                            oModel.MstTaxSetupDetails.Add(oDetail);
                        }
                        if (oModel.Id == 0)
                        {
                            if (oList.Where(x => x.MstTaxSetupDetails == oModel.MstTaxSetupDetails).Count() > 0)
                            {
                                Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                            else
                            {
                                res = await _mstTaxSetup.Insert(oModel);
                            }
                        }
                        else
                        {
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
                    oDetail.FlgActive = true;
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

        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

                    oModel.Id = res.Id;
                    oModel.SalaryYear = res.SalaryYear;
                    DisabledCode = true;
                    oModel.MinTaxSalaryF = res.MinTaxSalaryF;
                    oModel.SeniorCitizonAge = res.SeniorCitizonAge;
                    oModel.MaxSalaryDisc = res.MaxSalaryDisc;
                    oModel.DiscountOnTotalTax = res.DiscountOnTotalTax;
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
                oModel.MinTaxSalaryF = 0;

                oModel.DiscountOnTotalTax = 0;
                oModel.MaxSalaryDisc = 0;
                oModel.SeniorCitizonAge = 0;
                await GetAllCalendar();
                //await GetAllTaxSetup();
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
