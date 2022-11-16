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

        public async Task<List<VMUserAuthorization>> GetAllAuthorizationMenu(string UserID)
        {
            List<VMUserAuthorization> oList = new List<VMUserAuthorization>();
            try
            {
                using (var command = _DBContext.Database.GetDbConnection().CreateCommand())
                {
                    if (UserID.ToLower() == "manager")
                    {
                        command.CommandText = $"SELECT isnull(t3.ID,0) as ID,t3.CreatedBy,t3.CreatedDate,a.MenuLink,b.MenuID AS PMenuID,b.MenuName AS PMenuName\r\n,a.MenuID AS CMenuID,a.MenuName AS CMenuName\r\n,case when isnull(UserRights,2) = 1 then 'false' else 'true' end as UserRights FROM MstMenu a\r\ninner join MstMenu b on a.MenuParent=b.MenuID\r\nleft join UserAuthorization t3 on t3.FKMenuID=a.MenuID and FkUserID = '{UserID}'";
                    }
                    else
                    {
                        command.CommandText = $"SELECT isnull(t3.ID,0) as ID,t3.CreatedBy,t3.CreatedDate,a.MenuLink,b.MenuID AS PMenuID,b.MenuName AS PMenuName\r\n,a.MenuID AS CMenuID,a.MenuName AS CMenuName\r\n,case when isnull(UserRights,1) = 1 then 'false' else 'true' end as UserRights FROM MstMenu a\r\ninner join MstMenu b on a.MenuParent=b.MenuID\r\nleft join UserAuthorization t3 on t3.FKMenuID=a.MenuID and FkUserID = '{UserID}'";
                    }
                    command.CommandType = CommandType.Text;
                    _DBContext.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            VMUserAuthorization oData = new VMUserAuthorization();
                            oData.ID = Convert.ToInt32(result["ID"].ToString());
                            oData.CreatedBy = result["CreatedBy"].ToString();
                            oData.CreatedDate = result["CreatedDate"].ToString();
                            oData.MenuLink = result["MenuLink"].ToString();
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
