using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace AntDesign.Pro.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILogger<AuthStateProvider> _logger;
        private readonly ILocalStorageService _localStorageService;

        public AuthStateProvider(
            ILogger<AuthStateProvider> logger,
            ILocalStorageService localStorageService)
        {
            _logger = logger;
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            _logger.LogInformation($"Authentication: {token}");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, token),
            }, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
