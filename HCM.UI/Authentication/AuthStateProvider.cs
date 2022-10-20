using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI;
using HCM.UI.General;
using Microsoft.AspNetCore.Components.Authorization;
using RestSharp;
using System.Security.Claims;

namespace CA.UI.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {

        private readonly RestClient _restClient;
        private readonly ILocalStorageService oLocalStorage;
        private readonly AuthenticationState oAuthState;
        public AuthStateProvider(ILocalStorageService localStorageService)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            oLocalStorage = localStorageService;
            oAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                MstEmployee user = await oLocalStorage.GetItemAsync<MstEmployee>("User");
                if (user is not null)
                {
                    string jwtTokenString = user.MoajibEmail;
                    if (string.IsNullOrEmpty(jwtTokenString))
                    {
                        return oAuthState;
                    }
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(jwtTokenString), "jwtAuthType")));
                }
                else
                {
                    return oAuthState;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return oAuthState;
            }
        }

        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(oAuthState);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
