
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite seu nome de Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite seu E-mail")]
        public string Email { get; set; }
    }
}
