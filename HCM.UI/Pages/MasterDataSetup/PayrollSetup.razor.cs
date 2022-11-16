using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class PayrollSetup
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }
        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables 

        bool Loading = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        bool DisabledCode = false;
        private string PayrollCalendar = "";
        private string searchStringElement = "";
        private string searchStringPeriods = "";
        private bool FilterFunc(MstElement element) => FilterFuncElement(element, searchStringElement);
        private bool FilterFuncPeriods(CfgPeriodDate element) => FilterFuncPeriods(element, searchStringPeriods);

        CfgPayrollDefination oModel = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oPayrollList = new List<CfgPayrollDefination>();
        IEnumerable<CfgPeriodDate> oCfgPeriodDateList = new List<CfgPeriodDate>();
        IEnumerable<MstElementLink> oMstElementLinkList = new List<MstElementLink>();

        List<MstLove> oLoveList = new List<MstLove>();
        List<MstCalendar> oCalendarList = new List<MstCalendar>();

        MstElement oModelElement = new MstElement();
        private IEnumerable<MstElement> oElementList = new List<MstElement>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "PayrollSetup");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    DisabledCode = true;
                    var res = (CfgPayrollDefination)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oModel = res;
                    oMstElementLinkList = oModel.MstElementLinks;
                    await GetAllElements();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogElement(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "PayrollElement");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (HashSet<MstElement>)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    List<MstElement> oTempList = new List<MstElement>();
                    oTempList = oElementList.ToList();
                    foreach (var item in res)
                    {
                        var Element = oElementList.Where(x => x.Id == item.Id).FirstOrDefault();
                        if (Element == null)
                        {
                            oTempList.Add(item);
                        }
                    }
                    oElementList = oTempList;
                }
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
        private async Task GetAllCalendar()
        {
            try
            {
                oCalendarList = await _mstCalendar.GetAllData();
                oPayrollList = await _CfgPayrollDefination.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async void GetAllCalendarPeriods()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.PayrollType) && !string.IsNullOrWhiteSpace(PayrollCalendar))
                {
                    CfgPayrollDefination oCfgPayrollDefination = oPayrollList.Where(x => x.PayrollType == oModel.PayrollType).FirstOrDefault();
                    oCfgPeriodDateList = oCfgPayrollDefination.CfgPeriodDates.Where(x => x.CalCode == PayrollCalendar && x.PayrollId == oCfgPayrollDefination.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        private async Task GetAllElements()
        {
            try
            {
                var TempElement = await _mstElement.GetAllData();
                List<MstElement> oTempList = new List<MstElement>();
                foreach (var item in oMstElementLinkList)
                {
                    var Element = TempElement.Where(x => x.Id == item.ElementId).FirstOrDefault();
                    Element.FlgActive = item.FlgActive;
                    oTempList.Add(Element);
                }
                oElementList = oTempList;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncElement(MstElement element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ElmtType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Equals(searchString1))
                return true;
            return false;
        }
        private bool FilterFuncPeriods(CfgPeriodDate element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.PeriodName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.CalCode.Equals(searchString1))
                return true;
            if (element.StartDate.Equals(searchString1))
                return true;
            if (element.EndDate.Equals(searchString1))
                return true;
            return false;
        }
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.PayrollName) && !string.IsNullOrWhiteSpace(oModel.PayrollType) && !string.IsNullOrWhiteSpace(oModel.Gltype))
                {
                    if (oModel.PayrollName.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oElementList.Count() > 0)
                        {
                            foreach (var Element in oElementList)
                            {
                                MstElementLink oPayrollElement = new MstElementLink();
                                oPayrollElement.ElementId = Element.Id;
                                oPayrollElement.FlgActive = Element.FlgActive;
                                var CheckElement = oModel.MstElementLinks.Where(x => x.ElementId == oPayrollElement.ElementId).FirstOrDefault();
                                if (CheckElement == null)
                                {
                                    oModel.MstElementLinks.Add(oPayrollElement);
                                }
                            }
                        }
                        if (oModel.Id == 0)
                        {
                            if (oPayrollList.Where(x => x.PayrollName == oModel.PayrollName).Count() > 0)
                            {
                                Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                            else
                            {
                                oModel.UserId = LoginUser;
                                res = await _CfgPayrollDefination.Insert(oModel);
                            }
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _CfgPayrollDefination.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/PayrollSetup", forceLoad: true);
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
                Navigation.NavigateTo("/PayrollSetup", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
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
                    if (res.Where(x => x.CMenuID == 34 && x.UserRights == true).ToList().Count > 0)
                    {

                        oModel.WorkDays = 0;
                        oModel.WorkHours = 0;
                        oModel.FlgActive = true;
                        await GetAllLove();
                        //await GetAllElements();
                        await GetAllCalendar();
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
