using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Campo e-mail obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", 
            ErrorMessage = "A senha deve ter pelo menos 6 caracteres com letra maiúscula, letra minúscula, número e caracter especial")]
        public string Password { get; set; }
    }
}             