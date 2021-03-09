using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Infra.Security.Interfaces
{
    public interface IAccountService
    {
        Task LogoutAsync();

        Task<IdentityResult> RegisterAsync(string email, string password);

        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
    }
}
