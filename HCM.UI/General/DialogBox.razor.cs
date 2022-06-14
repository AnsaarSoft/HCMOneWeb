using HCM.API.Models;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.General
{
    public partial class DialogBox
    {
        #region InjectService        

        [Inject]
        public IDialogService Dialog { get; set; }

        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        #endregion

        #region Variables

        bool Loading = false;
        private string searchString1 = "";

        private bool FilterFuncElement(MstElement element) => FilterFuncElement(element, searchString1);
        void Cancel() => MudDialog.Cancel();

        MstElement oModel = new MstElement();
        List<MstElement> oListElement = new List<MstElement>();

        #endregion

        #region Functions

        private async Task GetAllElements()
        {
            try
            {
                oListElement = await _mstElement.GetAllData();
                if (oListElement?.Count == 0 || oListElement == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
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
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ElmtType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Type.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                await GetAllElements();
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        public void RowClickEvent(TableRowClickEventArgs<MstElement> tableRowClickEventArgs)
        {
            try
            {
                oModel.Code = tableRowClickEventArgs.Item.Code;
                MudDialog.Close(DialogResult.Ok<MstElement>(oModel));
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        #endregion
    }
}
