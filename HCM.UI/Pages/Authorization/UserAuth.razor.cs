using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;

namespace HCM.UI.Pages.Authorization
{
    public partial class UserAuth
    {
        #region Inject Service

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        //[Inject]
        //public IUserProfile _UserProfileService { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IUserAuthorization UserAuthorization { get; set; }

        #endregion

        #region Variables

        private bool Loading = false;

        private string LoginUser = "";

        private bool UserRight = false;

        MstEmployee oModelEmployee = new MstEmployee();

        //private TableGroupDefinition<VMUserAuthorization> groupDef { get; set; }
        //MstUserProfile oUser = new MstUserProfile();
        //List<MstUserProfile> oSelectedUserList = new List<MstUserProfile>();

        //VMUserAuthorization oVm = new VMUserAuthorization();
        //List<VMUserAuthorization> oVmList = new List<VMUserAuthorization>();

        //IEnumerable<VMUserAuthorization> oVmListTable = new List<VMUserAuthorization>();


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        MstMenu oMstMenu = new MstMenu();
        List<MstMenu> oMenuList = new List<MstMenu>();

        List<UserAuthorization> oUserAuthorizationList = new List<UserAuthorization>();
        UserAuthorization oUserAuthorization = new UserAuthorization();

        #endregion

        #region Function

        async void Save()
        {
            List<UserAuthorization> oUserAuthorizationList = new List<UserAuthorization>();
            foreach (var item in oList)
            {
                var check = oList.Where(x => x.PMenuID == item.PMenuID && x.UserRights == true).FirstOrDefault();
                if (check != null)
                {
                    var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID).FirstOrDefault();
                    if (checkParent == null)
                    {
                        UserAuthorization oUserAuthorization = new UserAuthorization();
                        oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                        oUserAuthorization.MenuName = item.PMenuName;
                        oUserAuthorization.UserRights = 2;
                        oUserAuthorization.FkmenuId = item.PMenuID;
                        oUserAuthorization.CreatedBy = LoginUser;
                        oUserAuthorization.CreatedDate = DateTime.Now;
                        oUserAuthorizationList.Add(oUserAuthorization);
                    }
                }
                else
                {
                    var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID).FirstOrDefault();
                    if (checkParent == null)
                    {
                        UserAuthorization oUserAuthorization = new UserAuthorization();
                        oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                        oUserAuthorization.MenuName = item.PMenuName;
                        oUserAuthorization.UserRights = 1;
                        oUserAuthorization.FkmenuId = item.PMenuID;
                        oUserAuthorization.CreatedBy = LoginUser;
                        oUserAuthorization.CreatedDate = DateTime.Now;
                        oUserAuthorizationList.Add(oUserAuthorization);
                    }
                }
                var checkChild = oList.Where(x => x.CMenuID == item.CMenuID && x.UserRights == true).FirstOrDefault();
                if (checkChild != null)
                {
                    UserAuthorization oUserAuthorization = new UserAuthorization();
                    oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                    oUserAuthorization.MenuName = item.CMenuName;
                    oUserAuthorization.UserRights = 2;
                    oUserAuthorization.FkmenuId = item.CMenuID;
                    oUserAuthorization.CreatedBy = LoginUser;
                    oUserAuthorization.CreatedDate = DateTime.Now;
                    oUserAuthorizationList.Add(oUserAuthorization);
                }
                else
                {
                    UserAuthorization oUserAuthorization = new UserAuthorization();
                    oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                    oUserAuthorization.MenuName = item.CMenuName;
                    oUserAuthorization.UserRights = 1;
                    oUserAuthorization.FkmenuId = item.CMenuID;
                    oUserAuthorization.CreatedBy = LoginUser;
                    oUserAuthorization.CreatedDate = DateTime.Now;
                    oUserAuthorizationList.Add(oUserAuthorization);
                }
            }
            var res = await UserAuthorization.AddUserAuthorization(oUserAuthorizationList);
            if (!res.Message.Contains("Failed"))
            {
                Snackbar.Add(res.Message, Severity.Normal, (options) => { options.Icon = Icons.Sharp.DoneAll; });
                await Task.Delay(1000);
                Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
            }
            else
            {
                Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.DoneAll; });
            }
            Loading = false;
        }

        //async Task<List<MstUserProfile>> GetAllUsers()
        //{
        //    try
        //    {
        //        oUserList = await _UserProfileService.GetAllData();
        //        return oUserList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return null;
        //    }
        //}

        //async Task<List<MstMenu>> GetMenu()
        //{
        //    try
        //    {
        //        oMenuList.Clear();
        //        oVmList.Clear();
        //        oMenuList = await _UserProfileService.GetAllMenu();
        //        string MenuParentName = "";
        //        int ID = 1;
        //        foreach (var item in oMenuList)
        //        {
        //            oVm = new VMUserAuthorization();
        //            if (item.MenuName == "Administration" || item.MenuParent == 1)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = 1;
        //            }
        //            else if (item.MenuName == "Master Data" || item.MenuParent == 9)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = 1;
        //            }
        //            else if (item.MenuName == "Cost Allocation" || item.MenuParent == 18)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.MenuId;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = 1;
        //            }
        //            oVmList.Add(oVm);
        //            ID++;
        //        }
        //        oVmListTable = oVmList;
        //        return oMenuList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return null;
        //    }
        //}

        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelEmployee = res;
                    //oModel.EmpId = oModelEmployee.Id;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenCopyDialog(DialogOptions options)
        {
            try
            {
                //if (oUser.UserCode != null)
                //{
                //    var parameters = new DialogParameters();
                //    parameters.Add("DialogFor", "UsersCopy");
                //    var dialog = Dialog.Show<DlgUsers>("", parameters, options);
                //    var result = await dialog.Result;
                //    if (!result.Cancelled)
                //    {
                //        var res = result.Data;
                //        oSelectedUserList = (List<MstUserProfile>)result.Data;
                //        //foreach (var item in result.Data)
                //        //{

                //        //}
                //        //oUserAuthorizationList = (UserAuthorization)result.Data;
                //    }
                //}

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }


        //async Task<List<UserAuthorization>> FetchUserAuth()
        //{
        //    Loading = true;

        //    var LoginuserID = oUser.Id;
        //    oUserAuthorizationList = await _UserProfileService.FetchUserAuth(LoginuserID);
        //    if (oUserAuthorizationList.Count > 0)
        //    {
        //        int ID = 1;
        //        string MenuParentName = "";
        //        oVmList.Clear();
        //        foreach (var item in oUserAuthorizationList)
        //        {
        //            oVm = new VMUserAuthorization();
        //            if (item.MenuName == "Administration" || item.MenuParent == 1)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = (int)item.UserRights;
        //            }
        //            else if (item.MenuName == "Master Data" || item.MenuParent == 9)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = (int)item.UserRights;
        //            }
        //            else if (item.MenuName == "Cost Allocation" || item.MenuParent == 18)
        //            {
        //                if (item.MenuParent == 0)
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = item.MenuName;
        //                    MenuParentName = oVm.MenuParent;
        //                }
        //                else
        //                {
        //                    oVm.ID = ID;
        //                    oVm.MenuID = (int)item.Id;
        //                    oVm.MenuParent = MenuParentName;
        //                    oVm.MenuChild = item.MenuName;
        //                }
        //                oVm.RightsValue = (int)item.UserRights;
        //            }
        //            oVmList.Add(oVm);
        //            ID++;
        //        }
        //        oVmListTable = oVmList;
        //    }
        //    else
        //    {
        //        await GetMenu();
        //    }
        //    Loading = false;
        //    return oUserAuthorizationList;
        //}

        //async void SaveUserAuthorization()
        //{
        //    try
        //    {
        //        Loading = true;
        //        if (string.IsNullOrWhiteSpace(oUser.UserCode))
        //        {
        //            Snackbar.Add("Please select User first", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
        //            Loading = false;
        //        }
        //        else
        //        {
        //            oUserAuthorizationList.Clear();
        //            if (oSelectedUserList.Count == 0)
        //            {
        //                foreach (var item in oVmListTable)
        //                {
        //                    oUserAuthorization = new UserAuthorization();
        //                    oUserAuthorization.FkuserId = oUser.Id;
        //                    oUserAuthorization.UserRights = item.RightsValue;
        //                    oUserAuthorization.FkmenuId = item.MenuID;
        //                    oUserAuthorizationList.Add(oUserAuthorization);
        //                }
        //            }
        //            else
        //            {
        //                foreach (var SUser in oSelectedUserList)
        //                {
        //                    foreach (var item in oVmListTable)
        //                    {
        //                        oUserAuthorization = new UserAuthorization();
        //                        oUserAuthorization.FkuserId = SUser.Id;
        //                        oUserAuthorization.UserRights = item.RightsValue;
        //                        oUserAuthorization.FkmenuId = item.MenuID;
        //                        oUserAuthorizationList.Add(oUserAuthorization);
        //                    }
        //                }
        //            }
        //            var res = await _UserProfileService.AddUserAuthorization(oUserAuthorizationList);
        //            if (!res.Message.Contains("Failed"))
        //            {
        //                Snackbar.Add(res.Message, Severity.Normal, (options) => { options.Icon = Icons.Sharp.DoneAll; });
        //                await Task.Delay(1000);
        //                navigation.NavigateTo(navigation.Uri, forceLoad: true);
        //            }
        //            else
        //            {
        //                Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.DoneAll; });
        //            }
        //            Loading = false;

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
                Navigation.NavigateTo("/UserAuth", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        MudTable<VMUserAuthorization> TableRef { get; set; }

        private TableGroupDefinition<VMUserAuthorization> _groupDefinition = new()
        {
            GroupName = "Module Name ",
            Indentation = false,
            Expandable = true,
            IsInitiallyExpanded = false,
            Selector = (e) => e.PMenuName

        };

        private IEnumerable<VMUserAuthorization> oList = new List<VMUserAuthorization>();

        private async Task GetAllCostType()
        {
            try
            {
                oList = await UserAuthorization.GetAllMenu(LoginUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Initialized

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    //await GetMenu();
                    await GetAllCostType();
                }
                else
                {
                    Navigation.NavigateTo("/Login", true);
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
