using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do cliente")]
        [EmailAddress(ErrorMessage = "Email informado inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do cliente")]
        [Phone(ErrorMessage = "O número de celular informado não é válido")]
        public string Celular { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }
        
    }
}
  