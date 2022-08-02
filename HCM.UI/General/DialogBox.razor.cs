using HCM.API.Models;
using HCM.UI.Interfaces.MasterData;
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

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public IMstTaxSetup _mstTaxSetup { get; set; }

        #endregion

        #region Variables

        bool Loading = false;
        private string searchString1 = "";

        private bool FilterFuncElement(MstElement element) => FilterFuncElement(element, searchString1);
        private bool FilterFuncShift(MstShift element) => FilterFuncShift(element, searchString1);
        private bool FilterFuncTaxSetup(MstTaxSetup element) => FilterFuncTaxSetup(element, searchString1);
        void Cancel() => MudDialog.Cancel();

        MstElement oModelElement = new MstElement();
        List<MstElement> oListElement = new List<MstElement>();
        private HashSet<MstElement> HashElement = new HashSet<MstElement>();

        MstShift oModelShift = new MstShift();
        List<MstShift> oListShift = new List<MstShift>();

        MstTaxSetup oModelTaxSetup = new MstTaxSetup();
        List<MstTaxSetup> oListTaxSetup = new List<MstTaxSetup>();

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

        private async Task GetAllShift()
        {
            try
            {
                oListShift = await _mstShift.GetAllData();
                if (oListShift?.Count == 0 || oListShift == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncShift(MstShift element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllTaxSetup()
        {
            try
            {
                oListTaxSetup = await _mstTaxSetup.GetAllData();
                if (oListTaxSetup?.Count == 0 || oListTaxSetup == null)
                {
                    Snackbar.Add("No Record Found.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFuncTaxSetup(MstTaxSetup element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.SalaryYear.Equals(searchString1))
                return true;
            if (element.MinTaxSalaryF.Equals(searchString1))
                return true;
            if (element.SeniorCitizonAge.Equals(searchString1))
                return true;
            if (element.MaxSalaryDisc.Equals(searchString1))
                return true;
            if (element.DiscountOnTotalTax.Equals(searchString1))
                return true;
            return false;
        }

        private void Ok()
        {
            
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                if (Settings.DialogFor == "Element" || Settings.DialogFor == "PayrollElement")
                {
                    await GetAllElements();
                }
                else if (Settings.DialogFor == "Shifts")
                {
                    await GetAllShift();
                }
                else if (Settings.DialogFor == "TaxSetup")
                {
                    await GetAllTaxSetup();
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        public void RowClickEventElement(TableRowClickEventArgs<MstElement> tableRowClickEventArgs)
        {
            try
            {
                MudDialog.Close(DialogResult.Ok<MstElement>(oModelElement));
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        public void RowClickEventShift(TableRowClickEventArgs<MstShift> tableRowClickEventArgs)
        {
            try
            {
                MudDialog.Close(DialogResult.Ok<MstShift>(oModelShift));
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        public void RowClickEventTaxSetup(TableRowClickEventArgs<MstTaxSetup> tableRowClickEventArgs)
        {
            try
            {
                MudDialog.Close(DialogResult.Ok<MstTaxSetup>(oModelTaxSetup));
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        #endregion
    }
}
