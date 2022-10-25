using HCM.API.General;
using HCM.API.Interfaces.Authorization;
using HCM.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HCM.API.Repository.Authorization
{
    public class UserAuthorizationRepo : IUserAuthorization
    {
        private HCMOneContext _DBContext;

        public UserAuthorizationRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<List<UserAuthorization>> FetchUserAuth(string userID)
        {
            List<UserAuthorization> oList = new List<UserAuthorization>();
            try
            {
                await Task.Run(() =>
                {
                    if (userID == "manager")
                    {
                        string qry1 = @"SELECT  
                                    ID,
                                    MenuName,
                                    MenuLink,
                                    MenuParent,
                                    ID as FKMenuID,
                                    'manager' as FKUserID,
                                    2 AS UserRights
                                    ,isnull(CreatedBy,'-') as CreatedBy,isnull(CreatedDate,GetDate()) as CreatedDate,isnull(CAppStamp,'-') as CAppStamp,isnull(UpdatedBy,'-') as UpdatedBy,isnull(UpdatedDate,GetDate()) as UpdatedDate,isnull(UAppStamp,'-') as UAppStamp
                                    FROM MstMenu ";
                        oList = _DBContext.UserAuthorizations.FromSqlRaw(qry1).ToList();
                    }
                    else
                    {
                        string qry = $@"SELECT  
                                t1.ID,
                                T1.MenuName,
                                T1.MenuLink,
                                T1.MenuParent,
                                T2.FKMenuID,
                                T2.FKUserID,
                                isnull(T2.UserRights,1) AS UserRights
                                ,isnull(t2.CreatedBy,'-') as CreatedBy,isnull(t2.CreatedDate,GETDATE()) as CreatedDate,isnull(t2.CAppStamp,'-') as CAppStamp,isnull(t2.UpdatedBy,'-') as UpdatedBy,isnull(t2.UpdatedDate,GETDATE()) as UpdatedDate,isnull(t2.UAppStamp,'-') as UAppStamp
                                FROM MstMenu T1
                                LEFT JOIN UserAuthorization T2 ON T2.FKMenuID = T1.MenuID and T2.FKUserID = @userID";
                        oList = _DBContext.UserAuthorizations.FromSqlRaw(qry, new SqlParameter("@userID", userID)).ToList();
                    }

                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);

            }
            return oList;
        }

        public async Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    foreach (var item in oUserAuthorization)
                    {
                        var Detail = _DBContext.UserAuthorizations.Where(x => x.FkuserId == item.FkuserId).ToList();
                        _DBContext.UserAuthorizations.RemoveRange(Detail);
                        break;
                    }
                    _DBContext.UserAuthorizations.AddRange(oUserAuthorization);
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

        public async Task<List<VMUserAuthorization>> GetAllMenu(string UserID)
        {
            List<VMUserAuthorization> oList = new List<VMUserAuthorization>();
            try
            {
                using (var command = _DBContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"SELECT b.MenuID AS PMenuID,b.MenuName AS PMenuName\r\n,a.MenuID AS CMenuID,a.MenuName AS CMenuName\r\n,case when isnull(UserRights,1) = 1 then 'false' else 'true' end as UserRights FROM MstMenu a\r\ninner join MstMenu b on a.MenuParent=b.MenuID\r\nleft join UserAuthorization t3 on t3.FKMenuID=a.MenuID and FkUserID = '{UserID}'";
                    command.CommandType = CommandType.Text;
                    _DBContext.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            VMUserAuthorization oData = new VMUserAuthorization();
                            oData.PMenuID = Convert.ToInt32(result["PMenuID"].ToString());
                            oData.PMenuName = result["PMenuName"].ToString();
                            oData.CMenuID = Convert.ToInt32(result["CMenuID"].ToString());
                            oData.CMenuName = result["CMenuName"].ToString();
                            oData.UserRights = Convert.ToBoolean(result["UserRights"].ToString());
                            oList.Add(oData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

    }
}
