using HCM.API.General;
using HCM.API.Interfaces.Account;
using HCM.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HCM.API.Repository.Account
{
    public class MstUserRepo : IMstUser
    {
        private HCMOneContext _DBContext;

        public MstUserRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<List<MstUser>> GetAllData()
        {
            List<MstUser> oList = new List<MstUser>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstBranchs.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstBranchs
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstUsers.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        public async Task<ApiResponseModel> Insert(MstUser oMstUsers)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstUsers.Add(oMstUsers);
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

        public async Task<ApiResponseModel> Update(MstUser oMstUsers)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstUsers.Update(oMstUsers);
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

        public async Task<MstUser> Login(MstUser oMstUsers)
        {
            MstUser oUser = new MstUser();
            try
            {
                await Task.Run(() =>
                {
                    oUser = _DBContext.MstUsers.Where(x => x.UserCode == oMstUsers.UserCode && x.PassCode == oMstUsers.PassCode).FirstOrDefault();
                });
                if (oUser is not null)
                {
                    oUser.UserName = await GenerateToken(oUser);
                }
                else
                {
                    oUser = new MstUser();
                    oUser.Id = 0;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oUser;
        }

        private async Task<string> GenerateToken(MstUser oMstUser)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, oMstUser.UserCode),
                    new Claim(ClaimTypes.NameIdentifier, oMstUser.Id.ToString()),
                    new Claim(ClaimTypes.Surname, oMstUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, oMstUser.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(1)).ToUnixTimeSeconds().ToString())
                };
                var Token = new JwtSecurityToken(
                    new JwtHeader(
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MEPLHCMONEkiSecretKeyJWTkliyaBahutSecret")), SecurityAlgorithms.HmacSha256)),
                    new JwtPayload(claims)
                    );

                string TokenString = "";
                TokenString = new JwtSecurityTokenHandler().WriteToken(Token);
                await Task.Delay(1);
                return TokenString;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return "Authentication Error.";
            }
        }

        public async Task<ApiResponseModel> GenerateOTP(MstUser oMstUser)
        {
            MstUser oUser = new MstUser();
            PasswordReset oPassword = new PasswordReset();
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oUser = _DBContext.MstUsers.Where(x => x.Email == oMstUser.Email).FirstOrDefault();
                    if (oUser != null)
                    {
                        string keyString = "ShabbirTileUser123456789";
                        var key = Encoding.UTF8.GetBytes(keyString);//16 bit or 32 bit key string

                        using (var aesAlg = Aes.Create())
                        {
                            using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                            {
                                using (var msEncrypt = new MemoryStream())
                                {
                                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                                    using (var swEncrypt = new StreamWriter(csEncrypt))
                                    {
                                        swEncrypt.Write(oUser.Email);
                                    }

                                    var iv = aesAlg.IV;

                                    var decryptedContent = msEncrypt.ToArray();

                                    var result = new byte[iv.Length + decryptedContent.Length];

                                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                                    Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                                    string EncryptKey = Convert.ToBase64String(result);

                                    oPassword = _DBContext.PasswordResets.Where(x => x.Email == oUser.Email && x.FlgActive == true).FirstOrDefault();
                                    if (oPassword == null)
                                    {
                                        oPassword = new PasswordReset();
                                        oPassword.Email = oUser.Email;
                                        oPassword.UserCode = oUser.UserCode;
                                        oPassword.EncryptKey = EncryptKey.Substring(0, 10);
                                        oPassword.FlgActive = true;
                                    }

                                    oPassword.FlgActive = false;
                                    _DBContext.PasswordResets.Update(oPassword);
                                    _DBContext.SaveChanges();

                                    // Sending Email
                                    string Subject = "Reset Password Request";
                                    string Detail = "Your One time Password (OTP) is given below;";
                                    string Body = Detail + "<br/><b>" + EncryptKey.Substring(0, 10) + "</b>";

                                    Email oEmail = new Email();
                                    if (oEmail.SentEmail(Subject, Body, "MEPL", oPassword.Email))
                                    {
                                        oPassword.Id = 0;
                                        oPassword.FlgActive = true;
                                        oPassword.EncryptKey = EncryptKey.Substring(0, 10);
                                        _DBContext.PasswordResets.Add(oPassword);
                                        _DBContext.SaveChanges();

                                        response.Id = 1;
                                        response.Message = "Email initiated Successfully.";
                                    }
                                    else
                                    {
                                        response.Id = 1;
                                        response.Message = "Failed to initiated email Successfully.";
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "Email not found";
                    }
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return response;
        }

        public async Task<ApiResponseModel> AuthenticateOTP(PasswordReset pPassword)
        {
            PasswordReset oPassword = new PasswordReset();
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oPassword = _DBContext.PasswordResets.Where(x => x.EncryptKey == pPassword.EncryptKey && x.FlgActive == true).FirstOrDefault();
                    if (oPassword != null)
                    {
                        response.Id = 1;
                        response.Message = "OTP authenticate successfully.";
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "OTP expired.";
                    }
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return response;
        }

        public async Task<ApiResponseModel> ChangePassword(MstUser pMstUser)
        {
            MstUser oUser = new MstUser();
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oUser = _DBContext.MstUsers.Where(x => x.Email == pMstUser.Email && x.FlgActiveUser == true).FirstOrDefault();
                    if (oUser != null)
                    {
                        oUser.PassCode = pMstUser.PassCode;
                        _DBContext.MstUsers.Update(oUser);
                        _DBContext.SaveChanges();
                        response.Id = 1;
                        response.Message = "Password successfully update.";
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "Failed to update password.";
                    }
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return response;
        }
    }
}
