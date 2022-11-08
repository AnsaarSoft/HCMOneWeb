using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.ClientSpecific;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.JSInterop;
using MudBlazor;

namespace HCM.UI.Pages.ClientSpecific
{
    public partial class ProductionStage
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }


        [Inject]
        public ITrnsProductStage _trnsProduct { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }

        private string LoginUser = "";

        int DocNum;
        // private string gltype1 = "";
        //private string D_BSC = "", D_BSD = "", C_BSC = "", C_BSD = "", D_ArreasC = "", D_ArreasD = "", C_ArreasC = "", C_ArreasD = ""
        //    , D_LeavEncC = "", D_LeavEncD = "", C_LeavEncC = "", C_LeavEncD = "", D_EOSC = "", D_EOSD = "", C_EOSC = "", C_EOSD = ""
        //    , D_GratuityC = "", D_GratuityD = "", C_GratuityC = "", C_GratuityD = "", D_IncomTaxC = "", D_IncomTaxD = "", C_IncomTaxC = "", C_IncomTaxD = "";
        #endregion

        #region Variables

        bool Loading = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        bool DisbaledCode = false;

        private bool FilterFuncStageItem(TrnsProductStageItem element) => FilterFuncStageItem(element, searchString1);
        private bool FilterFuncStageTeamLead(TrnsProductStageTeamLead element) => FilterFuncStageTeamLead(element, searchString1);
        private bool FilterFuncStageStation(TrnsProductStageStation element) => FilterFuncStageStation(element, searchString1);

        TrnsProductStage oModel = new TrnsProductStage();
        List<TrnsProductStage> oList = new List<TrnsProductStage>();

        TrnsProductStageItem oModelstageItem = new TrnsProductStageItem();
        List<TrnsProductStageItem> oListstageItem = new List<TrnsProductStageItem>();
        TrnsProductStageTeamLead oModelStageTeamLead = new TrnsProductStageTeamLead();
        List<TrnsProductStageTeamLead> oListStageTeamLead = new List<TrnsProductStageTeamLead>();
        TrnsProductStageStation oModelStageStation = new TrnsProductStageStation();
        List<TrnsProductStageStation> oListStageStation = new List<TrnsProductStageStation>();

        //MstGldetermination oModel1 = new MstGldetermination();
        //private IEnumerable<MstGldetermination> oList = new List<MstGldetermination>();

        //private IEnumerable<MstElement> oListElement = new List<MstElement>();
        //private IEnumerable<MstElement> oListElementEarn = new List<MstElement>();
        //private IEnumerable<MstElement> oListElementDeduction = new List<MstElement>();
        //private IEnumerable<MstElement> oListElementContribution = new List<MstElement>();

        //private IEnumerable<MstLoan> oListMstLoan = new List<MstLoan>();
        //private IEnumerable<MstAdvance> oListMstAdvance = new List<MstAdvance>();
        //private IEnumerable<MstOverTime> oListMstOverTime = new List<MstOverTime>();
        //private IEnumerable<MstLeaveDeduction> oListMstLeaveDeduction = new List<MstLeaveDeduction>();

        //private IEnumerable<MstEmployee> oListemp = new List<MstEmployee>();

        //MstGldearningDetail oModelGldearningDetail = new MstGldearningDetail();
        //List<MstGldearningDetail> oListGldearningDetail = new List<MstGldearningDetail>();

        //List<MstGlddeductionDetail> oListMstGlddeductionDetail = new List<MstGlddeductionDetail>();

        //List<MstGldcontribution> oListGldMstGldcontribution = new List<MstGldcontribution>();

        //List<MstGldloansDetail> oListGldMstGldloansDetail = new List<MstGldloansDetail>();

        //List<MstGldadvanceDetail> oListMstGldadvanceDetail = new List<MstGldadvanceDetail>();

        //List<MstGldoverTimeDetail> oListMstGldoverTimeDetail = new List<MstGldoverTimeDetail>();

        //List<MstGldleaveDedDetail> oListMstGldleaveDedDetail = new List<MstGldleaveDedDetail>();


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };
        #endregion

        #region Functions


        private bool FilterFuncStageItem(TrnsProductStageItem element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ItemCode.Equals(searchString1))
                return true;
            if (element.ItemDescription.Equals(searchString1))
                return true;
            if (element.ItemGrpCode.Equals(searchString1))
                return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncStageTeamLead(TrnsProductStageTeamLead element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpCode.Equals(searchString1))
                return true;
            if (element.EmpName.Equals(searchString1))
                return true;
            if (element.Department.Equals(searchString1))
                return true;
            if (element.Designation.Equals(searchString1))
                return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncStageStation(TrnsProductStageStation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.StationCode.Equals(searchString1))
                return true;
            if (element.StationDescription.Equals(searchString1))
                return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }

        private async Task GetAllProductionStages()
        {
            try
            {
                oList = await _trnsProduct.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogStageItem(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ProductStageItem");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageItem)result.Data;
                    oModelstageItem.ItemCode = res.ItemCode;
                    oModelstageItem.ItemGrpCode = res.ItemGrpCode;
                    oModelstageItem.ItemDescription = res.ItemDescription;
                    oModelstageItem.UserId = LoginUser;
                    oModelstageItem.CreateDate = DateTime.Now;
                    oListstageItem.Add(oModelstageItem);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialogStageItem(DialogOptions options, TrnsProductStageItem oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailTrnsProductStageItem ", oDetailPara);
                parameters.Add("DialogFor", "ProductStageItem");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageItem)result.Data;
                    var update = oListstageItem.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oListstageItem.Remove(update);
                    }
                    if (oModel.Id != 0)
                    {
                        res.UpdateDate = DateTime.Now;
                        res.UpdatedBy = LoginUser;
                    }
                    else
                    {
                        res.CreateDate = DateTime.Now;
                        res.UserId = LoginUser;

                    }
                    oListstageItem.Add(res);
                    // oListMstHolidayDtl.Add(res);
                    //oListMstHolidayDetail = oListMstHolidayDtl;
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task DeleteFromFilterStageItem(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);


                if (oListStageTeamLead.Count() > 0)
                {
                    var FilterRecord = oListstageItem.Where(x => x.Id == ID).FirstOrDefault();
                    oListstageItem.Remove(FilterRecord);
                }

                //oListMstHolidayDtl = oListMstHolidayDetail.ToList();
                //if (oListMstHolidayDetail.Count() > 0)
                //{
                //    var FilterRecord = oListMstHolidayDetail.Where(x => x.Id == ID).FirstOrDefault();
                //    oListMstHolidayDtl.Remove(FilterRecord);
                //    oListMstHolidayDetail = oListMstHolidayDtl;
                //}
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task OpenDialogStageTeamLead(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ProductStageTeamLead");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageTeamLead)result.Data;
                    oModelStageTeamLead.EmpCode = res.EmpCode;
                    oModelStageTeamLead.EmpName = res.EmpName;
                    oModelStageTeamLead.Designation = res.Designation;
                    oModelStageTeamLead.Department = res.Department;
                    oModelStageTeamLead.UserId = LoginUser;
                    oModelStageTeamLead.CreateDate = DateTime.Now;
                    oListStageTeamLead.Add(oModelStageTeamLead);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialogStageTeamLead(DialogOptions options, TrnsProductStageTeamLead oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaProductStageTeamLead ", oDetailPara);
                parameters.Add("DialogFor", "ProductStageTeamLead");
                // parameters.Add("EmpId", oModel.EmployeeId);
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageTeamLead)result.Data;
                    var update = oListStageTeamLead.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oListStageTeamLead.Remove(update);
                    }
                    if (oModel.Id != 0)
                    {
                        res.UpdateDate = DateTime.Now;
                        res.UpdatedBy = LoginUser;
                    }
                    else
                    {
                        res.CreateDate = DateTime.Now;
                        res.UserId = LoginUser;

                    }
                    oListStageTeamLead.Add(res);
                    // oListMstHolidayDtl.Add(res);
                    //oListMstHolidayDetail = oListMstHolidayDtl;
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task DeleteFromFilterStageTeamLead(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);


                if (oListStageTeamLead.Count() > 0)
                {
                    var FilterRecord = oListStageTeamLead.Where(x => x.Id == ID).FirstOrDefault();
                    oListStageTeamLead.Remove(FilterRecord);
                }

                //oListMstHolidayDtl = oListMstHolidayDetail.ToList();
                //if (oListMstHolidayDetail.Count() > 0)
                //{
                //    var FilterRecord = oListMstHolidayDetail.Where(x => x.Id == ID).FirstOrDefault();
                //    oListMstHolidayDtl.Remove(FilterRecord);
                //    oListMstHolidayDetail = oListMstHolidayDtl;
                //}
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task OpenDialogStageStation(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ProductStageStation");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageStation)result.Data;
                    oModelStageStation.StationCode = res.StationCode;
                    oModelStageStation.StationDescription = res.StationDescription;
                    oModelStageStation.UserId = LoginUser;
                    oModelStageStation.CreateDate = DateTime.Now;
                    oListStageStation.Add(oModelStageStation);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialogStageStation(DialogOptions options, TrnsProductStageStation oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailTrnsProductStageStation ", oDetailPara);
                parameters.Add("DialogFor", "ProductStageStation");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageStation)result.Data;
                    var update = oListStageStation.Where(x => x.Id == res.Id).FirstOrDefault();
                    if (update != null)
                    {
                        oListStageStation.Remove(update);
                    }
                    if (oModel.Id != 0)
                    {
                        res.UpdateDate = DateTime.Now;
                        res.UpdatedBy = LoginUser;
                    }
                    else
                    {
                        res.CreateDate = DateTime.Now;
                        res.UserId = LoginUser;

                    }
                    oListStageStation.Add(res);
                    // oListMstHolidayDtl.Add(res);
                    //oListMstHolidayDetail = oListMstHolidayDtl;
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task DeleteFromFilterStageStation(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);


                if (oListStageTeamLead.Count() > 0)
                {
                    var FilterRecord = oListStageStation.Where(x => x.Id == ID).FirstOrDefault();
                    oListStageStation.Remove(FilterRecord);
                }

                //oListMstHolidayDtl = oListMstHolidayDetail.ToList();
                //if (oListMstHolidayDetail.Count() > 0)
                //{
                //    var FilterRecord = oListMstHolidayDetail.Where(x => x.Id == ID).FirstOrDefault();
                //    oListMstHolidayDtl.Remove(FilterRecord);
                //    oListMstHolidayDetail = oListMstHolidayDtl;
                //}
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/ProductionStage", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();

                oModel.TrnsProductStageItems = oListstageItem;
                oModel.TrnsProductStageTeamLeads = oListStageTeamLead;
                oModel.TrnsProductStageStations = oListStageStation;
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && oModel.FlgActive == true && oModel.Rework == true
                    && oModel.TrnsProductStageItems.Count > 0 && oModel.TrnsProductStageTeamLeads.Count > 0 && oModel.TrnsProductStageStations.Count > 0)
                {
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsProduct.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsProduct.Update(oModel);
                    }


                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/ProductionStage", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }


                }
                else
                {
                    Snackbar.Add("Please fill the required field(s) Or Add Detail", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                //if (!string.IsNullOrWhiteSpace(oModel.Gltype))
                //{
                //    if (oModel.Id == 0)
                //    {
                //        oModel.UserId = LoginUser;
                //        res = await _mstGldetermination.Insert(oModel);
                //    }
                //    else
                //    {
                //        oModel.UpdatedBy = LoginUser;
                //        res = await _mstGldetermination.Update(oModel);
                //    }


                //    if (res != null && res.Id == 1)
                //    {
                //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //        await Task.Delay(3000);
                //        Navigation.NavigateTo("/ProductionStage", forceLoad: true);
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }

                //}
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
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
                    oModel.FlgActive = true;
                    oModel.Rework = true;
                    await GetAllProductionStages();
                    //await GetAllState();
                    //await GetAllGLDetermination();
                    //await SetDocNo();
                    //await GetAllElement();
                    //await GetAllLoans();
                    //await GetAllAdvances();
                    //await GetAllOverTimes();
                    //await GetAllLeaveDeduction();
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
