using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.Pages.Advance;
using HCM.UI.Pages.EmployeeMasterSetup;
using HCM.UI.Pages.Loan;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;

namespace HCM.UI.Pages.ApprovalSetup
{
    public partial class ApprovalDecesion
    {
        #region Inject Service

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IDocApprovalDecesion _DocApprovalDecesionService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variables

        private bool Loading = false;

        private MudTable<DocApprovalDecesion> _table;
        private string searchString1 = "";

        private string LoginUser = "";

        private bool FilterFunc1(DocApprovalDecesion element) => FilterFunc(element, searchString1);

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        List<DocApprovalDecesion> oDocApprovalDecesionList = new List<DocApprovalDecesion>();
        DocApprovalDecesion oModel = new DocApprovalDecesion();

        #endregion

        #region Functions

        private void PageChanged(int i)
        {
            _table.NavigateTo(i - 1);
        }

        private bool FilterFunc(DocApprovalDecesion element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.FkformName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DocStatus.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FkdocNum.Equals(searchString1))
                return true;
            if (element.CreatedBy.Equals(searchString1))
                return true;
            if (element.CreatedDate.Equals(searchString1))
                return true;
            return false;
        }

        public async Task<List<DocApprovalDecesion>> GetAllPendingDoc()
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

        private async Task OpenDialog(DialogOptions options, int ID, string status)
        {
            try
            {
                options.FullScreen = false;
                options.CloseButton = false;
                options.DisableBackdropClick = false;
                options.CloseOnEscapeKey = false;
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ApprovalDecesion");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;;
                if (!result.Cancelled)
                {
                    Loading = true;
                    var res = new ApiResponseModel();
                    string remarks = "";
                    if (result.Data == null)
                    {
                        remarks = "";
                    }
                    else
                    {
                        remarks = result.Data.ToString();
                    }
                    var obj = oDocApprovalDecesionList.Find(x => x.Id == ID);
                    oModel.Remarks = remarks;
                    oModel.DocStatus = status;
                    oModel.Id = obj.Id;
                    oModel.FkapprovalId = obj.FkapprovalId;
                    oModel.FkstageId = obj.FkstageId;
                    oModel.FkformName = obj.FkformName;
                    oModel.FkformId = obj.FkformId;
                    oModel.EmpId = obj.EmpId;
                    oModel.FkdocNum = obj.FkdocNum;
                    oModel.UpdatedBy = LoginUser;
                    oModel.UpdatedDate = DateTime.Now;
                    oModel.CreatedBy = obj.CreatedBy;
                    oModel.CreatedDate = obj.CreatedDate;
                    oModel.FlgActive = false;
                    res = await _DocApprovalDecesionService.UpdateDocApproval(oModel);
                    if (res != null)
                    {
                        Snackbar.Add(status == "Approved" ? "Accept Sucuessfully." : "Reject Sucuessfully.", Severity.Normal, (options) => { options.Icon = Icons.Sharp.DoneAll; });
                        await GetAllPendingDoc();
                    }
                    else
                    {
                        Snackbar.Add("An error occured.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    Loading = false;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task ViewApprovalDocument(DialogOptions options, int DocNum,int formID)
        {
            try
            {
                options.FullScreen = true;
                options.CloseButton = true;
                options.DisableBackdropClick = true;
                options.CloseOnEscapeKey = true;
                var parameters = new DialogParameters();
                parameters.Add("DocNum", DocNum);
                var dialog = (dynamic)null;
                switch (formID)
                {
                    case 2:
                        dialog = Dialog.Show<LeaveRequest>("", parameters, options);
                        break;
                    case 3:
                        dialog = Dialog.Show<LoanRequest>("", parameters, options);
                        break;
                    case 4:
                        dialog = Dialog.Show<AdvanceRequest>("", parameters, options);
                        break;
                    case 5:
                        dialog = Dialog.Show<EmployeeTransfer>("", parameters, options);
                        break;
                    case 6:
                        dialog = Dialog.Show<EmployeeResign>("", parameters, options);
                        break;
                }
                var result = await dialog.Result;
                if (!result.Cancelled)
                {

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
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    await GetAllPendingDoc();
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
            }
        }

        #endregion
    }
}
