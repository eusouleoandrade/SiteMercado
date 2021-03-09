using Microsoft.AspNetCore.Identity;
using SiteMercado.Teste.Infra.Security.Interfaces;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Infra.Security.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            return await _userManager.CreateAsync(user, password);
        }
    }
}
