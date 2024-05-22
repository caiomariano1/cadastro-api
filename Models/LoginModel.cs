using System.ComponentModel.DataAnnotations;

namespace cadastro_api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType (DataType.Password)]
        public string Password{ get; set; }
    }
}
