using Blazored.LocalStorage;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.Interfaces.Authorization;
using Microsoft.AspNetCore.Components;

namespace HCM.UI.Shared
{
    public partial class NavMenu
    {
        #region Inject Service

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public IDocApprovalDecesion _DocApprovalDecesionService { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variables

        private string LoginUser = "";

        List<UserAuthorization> AuthMenus;

        List<DocApprovalDecesion> oDocApprovalDecesionList = new List<DocApprovalDecesion>();

        #endregion

        #region Functions

        async Task<List<DocApprovalDecesion>> GetAllPendingDoc()
        {
            try
            {
                oDocApprovalDecesionList = await _DocApprovalDecesionService.GetAllData(LoginUser, "Pending");
                return oDocApprovalDecesionList;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        #endregion

        #region Events

        protected override async Task OnInitializedAsync()
        {

            try
            {
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    var res = await _UserAuthorization.FetchUserAuth(LoginUser);
                    AuthMenus = res?.Where(x => x.UserRights != 1).ToList();
                    await GetAllPendingDoc();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex.Message);
            }
        }

        #endregion
    }
}
