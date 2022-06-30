using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", 
            ErrorMessage = "A senha deve ter pelo menos 6 caracteres com letra maiúscula, letra minúscula, número e caracter especial")]
        public string Password { get; set; }
    }
}             