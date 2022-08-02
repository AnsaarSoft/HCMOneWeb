using HCM.API.Models;

namespace HCM.API.Interfaces.Account
{
    public interface IMstUser
    {
        Task<List<MstUser>> GetAllData();
        Task<ApiResponseModel> Insert(MstUser oMstUser);
        Task<ApiResponseModel> Update(MstUser oMstUser);
        Task<MstUser> Login(MstUser oMstUser);
        Task<ApiResponseModel> GenerateOTP(MstUser oMstUser);
        Task<ApiResponseModel> AuthenticateOTP(PasswordReset oPasswordReset);
        Task<ApiResponseModel> ChangePassword(MstUser oMstUser);
    }
}
