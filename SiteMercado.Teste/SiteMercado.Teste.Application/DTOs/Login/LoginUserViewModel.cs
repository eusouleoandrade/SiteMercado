using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Teste.Application.DTOs.Login
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "E-mail é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
