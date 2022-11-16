using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.JSInterop;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class GLdetermination
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public IMstGldetermination _mstGldetermination { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public IMstLoans _mstLoans { get; set; }

        [Inject]
        public IMstAdvance _mstAdvance { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public IMstLeaveDeduction _mstLeaveDeduction { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }

        private string LoginUser = "";

        private string gltype1 = "";
        int DocNum;
        //private string D_BSC = "", D_BSD = "", C_BSC = "", C_BSD = "", D_ArreasC = "", D_ArreasD = "", C_ArreasC = "", C_ArreasD = ""
        //    , D_LeavEncC = "", D_LeavEncD = "", C_LeavEncC = "", C_LeavEncD = "", D_EOSC = "", D_EOSD = "", C_EOSC = "", C_EOSD = ""
        //    , D_GratuityC = "", D_GratuityD = "", C_GratuityC = "", C_GratuityD = "", D_IncomTaxC = "", D_IncomTaxD = "", C_IncomTaxC = "", C_IncomTaxD = "";
        #endregion

        #region Variables

        bool Loading = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";

        private bool FilterFuncMstGldearningDetail(MstGldearningDetail element) => FilterFuncMstGldearningDetail(element, searchString1);
        private bool FilterFuncMstGlddeductionDetail(MstGlddeductionDetail element) => FilterFuncMstGlddeductionDetail(element, searchString1);
        private bool FilterFuncMstGldcontribution(MstGldcontribution element) => FilterFuncMstGldcontribution(element, searchString1);
        private bool FilterFuncMstGldloansDetail(MstGldloansDetail element) => FilterFuncMstGldloansDetail(element, searchString1);
        private bool FilterFuncMstGldadvanceDetail(MstGldadvanceDetail element) => FilterFuncMstGldadvanceDetail(element, searchString1);
        private bool FilterFuncMstGldoverTimeDetail(MstGldoverTimeDetail element) => FilterFuncMstGldoverTimeDetail(element, searchString1);
        private bool FilterFuncMstGldleaveDedDetail(MstGldleaveDedDetail element) => FilterFuncMstGldleaveDedDetail(element, searchString1);


        MstGldetermination oModel = new MstGldetermination();
        private IEnumerable<MstGldetermination> oList = new List<MstGldetermination>();

        private IEnumerable<MstElement> oListElement = new List<MstElement>();
        private IEnumerable<MstElement> oListElementEarn = new List<MstElement>();
        private IEnumerable<MstElement> oListElementDeduction = new List<MstElement>();
        private IEnumerable<MstElement> oListElementContribution = new List<MstElement>();

        private IEnumerable<MstLoan> oListMstLoan = new List<MstLoan>();
        private IEnumerable<MstAdvance> oListMstAdvance = new List<MstAdvance>();
        private IEnumerable<MstOverTime> oListMstOverTime = new List<MstOverTime>();
        private IEnumerable<MstLeaveDeduction> oListMstLeaveDeduction = new List<MstLeaveDeduction>();

        private IEnumerable<MstEmployee> oListemp = new List<MstEmployee>();

        MstGldearningDetail oModelGldearningDetail = new MstGldearningDetail();
        List<MstGldearningDetail> oListGldearningDetail = new List<MstGldearningDetail>();

        List<MstGlddeductionDetail> oListMstGlddeductionDetail = new List<MstGlddeductionDetail>();

        List<MstGldcontribution> oListGldMstGldcontribution = new List<MstGldcontribution>();

        List<MstGldloansDetail> oListGldMstGldloansDetail = new List<MstGldloansDetail>();

        List<MstGldadvanceDetail> oListMstGldadvanceDetail = new List<MstGldadvanceDetail>();

        List<MstGldoverTimeDetail> oListMstGldoverTimeDetail = new List<MstGldoverTimeDetail>();

        List<MstGldleaveDedDetail> oListMstGldleaveDedDetail = new List<MstGldleaveDedDetail>();


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };
        #endregion

        #region Functions

        private bool FilterFuncMstGldearningDetail(MstGldearningDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ElementDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGlddeductionDetail(MstGlddeductionDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.DeductionDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGldcontribution(MstGldcontribution element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ContributionDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGldloansDetail(MstGldloansDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.LoanDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGldadvanceDetail(MstGldadvanceDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.AdvancesDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGldoverTimeDetail(MstGldoverTimeDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.OvertimeDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private bool FilterFuncMstGldleaveDedDetail(MstGldleaveDedDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.LeaveDedDescription.Equals(searchString1))
                return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }

        void selectGlType(string value)
        {
            oModel.Gltype = value;
            gltype1 = "";
            //if (value == "Comp")
            //{
            //    gltype1 = "Company";
            //}
        }
        private async Task OpenDialogloc_Dept(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                gltype1 = "";
                if (oModel.Gltype == "Loc")
                {
                    parameters.Add("DialogFor", "Location");
                    var dialog = Dialog.Show<DialogBox>("", parameters, options);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                    {
                        var res = (VMLoc_Gldetermination)result.Data;
                        var check = oList.Where(x => x.Id == res.GlID).FirstOrDefault();
                        if (check != null)
                        {
                            oModel = check;
                            DocNum = check.Id;
                            gltype1 = res.LocDescription;
                            oListGldearningDetail = oModel.MstGldearningDetails.ToList();
                            oListMstGlddeductionDetail = oModel.MstGlddeductionDetails.ToList();
                            oListGldMstGldcontribution = oModel.MstGldcontributions.ToList();
                            oListGldMstGldloansDetail = oModel.MstGldloansDetails.ToList();
                            oListMstGldadvanceDetail = oModel.MstGldadvanceDetails.ToList();
                            oListMstGldoverTimeDetail = oModel.MstGldoverTimeDetails.ToList();
                            oListMstGldleaveDedDetail = oModel.MstGldleaveDedDetails.ToList();

                            //if (oListGldearningDetail.Count != oListElementEarn.Count())
                            //{
                            foreach (var item in oListElementEarn)
                            {
                                var restitem = oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Ear")
                                {
                                    MstGldearningDetail mstGldearningDetail = new MstGldearningDetail();
                                    mstGldearningDetail.ElementId = item.Id;
                                    mstGldearningDetail.ElementDescription = item.Description;
                                    mstGldearningDetail.CreateDate = DateTime.Now;
                                    mstGldearningDetail.UserId = LoginUser;
                                    oListGldearningDetail.Add(mstGldearningDetail);
                                }
                            }
                            //}
                            //if (oListMstGlddeductionDetail.Count != oListElementDeduction.Count())
                            //{
                            foreach (var item in oListElementDeduction)
                            {
                                var restitem = oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Ded")
                                {

                                    MstGlddeductionDetail mstGlddeductionDetail = new MstGlddeductionDetail();
                                    mstGlddeductionDetail.DeductionId = item.Id;
                                    mstGlddeductionDetail.DeductionDescription = item.Description;
                                    mstGlddeductionDetail.CreateDate = DateTime.Now;
                                    mstGlddeductionDetail.UserId = LoginUser;
                                    oListMstGlddeductionDetail.Add(mstGlddeductionDetail);
                                }
                            }
                            //}
                            //if (oListGldMstGldcontribution.Count != oListElementContribution.Count())
                            //{
                            foreach (var item in oListElementContribution)
                            {
                                var restitem = oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Con")
                                {
                                    MstGldcontribution mstGldcontribution = new MstGldcontribution();
                                    mstGldcontribution.ContributionId = item.Id;
                                    mstGldcontribution.ContributionDescription = item.Description;
                                    mstGldcontribution.CreateDate = DateTime.Now;
                                    mstGldcontribution.UserId = LoginUser;
                                    oListGldMstGldcontribution.Add(mstGldcontribution);
                                }
                            }
                            //}
                            //if (oListGldMstGldloansDetail.Count != oListMstLoan.Count())
                            //{
                            foreach (var item in oListMstLoan)
                            {
                                var restitem = oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldloansDetail mstGldloansDetail = new MstGldloansDetail();
                                    mstGldloansDetail.LoanId = item.Id;
                                    mstGldloansDetail.LoanDescription = item.Description;
                                    mstGldloansDetail.CreateDate = DateTime.Now;
                                    mstGldloansDetail.UserId = LoginUser;
                                    oListGldMstGldloansDetail.Add(mstGldloansDetail);
                                }
                            }
                            // }
                            //if (oListMstGldadvanceDetail.Count != oListMstAdvance.Count())
                            //{
                            foreach (var item in oListMstAdvance)
                            {
                                var restitem = oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldadvanceDetail mstGldadvanceDetail = new MstGldadvanceDetail();
                                    mstGldadvanceDetail.AdvancesId = item.Id;
                                    mstGldadvanceDetail.AdvancesDescription = item.Description;
                                    mstGldadvanceDetail.CreateDate = DateTime.Now;
                                    mstGldadvanceDetail.UserId = LoginUser;
                                    oListMstGldadvanceDetail.Add(mstGldadvanceDetail);
                                }
                            }
                            //}
                            //if (oListMstGldoverTimeDetail.Count != oListMstOverTime.Count())
                            //{
                            foreach (var item in oListMstOverTime)
                            {
                                var restitem = oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldoverTimeDetail mstGldoverTimeDetail = new MstGldoverTimeDetail();
                                    mstGldoverTimeDetail.OvertimeId = item.Id;
                                    mstGldoverTimeDetail.OvertimeDescription = item.Description;
                                    mstGldoverTimeDetail.CreateDate = DateTime.Now;
                                    mstGldoverTimeDetail.UserId = LoginUser;
                                    oListMstGldoverTimeDetail.Add(mstGldoverTimeDetail);
                                }
                            }
                            //}
                            //if (oListMstGldleaveDedDetail.Count != oListMstLeaveDeduction.Count())
                            //{
                            foreach (var item in oListMstLeaveDeduction)
                            {
                                var restitem = oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldleaveDedDetail mstGldleaveDedDetail = new MstGldleaveDedDetail();
                                    mstGldleaveDedDetail.LeaveDedId = item.Id;
                                    mstGldleaveDedDetail.LeaveDedDescription = item.Description;
                                    mstGldleaveDedDetail.CreateDate = DateTime.Now;
                                    mstGldleaveDedDetail.UserId = LoginUser;
                                    oListMstGldleaveDedDetail.Add(mstGldleaveDedDetail);
                                }
                            }
                            //}
                        }
                        else
                        {
                            oModel.Glvalue = res.LocID;
                            gltype1 = res.LocDescription;
                            await SetDocNo();
                        }
                    }
                }
                else if (oModel.Gltype == "Dept")
                {
                    parameters.Add("DialogFor", "department");
                    var dialog = Dialog.Show<DialogBox>("", parameters, options);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                    {
                        var res = (VMDept_Gldetermination)result.Data;
                        var check = oList.Where(x => x.Id == res.GlID).FirstOrDefault();
                        if (check != null)
                        {
                            oModel = check;
                            DocNum = check.Id;
                            gltype1 = res.DeptDescription;
                            oListGldearningDetail = oModel.MstGldearningDetails.ToList();
                            oListMstGlddeductionDetail = oModel.MstGlddeductionDetails.ToList();
                            oListGldMstGldcontribution = oModel.MstGldcontributions.ToList();
                            oListGldMstGldloansDetail = oModel.MstGldloansDetails.ToList();
                            oListMstGldadvanceDetail = oModel.MstGldadvanceDetails.ToList();
                            oListMstGldoverTimeDetail = oModel.MstGldoverTimeDetails.ToList();
                            oListMstGldleaveDedDetail = oModel.MstGldleaveDedDetails.ToList();

                            //if (oListGldearningDetail.Count != oListElementEarn.Count())
                            //{
                            foreach (var item in oListElementEarn)
                            {
                                var restitem = oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldearningDetail.Where(x => x.ElementId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Ear")
                                {
                                    MstGldearningDetail mstGldearningDetail = new MstGldearningDetail();
                                    mstGldearningDetail.ElementId = item.Id;
                                    mstGldearningDetail.ElementDescription = item.Description;
                                    mstGldearningDetail.CreateDate = DateTime.Now;
                                    mstGldearningDetail.UserId = LoginUser;
                                    oListGldearningDetail.Add(mstGldearningDetail);
                                }
                            }
                            //}
                            //if (oListMstGlddeductionDetail.Count != oListElementDeduction.Count())
                            //{
                            foreach (var item in oListElementDeduction)
                            {
                                var restitem = oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGlddeductionDetail.Where(x => x.DeductionId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Ded")
                                {

                                    MstGlddeductionDetail mstGlddeductionDetail = new MstGlddeductionDetail();
                                    mstGlddeductionDetail.DeductionId = item.Id;
                                    mstGlddeductionDetail.DeductionDescription = item.Description;
                                    mstGlddeductionDetail.CreateDate = DateTime.Now;
                                    mstGlddeductionDetail.UserId = LoginUser;
                                    oListMstGlddeductionDetail.Add(mstGlddeductionDetail);
                                }
                            }
                            //}
                            //if (oListGldMstGldcontribution.Count != oListElementContribution.Count())
                            //{
                            foreach (var item in oListElementContribution)
                            {
                                var restitem = oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldMstGldcontribution.Where(x => x.ContributionId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null && item.ElmtType == "Con")
                                {
                                    MstGldcontribution mstGldcontribution = new MstGldcontribution();
                                    mstGldcontribution.ContributionId = item.Id;
                                    mstGldcontribution.ContributionDescription = item.Description;
                                    mstGldcontribution.CreateDate = DateTime.Now;
                                    mstGldcontribution.UserId = LoginUser;
                                    oListGldMstGldcontribution.Add(mstGldcontribution);
                                }
                            }
                            //}
                            //if (oListGldMstGldloansDetail.Count != oListMstLoan.Count())
                            //{
                            foreach (var item in oListMstLoan)
                            {
                                var restitem = oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListGldMstGldloansDetail.Where(x => x.LoanId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldloansDetail mstGldloansDetail = new MstGldloansDetail();
                                    mstGldloansDetail.LoanId = item.Id;
                                    mstGldloansDetail.LoanDescription = item.Description;
                                    mstGldloansDetail.CreateDate = DateTime.Now;
                                    mstGldloansDetail.UserId = LoginUser;
                                    oListGldMstGldloansDetail.Add(mstGldloansDetail);
                                }
                            }
                            // }
                            //if (oListMstGldadvanceDetail.Count != oListMstAdvance.Count())
                            //{
                            foreach (var item in oListMstAdvance)
                            {
                                var restitem = oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldadvanceDetail.Where(x => x.AdvancesId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldadvanceDetail mstGldadvanceDetail = new MstGldadvanceDetail();
                                    mstGldadvanceDetail.AdvancesId = item.Id;
                                    mstGldadvanceDetail.AdvancesDescription = item.Description;
                                    mstGldadvanceDetail.CreateDate = DateTime.Now;
                                    mstGldadvanceDetail.UserId = LoginUser;
                                    oListMstGldadvanceDetail.Add(mstGldadvanceDetail);
                                }
                            }
                            //}
                            //if (oListMstGldoverTimeDetail.Count != oListMstOverTime.Count())
                            //{
                            foreach (var item in oListMstOverTime)
                            {
                                var restitem = oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldoverTimeDetail.Where(x => x.OvertimeId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldoverTimeDetail mstGldoverTimeDetail = new MstGldoverTimeDetail();
                                    mstGldoverTimeDetail.OvertimeId = item.Id;
                                    mstGldoverTimeDetail.OvertimeDescription = item.Description;
                                    mstGldoverTimeDetail.CreateDate = DateTime.Now;
                                    mstGldoverTimeDetail.UserId = LoginUser;
                                    oListMstGldoverTimeDetail.Add(mstGldoverTimeDetail);
                                }
                            }
                            //}
                            //if (oListMstGldleaveDedDetail.Count != oListMstLeaveDeduction.Count())
                            //{
                            foreach (var item in oListMstLeaveDeduction)
                            {
                                var restitem = oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault();
                                if (restitem != null)
                                {
                                    oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault().UpdateDate = DateTime.Now;
                                    oListMstGldleaveDedDetail.Where(x => x.LeaveDedId == item.Id).FirstOrDefault().UpdatedBy = LoginUser;
                                }
                                if (restitem == null)
                                {
                                    MstGldleaveDedDetail mstGldleaveDedDetail = new MstGldleaveDedDetail();
                                    mstGldleaveDedDetail.LeaveDedId = item.Id;
                                    mstGldleaveDedDetail.LeaveDedDescription = item.Description;
                                    mstGldleaveDedDetail.CreateDate = DateTime.Now;
                                    mstGldleaveDedDetail.UserId = LoginUser;
                                    oListMstGldleaveDedDetail.Add(mstGldleaveDedDetail);
                                }
                            }
                            //}
                        }
                        else
                        {
                            oModel.Glvalue = res.DeptID;
                            gltype1 = res.DeptDescription;
                            await SetDocNo();
                        }
                    }
                }
                else if (oModel.Gltype == "Comp")
                {
                    gltype1 = "Abacus Consulting";
                    //  await SetDocNo();
                }
                else
                {
                    Snackbar.Add("Please First Gl Type required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DEarns(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldearningDetail)
                    {
                        if (item.ElementId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CEarns(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldearningDetail)
                    {
                        if (item.ElementId == id)
                        {
                            item.CostAccout = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                    //foreach (var item in oListElementEarn)
                    //{

                    //}
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DDeducts(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGlddeductionDetail)
                    {
                        if (item.DeductionId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CDeducts(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGlddeductionDetail)
                    {
                        if (item.DeductionId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                    //foreach (var item in oListElementEarn)
                    //{

                    //}
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DContributs(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldMstGldcontribution)
                    {
                        if (item.ContributionId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CContributs(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldMstGldcontribution)
                    {
                        if (item.ContributionId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DLoans(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldMstGldloansDetail)
                    {
                        if (item.LoanId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CLoans(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListGldMstGldloansDetail)
                    {
                        if (item.LoanId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DAdvances(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldadvanceDetail)
                    {
                        if (item.AdvancesId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CAdvances(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldadvanceDetail)
                    {
                        if (item.AdvancesId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DOverTimes(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldoverTimeDetail)
                    {
                        if (item.OvertimeId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_COverTimes(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldoverTimeDetail)
                    {
                        if (item.OvertimeId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DLeavDeducts(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldleaveDedDetail)
                    {
                        if (item.LeaveDedId == id)
                        {
                            item.BalancingAccount = res.Code;
                            item.BalancingAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CLeavDeducts(DialogOptions options, int? id)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    foreach (var item in oListMstGldleaveDedDetail)
                    {
                        if (item.LeaveDedId == id)
                        {
                            item.CostAccount = res.Code;
                            item.CostAcctDisplay = res.Description;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DBS(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.BasicSalary = res.Code;
                    oModel.BasicSalaryDesc = res.Description;
                    //D_BSC = res.Code;
                    //D_BSD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CBS(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.Bspayable = res.Code;
                    oModel.BspayableDesc = res.Description;
                    //  C_BSC = res.Code;
                    //  C_BSD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DArreas(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.ArrearsExpense = res.Code;
                    oModel.ArrearsExpenseDesc = res.Description;
                    //  D_ArreasC = res.Code;
                    //  D_ArreasD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CArreas(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.ArrearsPayable = res.Code;
                    oModel.ArrearsPayableDesc = res.Description;
                    //  C_ArreasC = res.Code;
                    //   C_ArreasD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DLeavEnc(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.LeaveEncashmentExpense = res.Code;
                    oModel.LeaveEncashmentExpenseDesc = res.Description;
                    //  D_LeavEncC = res.Code;
                    // D_LeavEncD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CLeavEnc(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.LeaveEncashmentPayable = res.Code;
                    oModel.LeaveEncashmentPayableDesc = res.Description;
                    //  C_LeavEncC = res.Code;
                    //  C_LeavEncD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DEOS(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.Eosexpese = res.Code;
                    oModel.EosexpenseDesc = res.Description;
                    //    D_EOSC = res.Code;
                    //   D_EOSD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CEOS(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.Eospayable = res.Code;
                    oModel.EospayableDesc = res.Description;
                    //   C_EOSC = res.Code;
                    //   C_EOSD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DGratuity(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.GratuityExpense = res.Code;
                    oModel.GratuityExpenseDesc = res.Description;
                    //    D_GratuityC = res.Code;
                    //    D_GratuityD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CGratuity(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.GratuityPayable = res.Code;
                    oModel.GratuityPayableDesc = res.Description;
                    //   C_GratuityC = res.Code;
                    //    C_GratuityD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_DIncomTax(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.IncomeTaxExpense = res.Code;
                    oModel.IncomeTaxExpenseDesc = res.Description;
                    //   D_IncomTaxC = res.Code;
                    //   D_IncomTaxD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_CIncomTax(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.IncomeTaxPayable = res.Code;
                    oModel.IncomeTaxPayableDesc = res.Description;
                    //   C_IncomTaxC = res.Code;
                    //   C_IncomTaxD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogCOA_Ddifferenc(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.DiffDrcr = res.Code;
                    oModel.DiffDrcrdesc = res.Description;
                    //   D_IncomTaxC = res.Code;
                    //   D_IncomTaxD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogCOA_Cdifferenc(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "COA");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstchartofAccount)result.Data;
                    oModel.DiffDrcrpayable = res.Code;
                    oModel.DiffDrcrpayableDesc = res.Description;
                    //   C_IncomTaxC = res.Code;
                    //   C_IncomTaxD = res.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        //private async Task GetAllEmployees()
        //{
        //    try
        //    {
        //        oListemp = await _mstEmployeeMaster.GetAllData();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }
        //}



        private async Task GetAllGLDetermination()
        {
            try
            {
                oList = await _mstGldetermination.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private Task SetDocNo()
        {
            try
            {
                DocNum = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private async Task GetAllElement()
        {
            try
            {
                oListElement = await _mstElement.GetAllData();
                oListElementEarn = oListElement.Where(x => x.ElmtType == "Ear");
                oListElementDeduction = oListElement.Where(x => x.ElmtType == "Ded");
                oListElementContribution = oListElement.Where(x => x.ElmtType == "Con");
                foreach (var item in oListElementEarn)
                {
                    MstGldearningDetail mstGldearningDetail = new MstGldearningDetail();
                    mstGldearningDetail.ElementId = item.Id;
                    mstGldearningDetail.ElementDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        mstGldearningDetail.UserId = LoginUser;
                        mstGldearningDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        mstGldearningDetail.UpdatedBy = LoginUser;
                        mstGldearningDetail.UpdateDate = DateTime.Now;
                    }
                    oListGldearningDetail.Add(mstGldearningDetail);
                }
                foreach (var item in oListElementDeduction)
                {
                    MstGlddeductionDetail MstGlddeductionDetail = new MstGlddeductionDetail();
                    MstGlddeductionDetail.DeductionId = item.Id;
                    MstGlddeductionDetail.DeductionDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        MstGlddeductionDetail.UserId = LoginUser;
                        MstGlddeductionDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        MstGlddeductionDetail.UpdatedBy = LoginUser;
                        MstGlddeductionDetail.UpdateDate = DateTime.Now;
                    }
                    oListMstGlddeductionDetail.Add(MstGlddeductionDetail);
                }
                foreach (var item in oListElementContribution)
                {
                    MstGldcontribution MstGldcontribution = new MstGldcontribution();
                    MstGldcontribution.ContributionId = item.Id;
                    MstGldcontribution.ContributionDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        MstGldcontribution.UserId = LoginUser;
                        MstGldcontribution.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        MstGldcontribution.UpdatedBy = LoginUser;
                        MstGldcontribution.UpdateDate = DateTime.Now;
                    }
                    oListGldMstGldcontribution.Add(MstGldcontribution);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLoans()
        {
            try
            {
                oListMstLoan = await _mstLoans.GetAllData();
                foreach (var item in oListMstLoan)
                {
                    MstGldloansDetail MstGldloansDetail = new MstGldloansDetail();
                    MstGldloansDetail.LoanId = item.Id;
                    MstGldloansDetail.LoanDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        MstGldloansDetail.UserId = LoginUser;
                        MstGldloansDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        MstGldloansDetail.UpdatedBy = LoginUser;
                        MstGldloansDetail.UpdateDate = DateTime.Now;
                    }
                    oListGldMstGldloansDetail.Add(MstGldloansDetail);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllAdvances()
        {
            try
            {
                oListMstAdvance = await _mstAdvance.GetAllData();
                foreach (var item in oListMstAdvance)
                {
                    MstGldadvanceDetail MstGldadvanceDetail = new MstGldadvanceDetail();
                    MstGldadvanceDetail.AdvancesId = item.Id;
                    MstGldadvanceDetail.AdvancesDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        MstGldadvanceDetail.UserId = LoginUser;
                        MstGldadvanceDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        MstGldadvanceDetail.UpdatedBy = LoginUser;
                        MstGldadvanceDetail.UpdateDate = DateTime.Now;
                    }
                    oListMstGldadvanceDetail.Add(MstGldadvanceDetail);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllOverTimes()
        {
            try
            {
                oListMstOverTime = await _mstOverTime.GetAllData();
                foreach (var item in oListMstOverTime)
                {
                    MstGldoverTimeDetail MstGldoverTimeDetail = new MstGldoverTimeDetail();
                    MstGldoverTimeDetail.OvertimeId = item.Id;
                    MstGldoverTimeDetail.OvertimeDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        MstGldoverTimeDetail.UserId = LoginUser;
                        MstGldoverTimeDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        MstGldoverTimeDetail.UpdatedBy = LoginUser;
                        MstGldoverTimeDetail.UpdateDate = DateTime.Now;
                    }
                    oListMstGldoverTimeDetail.Add(MstGldoverTimeDetail);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLeaveDeduction()
        {
            try
            {
                oListMstLeaveDeduction = await _mstLeaveDeduction.GetAllData();
                foreach (var item in oListMstLeaveDeduction)
                {
                    MstGldleaveDedDetail mstGldleaveDedDetail = new MstGldleaveDedDetail();
                    mstGldleaveDedDetail.LeaveDedId = item.Id;
                    mstGldleaveDedDetail.LeaveDedDescription = item.Description;
                    if (oModel.Id == 0)
                    {
                        mstGldleaveDedDetail.UserId = LoginUser;
                        mstGldleaveDedDetail.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        mstGldleaveDedDetail.UpdatedBy = LoginUser;
                        mstGldleaveDedDetail.UpdateDate = DateTime.Now;
                    }
                    oListMstGldleaveDedDetail.Add(mstGldleaveDedDetail);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/GLdetermination", forceLoad: true);
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

                oModel.MstGldearningDetails = oListGldearningDetail;
                oModel.MstGlddeductionDetails = oListMstGlddeductionDetail;
                oModel.MstGldcontributions = oListGldMstGldcontribution;
                oModel.MstGldloansDetails = oListGldMstGldloansDetail;
                oModel.MstGldadvanceDetails = oListMstGldadvanceDetail;
                oModel.MstGldoverTimeDetails = oListMstGldoverTimeDetail;
                oModel.MstGldleaveDedDetails = oListMstGldleaveDedDetail;

                if (!string.IsNullOrWhiteSpace(oModel.Gltype))
                {
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        res = await _mstGldetermination.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _mstGldetermination.Update(oModel);
                    }


                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/GLdetermination", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }

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
                    if (res.Where(x => x.CMenuID == 68 && x.UserRights == true).ToList().Count > 0)
                    {
                        await GetAllGLDetermination();
                        await SetDocNo();
                        await GetAllElement();
                        await GetAllLoans();
                        await GetAllAdvances();
                        await GetAllOverTimes();
                        await GetAllLeaveDeduction();
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
