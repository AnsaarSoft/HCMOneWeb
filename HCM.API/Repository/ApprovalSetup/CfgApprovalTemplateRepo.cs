using HCM.API.General;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.HCMModels;
using System.Linq;

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
                    var DocDetail = _DBContext.CfgApprovalTemplateDocuments.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    var OriDetail = _DBContext.CfgApprovalTemplateOriginators.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    var StagesDetail = _DBContext.CfgApprovalTemplateStages.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    _DBContext.CfgApprovalTemplateDocuments.RemoveRange(DocDetail);
                    _DBContext.CfgApprovalTemplateOriginators.RemoveRange(OriDetail);
                    _DBContext.CfgApprovalTemplateStages.RemoveRange(StagesDetail);
                    _DBContext.CfgApprovalTemplates.Update(oCfgApprovalTemplate);
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

        public int InsertDocApprovalDecesion(string OriginatorID, int DocNum, string FLG, int FormCode, string FoamName, int EmpID)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                bool chkflg = false;
                CfgApprovalTemplate obj = new CfgApprovalTemplate();
                switch (FLG)
                {
                    case "flgEmpLeave":
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgEmpLeave == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case "flgLoan":
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgLoan == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case "flgAdvance":
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgAdvance == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case "flgEmpTransfer":
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgEmpTransfer == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case "flgResignation":
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgResignation == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                }
                if (obj.Id > 0)
                {
                    bool IsAlertAdded = false;
                    //foreach (var chkApprovalSetup in obj)
                    //{
                        foreach (var item in obj.CfgApprovalTemplateDocuments)
                        {
                            switch (FLG)
                            {
                                case "flgEmpLeave":
                                    chkflg = (bool)item.FlgEmpLeave;
                                    break;
                                case "flgLoan":
                                    chkflg = (bool)item.FlgLoan;
                                    break;
                                case "flgAdvance":
                                    chkflg = (bool)item.FlgAdvance;
                                    break;
                                case "flgEmpTransfer":
                                    chkflg = (bool)item.FlgEmpTransfer;
                                    break;
                                case "flgResignation":
                                    chkflg = (bool)item.FlgResignation;
                                    break;
                            }
                        }
                        if (chkflg)
                        {
                            //var stageID = olist.Select(x => x.CfgApprovalTemplateStages).FirstOrDefault().Select(z => z.StageId).FirstOrDefault();
                            var stageID = obj.CfgApprovalTemplateStages.FirstOrDefault();
                            var stageDetail = _DBContext.CfgApprovalStageDetails.Where(q => q.Asid == stageID.Id).ToList();
                            List<DocApprovalDecesion> oListDocApproval = new List<DocApprovalDecesion>();
                            foreach (var item in stageDetail)
                            {
                                DocApprovalDecesion oDocApproval = new DocApprovalDecesion();
                                oDocApproval.EmpId = item.AuthorizerId;
                                oDocApproval.FkformId = FormCode;
                                oDocApproval.FkformName = FoamName;
                                oDocApproval.FkstageId = stageID.Id;
                                oDocApproval.FkapprovalId = obj.Id;
                                oDocApproval.FkdocNum = DocNum;
                                oDocApproval.DocStatus = "Pending";
                                oDocApproval.FlgActive = true;
                                oDocApproval.CreatedBy = EmpID.ToString();
                                oDocApproval.CreatedDate = DateTime.Now;
                                oListDocApproval.Add(oDocApproval);
                            }
                            _DBContext.DocApprovalDecesions.AddRange(oListDocApproval);
                            _DBContext.SaveChanges();
                            response.Id = 1;
                            response.Message = "Saved successfully";
                            IsAlertAdded = true;
                        }
                        //if (IsAlertAdded)
                        //{
                        //    break;
                        //}
                    //}
                }

            }
            catch (Exception ex)
            {

            }
            return response.Id;
        }

        public async Task<List<DocApprovalDecesion>> GetAlerts(int EmpID, string DocStatus)
        {
            List<DocApprovalDecesion> oList = new List<DocApprovalDecesion>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.DocApprovalDecesions.Where(x => x.EmployeeId == EmpID && x.DocStatus == DocStatus && x.FlgActive == true).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        /*public async Task<DocApprovalDecesion> UpdateDocApprStatus(DocApprovalDecesion oUserAlert)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.DocApprovalDecesions.Update(oUserAlert);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
                var StrQueryMstStage = _DBContext.CfgApprovalStages.Where(x => x.Id == oUserAlert.FkstageId).FirstOrDefault();
                if (StrQueryMstStage != null)
                {
                    int NoOfApproval = (int)StrQueryMstStage.ApprovalsNo;
                    int NoOfRejection = (int)StrQueryMstStage.RejectionsNo;
                    int DocNum = Convert.ToInt32(oUserAlert.FkdocNum);
                    var StrQueryUserAlertReject = _DBContext.DocApprovalDecesions.Where(t => t.FkstageId == oUserAlert.FkstageId && t.DocStatus == "Rejected" && t.FkdocNum == oUserAlert.FkdocNum).Count();
                    var StrQueryUserAlertApproved = _DBContext.DocApprovalDecesions.Where(t => t.FkstageId == oUserAlert.FkstageId && t.DocStatus == "Approved" && t.FkdocNum == oUserAlert.FkdocNum).Count();
                    if (StrQueryUserAlertReject != 0)
                    {
                        int CheckRejection = StrQueryUserAlertReject;
                        if (NoOfRejection == CheckRejection)
                        {
                            //oUserAlert.FlgActive = false;
                            //_DBContext.DocApprovals.Update(oUserAlert);
                            //_DBContext.SaveChanges();

                            var result = _DBContext.DocApprovalDecesions.Where(b => b.FkdocNum == oUserAlert.FkdocNum).ToList();
                            List<DocApprovalDecesion> oListRDocApproval = new List<DocApprovalDecesion>();
                            foreach (var item in result)
                            {
                                DocApprovalDecesion oRUserAlert = new DocApprovalDecesion();
                                oRUserAlert = item;
                                oRUserAlert.FlgActive = false;
                                oListRDocApproval.Add(oRUserAlert);
                            }
                            _DBContext.DocApprovalDecesions.UpdateRange(oListRDocApproval);
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
