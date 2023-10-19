using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string SenhaAtual{ get; set; }
        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string NovaSenha{ get; set; }
        [Required(ErrorMessage = "Digite a nova senha mais uma vez")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a anterior")]
        public string ConfirmarNovaSenha{ get; set; }
    }
}
