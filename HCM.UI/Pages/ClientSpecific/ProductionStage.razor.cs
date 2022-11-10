using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.Authorization;
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
        public IUserAuthorization _UserAuthorization { get; set; }

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
        private IEnumerable<TrnsProductStageItem> oListstageItem = new List<TrnsProductStageItem>();
        TrnsProductStageTeamLead oModelStageTeamLead = new TrnsProductStageTeamLead();
        private IEnumerable<TrnsProductStageTeamLead> oListStageTeamLead = new List<TrnsProductStageTeamLead>();
        TrnsProductStageStation oModelStageStation = new TrnsProductStageStation();
        private IEnumerable<TrnsProductStageStation> oListStageStation = new List<TrnsProductStageStation>();

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

        private async Task OpenDialog(DialogOptions options)
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
                    oModel = res;
                    oListstageItem = res.TrnsProductStageItems.ToList();
                    oListStageTeamLead = res.TrnsProductStageTeamLeads.ToList();
                    oListStageStation = res.TrnsProductStageStations.ToList();
                    foreach (var item in oListstageItem)
                    {
                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = LoginUser;
                    }
                    foreach (var item in oListStageTeamLead)
                    {
                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = LoginUser;
                    }
                    foreach (var item in oListStageStation)
                    {
                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = LoginUser;
                    }
                    DisbaledCode = true;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
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
        private async Task OpenDialogStageItem1(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "StageItem");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (HashSet<SAPModels>)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    List<TrnsProductStageItem> oTempList = new List<TrnsProductStageItem>();
                    oTempList = oListstageItem.ToList();
                    foreach (var item in res)
                    {
                        var Items = oListstageItem.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                        if (Items == null)
                        {
                            TrnsProductStageItem trnsProductStageItem = new TrnsProductStageItem();
                            trnsProductStageItem.ItemCode = item.ItemCode;
                            trnsProductStageItem.ItemDescription = item.ItemName;
                            trnsProductStageItem.ItemGrpCode = item.ItemGroupCode.ToString();
                            trnsProductStageItem.ItemGrpName = item.ItemGroupName;
                            trnsProductStageItem.UserId = LoginUser;
                            trnsProductStageItem.CreateDate = DateTime.Now;
                            oTempList.Add(trnsProductStageItem);
                        }
                    }
                    oListstageItem = oTempList;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogStageTeamLead1(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "MultipleEmployeeSelect");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (HashSet<MstEmployee>)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    List<TrnsProductStageTeamLead> oTempList = new List<TrnsProductStageTeamLead>();
                    oTempList = oListStageTeamLead.ToList();
                    foreach (var item in res)
                    {
                        var Items = oListStageTeamLead.Where(x => x.EmpCode == item.EmpId).FirstOrDefault();
                        if (Items == null)
                        {
                            TrnsProductStageTeamLead trnsProductStageTeamLead = new TrnsProductStageTeamLead();
                            trnsProductStageTeamLead.EmpCode = item.EmpId;
                            trnsProductStageTeamLead.EmpName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                            trnsProductStageTeamLead.Designation = item.DesignationName;
                            trnsProductStageTeamLead.Department = item.DepartmentName;
                            trnsProductStageTeamLead.UserId = LoginUser;
                            trnsProductStageTeamLead.CreateDate = DateTime.Now;
                            oTempList.Add(trnsProductStageTeamLead);
                        }
                    }
                    oListStageTeamLead = oTempList;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogStageStation1(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "Station");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (HashSet<MstStation>)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    List<TrnsProductStageStation> oTempList = new List<TrnsProductStageStation>();
                    oTempList = oListStageStation.ToList();
                    foreach (var item in res)
                    {
                        var Items = oListStageStation.Where(x => x.StationCode == item.Code).FirstOrDefault();
                        if (Items == null)
                        {
                            TrnsProductStageStation trnsProductStageStation = new TrnsProductStageStation();
                            trnsProductStageStation.StationCode = item.Code;
                            trnsProductStageStation.StationDescription = item.Description;
                            trnsProductStageStation.UserId = LoginUser;
                            trnsProductStageStation.CreateDate = DateTime.Now;
                            oTempList.Add(trnsProductStageStation);
                        }
                    }
                    oListStageStation = oTempList;
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

                //List<TrnsEmployeeTransferDetail> oListTrnsEmployeeTransferDtl = new List<TrnsEmployeeTransferDetail>();
                //oListTrnsEmployeeTransferDtl = oListFilteredEmployeeTransferDetail.ToList();
                //if (oListFilteredEmployeeTransferDetail.Count() > 0)
                //{
                //    var FilterRecord = oListFilteredEmployeeTransferDetail.Where(x => x.Id == ID).FirstOrDefault();
                //    oListTrnsEmployeeTransferDtl.Remove(FilterRecord);
                //    oListFilteredEmployeeTransferDetail = oListTrnsEmployeeTransferDtl;
                //}


                List<TrnsProductStageItem> oListTrnsProductStageItem = new List<TrnsProductStageItem>();
                oListTrnsProductStageItem = oListstageItem.ToList();
                if (oListstageItem.Count() > 0)
                {
                    var FilterRecord = oListstageItem.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsProductStageItem.Remove(FilterRecord);
                    oListstageItem = oListTrnsProductStageItem;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task DeleteFromFilterStageTeamLead(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);


                List<TrnsProductStageTeamLead> oListTrnsProductStageTeamLead = new List<TrnsProductStageTeamLead>();
                oListTrnsProductStageTeamLead = oListStageTeamLead.ToList();
                if (oListStageTeamLead.Count() > 0)
                {
                    var FilterRecord = oListStageTeamLead.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsProductStageTeamLead.Remove(FilterRecord);
                    oListStageTeamLead = oListTrnsProductStageTeamLead;
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
        private async Task DeleteFromFilterStageStation(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);

                List<TrnsProductStageStation> oListTrnsProductStageStation = new List<TrnsProductStageStation>();
                oListTrnsProductStageStation = oListStageStation.ToList();
                if (oListStageStation.Count() > 0)
                {
                    var FilterRecord = oListStageStation.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsProductStageStation.Remove(FilterRecord);
                    oListStageStation = oListTrnsProductStageStation;
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

        //private async Task OpenDialogStageItem(DialogOptions options)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("DialogFor", "ProductStageItem");
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;
        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageItem)result.Data;
        //            oModelstageItem.ItemCode = res.ItemCode;
        //            oModelstageItem.ItemGrpCode = res.ItemGrpCode;
        //            oModelstageItem.ItemDescription = res.ItemDescription;
        //            oModelstageItem.UserId = LoginUser;
        //            oModelstageItem.CreateDate = DateTime.Now;
        //            oListstageItem.Add(oModelstageItem);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
        //private async Task OpenEditDialogStageItem(DialogOptions options, TrnsProductStageItem oDetailPara)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("oDetailTrnsProductStageItem ", oDetailPara);
        //        parameters.Add("DialogFor", "ProductStageItem");
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;

        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageItem)result.Data;
        //            var update = oListstageItem.Where(x => x.Id == res.Id).FirstOrDefault();
        //            if (update != null)
        //            {
        //                oListstageItem.Remove(update);
        //            }
        //            if (oModel.Id != 0)
        //            {
        //                res.UpdateDate = DateTime.Now;
        //                res.UpdatedBy = LoginUser;
        //            }
        //            else
        //            {
        //                res.CreateDate = DateTime.Now;
        //                res.UserId = LoginUser;

        //            }
        //            oListstageItem.Add(res);
        //            // oListMstHolidayDtl.Add(res);
        //            //oListMstHolidayDetail = oListMstHolidayDtl;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
        //private async Task OpenDialogStageTeamLead(DialogOptions options)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("DialogFor", "ProductStageTeamLead");
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;
        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageTeamLead)result.Data;
        //            oModelStageTeamLead.EmpCode = res.EmpCode;
        //            oModelStageTeamLead.EmpName = res.EmpName;
        //            oModelStageTeamLead.Designation = res.Designation;
        //            oModelStageTeamLead.Department = res.Department;
        //            oModelStageTeamLead.UserId = LoginUser;
        //            oModelStageTeamLead.CreateDate = DateTime.Now;
        //            oListStageTeamLead.Add(oModelStageTeamLead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
        //private async Task OpenEditDialogStageTeamLead(DialogOptions options, TrnsProductStageTeamLead oDetailPara)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("oDetailParaProductStageTeamLead ", oDetailPara);
        //        parameters.Add("DialogFor", "ProductStageTeamLead");
        //        // parameters.Add("EmpId", oModel.EmployeeId);
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;

        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageTeamLead)result.Data;
        //            var update = oListStageTeamLead.Where(x => x.Id == res.Id).FirstOrDefault();
        //            if (update != null)
        //            {
        //                oListStageTeamLead.Remove(update);
        //            }
        //            if (oModel.Id != 0)
        //            {
        //                res.UpdateDate = DateTime.Now;
        //                res.UpdatedBy = LoginUser;
        //            }
        //            else
        //            {
        //                res.CreateDate = DateTime.Now;
        //                res.UserId = LoginUser;

        //            }
        //            oListStageTeamLead.Add(res);
        //            // oListMstHolidayDtl.Add(res);
        //            //oListMstHolidayDetail = oListMstHolidayDtl;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
        //private async Task OpenDialogStageStation(DialogOptions options)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("DialogFor", "ProductStageStation");
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;
        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageStation)result.Data;
        //            oModelStageStation.StationCode = res.StationCode;
        //            oModelStageStation.StationDescription = res.StationDescription;
        //            oModelStageStation.UserId = LoginUser;
        //            oModelStageStation.CreateDate = DateTime.Now;
        //            oListStageStation.Add(oModelStageStation);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
        //private async Task OpenEditDialogStageStation(DialogOptions options, TrnsProductStageStation oDetailPara)
        //{
        //    try
        //    {
        //        var parameters = new DialogParameters();
        //        parameters.Add("oDetailTrnsProductStageStation ", oDetailPara);
        //        parameters.Add("DialogFor", "ProductStageStation");
        //        var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
        //        var result = await dialog.Result;

        //        if (!result.Cancelled)
        //        {
        //            var res = (TrnsProductStageStation)result.Data;
        //            var update = oListStageStation.Where(x => x.Id == res.Id).FirstOrDefault();
        //            if (update != null)
        //            {
        //                oListStageStation.Remove(update);
        //            }
        //            if (oModel.Id != 0)
        //            {
        //                res.UpdateDate = DateTime.Now;
        //                res.UpdatedBy = LoginUser;
        //            }
        //            else
        //            {
        //                res.CreateDate = DateTime.Now;
        //                res.UserId = LoginUser;

        //            }
        //            oListStageStation.Add(res);
        //            // oListMstHolidayDtl.Add(res);
        //            //oListMstHolidayDetail = oListMstHolidayDtl;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}
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

                oModel.TrnsProductStageItems = oListstageItem.ToList();
                oModel.TrnsProductStageTeamLeads = oListStageTeamLead.ToList();
                oModel.TrnsProductStageStations = oListStageStation.ToList();
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && oModel.FlgActive == true && oModel.Rework == true
                    && oModel.TrnsProductStageItems.Count > 0 && oModel.TrnsProductStageTeamLeads.Count > 0 && oModel.TrnsProductStageStations.Count > 0)
                {
                    if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0 && DisbaledCode == false)
                    {
                        Snackbar.Add(oModel.Code + " : is Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
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
                    var res = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res.Where(x => x.CMenuID == 70 && x.UserRights == true).ToList().Count > 0)
                    {
                        oModel.FlgActive = true;
                        oModel.Rework = true;
                        await GetAllProductionStages();
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
