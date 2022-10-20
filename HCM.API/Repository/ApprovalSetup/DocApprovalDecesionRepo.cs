using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ApprovalSetup
{
    public class DocApprovalDecesionRepo : IDocApprovalDecesion
    {
        private HCMOneContext _DBContext;

        public DocApprovalDecesionRepo(HCMOneContext dBContext)
        {
            _DBContext = dBContext;
        }

        public async Task<List<DocApprovalDecesion>> GetAllData(string EmpID, string DocStatus)
        {
            List<DocApprovalDecesion> oList = new List<DocApprovalDecesion>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.DocApprovalDecesions.Where(x => x.EmpId == EmpID && x.DocStatus == DocStatus && x.FlgActive == true).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        public int InsertDocApprovalDecesion(string OriginatorID, int DocNum, int FormCode, string FoamName)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                CfgApprovalTemplate obj = new CfgApprovalTemplate();
                switch (FormCode)
                {
                    case 2:
                        obj = (from a in _DBContext.CfgApprovalTemplates
                        join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                        join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgEmpLeave == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case 3:
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgLoan == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case 4:
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgAdvance == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case 5:
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgEmpTransfer == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                    case 6:
                        obj = (from a in _DBContext.CfgApprovalTemplates
                               join b in _DBContext.CfgApprovalTemplateDocuments on a.Id equals b.Atid
                               join c in _DBContext.CfgApprovalTemplateOriginators on a.Id equals c.Atid
                               join d in _DBContext.CfgApprovalTemplateStages on a.Id equals d.Atid
                               where a.FlgActive == true && b.FlgResignation == true && c.EmpId == OriginatorID
                               orderby a.CreateDate
                               select a).FirstOrDefault();
                        break;
                }
                if (obj != null && obj.Id > 0)
                {
                    var stageID = _DBContext.CfgApprovalTemplateStages.Where(x => x.Atid == obj.Id && x.Priorty == 1).FirstOrDefault();
                    var stageDetail = _DBContext.CfgApprovalStageDetails.Where(x => x.Asid == stageID.StageId).ToList();
                    List<DocApprovalDecesion> oListDocApproval = new List<DocApprovalDecesion>();
                    foreach (var item in stageDetail)
                    {
                        DocApprovalDecesion oDocApproval = new DocApprovalDecesion();
                        oDocApproval.EmpId = item.AuthorizerId;
                        oDocApproval.FkformId = FormCode;
                        oDocApproval.FkformName = FoamName;
                        oDocApproval.FkstageId = stageID.StageId;
                        oDocApproval.FkapprovalId = obj.Id;
                        oDocApproval.FkdocNum = DocNum;
                        oDocApproval.DocStatus = "Pending";
                        oDocApproval.FlgActive = true;
                        oDocApproval.CreatedBy = OriginatorID;
                        oDocApproval.CreatedDate = DateTime.Now;
                        oListDocApproval.Add(oDocApproval);
                    }
                    _DBContext.DocApprovalDecesions.AddRange(oListDocApproval);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                }
                else
                {
                    response.Id = 2;
                    response.Message = "No approval found.";
                }
            }
            catch (Exception ex)
            {

            }
            return response.Id;
        }

        public async Task<ApiResponseModel> UpdateDocApprStatus(DocApprovalDecesion oDocApprovalDecesion)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.DocApprovalDecesions.Update(oDocApprovalDecesion);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Accept successfully";
                });
                var oCfgApprovalStages = _DBContext.CfgApprovalStages.Where(x => x.Id == oDocApprovalDecesion.FkstageId && x.FlgActive == true).FirstOrDefault();
                if (oCfgApprovalStages != null)
                {
                    int CfgApprovalStageNoOfApproval = (int)oCfgApprovalStages.ApprovalsNo;
                    int CfgApprovalStageNoOfRejection = (int)oCfgApprovalStages.RejectionsNo;
                    int DocNum = Convert.ToInt32(oDocApprovalDecesion.FkdocNum);
                    var TotalApprovalDecesionRejected = _DBContext.DocApprovalDecesions.Where(t => t.FkstageId == oDocApprovalDecesion.FkstageId && t.DocStatus == "Rejected" && t.FkdocNum == oDocApprovalDecesion.FkdocNum).Count();
                    var TotalApprovalDecesionApproved = _DBContext.DocApprovalDecesions.Where(t => t.FkstageId == oDocApprovalDecesion.FkstageId && t.DocStatus == "Approved" && t.FkdocNum == oDocApprovalDecesion.FkdocNum).Count();
                    if (TotalApprovalDecesionRejected != 0)
                    {
                        if (CfgApprovalStageNoOfRejection == TotalApprovalDecesionRejected)
                        {
                            var result = _DBContext.DocApprovalDecesions.Where(b => b.FkdocNum == oDocApprovalDecesion.FkdocNum).ToList();
                            List<DocApprovalDecesion> oListRDocApproval = new List<DocApprovalDecesion>();
                            foreach (var item in result)
                            {
                                DocApprovalDecesion oRDocApprovalDecesion = new DocApprovalDecesion();
                                oRDocApprovalDecesion = item;
                                oRDocApprovalDecesion.FlgActive = false;
                                oListRDocApproval.Add(oRDocApprovalDecesion);
                            }
                            _DBContext.DocApprovalDecesions.UpdateRange(oListRDocApproval);
                            //_DBContext.SaveChanges();
                            string rejected = "Rejected";
                            switch (oDocApprovalDecesion.FkformId)
                            {
                                case 2:
                                    var result2 = _DBContext.TrnsLeavesRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                    if (result2 != null)
                                    {
                                        result2.DocAprStatus = rejected;
                                    }
                                    break;
                                case 3:
                                    var result3 = _DBContext.TrnsLoanRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                    if (result3 != null)
                                    {
                                        result3.DocAprStatus = rejected;
                                    }
                                    break;
                                case 4:
                                    var result4 = _DBContext.TrnsAdvanceRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                    if (result4 != null)
                                    {
                                        result4.DocAprStatus = rejected;
                                    }
                                    break;
                                case 5:
                                    var result5 = _DBContext.TrnsEmployeeTransfers.SingleOrDefault(b => b.DoNum == oDocApprovalDecesion.FkdocNum);
                                    if (result5 != null)
                                    {
                                        result5.DocAprStatus = rejected;
                                    }
                                    break;
                                case 6:
                                    var result6 = _DBContext.TrnsResignations.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                    if (result6 != null)
                                    {
                                        result6.DocAprStatus = rejected;
                                    }
                                    break;
                            }
                            _DBContext.SaveChanges();
                        }
                    }
                    else if (TotalApprovalDecesionApproved != 0)
                    {
                        if (CfgApprovalStageNoOfApproval == TotalApprovalDecesionApproved)
                        {
                            var chkAnotherStage = (from a in _DBContext.DocApprovalDecesions
                                                        join b in _DBContext.CfgApprovalTemplateStages on a.FkstageId equals b.StageId
                                                        where a.FkstageId == oDocApprovalDecesion.FkstageId
                                                        && b.Atid == oDocApprovalDecesion.FkapprovalId
                                                        && a.FlgActive == false
                                                        select b).FirstOrDefault();
                            if (chkAnotherStage != null)
                            {
                                int Priority = (int)chkAnotherStage.Priorty;
                                Priority += 1;
                                var GetCfgApprovalTemplateStages = _DBContext.CfgApprovalTemplateStages.Where(c => c.Atid == oDocApprovalDecesion.FkapprovalId && c.Priorty == Priority).FirstOrDefault();
                                if (GetCfgApprovalTemplateStages != null)
                                {
                                    int StageID = (int)GetCfgApprovalTemplateStages.StageId;

                                    var GetCfgApprovalStageDetail = _DBContext.CfgApprovalStageDetails.Where(x => x.Asid == StageID).ToList();
                                    if (GetCfgApprovalStageDetail.Count > 0)
                                    {
                                        string DocumnetOriginator = "";
                                        var StrQueryCreatedByForNextAlert = _DBContext.DocApprovalDecesions.Where(x => x.FkdocNum == oDocApprovalDecesion.FkdocNum).FirstOrDefault();
                                        if (StrQueryCreatedByForNextAlert != null)
                                        {
                                            DocumnetOriginator = StrQueryCreatedByForNextAlert.CreatedBy;
                                        }
                                        List<DocApprovalDecesion> oListDocApproval = new List<DocApprovalDecesion>();
                                        foreach (var item in GetCfgApprovalStageDetail)
                                        {
                                            DocApprovalDecesion oUserAlert1 = new DocApprovalDecesion();
                                            oUserAlert1.EmpId = item.AuthorizerId;
                                            oUserAlert1.FkformId = oDocApprovalDecesion.FkformId;
                                            oUserAlert1.FkstageId = StageID;
                                            oUserAlert1.FkapprovalId = oDocApprovalDecesion.FkapprovalId;
                                            oUserAlert1.FkdocNum = oDocApprovalDecesion.FkdocNum;
                                            oUserAlert1.DocStatus = "Pending";
                                            oUserAlert1.FlgActive = true;
                                            oUserAlert1.CreatedBy = DocumnetOriginator;
                                            oUserAlert1.CreatedDate = DateTime.Now;
                                            oUserAlert1.FkformName = oDocApprovalDecesion.FkformName;
                                            oListDocApproval.Add(oUserAlert1);
                                        }
                                        _DBContext.DocApprovalDecesions.AddRange(oListDocApproval);
                                        _DBContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    string approved = "Approved";
                                    string opened = "Opened";
                                    switch (oDocApprovalDecesion.FkformId)
                                    {
                                        case 2:
                                            var result2 = _DBContext.TrnsLeavesRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                            if (result2 != null)
                                            {
                                                result2.DocAprStatus = approved;
                                                result2.DocStatus = opened;
                                            }
                                            break;
                                        case 3:
                                            var result3 = _DBContext.TrnsLoanRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                            if (result3 != null)
                                            {
                                                result3.DocAprStatus = approved;
                                                result3.DocStatus = opened;
                                            }
                                            break;
                                        case 4:
                                            var result4 = _DBContext.TrnsAdvanceRequests.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                            if (result4 != null)
                                            {
                                                result4.DocAprStatus = approved;
                                                result4.DocStatus = opened;
                                            }
                                            break;
                                        case 5:
                                            var result5 = _DBContext.TrnsEmployeeTransfers.SingleOrDefault(b => b.DoNum == oDocApprovalDecesion.FkdocNum);
                                            if (result5 != null)
                                            {
                                                result5.DocAprStatus = approved;
                                                result5.DocStatus = opened;
                                            }
                                            break;
                                        case 6:
                                            var result6 = _DBContext.TrnsResignations.SingleOrDefault(b => b.DocNum == oDocApprovalDecesion.FkdocNum);
                                            if (result6 != null)
                                            {
                                                result6.DocAprStatus = approved;
                                                result6.DocStatus = opened;
                                            }
                                            break;
                                    }
                                    _DBContext.SaveChanges();
                                    response.Id = 2;
                                    response.Message = "Accept successfully";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to Update successfully";
            }
            return response;
        }
    }
}
