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

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

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
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.DocCode) && (oModel.DocNo > 0))
                {
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

                await SetDocNo();
                await GetAllBonus();
                await GetAllLove();
                await GetAllElement();
                oModel.FlgActive = true;
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
