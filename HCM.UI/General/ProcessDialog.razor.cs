using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.Interfaces.EmployeeMasterSetup;
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
        public ICfgTaxSetup _CfgTaxSetup { get; set; }

        [Inject]
        public IMstGratuity _mstGratuitySetup { get; set; }

        [Inject]
        public IMstBonus _mstBonus { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ITrnsEmployeeOverTime _trnsEmployeeOverTime { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }
        
        [Inject]
        public IMstHoliday _mstHoliday { get; set; }

        [Parameter]
        public string DialogFor { get; set; }

        [Parameter]
        public int EmpPayrollId { get; set; } = 0;
        [Parameter]
        public int EmpId { get; set; } = 0;
        #endregion

        #region Variables

        bool Loading = false;
        bool IsFlg = false;
        bool DisabledCode = false;

        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string amountType = "";
        private string taxtype = "";
        private decimal Amount;
        private decimal Hours;

        DateTime? docdate;
        TimeSpan? timefrom = new TimeSpan();
        TimeSpan? timeto = new TimeSpan();
        void Cancel() => MudDialog.Cancel();
        [Parameter] public List<VMMstShiftDetail> oDetailListPara { get; set; } = new List<VMMstShiftDetail>();

        VMMstShiftDetail oModelShiftDetail = new VMMstShiftDetail();
        List<VMMstShiftDetail> oListShift = new List<VMMstShiftDetail>();

        [Parameter] public CfgTaxDetail oDetailParaTax { get; set; } = new CfgTaxDetail();
        CfgTaxDetail oModelTaxSetupDetail = new CfgTaxDetail();

        [Parameter] public MstGratuityDetail oDetailParaGratuity { get; set; } = new MstGratuityDetail();
        MstGratuityDetail oModelGratuitySetupDetail = new MstGratuityDetail();

        [Parameter] public TrnsTaxAdjustmentDetail oDetailParaTaxAdjust { get; set; } = new TrnsTaxAdjustmentDetail();
        TrnsTaxAdjustmentDetail oModelTaxAdjustmentDetail = new TrnsTaxAdjustmentDetail();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oPayrollList = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oCfgPeriodDateList = new List<CfgPeriodDate>();
        [Parameter] public TrnsEmployeeOvertimeDetail oDetailParaEmployeeOT { get; set; } = new TrnsEmployeeOvertimeDetail();
        TrnsEmployeeOvertimeDetail oModelTrnsEmployeeOvertimeDetail = new TrnsEmployeeOvertimeDetail();

        [Parameter] public MstHolidayDetail oDetailParaMstHolidayDetail { get; set; } = new MstHolidayDetail();
        MstHolidayDetail oModelMstHolidayDetail = new MstHolidayDetail();

        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();


        MstOverTime oModelmstOvertime = new MstOverTime();
        private IEnumerable<MstOverTime> oListmstOverTime = new List<MstOverTime>();

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
            if (DialogFor == "Shifts")
            {
                MudDialog.Close(DialogResult.Ok<List<VMMstShiftDetail>>(oListShift));
            }
            else if (DialogFor == "TaxSetup")
            {
                if (!string.IsNullOrWhiteSpace(oModelTaxSetupDetail.TaxCode) && !string.IsNullOrWhiteSpace(oModelTaxSetupDetail.Description))
                {
                    if (oModelTaxSetupDetail.TaxCode.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        MudDialog.Close(DialogResult.Ok<CfgTaxDetail>(oModelTaxSetupDetail));
                    }
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            else if (DialogFor == "GratuitySetup")
            {
                if (!string.IsNullOrWhiteSpace(oModelGratuitySetupDetail.Description))
                {
                    MudDialog.Close(DialogResult.Ok<MstGratuityDetail>(oModelGratuitySetupDetail));
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            else if (DialogFor == "TaxAdjustment")
            {
                if (!string.IsNullOrWhiteSpace(oModelTaxAdjustmentDetail.Description) && !string.IsNullOrWhiteSpace(oModelTaxAdjustmentDetail.TaxType) && !string.IsNullOrWhiteSpace(oModelTaxAdjustmentDetail.AmountType) && oModelTaxAdjustmentDetail.Amount != null)
                {
                    if (oModelTaxAdjustmentDetail.TaxType == "Monthly")
                    {
                        //  oModelTaxAdjustmentDetail.FlgMonthly = true;
                        if (string.IsNullOrWhiteSpace(oModelTaxAdjustmentDetail.Period))
                        {
                            Snackbar.Add("Must Fill the Period field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });

                        }
                        else
                        {
                            MudDialog.Close(DialogResult.Ok<TrnsTaxAdjustmentDetail>(oModelTaxAdjustmentDetail));
                        }
                    }
                    else
                    {
                        MudDialog.Close(DialogResult.Ok<TrnsTaxAdjustmentDetail>(oModelTaxAdjustmentDetail));
                    }
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            else if (DialogFor == "EmployeeOverTime")
            {
                if (!string.IsNullOrWhiteSpace(oModelmstOvertime.Description) && docdate != null && !string.IsNullOrWhiteSpace(timefrom.ToString()) && !string.IsNullOrWhiteSpace(timeto.ToString())
                    && EmpId > 0 && Hours > 0 && IsFlg == true)
                {
                    oModelTrnsEmployeeOvertimeDetail.OvertimeId = oModelmstOvertime.Id;
                    // oModelTrnsEmployeeOvertimeDetail.EmpOvertimeId = oModel.Id;
                    oModelTrnsEmployeeOvertimeDetail.Otdate = docdate;
                    oModelTrnsEmployeeOvertimeDetail.FromTime = timefrom.ToString();
                    oModelTrnsEmployeeOvertimeDetail.ToTime = timeto.ToString();
                    oModelTrnsEmployeeOvertimeDetail.Othours = Hours;
                    oModelTrnsEmployeeOvertimeDetail.FlgActive = IsFlg;
                    oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModelmstOvertime.Id).FirstOrDefault();
                    oModelMstEmployee = oListEmployee.Where(x => x.Id == EmpId).FirstOrDefault();
                    oModelTrnsEmployeeOvertimeDetail.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Hours);

                    MudDialog.Close(DialogResult.Ok<TrnsEmployeeOvertimeDetail>(oModelTrnsEmployeeOvertimeDetail));
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            else if (DialogFor == "HolidayDetail")
            {
                if (!string.IsNullOrWhiteSpace(oModelMstHolidayDetail.Remarks) && oModelMstHolidayDetail.StartDate != null)
                {
                    MudDialog.Close(DialogResult.Ok<MstHolidayDetail>(oModelMstHolidayDetail));
                }
                else
                {
                    Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
        }

        private async Task GetAllEmployees()
        {
            try
            {
                oListEmployee = await _mstEmployeeMaster.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllOvertime()
        {
            try
            {
                oListmstOverTime = await _mstOverTime.GetAllData();
                oListmstOverTime = oListmstOverTime.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task<IEnumerable<MstOverTime>> SearchOvertime(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListmstOverTime.Select(o => new MstOverTime
                    {
                        Id = o.Id,
                        Code = o.Code,
                        Description = o.Description,
                    }).ToList();
                var res = oListmstOverTime.Where(x => x.Code.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstOverTime
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task CalHour()
        {
            try
            {
                await Task.Delay(1);
                if ((timefrom != null && timeto != null))
                {

                    string totalhour = (timeto - timefrom).ToString();
                    Hours = Convert.ToDecimal(TimeSpan.Parse(totalhour).TotalHours);
                }



            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;

                if (DialogFor == "Element")
                {

                }
                else if (DialogFor == "Shifts")
                {
                    await CreateRows();
                }
                else if (DialogFor == "TaxSetup")
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
                else if (DialogFor == "GratuitySetup")
                {
                    if (oDetailParaGratuity.Description != null)
                    {
                        oModelGratuitySetupDetail = oDetailParaGratuity;
                    }
                    else
                    {
                        oModelGratuitySetupDetail.Description = "";
                        oModelGratuitySetupDetail.FromPoints = 0;
                        oModelGratuitySetupDetail.ToPoints = 0;
                        oModelGratuitySetupDetail.DaysCount = 0;
                    }
                }
                else if (DialogFor == "TaxAdjustment")
                {
                    if (oDetailParaTaxAdjust.Description != null)
                    {
                        oPayrollList = await _CfgPayrollDefination.GetAllData();
                        oModelPayroll = oPayrollList.Where(x => x.Id == EmpPayrollId).FirstOrDefault();
                        oCfgPeriodDateList = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();

                        oModelTaxAdjustmentDetail = oDetailParaTaxAdjust;
                    }
                    else
                    {
                        if (EmpPayrollId != 0)
                        {
                            oPayrollList = await _CfgPayrollDefination.GetAllData();
                            oModelPayroll = oPayrollList.Where(x => x.Id == EmpPayrollId).FirstOrDefault();
                            oCfgPeriodDateList = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                        }
                        oModelTaxAdjustmentDetail.Description = "";
                        oModelTaxAdjustmentDetail.FlgActive = true;
                        oModelTaxAdjustmentDetail.Amount = 0;
                    }
                }
                else if (DialogFor == "EmployeeOverTime")
                {
                    await GetAllEmployees();
                    await GetAllOvertime();
                    oModelTrnsEmployeeOvertimeDetail = oDetailParaEmployeeOT;


                    // oModelTrnsEmployeeOvertimeDetail.EmpOvertimeId = oModel.Id;
                    docdate = oDetailParaEmployeeOT.Otdate;
                    if (oDetailParaEmployeeOT.FromTime != null && oDetailParaEmployeeOT.ToTime != null)
                    {
                        timefrom = TimeSpan.Parse(oDetailParaEmployeeOT.FromTime);
                        timeto = TimeSpan.Parse(oDetailParaEmployeeOT.ToTime);

                    }
                    Hours = (decimal)oDetailParaEmployeeOT.Othours;
                    Amount = (decimal)oDetailParaEmployeeOT.Amount;
                    IsFlg = (bool)oDetailParaEmployeeOT.FlgActive;
                    oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModelTrnsEmployeeOvertimeDetail.OvertimeId).FirstOrDefault();

                }
                else if (DialogFor == "HolidayDetail")
                {
                    if (oDetailParaMstHolidayDetail.StartDate!= null && oDetailParaMstHolidayDetail.Remarks != null)
                    {
                        oModelMstHolidayDetail= oDetailParaMstHolidayDetail;
                    }
                    else
                    {
                        oModelMstHolidayDetail.Remarks= "";
                        oModelMstHolidayDetail.StartDate = DateTime.Now;
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
