using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
namespace Lims.Components.Data
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly AuthenticationState _anonymous;
        private ClaimsPrincipal _user=new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var storedUser = await _sessionStorage.GetAsync<List<Claim>>("authClaims");
                var claims = storedUser.Success && storedUser.Value != null
                    ? storedUser.Value
                    : new List<Claim>();

                if (claims.Any())
                {
                    var identity = new ClaimsIdentity(claims, "custom");
                    var user = new ClaimsPrincipal(identity);
                    return await Task.FromResult(new AuthenticationState(user));
                }
            }
            catch(Exception ex)
            {
                // ignore errors and return anonymous
                var str = ex.Message.ToString();

            }

            return await Task.FromResult(new AuthenticationState(_user));
        }

        public  async Task MarkUserAsAuthenticated(ClaimsPrincipal user)
        {
            try
            {
                var claims = user.Claims.ToList();
                await _sessionStorage.SetAsync("authClaims", claims);
                var authState = Task.FromResult(new AuthenticationState(user));
                NotifyAuthenticationStateChanged(authState);
            }catch(Exception ex)
            {
                var str = ex.Message.ToString();
            }
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorage.DeleteAsync("authClaims");
            var authState = Task.FromResult(new AuthenticationState(_user));
            NotifyAuthenticationStateChanged(authState);
        }


    }
    
}
