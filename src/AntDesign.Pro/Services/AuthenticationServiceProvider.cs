using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using Microsoft.JSInterop;
using Blazored.LocalStorage;

namespace AntDesign.Pro.Template.Services
{

    public interface IAuthenticationService
    {
        void SignInAsync(string username, string password);
        void SignOut();
    }
    public class AuthenticationServiceProvider : AuthenticationStateProvider, IAuthenticationService
    {
        private readonly ILocalStorageService _localStorageService;
        public AuthenticationServiceProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public void SignInAsync(string username, string password)
        {
            try
            {
                //使用下面的key，生成Jwt Token
                string key = "oqiejgfowirhgowirhgoewirwpeoigjw04owigf";

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                JwtHeader header = new JwtHeader(new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new(ClaimTypes.Name, username));
                userClaims.Add(new(ClaimTypes.DateOfBirth, DateTime.Now.ToString()));
                JwtPayload payload = new JwtPayload(userClaims);

                JwtSecurityToken token = new JwtSecurityToken(header, payload);

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                string jwtToken = handler.WriteToken(token);

                //去掉token中的'符号
                StoreTokenAsync(jwtToken);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SignOut()
        {
            _localStorageService.RemoveItemAsync("token");
        }

        protected void StoreTokenAsync(string mytoken)
        {
            _localStorageService.SetItemAsync("token", mytoken);
        }

        protected virtual async Task<string> RestoreTokenAsync()
        {
            var tmp = await _localStorageService.GetItemAsStringAsync("token");
            //替换tmp中的双引号为空
            tmp = tmp.Replace("\"", "");
            return tmp;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();
            try
            {
                var token = await RestoreTokenAsync();
                //去掉token中的'符号
                string newToken = "" + token.Replace("'", "");
                if (!string.IsNullOrWhiteSpace(newToken))
                {
                    //解析 token
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    if (handler.CanReadToken(token))
                    {
                        var jwtToken = handler.ReadJwtToken(newToken);

                        var claims = jwtToken.Claims;
                        var identity = new ClaimsIdentity(claims,"api");
                        principal.AddIdentity(identity);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new AuthenticationState(principal);
        }
    }
}
