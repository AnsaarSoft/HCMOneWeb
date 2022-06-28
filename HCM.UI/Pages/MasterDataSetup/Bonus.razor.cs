using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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

        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        //private bool FilterFunc(MstBonus element) => FilterFunc(element, searchString1);

        MstBonu oModel = new MstBonu();
        
        List<VMMstBonusDetail> oDetailList = new List<VMMstBonusDetail>();
        private IEnumerable<MstBonu> oList = new List<MstBonu>();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };
        #endregion

        #region Functions

        /*private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                Settings.DialogFor = "Bonus";
                var dialog = Dialog.Show<DialogBox>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    oDetailList.Clear();
                    DisabledCode = true;
                    var res = (MstBonus)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oModel = res;
                    foreach (var item in oModel)
                    {
                        VMMstBonusDetail vm = new VMMstBonusDetail();
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
        }*/

        private async Task OpenEditDialog(DialogOptions options, VMMstBonusDetail oDetail)
        {
            try
            {
                Settings.DialogFor = "Bonus";

                var parameters = new DialogParameters { ["oDetailParaBonus"] = oDetail };
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (VMMstBonusDetail)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oDetailList.ElementAt(oDetail.Id).ValueType = res.ValueType;
                    oDetailList.ElementAt(oDetail.Id).SalaryFrom = res.SalaryFrom;
                    oDetailList.ElementAt(oDetail.Id).SalaryTo = res.SalaryTo;
                    oDetailList.ElementAt(oDetail.Id).ScaleFrom = res.ScaleFrom;
                    oDetailList.ElementAt(oDetail.Id).ScaleTo = res.ScaleTo;
                    oDetailList.ElementAt(oDetail.Id).BonusPercentage = res.BonusPercentage;
                    oDetailList.ElementAt(oDetail.Id).MinimumMonthsDuration = res.MinimumMonthsDuration;
                    oDetailList.ElementAt(oDetail.Id).ElementType = res.ElementType;
                    oDetailList.ElementAt(oDetail.Id).FlgActive = res.FlgActive;
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
                Settings.DialogFor = "Bonus";
                var dialog = Dialog.Show<ProcessDialog>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    //DisabledCode = true;
                    var res = (VMMstBonusDetail)result.Data;
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
                oModel = new MstBonu();
                
                    if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.DocCode) && (oModel.DocNo >0))
                    {
                        oModel = new MstBonu();
                        foreach (var item in oDetailList)
                        {

                            oModel.Id = item.Id;
                            oModel.DocNo = item.DocNo;
                            oModel.DocCode = item.DocCode;
                            oModel.Code = item.Code;
                            oModel.ValueType = item.ValueType;
                            oModel.SalaryFrom = item.SalaryFrom;
                            oModel.SalaryTo = item.SalaryTo;
                            oModel.ScaleFrom = item.ScaleFrom;
                            oModel.ScaleTo = item.ScaleTo;
                            oModel.BonusPercentage = item.BonusPercentage;
                            oModel.MinimumMonthsDuration = item.MinimumMonthsDuration;
                            oModel.ElementType = item.ElementType;
                            oModel.FlgActive = item.FlgActive;
                     
                    
                            if (oModel.Id == 0)
                            {
                                if (oList.Where(x => x.DocCode == oModel.DocCode).Count() > 0)
                                {
                                    Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                                }
                                else
                                {
                                    res = await _mstBonus.Insert(oModel);
                                }
                            }
                            else
                            {
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

       /* private bool FilterFunc(MstBonusDetail element, string searchString1)
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
        }*/

       

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

                    oDetailList.ElementAt(res.Id).ValueType = res.ValueType;
                    oDetailList.ElementAt(res.Id).SalaryFrom = res.SalaryFrom;
                    oDetailList.ElementAt(res.Id).SalaryTo = res.SalaryTo;
                    oDetailList.ElementAt(res.Id).ScaleFrom = res.ScaleFrom;
                    oDetailList.ElementAt(res.Id).ScaleTo = res.ScaleTo;
                    oDetailList.ElementAt(res.Id).BonusPercentage = res.BonusPercentage;
                    oDetailList.ElementAt(res.Id).MinimumMonthsDuration = res.MinimumMonthsDuration;
                    oDetailList.ElementAt(res.Id).ElementType = res.ElementType;
                    oDetailList.ElementAt(res.Id).FlgActive = res.FlgActive;
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

                await SetDocNo();
                await GetAllBonus();
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
