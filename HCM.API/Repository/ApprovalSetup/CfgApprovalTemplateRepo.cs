using HCM.API.General;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.HCMModels;

namespace HCM.API.Repository.ApprovalSetup
{
    public class CfgApprovalTemplateRepo : ICfgApprovalTemplate
    {
        private HCMOneContext _DBContext;

        public CfgApprovalTemplateRepo(HCMOneContext dBContext)
        {
            _DBContext = dBContext;
        }
        public async Task<List<CfgApprovalTemplate>> GetAllData()
        {
            List<CfgApprovalTemplate> oList = new List<CfgApprovalTemplate>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.CfgApprovalTemplates
                    .Include(x => x.CfgApprovalTemplateDocuments)
                    .Include(x => x.CfgApprovalTemplateOriginators)
                    .Include(x => x.CfgApprovalTemplateStages)
                    .ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgApprovalTemplates.Add(oCfgApprovalTemplate);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save successfully";
            }
            return response;
        }
        public async Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    //var Detail1 = _DBContext.MstApprovalOriginators.Where(x => x.FkApprovalId == oMstApprovalSetup.Id).ToList();
                    //var Detail2 = _DBContext.MstApprovalStages.Where(x => x.FkapprovalId == oMstApprovalSetup.Id).ToList();
                    //var Detail3 = _DBContext.MstApprovalTerms.Where(x => x.FkapprovalId == oMstApprovalSetup.Id).ToList();
                    //_DBContext.MstApprovalOriginators.RemoveRange(Detail1);
                    //_DBContext.MstApprovalStages.RemoveRange(Detail2);
                    //_DBContext.MstApprovalTerms.RemoveRange(Detail3);
                    //_DBContext.MstApprovalSetups.Update(oMstApprovalSetup);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save successfully";
            }
            return response;
        }
        public async Task<List<MstForm>> GetApprovalDocs()
        {
            List<MstForm> oList = new List<MstForm>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstForms.Where(x => x.FlgActive == true && x.FlgPayrollForms == true).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        /*public int InsertDocApproval(int OriginatorID, int DocNum, string FLG, int FormCode, string FoamName, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                bool chkflg = false;
                var GetApprovalSetup = _DBContext.MstApprovalSetups
                 .Include(x => x.MstApprovalOriginators.Where(t => t.OriginatorId == OriginatorID))
                 .Include(y => y.MstApprovalStages)
                 .Include(z => z.MstApprovalTerms)
                 .Where(u => u.FlgActive == true)
                 .ToList();
                if (GetApprovalSetup.Count > 0)
                {
                    bool IsAlertAdded = false;
                    foreach (var chkApprovalSetup in GetApprovalSetup)
                    {
                        switch (FLG)
                        {
                            case "flgSalesQuatation":
                                chkflg = (bool)chkApprovalSetup.FlgSalesQuatation;
                                break;
                            case "flgMonthlyVOHCalc":
                                chkflg = (bool)chkApprovalSetup.FlgMonthlyVohcalc;
                                break;
                            case "flgItemPriceList":
                                chkflg = (bool)chkApprovalSetup.FlgItemPriceList;
                                break;
                            case "flgResourceMasterData":
                                chkflg = (bool)chkApprovalSetup.FlgResourceMasterData;
                                break;
                            case "flgMonthlyFOHDriverRateCalc":
                                chkflg = (bool)chkApprovalSetup.FlgMonthlyFohdriverRateCalc;
                                break;
                            case "flgMonthlyFOHCostCalc":
                                chkflg = (bool)chkApprovalSetup.FlgMonthlyFohcostCalc;
                                break;
                            case "flgFOHRateCalc":
                                chkflg = (bool)chkApprovalSetup.FlgFohrateCalc;
                                break;
                            case "flgVariableOverheadCost":
                                chkflg = (bool)chkApprovalSetup.FlgVariableOverheadCost;
                                break;
                        }
                        if (chkflg)
                        {
                            bool Found = (bool)GetApprovalSetup.Select(x => x.MstApprovalTerms).FirstOrDefault().Select(z => z.Always).FirstOrDefault();
                            if (Found)
                            {
                                var stageID = GetApprovalSetup.Select(x => x.MstApprovalStages).FirstOrDefault().Select(z => z.FkstageId).FirstOrDefault();
                                var stageDetail = _DBContext.MstStageDetails.Where(q => q.FkStageId == stageID).ToList();
                                List<DocApproval> oListDocApproval = new List<DocApproval>();
                                foreach (var item in stageDetail)
                                {
                                    DocApproval oDocApproval = new DocApproval();
                                    oDocApproval.FkuserId = item.FkUserId;
                                    oDocApproval.FkformId = FormCode;
                                    oDocApproval.FkstageId = stageID;
                                    oDocApproval.FkformName = FoamName;
                                    oDocApproval.FkapprovalId = chkApprovalSetup.Id;
                                    oDocApproval.FkdocNum = DocNum;
                                    oDocApproval.DocStatus = "Pending";
                                    oDocApproval.FlgActive = true;
                                    oDocApproval.CreatedBy = UserCode;
                                    oDocApproval.CreatedDate = DateTime.Now;
                                    oListDocApproval.Add(oDocApproval);
                                }
                                _DBContext.DocApprovals.AddRange(oListDocApproval);
                                _DBContext.SaveChanges();
                                response.Id = 1;
                                response.Message = "Saved successfully";
                                IsAlertAdded = true;
                            }
                            else
                            {
                                //TermQuery = Convert.ToString(oDataTableApprovalSetup.Rows[apSetup]["TERMQUERY"]).Trim().Replace("{DOCNUM}", "'" + DocPrefix + "-" + DocNum + "'").ToUpper();
                                var TermQuery = GetApprovalSetup.Select(x => x.MstApprovalTerms).FirstOrDefault().Select(z => z.TermQuery).FirstOrDefault();
                                if (TermQuery != null)
                                {
                                    var stageID = GetApprovalSetup.Select(x => x.MstApprovalStages).FirstOrDefault().Select(z => z.FkstageId).FirstOrDefault();
                                    var stageDetail = _DBContext.MstStageDetails.Where(q => q.FkStageId == stageID).ToList();
                                    List<DocApproval> oListDocApproval = new List<DocApproval>();
                                    foreach (var item in stageDetail)
                                    {
                                        DocApproval oDocApproval = new DocApproval();
                                        oDocApproval.FkuserId = item.FkUserId;
                                        oDocApproval.FkformId = FormCode;
                                        oDocApproval.FkformName = FoamName;
                                        oDocApproval.FkstageId = stageID;
                                        oDocApproval.FkapprovalId = chkApprovalSetup.Id;
                                        oDocApproval.FkdocNum = DocNum;
                                        oDocApproval.DocStatus = "Pending";
                                        oDocApproval.FlgActive = true;
                                        oDocApproval.CreatedBy = UserCode;
                                        oDocApproval.CreatedDate = DateTime.Now;
                                        oListDocApproval.Add(oDocApproval);
                                    }
                                    _DBContext.DocApprovals.AddRange(oListDocApproval);
                                    _DBContext.SaveChanges();
                                    response.Id = 1;
                                    response.Message = "Saved successfully";
                                    IsAlertAdded = true;
                                }
                                else
                                {
                                    response.Id = 2;
                                    response.Message = "No approval Found.";
                                    IsAlertAdded = true;
                                }
                            }
                        }
                        if (IsAlertAdded)
                        {
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return response.Id;
        }

        public async Task<List<DocApproval>> GetAlerts(int UserID, string DocStatus)
        {
            List<DocApproval> oList = new List<DocApproval>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.DocApprovals.Where(x => x.FkuserId == UserID && x.DocStatus == DocStatus && x.FlgActive == true).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        public async Task<DocApproval> UpdateDocApprStatus(DocApproval oUserAlert)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.DocApprovals.Update(oUserAlert);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
                var StrQueryMstStage = _DBContext.MstStages.Where(x => x.Id == oUserAlert.FkstageId).FirstOrDefault();
                if (StrQueryMstStage != null)
                {
                    int NoOfApproval = (int)StrQueryMstStage.NoOfApproval;
                    int NoOfRejection = (int)StrQueryMstStage.NoOfRejection;
                    int DocNum = Convert.ToInt32(oUserAlert.FkdocNum);
                    var StrQueryUserAlertReject = _DBContext.DocApprovals.Where(t => t.FkstageId == oUserAlert.FkstageId && t.DocStatus == "Rejected" && t.FkdocNum == oUserAlert.FkdocNum).Count();
                    var StrQueryUserAlertApproved = _DBContext.DocApprovals.Where(t => t.FkstageId == oUserAlert.FkstageId && t.DocStatus == "Approved" && t.FkdocNum == oUserAlert.FkdocNum).Count();
                    if (StrQueryUserAlertReject != 0)
                    {
                        int CheckRejection = StrQueryUserAlertReject;
                        if (NoOfRejection == CheckRejection)
                        {
                            //oUserAlert.FlgActive = false;
                            //_DBContext.DocApprovals.Update(oUserAlert);
                            //_DBContext.SaveChanges();

                            var result = _DBContext.DocApprovals.Where(b => b.FkdocNum == oUserAlert.FkdocNum).ToList();
                            List<DocApproval> oListRDocApproval = new List<DocApproval>();
                            foreach (var item in result)
                            {
                                DocApproval oRUserAlert = new DocApproval();
                                oRUserAlert = item;
                                oRUserAlert.FlgActive = false;
                                oListRDocApproval.Add(oRUserAlert);
                            }
                            _DBContext.DocApprovals.UpdateRange(oListRDocApproval);
                            _DBContext.SaveChanges();

                            switch (oUserAlert.FkformId)
                            {
                                case 1:
                                    var result1 = _DBContext.TrnsSalesQuotations.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result1 != null)
                                    {
                                        result1.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 2:
                                    var result2 = _DBContext.TrnsVohs.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result2 != null)
                                    {
                                        result2.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 3:
                                    var result3 = _DBContext.MstItemPriceLists.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result3 != null)
                                    {
                                        result3.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 4:
                                    var result4 = _DBContext.MstResources.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result4 != null)
                                    {
                                        result4.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 5:
                                    var result5 = _DBContext.TrnsFohdriverRates.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result5 != null)
                                    {
                                        result5.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 6:
                                    var result6 = _DBContext.TrnsFohcosts.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result6 != null)
                                    {
                                        result6.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 7:
                                    var result7 = _DBContext.TrnsFohrates.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result7 != null)
                                    {
                                        result7.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                                case 8:
                                    var result8 = _DBContext.TrnsVocs.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                    if (result8 != null)
                                    {
                                        result8.DocApprovalStatus = "Rejected";
                                    }
                                    break;
                            }
                            _DBContext.SaveChanges();
                        }
                    }
                    else if (StrQueryUserAlertApproved != 0)
                    {
                        int CheckApproval = StrQueryUserAlertApproved;

                        if (NoOfApproval == CheckApproval)
                        {
                            oUserAlert.FlgActive = false;
                            _DBContext.DocApprovals.Update(oUserAlert);
                            _DBContext.SaveChanges();

                            var StrQueryAnotherStage = (from a in _DBContext.DocApprovals
                                                        join b in _DBContext.MstApprovalStages on a.FkstageId equals b.FkstageId
                                                        where a.FkstageId == oUserAlert.FkstageId
                                                        && b.FkapprovalId == oUserAlert.FkapprovalId
                                                        && a.FlgActive == false
                                                        select b).FirstOrDefault();
                            if (StrQueryAnotherStage != null)
                            {
                                int Priority = (int)StrQueryAnotherStage.ApprovalPriority;
                                Priority += 1;
                                var StrQueryApprovalStage = _DBContext.MstApprovalStages.Where(c => c.FkapprovalId == oUserAlert.FkapprovalId && c.ApprovalPriority == Priority).FirstOrDefault();
                                if (StrQueryApprovalStage != null)
                                {
                                    int StageID = (int)StrQueryApprovalStage.FkstageId;

                                    var StrQueryMstStageDetail = _DBContext.MstStageDetails.Where(x => x.FkStageId == StageID).ToList();
                                    if (StrQueryMstStageDetail.Count > 0)
                                    {
                                        string DocumnetOriginator = "";
                                        int DocumentApprovedBy = 0;

                                        var StrQueryCreatedByForNextAlert = _DBContext.DocApprovals.Where(x => x.FkdocNum == oUserAlert.FkdocNum).FirstOrDefault();

                                        if (StrQueryCreatedByForNextAlert != null)
                                        {
                                            DocumnetOriginator = StrQueryCreatedByForNextAlert.CreatedBy;
                                        }
                                        List<DocApproval> oListDocApproval = new List<DocApproval>();
                                        foreach (var item in StrQueryMstStageDetail)
                                        {
                                            DocApproval oUserAlert1 = new DocApproval();
                                            oUserAlert1.FkuserId = item.FkUserId;
                                            oUserAlert1.FkformId = oUserAlert.FkformId;
                                            oUserAlert1.FkstageId = StageID;
                                            oUserAlert1.FkapprovalId = oUserAlert.FkapprovalId;
                                            oUserAlert1.FkdocNum = oUserAlert.FkdocNum;
                                            oUserAlert1.DocStatus = "Pending";
                                            oUserAlert1.FlgActive = true;
                                            oUserAlert1.CreatedBy = DocumnetOriginator;
                                            oUserAlert1.CreatedDate = DateTime.Now;
                                            oUserAlert1.FkformName = oUserAlert.FkformName;
                                            oListDocApproval.Add(oUserAlert1);
                                        }
                                        _DBContext.DocApprovals.AddRange(oListDocApproval);
                                        _DBContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    switch (oUserAlert.FkformId)
                                    {
                                        case 1:
                                            var result1 = _DBContext.TrnsSalesQuotations.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result1 != null)
                                            {
                                                result1.DocApprovalStatus = "Approved";
                                                result1.DocStatus = "Approved";
                                            }
                                            break;
                                        case 2:
                                            var result2 = _DBContext.TrnsVohs.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result2 != null)
                                            {
                                                result2.DocApprovalStatus = "Approved";
                                                result2.DocStatus = "Approved";
                                            }
                                            break;
                                        case 3:
                                            var result3 = _DBContext.MstItemPriceLists.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result3 != null)
                                            {
                                                result3.DocApprovalStatus = "Approved";
                                                result3.DocStatus = "Approved";
                                            }
                                            break;
                                        case 4:
                                            var result4 = _DBContext.MstResources.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result4 != null)
                                            {
                                                result4.DocApprovalStatus = "Approved";
                                                result4.DocStatus = "Approved";
                                            }
                                            break;
                                        case 5:
                                            var result5 = _DBContext.TrnsFohdriverRates.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result5 != null)
                                            {
                                                result5.DocApprovalStatus = "Approved";
                                                result5.DocStatus = "Approved";
                                            }
                                            break;
                                        case 6:
                                            var result6 = _DBContext.TrnsFohcosts.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result6 != null)
                                            {
                                                result6.DocApprovalStatus = "Approved";
                                                result6.DocStatus = "Approved";
                                            }
                                            break;
                                        case 7:
                                            var result7 = _DBContext.TrnsFohrates.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result7 != null)
                                            {
                                                result7.DocApprovalStatus = "Approved";
                                                result7.DocStatus = "Approved";
                                            }
                                            break;
                                        case 8:
                                            var result8 = _DBContext.TrnsVocs.SingleOrDefault(b => b.DocNum == oUserAlert.FkdocNum);
                                            if (result8 != null)
                                            {
                                                result8.DocApprovalStatus = "Approved";
                                                result8.DocStatus = "Approved";
                                            }
                                            break;
                                    }
                                    _DBContext.SaveChanges();
                                }
                            }

                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oUserAlert;
        }*/
    }
}
