﻿using HCM.API.Models;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Globalization;

namespace HCM.UI.General
{
    public partial class ProcessDialog
    {
        #region InjectService        

        [Inject]
        public IDialogService Dialog { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }        

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public IMstTaxSetup _mstTaxSetup { get; set; }

        [Inject]
        public IMstBonus _mstBonus { get; set; }        

        #endregion

        #region Variables

        bool Loading = false;

        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        void Cancel() => MudDialog.Cancel();
        [Parameter] public List<VMMstShiftDetail> oDetailListPara { get; set; } = new List<VMMstShiftDetail>();

        VMMstShiftDetail oModelShiftDetail = new VMMstShiftDetail();
        List<VMMstShiftDetail> oListShift = new List<VMMstShiftDetail>();

        [Parameter] public MstTaxSetupDetail oDetailParaTax { get; set; } = new MstTaxSetupDetail();
        MstTaxSetupDetail oModelTaxSetupDetail = new MstTaxSetupDetail();       

        #endregion

        #region Functions        

        private async Task CreateRows()
        {
            await Task.Delay(3);
            if (oDetailListPara.Count > 0)
            {
                oListShift = oDetailListPara;
            }
            else
            {
                for (int i = 0; i <= 6; i++)
                {
                    oModelShiftDetail = new VMMstShiftDetail();
                    if (i == 0)
                    {
                        oModelShiftDetail.Day = "Monday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 1)
                    {
                        oModelShiftDetail.Day = "Tuesday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 2)
                    {
                        oModelShiftDetail.Day = "Wednesday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 3)
                    {
                        oModelShiftDetail.Day = "Thursday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 4)
                    {
                        oModelShiftDetail.Day = "Friday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 5)
                    {
                        oModelShiftDetail.Day = "Saturday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    if (i == 6)
                    {
                        oModelShiftDetail.Day = "Sunday";
                        oModelShiftDetail.TSStartTime = new TimeSpan();
                        oModelShiftDetail.TSEndTime = new TimeSpan();
                        oModelShiftDetail.TSDuration = new TimeSpan();
                        oModelShiftDetail.TSBufferStartTime = new TimeSpan();
                        oModelShiftDetail.TSBufferEndTime = new TimeSpan();
                        oModelShiftDetail.TSGraceStartTime = new TimeSpan();
                        oModelShiftDetail.TSGraceEndTime = new TimeSpan();
                        oModelShiftDetail.TSBreakTime = new TimeSpan();
                        oModelShiftDetail.FlgOutOverlap = true;
                        oModelShiftDetail.FlgExpectedIn = true;
                        oModelShiftDetail.FlgExpectedOut = true;
                    }
                    oListShift.Add(oModelShiftDetail);
                }
            }
        }

        private async Task OnValueChanged(string Day)
        {
            try
            {
                await Task.Delay(2);
                var res = oListShift.Where(x => x.Day == Day).FirstOrDefault();
                TimeSpan Dur = DateTime.ParseExact(res.TSEndTime.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture).Subtract(DateTime.ParseExact(res.TSStartTime.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture));

                oListShift.Where(x => x.Day == Day).ToList().ForEach(s => s.TSDuration = Dur);
                //foreach (var item in oListShift)
                //{
                //    if(Day == "Monday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Tuesday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Wednesday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Thursday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Friday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Saturday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    if (Day == "Sunday")
                //    {
                //        item.TSDuration = Dur;
                //        break;
                //    }
                //    continue;
                //}
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task Submit()
        {
            await Task.Delay(2);
            if (Settings.DialogFor == "Shifts")
            {
                MudDialog.Close(DialogResult.Ok<List<VMMstShiftDetail>>(oListShift));
            }
            else if (Settings.DialogFor == "TaxSetup")
            {
                if (!string.IsNullOrWhiteSpace(oModelTaxSetupDetail.TaxCode) && !string.IsNullOrWhiteSpace(oModelTaxSetupDetail.Description))
                {
                    if (oModelTaxSetupDetail.TaxCode.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        MudDialog.Close(DialogResult.Ok<MstTaxSetupDetail>(oModelTaxSetupDetail));
                    }
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
        }        

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                if (Settings.DialogFor == "Element")
                {

                }
                else if (Settings.DialogFor == "Shifts")
                {
                    await CreateRows();
                }
                else if (Settings.DialogFor == "TaxSetup")
                {
                    if (oDetailParaTax.TaxCode != null)
                    {
                        oModelTaxSetupDetail = oDetailParaTax;
                        DisabledCode = true;
                    }
                    else
                    {
                        oModelTaxSetupDetail.FlgActive = true;
                        oModelTaxSetupDetail.MinAmount = 0;
                        oModelTaxSetupDetail.MaxAmount = 0;
                        oModelTaxSetupDetail.TaxValue = 0;
                        oModelTaxSetupDetail.FixTerm = 0;
                        oModelTaxSetupDetail.AdditionalDisc = 0;
                    }
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
