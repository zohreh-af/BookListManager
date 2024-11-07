using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BookListManager.Models
{
    public class AuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            return user.Identity.IsAuthenticated;
        }

        public string GetCurrentUserId()
        {
            var authenticationState = _authenticationStateProvider.GetAuthenticationStateAsync().Result;
            var user = authenticationState.User;
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
